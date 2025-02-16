using AutoMapper;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Features.Commands.AppUser.CreateUser;
using BookHeaven.Core.Models;

namespace BookHeaven.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Categori, CategoriDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Core.Models.File, FileDto>().ReverseMap();
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
            CreateMap<Core.Models.Identity.AppUser, AppUserDto>().ReverseMap();
            CreateMap<CreateUserCommandRequest, Core.Models.Identity.AppUser>()
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)) 
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));
            
        }
    }
}
