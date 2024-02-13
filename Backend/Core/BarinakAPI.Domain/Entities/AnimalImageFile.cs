using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Domain.Entities
{
    public class AnimalImageFile:File
    {
        public bool Showcase { get; set; }
        public ICollection<Animal> Animal { get; set; }
    }
}
