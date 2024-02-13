using BarinakAPI.Application.Abstractions.Services.Configurations;
using BarinakAPI.Application.CustomAttrubutes;
using BarinakAPI.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarinakAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ApplicationServicesController : Controller
    {


        IAppplicationService _appplicationService;

        public ApplicationServicesController(IAppplicationService appplicationService)
        {
            _appplicationService = appplicationService;
        }
        [HttpGet]
        [AuthorizzeDefinition(ActionType =ActionType.Reading,Definition ="Get Authrize Definition Endpoints",Menu ="Application Services")]
        public IActionResult GetAuthorizeDefinitionEndpoints()
        {
             
         var datas= _appplicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));



         return Ok(datas);

        }
    }
}
