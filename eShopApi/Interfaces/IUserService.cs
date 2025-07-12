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
    public interface IUserService
    {
        Task<(bool status,string message, ResponseRegister register)> Register(RegisterDto payload);
        Task<(bool status,string message, ResponseLogin login)> Login(LoginDto payload);
        Task<(bool status, PaginationResult<ResponseUser> user)> Get(PaginationDto paginationParams);
    }
}