using eShopApi.Models;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace eShopApi.DTOs
{
    public class CreateShopDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string Website { get; set; }

        [Required]
        public double Longtitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public List<FileUploadDto> FileInfo { get; set; }
    }
}
