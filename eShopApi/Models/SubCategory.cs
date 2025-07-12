using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eShopApi.Models
{
    public class SubCategory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonElement]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } = "";

        [BsonElement]
        public string Name { get; set; } = "";
        
        [BsonElement]
        public string Images { get; set; } = "";

        [BsonElement]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CreatedBy { get; set; } = "";

        [BsonElement]
        public Boolean IsActive { get; set; } = true;
        
        [BsonElement]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        
        [BsonElement]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}