using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.AnimalImageFile.RemoveAnimalImage
{
    public class RemoveAnimalImageCommandRequest:IRequest<RemoveAnimalImageCommandResponse>
    {
        public string Id { get; set; }
        public String? ImageId { get; set; }

    }
}
