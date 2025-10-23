using AutoMapper;
using CMS.Application.Features.StudentCourses.Commands.Create;
using CMS.Application.Features.StudentCourses.Commands.Delete;
using CMS.Application.Features.StudentCourses.Commands.Update;
using CMS.Application.Features.StudentCourses.Queries.GetListStudentsByCourseGroupId;
using CMS.Application.Features.StudentCourses.Queries.GetListStudentsByCourseId;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.StudentCourses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateStudentCourseCommand, StudentCourse>().ReverseMap();
        CreateMap<CreateStudentCourseResponse, StudentCourse>().ReverseMap();
        CreateMap<UpdateStudentCoursesCommand, StudentCourse>().ReverseMap();
        CreateMap<UpdateStudentCoursesResponse, StudentCourse>().ReverseMap();
        CreateMap<DeleteStudentCourseCommand, StudentCourse>().ReverseMap();
        CreateMap<DeleteStudentCourseResponse, StudentCourse>().ReverseMap();
        CreateMap<GetListStudentsByCourseGroupIdQuery, StudentCourse>().ReverseMap();
        CreateMap<GetListStudentsByCourseGroupIdResponse, Student>().ReverseMap();
        CreateMap<GetListStudentsByCourseIdQuery, StudentCourse>().ReverseMap();
        CreateMap<GetListStudentsByCourseIdResponse, Student>().ReverseMap();
    }
}
