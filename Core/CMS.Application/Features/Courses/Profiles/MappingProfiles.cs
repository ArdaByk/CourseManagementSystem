using AutoMapper;
using CMS.Application.Features.CourseGroups.Queries.GetListCourseGroupsByCourseId;
using CMS.Application.Features.Courses.Commands.Create;
using CMS.Application.Features.Courses.Commands.Delete;
using CMS.Application.Features.Courses.Commands.Update;
using CMS.Application.Features.Courses.Queries.GetListTeachers;
using CMS.Application.Features.Courses.Queries.GetTeacherById;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Courses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCourseCommand, Course>().ReverseMap();
        CreateMap<CreateCourseResponse, Course>().ReverseMap();
        CreateMap<UpdateCourseCommand, Course>().ReverseMap();
        CreateMap<UpdateCourseResponse, Course>().ReverseMap();
        CreateMap<DeleteCourseCommand, Course>().ReverseMap();
        CreateMap<DeleteCourseResponse, Course>().ReverseMap();
        CreateMap<GetListCoursesQuery, Course>().ReverseMap();
        CreateMap<GetListCoursesResponse, Course>().ReverseMap();
        CreateMap<GetCourseByIdQuery, Course>().ReverseMap();
        CreateMap<GetCourseByIdResponse, Course>().ReverseMap();
    }
}
