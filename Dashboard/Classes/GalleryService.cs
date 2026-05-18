namespace Dashboard.Classes
{
    public class GalleryService
    {
        private readonly string _galleryPath;

        public GalleryService()
        {
            _galleryPath = Path.Combine(
               System.AppDomain.CurrentDomain.BaseDirectory, "GalleryImages");
        }

        public string GalleryPath => _galleryPath;

        public async Task EnsureFolderExistsAsync()
        {
            await Task.Run(() =>
            {
                if (!Directory.Exists(_galleryPath))
                    Directory.CreateDirectory(_galleryPath);
            });
        }

        public async Task<string[]> GetImageFilesAsync()
        {
            return await Task.Run(() =>
                Directory.Exists(_galleryPath)
                    ? Directory.GetFiles(_galleryPath, "*.*")
                        .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png") || f.EndsWith(".jpeg"))
                        .ToArray()
                    : Array.Empty<string>()
            );
        }

        public async Task<string> SaveImageAsync(string sourcePath)
        {
            await EnsureFolderExistsAsync();
            string ext = Path.GetExtension(sourcePath);
            string destPath = Path.Combine(_galleryPath, $"{Guid.NewGuid()}{ext}");
            byte[] bytes = await File.ReadAllBytesAsync(sourcePath);
            await File.WriteAllBytesAsync(destPath, bytes);
            return destPath;
        }
    }
}