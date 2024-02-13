using BarinakAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Product.RemoveAnimal
{
    public class RemoveAnimalCommandHandler : IRequestHandler<RemoveAnimalCommandRequest, RemoveAnimalCommandResponse>
    {
        readonly IAnimalWriteRepository _animalWriteRepository;

        public RemoveAnimalCommandHandler(IAnimalWriteRepository animalWriteRepository)
        {
            _animalWriteRepository = animalWriteRepository;
        }

        public async Task<RemoveAnimalCommandResponse> Handle(RemoveAnimalCommandRequest request, CancellationToken cancellationToken)
        {


            await _animalWriteRepository.RemoveAsync(request.Id);
            await _animalWriteRepository.SaveAsync();
            return new();


        }
    }
}
