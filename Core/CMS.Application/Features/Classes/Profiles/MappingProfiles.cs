using AutoMapper;
using CMS.Application.Features.Classes.Commands.Create;
using CMS.Application.Features.Classes.Commands.Delete;
using CMS.Application.Features.Classes.Commands.Update;
using CMS.Application.Features.Classes.Queries.GetClassById;
using CMS.Application.Features.Classes.Queries.GetListClasses;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Classes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateClassCommand, Class>().ReverseMap();
        CreateMap<CreateClassResponse, Class>().ReverseMap();
        CreateMap<UpdateClassCommand, Class>().ReverseMap();
        CreateMap<UpdateClassResponse, Class>().ReverseMap();
        CreateMap<DeleteClassCommand, Class>().ReverseMap();
        CreateMap<DeleteClassResponse, Class>().ReverseMap();
        CreateMap<UpdateClassResponse, Class>().ReverseMap();
        CreateMap<GetListClassesQuery, Class>().ReverseMap();
        CreateMap<GetListClassesResponse, Class>().ReverseMap();
        CreateMap<GetClassByIdQuery, Class>().ReverseMap();
        CreateMap<GetClassByIdResponse, Class>().ReverseMap();
    }
}
