using BarinakAPI.Application.Abstractions.Hubs;
using BarinakAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Product.CreateAnimal
{
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommandRequest, CreateAnimalCommandResponse>
    {
        readonly IAnimalWriteRepository _animalWriteRepository;
        readonly IAnimalHubService _animalHubService;

        public CreateAnimalCommandHandler(IAnimalWriteRepository animalWriteRepository, IAnimalHubService animalHubService)
        {
            _animalWriteRepository = animalWriteRepository;
            _animalHubService = animalHubService;
        }

        public  async Task<CreateAnimalCommandResponse> Handle(CreateAnimalCommandRequest request, CancellationToken cancellationToken)
        {

            await _animalWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Gender = request.Gender,
                Type = request.Type,
                Age = request.Age,
                Vaccination = request.Vaccination,
            });
            await _animalWriteRepository.SaveAsync();
            await  _animalHubService.AnimalAddedMessageAsync($"{request.Name} ürünü eklenmiştir.");

            return new();

        }
    }
}
