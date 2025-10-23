using AutoMapper;
using CMS.Application.Features.Students.Commands.Create;
using CMS.Application.Features.Students.Commands.Delete;
using CMS.Application.Features.Students.Commands.Update;
using CMS.Application.Features.Students.Queries.GetListStudents;
using CMS.Application.Features.Students.Queries.GetStudentById;
using CMS.Application.Features.Students.Queries.GetStudentByNationalId;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Students.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateStudentCommand, Student>().ReverseMap();
        CreateMap<CreateStudentResponse, Student>().ReverseMap();
        CreateMap<UpdateStudentCommand, Student>().ReverseMap();
        CreateMap<UpdateStudentResponse, Student>().ReverseMap();
        CreateMap<DeleteStudentCommand, Student>().ReverseMap();
        CreateMap<DeleteStudentResponse, Student>().ReverseMap();
        CreateMap<GetListStudentResponse, Student>().ReverseMap();
        CreateMap<GetListStudentQuery, Student>().ReverseMap();
        CreateMap<GetStudentByIdQuery, Student>().ReverseMap();
        CreateMap<GetStudentByIdResponse, Student>().ReverseMap();
        CreateMap<GetStudentByNationalIdQuery, Student>().ReverseMap();
        CreateMap<GetStudentByNationalIdResponse, Student>().ReverseMap();
    }
}
