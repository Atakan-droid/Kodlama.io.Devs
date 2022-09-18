using Application.Features.User.Dtos;
using AutoMapper;

namespace Application.Features.User.Profiles;

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<UserForLoginDto, Domain.Entities.User>();
        CreateMap<UserForRegisterDto, Domain.Entities.User>();
        
    }
}