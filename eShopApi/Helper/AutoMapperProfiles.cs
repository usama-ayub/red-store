using AutoMapper;
using eShopApi.DTOs;
using eShopApi.Models;
using eShopApi.Responses;

namespace eShopApi.Helper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResponseUser, User>().ReverseMap();

            CreateMap<ResponseCategory, Category>().ReverseMap();

            //CreateMap<ResponseSubCategory, SubCategory>().ReverseMap();

            CreateMap<Product, ResponseProduct>().ReverseMap();

            CreateMap<ImagesProduct, ResponseProductImages>().ReverseMap();

            CreateMap<SubCategory, ResponseSubCategory>().ReverseMap();

            CreateMap<ImagesShop, ResponseShopImages>().ReverseMap();

            CreateMap<Shop, ResponseShop>().ReverseMap();

        }
    }
}
