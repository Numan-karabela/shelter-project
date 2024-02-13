using BarinakAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Queries.Application
{
    public class GetAllApplicationQueryHandler : IRequestHandler<GetAllApplicationQueryRequest,List<GetAllApplicationQueryResponse>>
    {
        readonly IApplicantService _applicantService;

        public GetAllApplicationQueryHandler(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
         
        public async Task<List<GetAllApplicationQueryResponse>> Handle(GetAllApplicationQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _applicantService.GetAllApplicantAsync();
            return data.Select(o => new GetAllApplicationQueryResponse
            {
                applicationrCode = o.applicantCode,
                Description = o.Description,
                userName = o.userName

            }).ToList();
        }

    }
}
