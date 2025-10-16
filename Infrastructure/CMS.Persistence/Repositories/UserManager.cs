using CMS.Application.Abstractions.Services;
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

public class UserManager : BaseRepository<User, Guid, CMSDbContext>, IUserService
{
    public UserManager(DbContext context) : base(context)
    {
    }
}
