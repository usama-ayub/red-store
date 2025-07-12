using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using eShopApi.DTOs;
using eShopApi.Helper;
using eShopApi.Interfaces;
using eShopApi.Models;
using eShopApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace eShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductPaginationDto paginationParams)
        {
            var result = await _productService.Get(paginationParams);
            if (result.status)
            {
                return BaseResponse(result.product, HttpStatusCode.OK, "Found");
            }
            return BaseResponse("", HttpStatusCode.NotFound, "Not Found", false, true);
        }

        // GET api/ProductController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/ProductController
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateProductDto payload)
        {
            var result = await _productService.CreateAsync(payload);
            if (result.status)
            {
                return BaseResponse("", HttpStatusCode.OK, result.Message);
            }
            return BaseResponse("", HttpStatusCode.Conflict, result.Message, false, true);
        }

        // PUT api/ProductController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Product newProduct)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound();
            await _productService.UpdateAsync(id, newProduct);
            return Ok("updated successfully");
        }

        // DELETE api/ProductController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
                return NotFound();
            await _productService.DeleteAysnc(id);
            return Ok("deleted successfully");
        }
    }
}