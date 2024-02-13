using BarinakAPI.Application.CustomAttrubutes;
using BarinakAPI.Application.Enums;
using BarinakAPI.Application.Features.Commands.Role.CreateRole;
using BarinakAPI.Application.Features.Commands.Role.DeleteRole;
using BarinakAPI.Application.Features.Commands.Role.UpdateRole;
using BarinakAPI.Application.Features.Queries.Role.GetRoles;
using BarinakAPI.Application.Features.Queries.Role.GetRolesById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarinakAPI.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RolesController : Controller
    {
        readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizzeDefinition(ActionType =ActionType.Reading,Definition ="Gett Roles",Menu ="Roles")]
        public async Task<IActionResult> GetRoles([FromQuery] GetRolesQueryRequest getRolesQueryRequest)
        {

            GetRolesQueryResponse response = await _mediator.Send(getRolesQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]

        [AuthorizzeDefinition(ActionType = ActionType.Reading, Definition = "Gett Role By Id", Menu = "Roles")]
        public async Task<IActionResult> GetRoles([FromRoute] GetRolesByIdQueryRequest getRolesByIdQueryRequest)
        {
            GetRolesByIdQueryResponse response = await _mediator.Send(getRolesByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost()]

        [AuthorizzeDefinition(ActionType = ActionType.Writing, Definition = "Create Role", Menu = "Roles")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommanRequest createRoleCommanRequest)
        {
            CreateRoleCommanResponse response= await _mediator.Send(createRoleCommanRequest);

            return Ok(response);
        }


        [HttpPut("{Id}")]

        [AuthorizzeDefinition(ActionType = ActionType.Updating, Definition = "Update Role", Menu = "Roles")]
        public async Task<IActionResult> UpdateRole([FromBody,FromRoute]UpdateRoleCommanRequest updateRoleCommanRequest)
        {
           UpdateRoleCommanResponse response= await _mediator.Send(updateRoleCommanRequest);
            return Ok(response);
        }

        [HttpPut("{name}")]

        [AuthorizzeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Roles", Menu = "Roles")]
        public async Task<IActionResult> DeleteRole([FromRoute]DeleteRoleCommanRequest deleteRoleCommanRequest)
        {
           DeleteRoleCommanResponse response= await _mediator.Send(deleteRoleCommanRequest);
            return Ok(response);
        }
    }
}
