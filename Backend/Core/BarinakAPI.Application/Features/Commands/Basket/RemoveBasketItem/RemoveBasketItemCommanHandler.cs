using BarinakAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Basket.RemoveBasketItem
{
    public class RemoveBasketItemCommanHandler : IRequestHandler<RemoveBasketItemCommanRequest, RemoveBasketItemCommanResponse>
    {
        readonly IBasketService _basketService;

        public RemoveBasketItemCommanHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<RemoveBasketItemCommanResponse> Handle(RemoveBasketItemCommanRequest request, CancellationToken cancellationToken)
        {
           await _basketService.RemoveBasketItemAsync(request.BasketItemId);
            return new();

        }
    }
}
