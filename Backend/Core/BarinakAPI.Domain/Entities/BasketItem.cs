using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Domain.Entities
{
    public class BasketItem:BaseEntity
    {

        public Guid BasketId { get; set; }
        public Guid AnimalId { get; set; } 
        public Basket Basket { get; set; }
        public Animal Animal { get; set; }
        public int Quentity { get; set; }


    }
}
