using BarinakAPI.Application.Abstractions.Hubs;
using BarinakAPI.SignaIR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.SignaIR.HubServices
{
    public class ApplicantHubService : IApplicantHubService
    {
        readonly IHubContext<ApplicantHub> _hubContext;

        public ApplicantHubService(IHubContext<ApplicantHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task ApplicantAddedMessageAsync(string message)
            =>await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.ApplicantAddedMessage,message);
        
         

    }
}
