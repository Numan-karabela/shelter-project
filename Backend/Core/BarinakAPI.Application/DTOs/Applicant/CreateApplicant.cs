using BarinakAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.DTOs.Applicant
{
    public class CreateApplicant
    {
        public string? BasketId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
     }
}
