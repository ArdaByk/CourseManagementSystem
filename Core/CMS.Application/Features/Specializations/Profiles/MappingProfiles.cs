using AutoMapper;
using CMS.Application.Features.Specializations.Commands.Create;
using CMS.Application.Features.Specializations.Commands.Delete;
using CMS.Application.Features.Specializations.Commands.Update;
using CMS.Application.Features.Specializations.Queries.GetListSpecializations;
using CMS.Application.Features.Specializations.Queries.GetSpecializationById;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Specializations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSpecializationCommand, Specialization>().ReverseMap();
        CreateMap<CreateSpecializationResponse, Specialization>().ReverseMap();
        CreateMap<UpdateSpecializationCommand, Specialization>().ReverseMap();
        CreateMap<UpdateSpecializationResponse, Specialization>().ReverseMap();
        CreateMap<DeleteSpecializationCommand, Specialization>().ReverseMap();
        CreateMap<DeleteSpecializationResponse, Specialization>().ReverseMap();
        CreateMap<GetListSpecializationsQuery, Specialization>().ReverseMap();
        CreateMap<GetListSpecializationsResponse, Specialization>().ReverseMap();
        CreateMap<GetSpecializationByIdQuery, Specialization>().ReverseMap();
        CreateMap<GetSpecializationByIdResponse, Specialization>().ReverseMap();
    }
}
