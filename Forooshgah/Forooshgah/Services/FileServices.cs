using Forooshgah.Dtos;
using System.IO;

namespace Forooshgah.Services
{
    public class FileServices : IFileServices
    {
        public async Task<UploadFileResponse> UploadFile(UploadFileRequest uploadFileRequest)
        {
            var fileId = DateTime.Now.Ticks.ToString();
            string fileName = "";
            if (uploadFileRequest.File != null && uploadFileRequest.File.Length > 0)
            {
                var fileExtension = Path.GetExtension(uploadFileRequest.File.FileName);
                fileName = fileId + fileExtension;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadFileRequest.File.CopyToAsync(stream);
                }
            }

            return new UploadFileResponse
            {
                FileId = fileName,
            };
        }
    }
}