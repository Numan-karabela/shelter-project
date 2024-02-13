using MediatR;

namespace BarinakAPI.Application.Features.Queries.Product.GetAllAnimal
{
    public class GetAllAnimalQueryRequest : IRequest<GetAllAnimalQueryResponse>
    {
        //public Pagination  Pagination{ get; set; }

        public int page { get; set; } = 0;
        public int size { get; set; } = 5;
    }
}
