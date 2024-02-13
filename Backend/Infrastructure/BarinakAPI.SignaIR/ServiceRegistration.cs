using BarinakAPI.Application.Abstractions.Hubs;
using BarinakAPI.SignaIR.HubServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.SignaIR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRService(this IServiceCollection collection)
        {

            collection.AddTransient<IAnimalHubService, AnimalHubService>();
            collection.AddTransient<IApplicantHubService, ApplicantHubService>();

            collection.AddSignalR();


        }


    }
}
