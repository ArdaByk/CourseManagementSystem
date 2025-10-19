using AutoMapper;
using CMS.Application.Features.Exams.Commands.Create;
using CMS.Application.Features.Exams.Commands.Delete;
using CMS.Application.Features.Exams.Commands.Update;
using CMS.Application.Features.Exams.Queries.GetExamById;
using CMS.Application.Features.Exams.Queries.GetListExams;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Exams.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateExamCommand, Exam>().ReverseMap();
        CreateMap<CreateExamResponse, Exam>().ReverseMap();
        CreateMap<UpdateExamCommand, Exam>().ReverseMap();
        CreateMap<UpdateExamResponse, Exam>().ReverseMap();
        CreateMap<DeleteExamCommand, Exam>().ReverseMap();
        CreateMap<DeleteExamResponse, Exam>().ReverseMap();
        CreateMap<GetListExamsQuery, Exam>().ReverseMap();
        CreateMap<GetListExamsResponse, Exam>().ReverseMap();
        CreateMap<GetExamByIdQuery, Exam>().ReverseMap();
        CreateMap<GetExamByIdResponse, Exam>().ReverseMap();
    }
}
