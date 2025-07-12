using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using eShopApi.DTOs;
using eShopApi.Interfaces;
using eShopApi.Responses;
using Microsoft.Extensions.Options;
using System.Security.Claims;
namespace eShopApi.Shared
{
   public class MediaService : IMediaService
    {
        private readonly Cloudinary _cloudinary;
        private readonly IWebHostEnvironment _env;
        public MediaService(IOptions<CloudinarySetting> config, IWebHostEnvironment env)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.APIKey,
                config.Value.APISecret
            );
            _cloudinary = new Cloudinary(acc);
            _env = env;
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var imageUploadResult = new ImageUploadResult();

            using var stream = file.OpenReadStream();
            var imageParam = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
            };
            imageUploadResult = await _cloudinary.UploadAsync(imageParam);
            
            return imageUploadResult;
        }

        public async Task<ImageUploadResult> AddBase64PhotoAsync(string base64, string filename)
        {
            var imageUploadResult = new ImageUploadResult();
            // if (file.Length != 0)
            // {
            var imageParam = new ImageUploadParams
            {
                File = new FileDescription(filename, $"@{base64}"),
                Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
            };
            imageUploadResult = await _cloudinary.UploadAsync(imageParam);
            return imageUploadResult;
            // }
        }

        public Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = _cloudinary.DestroyAsync(deleteParams);
            return result;
        }

        public async Task<(bool Success, string FileUrl)> SaveFileLocal(IFormFile file, string folder, string id)
        {
            if (file == null || file.Length == 0)
                return (false, "");
            try
            {
                // Sanitize file name to avoid issues/security risks
                var safeFileName = Path.GetFileName(file.FileName);

                // Build the full directory and file path safely
                var directoryPath = Path.Combine(_env.ContentRootPath, "Uploads/Images", folder, id);
                var filePath = Path.Combine(directoryPath, safeFileName);

                // Create directory if it doesn't exist
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return (true, $"/Uploads/Images/{folder}/{id}/{safeFileName}");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<bool> SaveFileLocalAsync(IFormFile file, string folder, string id)
        {
            if (file == null || file.Length == 0)
                return false;

            try
            {
                // Sanitize file name to avoid issues/security risks
                var safeFileName = Path.GetFileName(file.FileName);

                // Build the full directory and file path safely
                var directoryPath = Path.Combine(_env.ContentRootPath, "Uploads/Images", folder, id);
                var filePath = Path.Combine(directoryPath, safeFileName);

                // Create directory if it doesn't exist
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                // Save the file asynchronously
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return true;
            }
            catch (Exception ex)
            {
                // TODO: Log the exception (ex) here using your preferred logging framework
                return false;
            }
        }


        
       public async Task<List<ResponseFileUpload>> SaveFilesLocal(List<FileUploadDto> files, string folder, string id)
        {
            var results = new List<ResponseFileUpload>();

            if (files == null || !files.Any())
                return results;

            var directoryPath = Path.Combine(_env.ContentRootPath, "Uploads/Images", folder, id);

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            foreach (var item in files)
            {
                var file = item.File;
                if (file == null || file.Length == 0)
                {
                    results.Add(new ResponseFileUpload { Success = false, FileUrl = "Empty or null file", Main = item.Main });
                    continue;
                }

                try
                {
                    var safeFileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(directoryPath, safeFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var relativePath = Path.Combine("Uploads/Images", folder, id, safeFileName).Replace("\\", "/");
                    results.Add(new ResponseFileUpload { Success = true, FileUrl = relativePath, Main = item.Main });
                }
                catch (Exception ex)
                {
                    results.Add(new ResponseFileUpload { Success = false, FileUrl = ex.Message, Main = item.Main });
                }
            }

            return results;
        }




        // [Route("SaveFile")]
        // [HttpPost]
        // public JsonResult SaveFile()
        // {
        //     try
        //     {
        //         var httpRequest = Request.Form;
        //         var postedFile = httpRequest.Files[0];
        //         string filename = postedFile.FileName;
        //         var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

        //         using(var stream=new FileStream(physicalPath, FileMode.Create))
        //         {
        //             postedFile.CopyTo(stream);
        //         }

        //         return new JsonResult(filename);
        //     }
        //     catch (Exception)
        //     {

        //         return new JsonResult("anonymous.png");
        //     }
        // }
    }
}