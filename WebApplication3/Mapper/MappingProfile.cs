using AutoMapper;
using Domin.Entities;
using WebApplication3.DTO;

namespace WebApplication3.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().
                ForMember(d => d.BrandName, s => s.MapFrom(s => s.Brand.Name)).
                ForMember(d => d.CategoryName, op => op.MapFrom(s => s.Category.Name));
            CreateMap<UserBasket,BasketDTO>().ReverseMap();
        }
          

    }
}
