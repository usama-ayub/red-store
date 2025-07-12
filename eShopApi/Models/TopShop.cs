using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eShopApi.Models
{
    public class TopShop
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ShopId { get; set; } = "";
        
        [BsonElement]
        public Boolean IsActive { get; set; } = true;
        
        [BsonElement]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        
        [BsonElement]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}