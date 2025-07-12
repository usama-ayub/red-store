using AutoMapper;
using eShopApi.DTOs;
using eShopApi.Helper;
using eShopApi.Interfaces;
using eShopApi.Models;
using eShopApi.Responses;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Claims;

namespace eShopApi.Services
{
    public class SubCategoryService: ISubCategoryService
    {
        private readonly IMongoCollection<SubCategory> _subcategoryCollection;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public SubCategoryService(IDBConnection dbconnection, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _subcategoryCollection = dbconnection.DataBase.GetCollection<SubCategory>("SubCategory");
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<(bool status, string Message)> CreateAsync(CreateSubCategoryDto payload)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var id = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(payload.Name))
            {
                return (false, "Name is required");
            }
            if (string.IsNullOrWhiteSpace(id))
            {
                return (false, "CreatedBy is required");
            }
            if (string.IsNullOrWhiteSpace(payload.CategoryId))
            {
                return (false, "CategoryId is required");
            }
            var existing = await _subcategoryCollection
                .Find(c => c.Name.ToLower() == payload.Name.Trim().ToLower())
                .FirstOrDefaultAsync();

            if (existing != null)
            {
                return (false, "Sub Category name already exists");
            }
            var subCategoryEntity = new SubCategory
            {
                Name = payload.Name.Trim(),
                CategoryId = payload.CategoryId,
                CreatedBy = id
            };
            await _subcategoryCollection.InsertOneAsync(subCategoryEntity);
            return (true, "created successfully");
        }

        public async Task<(bool status, PaginationResult<ResponseSubCategory> subCategory)> Get(PaginationDto paginationParams)
        {

            var mongoFilter = Builders<SubCategory>.Filter.Empty;
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
     { "CreatedBy", new BsonDocument("$toString", "$CreatedBy") },
     { "CategoryName", "$product_category.Name" },
     { "UserName", "$product_user.UserName" }
   })
};
            //if (!string.IsNullOrEmpty(filter?.Name))
            //{
            //    mongoFilter &= Builders<Product>.Filter.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression(filter.Name, "i"));
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

            var result = await PaginationResult<ResponseSubCategory>.GetPaginatedDataAsync<SubCategory, ResponseSubCategory>(
           _subcategoryCollection, _mapper, paginationParams.PageNumber, paginationParams.PageSize, mongoFilter, pipeline);


            return (true, new PaginationResult<ResponseSubCategory>(result.Items, result.TotalCount, result.CurrentPage, result.PageSize));
        }
    }
}
