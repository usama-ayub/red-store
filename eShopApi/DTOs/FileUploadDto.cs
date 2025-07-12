namespace eShopApi.DTOs
{
    public class FileUploadDto
    {
        public bool Main { get; set; } = false;
        public IFormFile File { get; set; }
    }
}
