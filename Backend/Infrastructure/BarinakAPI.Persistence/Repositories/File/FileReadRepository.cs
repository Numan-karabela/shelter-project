using BarinakAPI.Application;
using BarinakAPI.Application.Repositories;
using BarinakAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Persistence.Repositories
{
    public class FileReadRepository:ReadRepository<BarinakAPI.Domain.Entities.File>,IFileReadRepository
    {

        public FileReadRepository(BarinakAPIDBContext context):base(context) 
        {

        }

    }
}
