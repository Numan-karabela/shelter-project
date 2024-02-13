using BarinakAPI.Application.Abstractions.Services;
using BarinakAPI.Application.DTOs.Applicant;
using BarinakAPI.Application.Repositories;
using BarinakAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarinakAPI.Persistence.Services
{
    public class ApplicantService : IApplicantService
    {
        readonly IApplicantWriteRepository _applicantWriteRepository;
        readonly IApplicantReadRepository _applicantReadRepository;

        public ApplicantService(IApplicantWriteRepository applicantWriteRepository, IApplicantReadRepository applicantReadRepository)
        {
            _applicantWriteRepository = applicantWriteRepository;
            _applicantReadRepository = applicantReadRepository;
        }



        public async Task CreateApplicantAsync(CreateApplicant createApplicant)
        {
            var ApplicantCode = (new Random().NextDouble() * 100000000).ToString();
            ApplicantCode = ApplicantCode.Substring(ApplicantCode.IndexOf(".")+1, ApplicantCode.Length- ApplicantCode.IndexOf('.')-1);

            await _applicantWriteRepository.AddAsync(new()
            {
                Address = createApplicant.Address,
                Id = Guid.Parse(createApplicant.BasketId),
                Description = createApplicant.Description,
                ApplicantCode = ApplicantCode
            });
            await _applicantWriteRepository.SaveAsync();
        }

        public async Task<List<ListApplicant>> GetAllApplicantAsync
            ()=> await _applicantReadRepository.Table.Include(o => o.Basket)
                .ThenInclude(b => b.User)
                .Select(o => new ListApplicant
                {
                    applicantCode=o.ApplicantCode,
                    Description=o.Description,
                    userName=o.Basket.User.UserName
                })
                .ToListAsync();
        }
         
    } 
