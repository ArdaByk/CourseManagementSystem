using AutoMapper;
using CMS.Application.Features.ExamResults.Commands.Create;
using CMS.Application.Features.ExamResults.Commands.Delete;
using CMS.Application.Features.ExamResults.Commands.Update;
using CMS.Application.Features.ExamResults.Queries.GetListExamResultsByExamId;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.ExamResults.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateExamResultCommand, ExamResult>().ReverseMap();
        CreateMap<CreateExamResultResponse, ExamResult>().ReverseMap();
        CreateMap<UpdateExamResultCommand, ExamResult>().ReverseMap();
        CreateMap<UpdateExamResultResponse, ExamResult>().ReverseMap();
        CreateMap<DeleteExamResultCommand, ExamResult>().ReverseMap();
        CreateMap<DeleteExamResultResponse, ExamResult>().ReverseMap();
        CreateMap<ExamResult, GetListExamResultsByExamIdResponse>()
            .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
            .ReverseMap();
    }
}
