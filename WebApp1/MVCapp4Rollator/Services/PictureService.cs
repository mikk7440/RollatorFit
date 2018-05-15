using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using MVCapp4Rollator.Data;
using MVCapp4Rollator.Models;

namespace MVCapp4Rollator.Services
{
    public class PictureService :IImage
    {
        private readonly ApplicationDbContext _ctx;
       
        public PictureService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public CloudBlobContainer GetBlobContainer(string azureConnectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();

            return blobClient.GetContainerReference(containerName);
        }

        public async Task SetImage(string title, string text, Uri uri)
        {
            var image = new PictureModel
            {
                Title = title,
                Text = text,
                URL = uri.AbsoluteUri,
                Created = DateTime.Now
            };
            _ctx.Add(image);
            await _ctx.SaveChangesAsync();

        }

    }
}
