using CloudinaryDotNet.Actions;
using eShopApi.DTOs;
using eShopApi.Responses;

namespace eShopApi.Interfaces
{

    public interface IMediaService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<ImageUploadResult> AddBase64PhotoAsync(string base64, string filename);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
        Task<(bool Success, string FileUrl)> SaveFileLocal(IFormFile file, string folder, string id);
        Task<List<ResponseFileUpload>> SaveFilesLocal(List<FileUploadDto> files, string folder, string id);
    }
}