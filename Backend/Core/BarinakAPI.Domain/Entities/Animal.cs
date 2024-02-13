using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Domain.Entities
{
    public class Animal:BaseEntity
    {
        public string Name{ get; set; }
        public string Type{ get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Vaccination { get; set; }
        //public ICollection<Applicant> Applicants{ get; set; }
        public ICollection<AnimalImageFile> AnimalImageFiles { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }

    }
}
