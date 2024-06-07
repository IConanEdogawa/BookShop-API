using AutoMapper;
using App.Domain.Entities.Models;
using App.Domain.Entities.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class UserProfile : Profile
{
    public UserProfile()
    {
        //CreateMap<UserModel, UserDto>().ReverseMap();
        CreateMap<UserModel, ViewDto>().ReverseMap();
    }
}
