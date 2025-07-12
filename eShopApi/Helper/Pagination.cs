using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace eShopApi.Helper
{
    public class PaginationResult<T>
    {
        public List<T> Items { get; set; }
        public int CurrentPage { set; get; }
        public int TotalPages { set; get; }
        public int PageSize { set; get; }
        public int TotalCount { set; get; }
        public PaginationResult(List<T> items, int count, int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;
            Items = items;
        }

        public static async Task<PaginationResult<TDto>> GetPaginatedDataAsync<T, TDto>(IMongoCollection<T> collection,IMapper mapper,int pageNumber,int pageSize,FilterDefinition<T> filter = null, IEnumerable<BsonDocument> additionalPipeline = null)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : pageSize;

            filter ??= Builders<T>.Filter.Empty;

            if (additionalPipeline == null)
            {

                var totalItems = await collection.CountDocumentsAsync(filter);

                var items = await collection.Find(filter)
                    .Skip((pageNumber - 1) * pageSize)
                    .Limit(pageSize)
                    .ToListAsync();

                var dtoItems = mapper.Map<List<TDto>>(items);
                return new PaginationResult<TDto>(dtoItems, (int)totalItems, pageNumber, pageSize);
            }
            else
            {

                var matchStage = new BsonDocument("$match", filter.Render(
                    BsonSerializer.SerializerRegistry.GetSerializer<T>(),
                    BsonSerializer.SerializerRegistry));

                var pipeline = new List<BsonDocument> { matchStage };
                pipeline.AddRange(additionalPipeline);

                // Count total items
                var countPipeline = new List<BsonDocument>(pipeline)
                {
                 new BsonDocument("$count", "totalCount")
                };

                var countResult = await collection.Aggregate<BsonDocument>(countPipeline).FirstOrDefaultAsync();
                var totalItems = countResult != null ? countResult.GetValue("totalCount").AsInt32 : 0;

                // Add pagination stages
                pipeline.Add(new BsonDocument("$skip", (pageNumber - 1) * pageSize));
                pipeline.Add(new BsonDocument("$limit", pageSize));

                var paginatedResults = await collection.Aggregate<BsonDocument>(pipeline).ToListAsync();

                // Deserialize to DTO directly
                var dtoItems = paginatedResults.Select(doc => BsonSerializer.Deserialize<TDto>(doc)).ToList();

                // If you want to transform DTOs further with AutoMapper (optional)
                // dtoItems = mapper.Map<List<TDto>>(dtoItems);

                return new PaginationResult<TDto>(dtoItems, totalItems, pageNumber, pageSize);
            }
        }
    }


}