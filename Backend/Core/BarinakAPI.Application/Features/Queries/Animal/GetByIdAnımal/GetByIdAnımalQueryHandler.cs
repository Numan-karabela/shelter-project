using BarinakAPI.Application.Repositories;
using BarinakAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Queries.Product.GetByIdAnımal
{
    public class GetByIdAnımalQueryHander : IRequestHandler<GetByIdAnımalQueryRequest, GetByIdAnımalQueryResponse>
    {
        readonly IAnimalReadRepository _animalReadRepository;

        public GetByIdAnımalQueryHander(IAnimalReadRepository animalReadRepository)
        {
            _animalReadRepository= animalReadRepository;
        }
         
        public async Task<GetByIdAnımalQueryResponse> Handle(GetByIdAnımalQueryRequest request, CancellationToken cancellationToken)
        {
             Animal animal= await  (_animalReadRepository.GetByIdAsync(request.Id, false));

            return new()
            {

                Name = animal.Name,
                Age = animal.Age,
                Gender = animal.Gender,
                Type = animal.Type,
                Vaccination = animal.Vaccination
            };
        }
    }
}
