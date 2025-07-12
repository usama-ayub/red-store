using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace eShopApi.DTOs
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string SubCategoryId { get; set; }

        [Required]
        public string ShopId { get; set; }

        [Required]
        public List<string> Tags { get; set; }

        [Required]
        public List<FileUploadDto> FileInfo { get; set; }
    }
}
