using eShopApi.DTOs;
using eShopApi.Helper;
using eShopApi.Models;
using eShopApi.Responses;

namespace eShopApi.Interfaces
{
    public interface IShopService
    {
        Task<(bool status, string Message)> CreateAsync(CreateShopDto shop);

        Task<(bool status, PaginationResult<ResponseShop> shop)> Get(PaginationDto paginationParams);
    }
}
