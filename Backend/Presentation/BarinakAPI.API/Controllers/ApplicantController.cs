using BarinakAPI.Application.Consts;
using BarinakAPI.Application.CustomAttrubutes;
using BarinakAPI.Application.Enums;
using BarinakAPI.Application.Features.Commands.Applicant.CreateApplicant;
using BarinakAPI.Application.Features.Queries.Application;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarinakAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ApplicantController : ControllerBase
    {
        readonly IMediator _mediator;

        public ApplicantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        [AuthorizzeDefinition(Menu = AuthorizeDefinitionConsts.Applicant, ActionType = ActionType.Reading, Definition = "Get Applicant by Id")]
        public async Task<IActionResult> GettAllapplication(GetAllApplicationQueryRequest getAllApplicationQueryRequest)
        {
                 List<GetAllApplicationQueryResponse> response=await _mediator.Send(getAllApplicationQueryRequest);

                 return Ok(response);
             
        }

        [HttpPost]
        [AuthorizzeDefinition(Menu = AuthorizeDefinitionConsts.Applicant, ActionType = ActionType.Writing, Definition = "Create Applicant")]
        public async Task<IActionResult> CreateApplication(CreateApplicantCommandRequest createApplicantCommandRequest)
        {
            CreateApplicantCommandResponse response = await _mediator.Send(createApplicantCommandRequest);

            return Ok(response);

        }



    }
}
