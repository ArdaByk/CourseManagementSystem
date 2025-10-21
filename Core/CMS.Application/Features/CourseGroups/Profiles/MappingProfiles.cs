using AutoMapper;
using CMS.Application.Features.CourseGroups.Commands.Create;
using CMS.Application.Features.CourseGroups.Commands.Delete;
using CMS.Application.Features.CourseGroups.Commands.Update;
using CMS.Application.Features.CourseGroups.Queries.GetCourseGroupById;
using CMS.Application.Features.CourseGroups.Queries.GetListCourseGroups;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.CourseGroups.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCourseGroupCommand, CourseGroup>().ReverseMap();
        CreateMap<CreateCourseGroupResponse, CourseGroup>().ReverseMap();
        CreateMap<UpdateCourseGroupCommand, CourseGroup>().ReverseMap();
        CreateMap<UpdateCourseGroupResponse, CourseGroup>().ReverseMap();
        CreateMap<DeleteCourseGroupCommand, CourseGroup>().ReverseMap();
        CreateMap<DeleteCourseGroupResponse, CourseGroup>().ReverseMap();
        CreateMap<GetListCourseGroupsQuery, CourseGroup>().ReverseMap();
        CreateMap<GetListCourseGroupsResponse, CourseGroup>().ReverseMap();
        CreateMap<GetCourseGroupByIdQuery, CourseGroup>().ReverseMap();
        CreateMap<GetCourseGroupByIdResponse, CourseGroup>().ReverseMap();
    }
}
