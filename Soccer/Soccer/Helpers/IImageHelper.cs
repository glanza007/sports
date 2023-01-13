namespace Soccer.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);
    }
}
