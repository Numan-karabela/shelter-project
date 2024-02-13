using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BarinakAPI.Application.Abstractions.Storage.Aruze;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Infrastructure.Services.Storage.Aruze
{
    public class AruzeStorage :Storage, IAzureStorage
    {
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;

        public AruzeStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Aruze"]);
        }

        public async Task DeleteAsync(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
             BlobClient blobClient= _blobContainerClient.GetBlobClient(fileName);
           await blobClient.DeleteAsync();

        }

        public List<string> GetFiles(string containerName)
        {
            _blobContainerClient=_blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Select(b=>b.Name).ToList();

        }

        public bool HasFile(string containerName, string fileName)
        {

            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);

        }

        public async Task<List<(string filename, string pathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
        {

            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);


            List<(string filename, string pathOrContainerName)> datas = new();

            foreach (IFormFile file in files)
            {
           string fileNewName= await  FileRemoveAsync(containerName, file.Name,HasFile);

               BlobClient blobClient= _blobContainerClient.GetBlobClient(fileNewName );
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add((fileNewName,$"{containerName}/{fileNewName }"));
            } 

            return datas;

        }
    }
}
