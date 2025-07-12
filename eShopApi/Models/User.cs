using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace eShopApi.Models
{
     public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement]
        public string UserName { get; set; } = "";
        [BsonElement]
        public string Email { get; set; } = "";
        [BsonElement]
        public string ContactNumber { get; set; } = "";
        [BsonElement]
        public string Country { get; set; } = "";
        [BsonElement]
        public string Province { get; set; } = "";
        [BsonElement]
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> FaouriteProducts { get; set; } = new List<string>();
        [BsonElement]
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> FaouriteShops { get; set; } = new List<string>();
        [BsonElement]
        public string ImageUrl { get; set; } = "";
        [BsonElement]
        public byte[] PasswordHash { get; set; }
        [BsonElement]
        public byte[] PasswordSalt { get; set; }
        [BsonElement]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [BsonElement]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        [BsonElement]
        public DateTime LastActive { get; set; } = DateTime.Now;
        [BsonElement]
        public Boolean IsActive { get; set; } = true;
    }
}