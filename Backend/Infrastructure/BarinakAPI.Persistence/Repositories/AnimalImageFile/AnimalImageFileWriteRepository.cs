using BarinakAPI.Application;
using BarinakAPI.Domain.Entities;
using BarinakAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Persistence.Repositories 
{
    public class AnimalImageFileWriteRepository : WriteRepository<AnimalImageFile>, IAnimalImageFileWriteRepository
    {
        public AnimalImageFileWriteRepository(BarinakAPIDBContext context) : base(context)
        {
        }
    }
}
