using BarinakAPI.Application.Abstractions.Services;
using BarinakAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemToBasketCommanHandler : IRequestHandler<AddItemToBasketCommanRequest, AddItemToBasketCommanResponse>
    {

         readonly IBasketService _basketService;

        public AddItemToBasketCommanHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<AddItemToBasketCommanResponse> Handle(AddItemToBasketCommanRequest request, CancellationToken cancellationToken)
        {
           await _basketService.AddItemToBasketAsync(new()
            {
                AnimalId = request.AnimalId,
                Quantity = request.Quantity
             
            });
            return new();

        }
    }
}
