using BarinakAPI.Application.Repositories;
using BarinakAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Product.UpdateAnimal
{
    public class UpdateAnimalCommandHander : IRequestHandler<UpdateAnimalCommandRequest, UpdateAnimalCommandResponse>
    {

        readonly IAnimalReadRepository _animalReadRepository;
        readonly IAnimalWriteRepository _animalWriteRepository;

        public UpdateAnimalCommandHander(IAnimalReadRepository animalReadRepository, IAnimalWriteRepository animalWriteRepository)
        {
            _animalReadRepository = animalReadRepository;
            _animalWriteRepository = animalWriteRepository;
        }

        public async Task<UpdateAnimalCommandResponse> Handle(UpdateAnimalCommandRequest request, CancellationToken cancellationToken)
        {
            Animal animal = await _animalReadRepository.GetByIdAsync(request.Id);
            animal.Name = request.Name;
            animal.Gender = request.Gender;
            animal.Type = request.Type;
            animal.Age = request.Age;
            animal.Vaccination = request.Vaccination;
            await _animalWriteRepository.SaveAsync();
            return new();
        }
    }
}
