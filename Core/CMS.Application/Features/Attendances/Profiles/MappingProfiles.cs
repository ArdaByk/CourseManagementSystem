using AutoMapper;
using CMS.Application.Features.Attendances.Commands.Create;
using CMS.Application.Features.Attendances.Commands.Delete;
using CMS.Application.Features.Attendances.Commands.Update;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Attendances.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAttendanceCommand, Attendance>().ReverseMap();
        CreateMap<CreateAttendanceResponse, Attendance>().ReverseMap();
        CreateMap<UpdateAttendanceCommand, Attendance>().ReverseMap();
        CreateMap<UpdateAttendanceResponse, Attendance>().ReverseMap();
        CreateMap<DeleteAttendanceCommand, Attendance>().ReverseMap();
        CreateMap<DeleteAttendanceResponse, Attendance>().ReverseMap();
    }
}
