using BarinakAPI.Application.Repositories;
using BarinakAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarinakAPI.Domain.Entities;

namespace BarinakAPI.Application 
{
    public interface IInvoicFileReadRepository:IReadRepository<InvoiceFile>
    {
    }
}
