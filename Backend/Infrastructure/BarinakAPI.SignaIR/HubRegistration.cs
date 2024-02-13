using BarinakAPI.Domain.Entities;
using BarinakAPI.SignaIR.Hubs;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.SignaIR
{
    public static class HubRegistration
    {
        public static void MapHubs(this WebApplication webApplication)
        {
            webApplication.MapHub<AnimalHub>("/animals-hub");
            webApplication.MapHub<ApplicantHub>("/applicants-hub"); 
        }

    }
}
