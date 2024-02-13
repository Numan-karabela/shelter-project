using BarinakAPI.Application.Consts;
using BarinakAPI.Application.CustomAttrubutes;
using BarinakAPI.Application.Enums;
using BarinakAPI.Application.Features.Commands.Basket.AddItemToBasket;
using BarinakAPI.Application.Features.Commands.Basket.RemoveBasketItem;
using BarinakAPI.Application.Features.Commands.Basket.UpdateQuantity;
using BarinakAPI.Application.Features.Commands.Product.UpdateAnimal;
using BarinakAPI.Application.Features.Queries.Basket.GetBasketItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarinakAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class BasketsController : ControllerBase
    {
        readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizzeDefinition(Menu= AuthorizeDefinitionConsts.Baskets, ActionType =ActionType.Reading ,Definition ="Get Basket Items")]
        public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQueryRequest getBasketItemsQueryRequest)
        {
        List<GetBasketItemsQueryResponse> response = await _mediator.Send(getBasketItemsQueryRequest);
          return Ok(response); 
        }



        [HttpPost]
        [AuthorizzeDefinition(Menu = AuthorizeDefinitionConsts.Baskets, ActionType = ActionType.Writing, Definition = "Add Items To Basket")]
        public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommanRequest addItemToBasketCommanRequest)
        {
            AddItemToBasketCommanResponse response = await _mediator.Send(addItemToBasketCommanRequest);
            return Ok(response);
        }



        [HttpPut]
        [AuthorizzeDefinition(Menu =AuthorizeDefinitionConsts.Baskets,ActionType =ActionType.Updating,Definition ="Update Item Basket")]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommanRequest  updateQuantityCommanRequest)
        {
           UpdateQuantityCommanResponse response= await _mediator.Send(updateQuantityCommanRequest);
             return Ok(response);

        }



        [HttpDelete("{BasketItemId}")]
        [AuthorizzeDefinition(Menu = AuthorizeDefinitionConsts.Baskets, ActionType = ActionType.Deleting, Definition = "Remove basket Items")]
        public async Task<IActionResult> RemoveBasketItem([FromRoute]RemoveBasketItemCommanRequest removeBasketItemCommanRequest)
        {
            RemoveBasketItemCommanResponse response = await _mediator.Send(removeBasketItemCommanRequest);
            return Ok(response);
        }

    }
}
