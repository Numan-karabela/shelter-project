using BarinakAPI.Application;
using BarinakAPI.Application.Abstractions.Services;
using BarinakAPI.Application.Abstractions.Services.Authentications;
using BarinakAPI.Application.Repositories;
using BarinakAPI.Domain.Entities.Identity;
using BarinakAPI.Persistence.Contexts;
using BarinakAPI.Persistence.Repositories;
using BarinakAPI.Persistence.Repositoriesr;
using BarinakAPI.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BarinakAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            DbContextOptionsBuilder<BarinakAPIDBContext> DbContextOptionsBuilder = new();

            service.AddDbContext<BarinakAPIDBContext>(options => options.UseSqlServer(Configuration.ConfigrationString));

            service.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;


            }).AddEntityFrameworkStores<BarinakAPIDBContext>()
            .AddDefaultTokenProviders();

            service.AddScoped<IAnimalReadRepository, AnimalReadRepository>();
            service.AddScoped<IAnimalWriteRepository, AnimalWriteRepository>();

            service.AddScoped<IApplicantReadRepository, ApplicantReadRepository>();
            service.AddScoped<IApplicantWriteRepository, ApplicantWriteRepository>();

            service.AddScoped<IFileReadRepository, FileReadRepository>();
            service.AddScoped<IFileWriteRepository,  FileWriteRepository>();

            service.AddScoped<IAnimalImageFileReadRepository,  AnimalImageFileReadRepository>();
            service.AddScoped<IAnimalImageFileWriteRepository, AnimalImageFileWriteRepository>();

            service.AddScoped<IInvoicFileReadRepository, InvoiceReadRepository>();
            service.AddScoped<IInvoicFileWriteRepository, InvoiceWriteRepository>();


            service.AddScoped<IBasketItemReadRepository,BasketItemReadRepository>();
            service.AddScoped<IBasketItemWriteRepository,BasketItemWriteRepository>();


            service.AddScoped<IBasketReadRepository,BasketReadRepository>();
            service.AddScoped<IBasketWriteRepository,BasketWriteRepository>();

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAuthService, AuthService>();


            service.AddScoped<IExternalAuthentications, AuthService>();
            service.AddScoped<IInternalAuthentications, AuthService>();

            service.AddScoped<IBasketService, BasketService>();

            service.AddScoped<IApplicantService, ApplicantService>();

            service.AddScoped<IRoleService,RoleService>();




        }

    }
}
