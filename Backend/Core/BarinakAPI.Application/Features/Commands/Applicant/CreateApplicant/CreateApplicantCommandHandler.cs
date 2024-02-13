using BarinakAPI.Application.Abstractions.Hubs;
using BarinakAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Applicant.CreateApplicant
{
    public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommandRequest, CreateApplicantCommandResponse>
    {
        readonly IApplicantService _applicantService;
        readonly IBasketService _basketService;
        readonly IApplicantHubService _applicantHubService;


        public CreateApplicantCommandHandler(IApplicantService applicantService, IApplicantHubService applicantHubService, IBasketService basketService)
        {
            _applicantService = applicantService;
            _applicantHubService = applicantHubService;
            _basketService = basketService;
        }

        public async Task<CreateApplicantCommandResponse> Handle(CreateApplicantCommandRequest request, CancellationToken cancellationToken)
        {

         await   _applicantService.CreateApplicantAsync(new()
            {
                Address= request.Address,
                Description= request.Description,
                BasketId= _basketService.GetUserActiveBasket?.Id.ToString()

            });

           await _applicantHubService.ApplicantAddedMessageAsync("!!!Başvuru Geldi!:)");
             
            return new();
        }
    }
}
