using BarinakAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarinakAPI.Domain.Entities;

namespace BarinakAPI.Application 
{
    public interface IFileReadRepository: IReadRepository<BarinakAPI.Domain.Entities.File> 

    {
    }
}
