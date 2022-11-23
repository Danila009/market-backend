using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;

namespace Market.Application.Repositories.ImageRepository
{
    internal class ImageRepository : IImageRepository
    {
        public void Delete(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public byte[] Get(string path)
        {
            if (File.Exists(path))
                return File.ReadAllBytes(path);
            else
                return null;
        }

        public string Save(byte[] imgBytes, string path)
        {
            var image = Image.Load(imgBytes);
            var imageId = Guid.NewGuid().ToString();

            image.Mutate(m =>
                m.Resize(
                    new ResizeOptions
                    {
                        Mode = ResizeMode.Max,
                        Size = new Size(512)
                    }
                 )
            );

            image.Save($"{imageId}.jpg");

            return imageId;
        }
    }
}
