using AutoMapper;
using CMS.Application.Features.Teachers.Commands.Create;
using CMS.Application.Features.Teachers.Commands.Delete;
using CMS.Application.Features.Teachers.Commands.Update;
using CMS.Application.Features.Teachers.Queries.GetListTeachers;
using CMS.Application.Features.Teachers.Queries.GetTeacherById;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Teachers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTeacherCommand, Teacher>().ReverseMap();
        CreateMap<CreateTeacherResponse, Teacher>().ReverseMap();
        CreateMap<UpdateTeacherCommand, Teacher>().ReverseMap();
        CreateMap<UpdateTeacherResponse, Teacher>().ReverseMap();
        CreateMap<DeleteTeacherCommand, Teacher>().ReverseMap();
        CreateMap<DeleteTeacherResponse, Teacher>().ReverseMap();
        CreateMap<GetListTeacherQuery, Teacher>().ReverseMap();
        CreateMap<GetListTeacherResponse, Teacher>().ReverseMap();
        CreateMap<GetTeacherByIdQuery, Teacher>().ReverseMap();
        CreateMap<GetTeacherByIdResponse, Teacher>().ReverseMap();
    }
}
