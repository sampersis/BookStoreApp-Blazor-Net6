using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.DTO.Author;
using BookStoreApp.API.DTO.Book;
using BookStoreApp.API.DTO.User;

namespace BookStoreApp.API.Config
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<AuthourDTO, Authour>().ReverseMap();
            CreateMap<AuthourUpdateDTO, Authour>().ReverseMap();
            CreateMap<AuthourReadOnlyDTO, Authour>().ReverseMap();

            CreateMap<BookCreateDTO, Book>().ReverseMap();
            CreateMap<BookUpdateDTO, Book>().ReverseMap();
            CreateMap<Book,BookReadOnlyDTO>()
                .ForMember(q=> q.AuthorName, d => d.MapFrom(map => $"{map.Auth.FirstName} {map.Auth.LastName}"))
                .ReverseMap();

            CreateMap<Book, BookDetailsDTO>()
            .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Auth.FirstName} {map.Auth.LastName}"))
            .ReverseMap();

            CreateMap<ApiUser, UserDto>().ReverseMap();

        }
    }
}
