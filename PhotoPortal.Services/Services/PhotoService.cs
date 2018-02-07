using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using PhotoPortal.DataAccess.Interfaces.Factories;
using PhotoPortal.DataAccess.Interfaces.Repositories;
using PhotoPortal.DomainEntities.Entities;
using PhotoPortal.Services.Interfaces.Factories;
using PhotoPortal.Services.Interfaces.Services;
using PhotoPortal.Services.Services.Base;

namespace PhotoPortal.Services.Services
{
    public class PhotoService : EntityService<Photo, IPhotoRepository>, IPhotoService
    {
        private readonly CloudBlobClient _client;
        private readonly Uri _baseUri = new Uri("https://mkphotoportalstore.blob.core.windows.net/");
        public PhotoService(IRepositoryFactory repositories, IServiceFactory services) : base(repositories, services)
        {
            _client = new CloudBlobClient(_baseUri, new StorageCredentials("fake", "fake"));
        }

        public async Task<string> Save(Stream stream)
        {
            var container = _client.GetContainerReference("images");
            var blobName = Guid.NewGuid().ToString();
            var blob = container.GetBlockBlobReference(blobName);
            await blob.UploadFromStreamAsync(stream);

            Repository.Create(new Photo() {BlobName = blobName});

            return blobName;
        }

        public Uri UriFor(string blobName)
        {
            var sasPolicy = new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessStartTime = DateTime.Now.AddMinutes(-15),
                SharedAccessExpiryTime = DateTime.Now.AddMinutes(30)
            };

            var container = _client.GetContainerReference("images");
            //var blob = container.GetBlockBlobReference(blobName);

            var sasToken = container.GetSharedAccessSignature(sasPolicy);

            return new Uri(_baseUri, $"/images/{blobName}{sasToken}");
        }
    }
}
