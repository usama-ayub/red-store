using eShopApi.DTOs;
using eShopApi.Helper;
using eShopApi.Models;
using eShopApi.Responses;

namespace eShopApi.Interfaces
{
    public interface ICategoryService
    {
        Task<(bool status, PaginationResult<ResponseCategory> category)> Get(PaginationDto paginationParams);
        Task<(bool status, Category category)> GetById(string id);
        Task<(bool status, string Message)> CreateAsync(CreateCategoryDto category);
        Task UpdateAsync(string id, Category category);
        Task DeleteAysnc(string id);
    }
}