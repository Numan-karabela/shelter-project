using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommanRequest:IRequest<AddItemToBasketCommanResponse>
    {

        public string AnimalId { get; set; }

        public int Quantity { get; set; }

    }
}
