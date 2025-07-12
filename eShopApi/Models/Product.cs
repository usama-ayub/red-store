using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eShopApi.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";
        [BsonElement]
        public string Name { get; set; } = "";

        [BsonElement]
        public double Price { get; set; } = 0;
        [BsonElement]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = "";

        [BsonElement]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SubCategoryId { get; set; } = "";

        [BsonElement]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ShopId { get; set; } = "";

        [BsonElement]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CreatedBy { get; set; } = "";

        [BsonElement]
        public List<string> Tags { get; set; } = new List<string>();

        [BsonElement]
        public Boolean IsHotItem { get; set; } = false;

        [BsonElement]
        public Boolean IsActive { get; set; } = true;

        [BsonElement]
        public Boolean OutOfStoke { get; set; } = false;

        [BsonElement]
        public List<ImagesProduct> Images { get; set; } = new List<ImagesProduct>();
        [BsonElement]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [BsonElement]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }

    public class ImagesProduct
    {
        [BsonElement]
        public Boolean Main { get; set; } = false;

        [BsonElement]
        public string Url { get; set; } = "";
    }
}