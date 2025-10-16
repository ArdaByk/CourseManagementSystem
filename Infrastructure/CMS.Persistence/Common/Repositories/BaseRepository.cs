using CMS.Application.Abstractions.Repositories;
using CMS.Domain.Common;
using CMS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Common.Repositories;

public class BaseRepository<TEntity, TEntityId, TContext> : IAsyncRepository<TEntity, TEntityId>, IQuery<TEntity>
    where TEntity: BaseEntity<TEntityId>
{
    protected readonly CMSDbContext context;
    public BaseRepository(CMSDbContext context)
    {
        this.context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
    {
        foreach (var entity in entities)
            entity.CreatedDate = DateTime.UtcNow;
        await context.AddRangeAsync(entities);
        await context.SaveChangesAsync();
        return entities;
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null, bool enableTracking = true, bool withDeleted = false, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();

        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();
        if(predicate != null)
            queryable = queryable.Where(predicate);
        return queryable.AnyAsync(cancellationToken);
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false)
    {
        entity.DeletedDate = DateTime.UtcNow;

        if (permanent)
        {
            await SoftDeleteChildrenAsync(entity, DateTime.UtcNow);
        }

        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false)
    {
        foreach (TEntity entity in entities)
            entity.DeletedDate = DateTime.UtcNow;

        if (permanent)
        {
            await SoftDeleteChildrenAsync(entities, DateTime.UtcNow);
        }

        await context.SaveChangesAsync();
        return entities;
    }

    public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool enableTracking = true, bool withDeleted = false, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();

        if(!enableTracking)
            queryable = queryable.AsNoTracking();
        if(withDeleted)
            queryable = queryable.IgnoreQueryFilters();
        if (include != null)
            queryable = include(queryable);
        return queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool enableTracking = true, bool withDeleted = false, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();

        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (orderBy != null)
            queryable = orderBy(queryable);

        return queryable.ToListAsync(cancellationToken);
    }

    public IQueryable<TEntity> Query()
    {
       return context.Set<TEntity>();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        context.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities)
    {
        foreach(var entity in entities)
            entity.UpdatedDate = DateTime.UtcNow;
        context.UpdateRange(entities);
        await context.SaveChangesAsync();
        return entities;
    }

    private async Task SoftDeleteChildrenAsync<TEntity>(TEntity entity, DateTime now)
    where TEntity : BaseEntity<TEntityId>
    {
        var navigations = context.Entry(entity).Navigations.ToList();

        foreach (var nav in navigations)
        {
            if (!nav.IsLoaded)
                await nav.LoadAsync();

            if (nav.CurrentValue is IEnumerable<BaseEntity<TEntityId>> collection)
            {
                foreach (var child in collection)
                {
                    child.DeletedDate = now;
                    await SoftDeleteChildrenAsync(child, now);
                }
            }
            else if (nav.CurrentValue is BaseEntity<TEntityId> single)
            {
                single.DeletedDate = now;
                await SoftDeleteChildrenAsync(single, now);
            }
        }
    }

    private async Task SoftDeleteChildrenAsync<TEntity>(ICollection<TEntity> entities, DateTime now)
        where TEntity : BaseEntity<TEntityId>
    {
        foreach (var entity in entities)
        {
            entity.DeletedDate = now;
            await SoftDeleteChildrenAsync(entity, now);
        }
    }

}
