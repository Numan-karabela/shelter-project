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
    public class FileWriteRepository : WriteRepository<BarinakAPI.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(BarinakAPIDBContext context) : base(context)
        {
        }
    }
}
