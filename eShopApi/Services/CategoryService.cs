using AutoMapper;
using eShopApi.DTOs;
using eShopApi.Helper;
using eShopApi.Interfaces;
using eShopApi.Models;
using eShopApi.Responses;
using eShopApi.Shared;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Claims;

namespace eShopApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IMediaService _mediaService;
        public CategoryService(IDBConnection dbconnection, IHttpContextAccessor httpContextAccessor, IMapper mapper, IMediaService MediaService)
        {
            _categoryCollection = dbconnection.DataBase.GetCollection<Category>("Category");
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _mediaService = MediaService;
        }


        public async Task<(bool status, PaginationResult<ResponseCategory> category)> Get(PaginationDto paginationParams)
        {
            //IEnumerable<Category> category = await _categoryCollection.Find(_ => true).ToListAsync();
            //if (category.Count() == 0)
            //{
            //    return (false, []);
            //}
            //var result = _mapper.Map<IEnumerable<CategoryDto>>(category);
            //return (true, result);

            var mongoFilter = Builders<Category>.Filter.Empty;
            var pipeline = new BsonDocument[]
{
    new BsonDocument("$match", new BsonDocument("IsActive", true)),
    new BsonDocument("$lookup", new BsonDocument
    {
        { "from", "User" },
        { "localField", "CreatedBy" },
        { "foreignField", "_id" },
        { "as", "created_by_user" }
    }),
    new BsonDocument("$unwind", "$created_by_user"),
    new BsonDocument("$project", new BsonDocument
    {
         { "_id", new BsonDocument("$toString", "$_id") },
        { "Name", 1 },
        { "Images", 1 },
        { "UserName", "$created_by_user.UserName" },
        { "UserEmail", "$created_by_user.Email" },
        { "UserId", new BsonDocument("$toString", "$created_by_user._id") }
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

            var result = await PaginationResult<ResponseCategory>.GetPaginatedDataAsync<Category, ResponseCategory>(
           _categoryCollection, _mapper, paginationParams.PageNumber, paginationParams.PageSize, mongoFilter, pipeline);


            return (true, new PaginationResult<ResponseCategory>(result.Items, result.TotalCount, result.CurrentPage, result.PageSize));
        }
        public async Task<(bool status, Category category)> GetById(string id)
        {
            Category category = await _categoryCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                category.Name = "";
                category.Id = "";
                return (false, category);
            }
            return (true, category);
        }

        public async Task<(bool status, string Message)> CreateAsync(CreateCategoryDto category)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var id = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                return (false, "Name is required");
            }
            if (category.File == null || category.File.Length == 0)
            {
                return (false, "File is required");
            }
            if (string.IsNullOrWhiteSpace(id))
            {
                return (false, "CreatedBy is required");
            }
            var existingCategory = await _categoryCollection
                .Find(c => c.Name.ToLower() == category.Name.Trim().ToLower())
                .FirstOrDefaultAsync();

            if (existingCategory != null)
            {
                return (false, "Category name already exists");
            }
            var categoryEntity = new Category
            {
                Name = category.Name.Trim(),
                CreatedBy = id,
            };
            await _categoryCollection.InsertOneAsync(categoryEntity);
            var filePath = await _mediaService.SaveFileLocal(category.File, "category", categoryEntity.Id);
            if (filePath.Success)
            {
                categoryEntity.Images = filePath.FileUrl;
                var update = Builders<Category>.Update.Set(c => c.Images, filePath.FileUrl);
                await _categoryCollection.UpdateOneAsync(c => c.Id == categoryEntity.Id, update);
                return (true, "created successfully");
            }
            return (false, filePath.FileUrl);
        }

        public async Task UpdateAsync(string id, Category Category) =>
            await _categoryCollection
            .ReplaceOneAsync(a => a.Id == id, Category);

        public async Task DeleteAysnc(string id) =>
            await _categoryCollection.DeleteOneAsync(a => a.Id == id);

    }
}