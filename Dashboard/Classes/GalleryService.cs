namespace Dashboard.Classes
{
    public class GalleryService
    {
        private readonly string _galleryPath;
        private readonly string _linkFilePath;

        public GalleryService()
        {
            _galleryPath = Path.Combine(
               System.AppDomain.CurrentDomain.BaseDirectory, "GalleryImages");
            _linkFilePath = Path.Combine(_galleryPath, "gallery-links.json");
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

        public async Task<Guid?> GetLinkedOrderIdAsync(string imagePath)
        {
            var links = await LoadLinksAsync();
            string key = GetImageKey(imagePath);
            return links.TryGetValue(key, out Guid? measurementId) ? measurementId : null;
        }

        public async Task SetLinkedOrderAsync(string imagePath, Guid? measurementId)
        {
            await EnsureFolderExistsAsync();
            var links = await LoadLinksAsync();
            string key = GetImageKey(imagePath);

            if (measurementId.HasValue)
            {
                links[key] = measurementId.Value;
            }
            else
            {
                links.Remove(key);
            }

            await SaveLinksAsync(links);
        }

        public async Task<string[]> GetImageFilesForOrderAsync(Guid measurementId)
        {
            var links = await LoadLinksAsync();
            return links
                .Where(link => link.Value == measurementId)
                .Select(link => Path.Combine(_galleryPath, link.Key))
                .Where(File.Exists)
                .ToArray();
        }

        public async Task DeleteImageAsync(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            var links = await LoadLinksAsync();
            links.Remove(GetImageKey(imagePath));
            await SaveLinksAsync(links);
        }

        private async Task<Dictionary<string, Guid?>> LoadLinksAsync()
        {
            await EnsureFolderExistsAsync();

            if (!File.Exists(_linkFilePath))
            {
                return new Dictionary<string, Guid?>(StringComparer.OrdinalIgnoreCase);
            }

            try
            {
                string json = await File.ReadAllTextAsync(_linkFilePath);
                return System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Guid?>>(json)
                    ?? new Dictionary<string, Guid?>(StringComparer.OrdinalIgnoreCase);
            }
            catch
            {
                return new Dictionary<string, Guid?>(StringComparer.OrdinalIgnoreCase);
            }
        }

        private async Task SaveLinksAsync(Dictionary<string, Guid?> links)
        {
            await EnsureFolderExistsAsync();
            var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            string json = System.Text.Json.JsonSerializer.Serialize(links, options);
            await File.WriteAllTextAsync(_linkFilePath, json);
        }

        private static string GetImageKey(string imagePath) => Path.GetFileName(imagePath);
    }
}
