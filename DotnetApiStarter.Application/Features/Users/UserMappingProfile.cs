using AutoMapper;
using DotnetApiStarter.Domain.Entities;

namespace DotnetApiStarter.Application.Features.Users;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserResponse>();
    }
}