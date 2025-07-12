using AutoMapper;
using eShopApi.DTOs;
using eShopApi.Helper;
using eShopApi.Interfaces;
using eShopApi.Models;
using eShopApi.Responses;
using eShopApi.Shared;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Claims;

namespace eShopApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IMediaService _mediaService;

        public ProductService(IDBConnection dbconnection, IHttpContextAccessor httpContextAccessor, IMapper mapper, IMediaService MediaService)
        {
             _productCollection = dbconnection.DataBase.GetCollection<Product>("Product");
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _mediaService = MediaService;
        }

        public async Task<(bool status, PaginationResult<ResponseProduct> product)> Get(ProductPaginationDto paginationParams)
        {
            var mongoFilter = Builders<Product>.Filter.Empty;
            var pipeline = new BsonDocument[]
{
    new BsonDocument("$match", new BsonDocument("IsActive", true)),
   new BsonDocument("$lookup", new BsonDocument
   {
     { "from", "Category" },
     { "localField", "CategoryId" },
     { "foreignField", "_id" },
     { "as", "product_category" }
   }),
   new BsonDocument("$unwind", "$product_category"),
   new BsonDocument("$lookup", new BsonDocument
   {
     { "from", "SubCategory" },
     { "localField", "SubCategoryId" },
     { "foreignField", "_id" },
     { "as", "product_subcategory" }
   }),
   new BsonDocument("$unwind", "$product_subcategory"),
     new BsonDocument("$lookup", new BsonDocument
   {
     { "from", "Shop" },
     { "localField", "ShopId" },
     { "foreignField", "_id" },
     { "as", "product_shop" }
   }),
   new BsonDocument("$unwind", "$product_shop"),

    new BsonDocument("$lookup", new BsonDocument
    {
      { "from", "User" },
      { "localField", "CreatedBy" },
      { "foreignField", "_id" },
      { "as", "product_user" }
    }),
   new BsonDocument("$unwind", "$product_user"),
   new BsonDocument("$project", new BsonDocument
   {
     { "_id", new BsonDocument("$toString", "$_id") },
     { "Name",1 },
     { "CategoryId", new BsonDocument("$toString", "$CategoryId") },
     { "SubCategoryId", new BsonDocument("$toString", "$SubCategoryId") },
     { "ShopId", new BsonDocument("$toString", "$ShopId") },
     { "CreatedBy", new BsonDocument("$toString", "$CreatedBy") },
     { "Tags", 1},
     { "Images", 1},
     { "Price" ,1 },
     { "CategoryName", "$product_category.Name" },
     { "SubCategoryName", "$product_subcategory.Name" },
     { "ShopName", "$product_shop.Name" },
     { "UserName", "$product_user.UserName" }
   })
};
            //if (!string.IsNullOrEmpty(paginationParams.Name))
            //{
            //    mongoFilter &= Builders<Product>.Filter.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression(paginationParams.Name, "i"));
            //}

            //if (!string.IsNullOrEmpty(filter?.Category))
            //{
            //    mongoFilter &= Builders<Product>.Filter.Eq(p => p.Category, filter.Category);
            //}

            //if (filter?.MinPrice.HasValue == true)
            //{
            //    mongoFilter &= Builders<Product>.Filter.Gte(p => p.Price, filter.MinPrice.Value);
            //}

            //if (filter?.MaxPrice.HasValue == true)
            //{
            //    mongoFilter &= Builders<Product>.Filter.Lte(p => p.Price, filter.MaxPrice.Value);
            //}

            var result = await PaginationResult<ResponseProduct>.GetPaginatedDataAsync<Product, ResponseProduct>(
           _productCollection, _mapper, paginationParams.PageNumber, paginationParams.PageSize, mongoFilter, pipeline);


            return (true, new PaginationResult<ResponseProduct>(result.Items, result.TotalCount, result.CurrentPage, result.PageSize));
        }


        public async Task<Product> GetById(string id) =>
            await _productCollection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task<(bool status, string Message)> CreateAsync(CreateProductDto payload)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var id = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(payload.Name))
            {
                return (false, "Name is required");
            }
            if (payload.FileInfo == null || !payload.FileInfo.Any())
            {
                return (false, "At least one file is required");
            }
            if (string.IsNullOrWhiteSpace(id))
            {
                return (false, "CreatedBy is required");
            }
            var existing = await _productCollection
                .Find(c => c.Name.ToLower() == payload.Name.Trim().ToLower())
                .FirstOrDefaultAsync();

            if (existing != null)
            {
                return (false, "Product name already exists");
            }
            var productEntity = new Product
            {
                Name = payload.Name.Trim(),
                CategoryId = payload.CategoryId,
                SubCategoryId = payload.SubCategoryId,
                ShopId = payload.ShopId,
                Tags = payload.Tags,
                CreatedBy = id,
                Price = payload.Price
            };
            await _productCollection.InsertOneAsync(productEntity);
            var imageUrls = new List<ImagesProduct>();

            var uploadResults = await _mediaService.SaveFilesLocal(payload.FileInfo, "product", productEntity.Id);
            foreach (var formFile in uploadResults)
            {

                if (formFile.Success)
                {
                    imageUrls.Add(new ImagesProduct
                    {
                        Main = formFile.Main,
                        Url = formFile.FileUrl
                    });
                }
            }

            var update = Builders<Product>.Update.Set(c => c.Images, imageUrls);
            await _productCollection.UpdateOneAsync(c => c.Id == productEntity.Id, update);
            return (true, "created successfully");
        }

        public async Task UpdateAsync(string id, Product Product) =>
            await _productCollection
            .ReplaceOneAsync(a => a.Id == id, Product);

        public async Task DeleteAysnc(string id) =>
            await _productCollection.DeleteOneAsync(a => a.Id == id);

    }
}