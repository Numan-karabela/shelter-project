using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Product.RemoveAnimal
{
    public class RemoveAnimalCommandRequest:IRequest<RemoveAnimalCommandResponse>
    {
        public String Id  { get; set; }
    }
}
