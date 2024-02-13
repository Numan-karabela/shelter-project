using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.AnimalImageFile.ChangeShowcaseImage
{
    public class ChangeShowcaseImageCommandRequest:IRequest<ChangeShowcaseImageCommandResponse>
    {
        public string ImageId { get; set; }
        public string AnimalId { get; set; }
    }
}
