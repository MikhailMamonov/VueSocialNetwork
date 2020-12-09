using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VueJSSocialNetwork.Data;

namespace VueJSSocialNetwork.Services.Implementations
{
    public class PhotoService : IPhotoService
    {
        private readonly ApplicationDbContext db;

        public PhotoService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public byte[] PhotoAsBytes(IFormFile photo)
        {
            byte[] photoAsBytes;

            using (var memoryStream = new MemoryStream())
            {
                photo.CopyTo(memoryStream);
                photoAsBytes = memoryStream.ToArray();
            };

            return photoAsBytes;
        }
    }
}
