using System.IO;

namespace WRS.Helper
{
    public class FileHelper
    {
        public static async Task<string> Upload(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()}__{file.FileName}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            string fullPath = "uploads\\" + fileName;
            using(FileStream stream = File.Create(fullPath))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }
    }
}
