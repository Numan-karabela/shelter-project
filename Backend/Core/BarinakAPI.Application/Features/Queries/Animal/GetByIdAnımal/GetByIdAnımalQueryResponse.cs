using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Queries.Product.GetByIdAnımal
{
    public class GetByIdAnımalQueryResponse
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Vaccination { get; set; } 

    }
}
