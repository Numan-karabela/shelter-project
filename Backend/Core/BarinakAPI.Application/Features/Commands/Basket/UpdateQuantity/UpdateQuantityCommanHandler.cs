using BarinakAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Basket.UpdateQuantity
{
    public class UpdateQuantityCommanHandler : IRequestHandler<UpdateQuantityCommanRequest, UpdateQuantityCommanResponse>
    {
        readonly IBasketService _basketService;

        public UpdateQuantityCommanHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<UpdateQuantityCommanResponse> Handle(UpdateQuantityCommanRequest request, CancellationToken cancellationToken)
        {

           await _basketService.UpdateQuentityAsync(new()
            {
                BasketItemId = request.BasketItemId,
                Quantity = request.Quantity,

            });
            return new(); 
        
        }
    }
}
