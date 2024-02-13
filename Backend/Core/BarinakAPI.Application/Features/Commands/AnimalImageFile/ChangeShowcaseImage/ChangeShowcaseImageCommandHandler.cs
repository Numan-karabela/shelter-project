using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.AnimalImageFile.ChangeShowcaseImage
{
    public class ChangeShowcaseImageCommandHandler : IRequestHandler<ChangeShowcaseImageCommandRequest, ChangeShowcaseImageCommandResponse>
    {
        readonly IAnimalImageFileWriteRepository _animalImageFileWriteRepository;

        public ChangeShowcaseImageCommandHandler(IAnimalImageFileWriteRepository animalImageFileWriteRepository)
        {
            _animalImageFileWriteRepository = animalImageFileWriteRepository;
        }

        public async Task<ChangeShowcaseImageCommandResponse> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
        {
            var query = _animalImageFileWriteRepository.Table
                   .Include(p => p.Animal)
                   .SelectMany(p => p.Animal, (pif, p) => new
                   {
                       pif,
                       p


                   });

            var data =await query.FirstOrDefaultAsync(p => p.p.Id == Guid.Parse(request.AnimalId) && p.pif.Showcase);

            

            if (data != null)
                data.pif.Showcase = false;
            var image= await query.FirstOrDefaultAsync(p => p.pif.Id == Guid.Parse(request.ImageId));
            

            if(image!=null)
            image.pif.Showcase = true;


            await _animalImageFileWriteRepository.SaveAsync();

           return new();
        }
    }
}
