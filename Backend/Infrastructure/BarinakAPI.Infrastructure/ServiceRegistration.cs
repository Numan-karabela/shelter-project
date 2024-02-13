using BarinakAPI.Application.Abstractions.Services;
using BarinakAPI.Application.Abstractions.Services.Configurations;
using BarinakAPI.Application.Abstractions.Storage;
using BarinakAPI.Application.Abstractions.Token;
using BarinakAPI.Infrastructure.Enums;
using BarinakAPI.Infrastructure.Services;
using BarinakAPI.Infrastructure.Services.Configuration;
using BarinakAPI.Infrastructure.Services.Storage;
using BarinakAPI.Infrastructure.Services.Storage.Aruze;
using BarinakAPI.Infrastructure.Services.Storage.Local;
using BarinakAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Infrastructure
{
    public static  class ServiceRegistration
    {

        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {

                 serviceCollection.AddScoped<IStorageService,StorageService>();
                 serviceCollection.AddScoped<ITokenHandler,TokenHandler>();
                 serviceCollection.AddScoped<IMailService,MailService>();
                 serviceCollection.AddScoped<IAppplicationService, AppplicationService>();


        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T :Storage, IStorage
        {
                serviceCollection.AddScoped<IStorage,T>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection, StorageType storageType ) 
        {

            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AruzeStorage>();

                    break;
                case StorageType.AWS:
                    break;
                default:
                    break;
            }


        }

    }
}
