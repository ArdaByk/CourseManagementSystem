using AutoMapper;
using CMS.Application.Features.Students.Commands.Create;
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
    }
}
