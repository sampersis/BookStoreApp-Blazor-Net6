using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.DTO.Author;

namespace BookStoreApp.API.Config
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<AuthourDTO, Authour>().ReverseMap();
            CreateMap<AuthourUpdateDTO, Authour>().ReverseMap();
            CreateMap<AuthourReadOnlyDTO, Authour>().ReverseMap();

        }
    }
}
