using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Basket.UpdateQuantity
{
    public class UpdateQuantityCommanRequest:IRequest<UpdateQuantityCommanResponse>
    {
        public string BasketItemId { get; set; }
        public int Quantity { get; set; }

    }
}
