using BarinakAPI.Application.DTOs.Applicant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Abstractions.Services
{
    public interface IApplicantService
    {
        Task CreateApplicantAsync(CreateApplicant createApplicant);
        Task<List<ListApplicant>> GetAllApplicantAsync();


    }
}
