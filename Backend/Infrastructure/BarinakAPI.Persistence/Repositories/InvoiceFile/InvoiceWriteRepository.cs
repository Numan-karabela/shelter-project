using BarinakAPI.Application;
using BarinakAPI.Domain.Entities;
using BarinakAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Persistence.Repositories 
{
    public class InvoiceWriteRepository : WriteRepository<InvoiceFile>, IInvoicFileWriteRepository
    {
        public InvoiceWriteRepository(BarinakAPIDBContext context) : base(context)
        {
        }
    }
}
