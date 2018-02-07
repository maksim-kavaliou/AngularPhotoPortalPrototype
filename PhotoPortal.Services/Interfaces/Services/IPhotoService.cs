using System;
using System.IO;
using System.Threading.Tasks;
using PhotoPortal.DomainEntities.Entities;
using PhotoPortal.Services.Interfaces.Services.Base;

namespace PhotoPortal.Services.Interfaces.Services
{
    public interface IPhotoService : IEntityService<Photo>
    {
        Task<string> Save(Stream stream);

        Uri UriFor(string blobName);
    }
}
