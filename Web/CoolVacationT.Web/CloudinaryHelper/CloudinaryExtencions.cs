namespace CoolVacationT.Web.CloudinaryHelper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryExtencions
    {
        public static async Task<string> UploadAsync(Cloudinary cloudinary, IFormFile file)
        {
            string nameString = null;
            byte[] destinationImage;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();
            }

            using (var destinationStream = new MemoryStream(destinationImage))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, destinationStream),
                };

                var res = await cloudinary.UploadAsync(uploadParams);

                nameString = res.Uri.AbsoluteUri;
            }

            return nameString;
        }
    }
}
