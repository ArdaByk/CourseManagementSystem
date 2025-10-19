using AutoMapper;
using CMS.Application.Features.Users.Commands.Create;
using CMS.Application.Features.Users.Commands.Delete;
using CMS.Application.Features.Users.Commands.Update;
using CMS.Application.Features.Users.Queries.GetListUsers;
using CMS.Application.Features.Users.Queries.GetUserById;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Features.Users.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserCommand, User>().ReverseMap();
        CreateMap<CreateUserResponse, User>().ReverseMap();
        CreateMap<UpdateUserCommand, User>().ReverseMap();
        CreateMap<UpdateUserResponse, User>().ReverseMap();
        CreateMap<DeleteUserCommand, User>().ReverseMap();
        CreateMap<DeleteUserResponse, User>().ReverseMap();
        CreateMap<GetListUsersQuery, User>().ReverseMap();
        CreateMap<GetListUsersResponse, User>().ReverseMap();
        CreateMap<GetUserByIdQuery, User>().ReverseMap();
        CreateMap<GetUserByIdResponse, User>().ReverseMap();
    }
}
