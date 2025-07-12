using System;
using System.Collections.Generic;
using eShopApi.Models;

namespace eShopApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}