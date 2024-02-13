using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Queries.Product.GetByIdAnımal
{
    public class GetByIdAnımalQueryRequest:IRequest<GetByIdAnımalQueryResponse>
    {
        public  string Id { get; set; }
    }
}
