using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace eShopApi.DTOs
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}
