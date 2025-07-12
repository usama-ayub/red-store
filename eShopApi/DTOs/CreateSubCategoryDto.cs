using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace eShopApi.DTOs
{
    public class CreateSubCategoryDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

    }
}
