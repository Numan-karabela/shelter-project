using Azure.Core;
using BarinakAPI.Application.Abstractions.Storage;
using BarinakAPI.Application.Features.Commands.AnimalImageFile.UploadAnimalImages;
using BarinakAPI.Application.Repositories;
using BarinakAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.AnimalImageFile.UploadAnimalImages
{
    public class UploadAnimalimageCommandHandler : IRequestHandler<UploadAnimalimageCommandRequest, UploadAnimalimageCommandResponse>
    {
        readonly IStorageService _storageService;
        readonly IAnimalReadRepository _animalReadRepository;
        readonly IAnimalImageFileWriteRepository _animalImageFileWriteRepository;

        public UploadAnimalimageCommandHandler(IStorageService storageService, IAnimalReadRepository animalReadRepository, IAnimalImageFileWriteRepository animalImageFileWriteRepository)
        {
            _storageService = storageService;
            _animalReadRepository = animalReadRepository;
            _animalImageFileWriteRepository = animalImageFileWriteRepository;
        }

        public async Task<UploadAnimalimageCommandResponse> Handle(UploadAnimalimageCommandRequest request, CancellationToken cancellationToken)
        { 
            List<(string fileName, string pathOrContainerName)> results = await _storageService.UploadAsync("Photo-image"
                , request.Files);
            //string id = "8ba6e344-8326-4c89-a75f-08dbbb784216";

       Domain.Entities.Animal animal = await _animalReadRepository.GetByIdAsync(request.Id);

            await _animalImageFileWriteRepository.AddRangeAsync(results.Select(r => new 
            Domain.Entities.AnimalImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Animal = new List<Animal>() { animal }

            }).ToList());

            await _animalImageFileWriteRepository.SaveAsync();
            return new();
        }
    }
}
 


    //string id = "8ba6e344-8326-4c89-a75f-08dbbb784216";
    //List<(string fileName, string pathOrContainerName)> results = await _storageService.UploadAsync("Photo-image", Request.Form.Files);

    //Animal animal = await _animalReadRepository.GetByIdAsync(id);

    //await _animalImageFileWriteRepository.AddRangeAsync(results.Select(r => new AnimalImageFile
    //{
    //    FileName = r.fileName,
    //    Path = r.pathOrContainerName,
    //    Storage = _storageService.StorageName,
    //    Animal = new List<Animal>() { animal }

    //}).ToList());

    //await _animalImageFileWriteRepository.SaveAsync();

 