﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Abstractions.Hubs
{
    public interface  IAnimalHubService
    {
        Task AnimalAddedMessageAsync(string message);


    }
}
