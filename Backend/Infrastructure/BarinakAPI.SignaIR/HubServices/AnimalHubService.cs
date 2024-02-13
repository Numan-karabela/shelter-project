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
    public class AnimalHubService : IAnimalHubService
    {   readonly IHubContext<AnimalHub> _hubContext;

        public AnimalHubService(IHubContext<AnimalHub> hubcontext)
        {
            _hubContext = hubcontext;
        }

        public async Task AnimalAddedMessageAsync(string message)
        {

           await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.AnimalAddedMessage, message);


        }
    }
}
