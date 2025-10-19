using AutoMapper;
using CMS.Application.Features.Roles.Queries.GetListRoles;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Roles.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<GetListRolesResponse, Role>().ReverseMap();
        CreateMap<GetListRolesQuery, Role>().ReverseMap();
    }
}
