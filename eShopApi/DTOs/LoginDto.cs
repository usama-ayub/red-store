using System.ComponentModel.DataAnnotations;

namespace eShopApi.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}