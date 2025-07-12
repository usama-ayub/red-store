using System.Net;
using eShopApi.DTOs;
using eShopApi.Helper;
using eShopApi.Interfaces;
using eShopApi.Models;
using eShopApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShopApi.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] PaginationDto paginationParams)
        {
            var result = await _categoryService.Get(paginationParams);
            if (result.status)
            {
                return BaseResponse(result.category, HttpStatusCode.OK, "Found");
            }
            return BaseResponse("", HttpStatusCode.NotFound, "Not Found", false, true);
        }

        // GET api/CategoryController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _categoryService.GetById(id);
            if (result.status)
            {
                return BaseResponse(result.category, HttpStatusCode.OK, "Found");
            }
            return BaseResponse("", HttpStatusCode.NotFound, "Not Found", false, true);
        }

        // POST api/CategoryController
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateCategoryDto payload)
        {
            var result =  await _categoryService.CreateAsync(payload);
            if (result.status)
            {
                return BaseResponse("", HttpStatusCode.OK, result.Message);
            }
            return BaseResponse("", HttpStatusCode.Conflict, result.Message, false, true);
            //return Ok("created successfully");
        }

        // PUT api/CategoryController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Category newCategory)
        {
            var category = await _categoryService.GetById(id);
            if (!category.status)
            {
                return NotFound();
            }
            await _categoryService.UpdateAsync(id, newCategory);
            return Ok("updated successfully");
        }

        // DELETE api/CategoryController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await _categoryService.GetById(id);
            if (!category.status)
            {
                return NotFound();
            }
            await _categoryService.DeleteAysnc(id);
            return Ok("deleted successfully");
        }
    }
}