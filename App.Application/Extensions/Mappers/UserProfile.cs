using AutoMapper;
using App.Domain.Entities.Models;
using App.Domain.Entities.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;
using App.Application.UseCases.BookCase.Commands;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserModel, ViewDto>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
        CreateMap<Book, UpdateBookCommand>().ReverseMap();
    }
}
