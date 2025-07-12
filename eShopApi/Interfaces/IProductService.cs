using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopApi.DTOs;
using eShopApi.Helper;
using eShopApi.Models;
using eShopApi.Responses;

namespace eShopApi.Interfaces
{
    public interface IProductService
    {
        Task<(bool status, PaginationResult<ResponseProduct> product)> Get(ProductPaginationDto paginationParams);
        Task<Product> GetById(string id);
        Task<(bool status, string Message)> CreateAsync(CreateProductDto payload);
        Task  UpdateAsync(string id, Product Product);
        Task DeleteAysnc(string id);
    }
}