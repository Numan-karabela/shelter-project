using BarinakAPI.Application.DTOs.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Abstractions.Services.Configurations
{
    public interface IAppplicationService
    {
        List<Menu> GetAuthorizeDefinitionEndpoints(Type type);


    }
}
