using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.AnimalImageFile.UploadAnimalImages
{
    public class UploadAnimalimageCommandRequest:IRequest<UploadAnimalimageCommandResponse>
    {
        public string? Id { get; set; }
        public IFormFileCollection? Files{ get; set; }
    }
}
