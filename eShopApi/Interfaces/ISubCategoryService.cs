using eShopApi.DTOs;
using eShopApi.Helper;
using eShopApi.Responses;

namespace eShopApi.Interfaces
{
    public interface ISubCategoryService
    {
        Task<(bool status, string Message)> CreateAsync(CreateSubCategoryDto subcategory);

        Task<(bool status, PaginationResult<ResponseSubCategory> subCategory)> Get(PaginationDto paginationParams);
    }
}
