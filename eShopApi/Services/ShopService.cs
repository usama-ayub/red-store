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
using SharpCompress.Common;
using System.Security.Claims;

namespace eShopApi.Services
{
    public class ShopService: IShopService
    {
        private readonly IMongoCollection<Shop> _shopCollection;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IMediaService _mediaService;

        public ShopService(IDBConnection dbconnection, IHttpContextAccessor httpContextAccessor, IMapper mapper, IMediaService MediaService)
        {
            _shopCollection = dbconnection.DataBase.GetCollection<Shop>("Shop");
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _mediaService = MediaService;
        }

        public async Task<(bool status, string Message)> CreateAsync(CreateShopDto payload)
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
            var existing = await _shopCollection
                .Find(c => c.Name.ToLower() == payload.Name.Trim().ToLower())
                .FirstOrDefaultAsync();

            if (existing != null)
            {
                return (false, "Shop name already exists");
            }
            var shopEntity = new Shop
            {
                Name = payload.Name.Trim(),
                Address = payload.Address.Trim(),
                ContactNumber = payload.ContactNumber.Trim(),
                Website = payload.Website.Trim(),
                Longtitude = payload.Longtitude,
                Latitude = payload.Latitude,
                CreatedBy = id,
            };
            await _shopCollection.InsertOneAsync(shopEntity);
            var imageUrls = new List<ImagesShop>();

            var uploadResults = await _mediaService.SaveFilesLocal(payload.FileInfo, "shop", shopEntity.Id);
            foreach (var formFile in uploadResults)
            {

                if (formFile.Success)
                {
                    imageUrls.Add(new ImagesShop
                    {
                        Main = formFile.Main,
                        Url = formFile.FileUrl
                    });
                }
            }

            var update = Builders<Shop>.Update.Set(c => c.Images, imageUrls);
            await _shopCollection.UpdateOneAsync(c => c.Id == shopEntity.Id, update);
            return (true, "created successfully");
        }

        public async Task<(bool status, PaginationResult<ResponseShop> shop)> Get(PaginationDto paginationParams)
        {
            //IEnumerable<Category> category = await _categoryCollection.Find(_ => true).ToListAsync();
            //if (category.Count() == 0)
            //{
            //    return (false, []);
            //}
            //var result = _mapper.Map<IEnumerable<CategoryDto>>(category);
            //return (true, result);

            var mongoFilter = Builders<Shop>.Filter.Empty;
            var pipeline = new BsonDocument[]
{
     new BsonDocument("$match", new BsonDocument("IsActive", true)),
    new BsonDocument("$lookup", new BsonDocument
    {
        { "from", "User" },
        { "localField", "CreatedBy" },
        { "foreignField", "_id" },
        { "as", "createdby_user" }
    }),
    new BsonDocument("$unwind", "$createdby_user"),
    new BsonDocument("$project", new BsonDocument
    {
         { "_id", new BsonDocument("$toString", "$_id") },
          { "CreatedBy", new BsonDocument("$toString", "$CreatedBy") },
        { "Name", 1 },
        {"Address",1 },
        { "Images", 1 },
        { "Latitude", 1 },
        { "Longtitude", 1 },
        { "Website", 1 },
         { "ContactNumber", 1 },
        { "UserName", "$createdby_user.UserName" },
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

            var result = await PaginationResult<ResponseShop>.GetPaginatedDataAsync<Shop, ResponseShop>(
           _shopCollection, _mapper, paginationParams.PageNumber, paginationParams.PageSize, mongoFilter, pipeline);


            return (true, new PaginationResult<ResponseShop>(result.Items, result.TotalCount, result.CurrentPage, result.PageSize));
        }
    }
}
