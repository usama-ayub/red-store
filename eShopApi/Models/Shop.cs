using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace eShopApi.Models
{
    public class Shop
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonElement]
        public string Name { get; set; } = "";

        [BsonElement]
        public string Address { get; set; } = "";

        [BsonElement]
        public List<ImagesShop> Images { get; set; } = new List<ImagesShop>();

        [BsonElement]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CreatedBy { get; set; } = "";

        [BsonElement]
        public string ContactNumber { get; set; } = "";

        [BsonElement]
        public string Website { get; set; } = "";

        [BsonElement]
        public double Latitude { get; set; }

        [BsonElement]
        public double Longtitude { get; set; }

        [BsonElement]
        public Boolean IsActive { get; set; } = true;

        [BsonElement]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [BsonElement]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }

    public class ImagesShop
    {
        [BsonElement]
        public Boolean Main { get; set; } = false;

        [BsonElement]
        public string Url { get; set; } = "";
    }
}
