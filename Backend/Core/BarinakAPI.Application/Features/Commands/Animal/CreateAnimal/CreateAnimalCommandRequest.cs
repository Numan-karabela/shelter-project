using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Product.CreateAnimal
{
    public class CreateAnimalCommandRequest:IRequest<CreateAnimalCommandResponse>
    {

        public string Name { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Vaccination { get; set; }


    }
}
