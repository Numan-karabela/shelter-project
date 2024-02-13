using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Features.Commands.Applicant.CreateApplicant
{
    public class CreateApplicantCommandRequest:IRequest<CreateApplicantCommandResponse>
    {
        public string Address { get; set; }
        public string Description { get; set; }

    }
}
