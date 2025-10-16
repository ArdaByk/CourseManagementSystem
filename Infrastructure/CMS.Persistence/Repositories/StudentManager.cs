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

public class StudentManager : BaseRepository<Student, Guid, CMSDbContext>, IAsyncRepository<Student, Guid>
{
    public StudentManager(DbContext context) : base(context)
    {
    }
}
