using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Queries.Product.GetAllAnimal
{
    public class GetAllAnimalQueryResponse
    {
        public int TotalAnimalCount { get; set; }
        public object Animals { get; set; }


    }
}
