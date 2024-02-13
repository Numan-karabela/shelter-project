using BarinakAPI.Application.Repositories;
using BarinakAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.AnimalImageFile.RemoveAnimalImage
{
    public class RemoveAnimalImageCommandHandler : IRequestHandler<RemoveAnimalImageCommandRequest, RemoveAnimalImageCommandResponse>
    {
        readonly IAnimalReadRepository _animalReadRepository;
        readonly IAnimalWriteRepository _animalWriteRepository;
        readonly IAnimalImageFileWriteRepository _animalImageFileWriteRepository;

        public RemoveAnimalImageCommandHandler(IAnimalReadRepository animalReadRepository, IAnimalWriteRepository animalWriteRepository, IAnimalImageFileWriteRepository animalImageFileWriteRepository)
        {
            _animalReadRepository = animalReadRepository;
            _animalWriteRepository = animalWriteRepository;
            _animalImageFileWriteRepository = animalImageFileWriteRepository;
        }

        public async Task<RemoveAnimalImageCommandResponse> Handle(RemoveAnimalImageCommandRequest request, CancellationToken cancellationToken)
        {
            Animal? animal = await _animalReadRepository.Table.Include(p => p.AnimalImageFiles)
               .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
            string ImageId = "8ed2c012-ab6d-48ff-446e-08dbc27b7ebd";/*imageId karsılık gelen ıd*/

            Domain.Entities.AnimalImageFile? animalImageFile = animal?.AnimalImageFiles.FirstOrDefault(p => p.Id 
            == Guid.Parse(/*request.*/ImageId));

            if (animalImageFile!=null)
            animal?.AnimalImageFiles.Remove(animalImageFile);
            await _animalWriteRepository.SaveAsync();

            return new();
        }
    }
}
