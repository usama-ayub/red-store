using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eShopApi.Models
{
    public class TopProduct
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; } = "";
        
        [BsonElement]
        public Boolean IsActive { get; set; } = true;
        
        [BsonElement]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        
        [BsonElement]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}