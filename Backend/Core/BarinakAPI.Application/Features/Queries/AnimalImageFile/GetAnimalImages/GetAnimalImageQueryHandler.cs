using BarinakAPI.Application.Repositories;
using BarinakAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Queries.AnimalImageFile.GetAnimalImages
{
    public class GetAnimalImageQueryHandler : IRequestHandler<GetAnimalImageQueryRequest, List<GetAnimalImageQueryResponse>>
    {
        readonly IAnimalReadRepository _animalReadRepository;
        readonly IConfiguration configuration;

        public GetAnimalImageQueryHandler(IAnimalReadRepository animalReadRepository, IConfiguration configuration)
        {
            _animalReadRepository = animalReadRepository;
            this.configuration = configuration;
        }

        public async Task<List<GetAnimalImageQueryResponse>> Handle(GetAnimalImageQueryRequest request, CancellationToken cancellationToken)
        {
            string id = "8ba6e344-8326-4c89-a75f-08dbbb784216";

            Animal? animal = await _animalReadRepository.Table.Include(p => p.AnimalImageFiles)
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));

            return animal?.AnimalImageFiles.Select(p => new GetAnimalImageQueryResponse
            {
                Path = $"{configuration["BaseStorageUrl"]}/{p.Path}",
                FileName = p.FileName,
                Id = p.Id
            }).ToList();
        }
    }
}
