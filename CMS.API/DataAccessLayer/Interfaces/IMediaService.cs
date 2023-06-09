using CloudinaryDotNet.Actions;

namespace CMS.API.DataAccessLayer.Interfaces
{
    public interface IMediaService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile image);
        Task<VideoUploadResult> AddVideoAsync(IFormFile video);
        Task<DeletionResult> DeleteMediaAsync(string url);
        
    }
}
