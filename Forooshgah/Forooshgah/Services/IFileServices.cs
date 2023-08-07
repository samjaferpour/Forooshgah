using Forooshgah.Dtos;

namespace Forooshgah.Services
{
    public interface IFileServices
    {
        Task<UploadFileResponse> UploadFile(UploadFileRequest uploadFileRequest);
    }
}
