using AutoMapper;
using WS.Basic.Webapi.Models;
using WS.Basic.Webapi.Entities;

namespace WS.Basic.Webapi.Mappers
{
    public class WebapiProfile : Profile
    {
        public WebapiProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Category, CategoryViewModel>();

            CreateMap<ProductInputModel, Product>();
            CreateMap<CategoryInputModel, Category>();
        }
    }
}