using BarinakAPI.Application.Repositories.RequestParamaters;
using BarinakAPI.Application.Repositories;
using BarinakAPI.Application.ViewModel.Animals;
using BarinakAPI.Application;
using BarinakAPI.Domain.Entities;
using BarinakAPI.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BarinakAPI.Application.Abstractions.Storage;
using Microsoft.EntityFrameworkCore;
using MediatR;
using BarinakAPI.Application.Features.Commands.Product.CreateAnimal;
using BarinakAPI.Application.Features.Queries.Product.GetAllAnimal;
using BarinakAPI.Application.Features.Queries.Product.GetByIdAnımal;
using BarinakAPI.Application.Features.Commands.Product.UpdateAnimal;
using BarinakAPI.Application.Features.Commands.Product.RemoveAnimal;
using BarinakAPI.Application.Features.Commands.AnimalImageFile.UploadAnimalImages;
using BarinakAPI.Application.Features.Commands.AnimalImageFile.RemoveAnimalImage;
using BarinakAPI.Application.Features.Queries.AnimalImageFile.GetAnimalImages;
using Microsoft.AspNetCore.Authorization;
using BarinakAPI.Application.Features.Commands.AnimalImageFile.ChangeShowcaseImage;
using BarinakAPI.Application.Consts;
using BarinakAPI.Application.CustomAttrubutes;
using BarinakAPI.Application.Enums;

namespace BarinakAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    { 
        readonly IMediator _mediator;

         
        public ProductController( IMediator mediator)

        { 
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllAnimalQueryRequest getAllAnimalQueryRequest)
        {

            GetAllAnimalQueryResponse response = await _mediator.Send(getAllAnimalQueryRequest);
            return Ok(response);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdAnımalQueryRequest getByIdAnımalQueryRequest)
        {
            GetByIdAnımalQueryResponse response = await _mediator.Send(getByIdAnımalQueryRequest);
            return Ok(response);

        }




        [HttpPost]

        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizzeDefinition(Menu = AuthorizeDefinitionConsts.Product, ActionType = ActionType.Writing, Definition = "Create Product")]

        public async Task<IActionResult> Post(CreateAnimalCommandRequest createAnimalCommandRequest)
        {
            CreateAnimalCommandResponse response = await _mediator.Send(createAnimalCommandRequest);

            return Ok();
        }



        [HttpPut]

        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizzeDefinition(Menu = AuthorizeDefinitionConsts.Product, ActionType = ActionType.Updating, Definition = "Update product")]
        public async Task<IActionResult> Put([FromBody]UpdateAnimalCommandRequest updateAnimalCommandRequest)
        {
            UpdateAnimalCommandResponse response = await _mediator.Send(updateAnimalCommandRequest);
            return Ok();
        }



        [HttpDelete("{Id}")]

        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizzeDefinition(Menu = AuthorizeDefinitionConsts.Product, ActionType = ActionType.Deleting, Definition = "Delete product")]
        public async Task<IActionResult> Delete([FromRoute]RemoveAnimalCommandRequest removeAnimalCommandRequest)
        {
           RemoveAnimalCommandResponse response= await _mediator.Send(removeAnimalCommandRequest);
            return Ok();
        }



        [HttpPost("[action]")]

        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizzeDefinition(Menu = AuthorizeDefinitionConsts.Product, ActionType = ActionType.Writing, Definition = "Update product file")]
        public async Task<IActionResult> Upload([FromQuery] UploadAnimalimageCommandRequest 
            uploadAnimalimageCommandRequest) 
        {
            uploadAnimalimageCommandRequest.Files = Request.Form.Files;
            uploadAnimalimageCommandRequest.Id = "8ba6e344-8326-4c89-a75f-08dbbb784216";

           UploadAnimalimageCommandResponse response= await _mediator.Send(uploadAnimalimageCommandRequest);
            return Ok();


            //string id = "8ba6e344-8326-4c89-a75f-08dbbb784216";
            //List<(string fileName, string pathOrContainerName)> results = await _storageService.UploadAsync("Photo-image", Request.Form.Files);

            //Animal animal = await _animalReadRepository.GetByIdAsync(id);

            //await _animalImageFileWriteRepository.AddRangeAsync(results.Select(r => new AnimalImageFile
            //{
            //    FileName = r.fileName,
            //    Path = r.pathOrContainerName,
            //    Storage = _storageService.StorageName,
            //    Animal = new List<Animal>() { animal }

            //}).ToList());

            //await _animalImageFileWriteRepository.SaveAsync();
             
        }

        
        
        [HttpGet("[action]/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizzeDefinition(Menu = AuthorizeDefinitionConsts.Product, ActionType = ActionType.Reading, Definition = "Get product image")]
        public async Task<IActionResult> GetAnimalImage([FromRoute]GetAnimalImageQueryRequest getAnimalImageQueryRequest) /*parantez için string id olucak hangi fotoya karsılık hangi hayvana ait oldu  belirleye hata aldım için manuel verdim*/
        {

            List<GetAnimalImageQueryResponse> response = await _mediator.Send(getAnimalImageQueryRequest);
            return Ok(response);
             
        }



        [HttpDelete("[action]/{Id}")] 

        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizzeDefinition(Menu = AuthorizeDefinitionConsts.Product, ActionType = ActionType.Deleting, Definition = "Delete product image")]
        public async Task<IActionResult> DeleteAnimalImage([FromRoute]RemoveAnimalImageCommandRequest removeAnimalImageCommandRequest
             ) /*parantez içi  strinf imageId olucak hata verdi için fotoğrafa karşılık gelen id manuel verim*/
         { 
            RemoveAnimalImageCommandResponse response = await _mediator.Send(removeAnimalImageCommandRequest);
            return Ok();

        }


        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizzeDefinition(Menu = AuthorizeDefinitionConsts.Product, ActionType = ActionType.Updating, Definition = "Change Show Case image")]

        public async Task<IActionResult> ChangeShowcaseImage([FromQuery]ChangeShowcaseImageCommandRequest changeShowcaseImageCommandRequest)
        {
          ChangeShowcaseImageCommandResponse response=  await _mediator.Send(changeShowcaseImageCommandRequest);
            return Ok();
        }
    }
}