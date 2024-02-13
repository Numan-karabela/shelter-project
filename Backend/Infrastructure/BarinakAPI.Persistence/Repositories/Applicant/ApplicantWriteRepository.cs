using BarinakAPI.Application.Repositories;
using BarinakAPI.Persistence.Contexts;
using BarinakAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Persistence.Repositories
{
    public class ApplicantWriteRepository : WriteRepository<Applicant>, IApplicantWriteRepository
    {
        public ApplicantWriteRepository(BarinakAPIDBContext context) : base(context)
        {
        }
    }
}
