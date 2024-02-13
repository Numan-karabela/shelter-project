using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Queries.AnimalImageFile.GetAnimalImages
{
    public class GetAnimalImageQueryRequest:IRequest<List<GetAnimalImageQueryResponse>>
    {

        public string? Id { get; set; }
    }
}
