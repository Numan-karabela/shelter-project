using BarinakAPI.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.DTOs.Configurations
{
    public class Action
    {
       public string ActionType { get; set; }
       public string HttpType { get; set; }
       public string Definition { get; set; }
       public string Code { get; set; }

    }
}
