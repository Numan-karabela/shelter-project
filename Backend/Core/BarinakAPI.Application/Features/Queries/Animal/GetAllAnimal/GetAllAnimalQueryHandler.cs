using BarinakAPI.Application.Repositories.RequestParamaters;
using BarinakAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace BarinakAPI.Application.Features.Queries.Product.GetAllAnimal
{
    public class GetAllAnimalQueryHandler : IRequestHandler<GetAllAnimalQueryRequest, GetAllAnimalQueryResponse>
    {
        readonly IAnimalReadRepository _animalReadRepository;
        readonly ILogger<GetAllAnimalQueryHandler> _logger;
        public GetAllAnimalQueryHandler(IAnimalReadRepository animalReadRepository, ILogger<GetAllAnimalQueryHandler> logger)
        {
            _animalReadRepository = animalReadRepository;
            _logger = logger;
        }

        public async Task<GetAllAnimalQueryResponse> Handle(GetAllAnimalQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get all animal");

            var totalAnimalCount = _animalReadRepository.GettAll(false).Count();
            var animals = _animalReadRepository.GettAll(false).Skip(request.size * request.page).Take
                (request.size)
                .Include(p=>p.AnimalImageFiles)
                .Select(p => new
            {
                p.Id,
                p.Name,
                p.Age,
                p.Gender,
                p.Type,
                p.Vaccination,
                p.AnimalImageFiles

                }).ToList();


            return new()
            {
                Animals = animals, 
                TotalAnimalCount = totalAnimalCount

            };


        }
    }
}
