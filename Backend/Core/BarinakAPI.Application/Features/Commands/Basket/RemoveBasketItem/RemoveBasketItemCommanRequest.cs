using BarinakAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Basket.RemoveBasketItem
{
   
    public class RemoveBasketItemCommanRequest:IRequest<RemoveBasketItemCommanResponse>
    {

        public string BasketItemId { get; set; }

    }
}
