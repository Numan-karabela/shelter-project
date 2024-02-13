using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Domain.Entities
{
    public class Applicant:BaseEntity
    {
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Address{ get; set; }
        public string ApplicantCode { get; set; }
        public Basket Basket { get; set; }

        //public string Animal_ID { get; set; }

    }
}
