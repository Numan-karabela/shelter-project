using BarinakAPI.Application.Repositories;
using BarinakAPI.Domain.Entities;
using BarinakAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Persistence.Repositories
{
    public class BasketWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
    {
        public BasketWriteRepository(BarinakAPIDBContext context) : base(context)
        {
        }
    }
}
