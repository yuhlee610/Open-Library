using AutoMapper;
using BookApi.Data;
using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Book, BookDTO>().ForMember(dest => dest.Picture, opt => opt.MapFrom(src => Convert.ToBase64String(src.Picture))).ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
