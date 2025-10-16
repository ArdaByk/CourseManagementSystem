using CMS.Domain.Entities;
using CMS.Persistence.Common.Repositories;
using CMS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Repositories;

public class TeacherManager : BaseRepository<Teacher, Guid, CMSDbContext>, IAsyncRepository<Teacher, Guid>
{
    public TeacherManager(DbContext context) : base(context)
    {
    }
}
