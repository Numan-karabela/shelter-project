using BarinakAPI.Application.Features.Commands.AppUser.CreateUser;
using BarinakAPI.Application.Features.Commands.AppUser.GoogleLogin;
using BarinakAPI.Application.Features.Commands.AppUser.LoginUser;
using BarinakAPI.Application.Features.Commands.Product.UpdateAnimal;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarinakAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommandRequest createUserCommandRequest)
        {

            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }
        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody]UpdateAnimalCommandRequest updateAnimalCommandRequest)
        {
            UpdateAnimalCommandResponse response=await _mediator.Send(updateAnimalCommandRequest);
            return Ok(response);
        }
       
    }
}
