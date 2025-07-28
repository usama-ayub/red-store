using eShopApi.DTOs;
using eShopApi.Helper;
using eShopApi.Interfaces;
using eShopApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace eShopApi.Controllers
{
    public class SubCategoryController : BaseApiController
    {
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        // POST api/SubCategoryController
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateSubCategoryDto payload)
        {
            var result = await _subCategoryService.CreateAsync(payload);
            if (result.status)
            {
                return BaseResponse("", HttpStatusCode.OK, result.Message);
            }
            return BaseResponse("", HttpStatusCode.Conflict, result.Message, false, true);
            //return Ok("created successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetSubCategories([FromQuery] SubCategoryPaginationDto paginationParams)
        {
            var result = await _subCategoryService.Get(paginationParams);
            if (result.status)
            {
                return BaseResponse(result.subCategory, HttpStatusCode.OK, "Found");
            }
            return BaseResponse("", HttpStatusCode.NotFound, "Not Found", false, true);
        }
    }
}
