using eShopApi.DTOs;
using eShopApi.Helper;
using eShopApi.Interfaces;
using eShopApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace eShopApi.Controllers
{
    public class ShopController: BaseApiController
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        // POST api/ShopController
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateShopDto payload)
        {
            var result = await _shopService.CreateAsync(payload);
            if (result.status)
            {
                return BaseResponse("", HttpStatusCode.OK, result.Message);
            }
            return BaseResponse("", HttpStatusCode.Conflict, result.Message, false, true);
        }

        [HttpGet]
        public async Task<IActionResult> GetShops([FromQuery] PaginationDto paginationParams)
        {
            var result = await _shopService.Get(paginationParams);
            if (result.status)
            {
                return BaseResponse(result.shop, HttpStatusCode.OK, "Found");
            }
            return BaseResponse("", HttpStatusCode.NotFound, "Not Found", false, true);
        }
    }
}
