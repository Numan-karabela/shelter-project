using BarinakAPI.API.Middlewares;
using BarinakAPI.Application;
using BarinakAPI.Application.Validators.Animals;
using BarinakAPI.Infrastructure;
using BarinakAPI.Infrastructure.Filters;
using BarinakAPI.Infrastructure.Services.Storage.Aruze;
using BarinakAPI.Infrastructure.Services.Storage.Local;
using BarinakAPI.Persistence;
using BarinakAPI.SignaIR;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();//


builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationService();

builder.Services.AddStorage<LocalStorage>();
//builder.Services.AddStorage();
//builder.Services.AddStorage<AruzeStorage>();



builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>
policy.WithOrigins("http://localhost:4200", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

builder.Services.AddSignalRService();
//Logger log = new LoggerConfiguration()
//     .WriteTo.Console()
//     .WriteTo.File("logs/log.txt")
//     .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("Sql"), "logs", autoCreateSqlTable: true
//).CreateLogger();

//var columnOpts = new ColumnOptions();
//columnOpts.Message.DataType = SqlDbType.NVarChar;
//columnOpts.Id.DataType = System.Data.SqlDbType.BigInt;
//columnOpts.Level.DataType = System.Data.SqlDbType.NVarChar;


//builder.Host.UseSerilog(log);


builder.Services.AddControllers(options=>options.Filters.Add<ValidatiorFilters>())
    .AddFluentValidation(configuration =>
    configuration.RegisterValidatorsFromAssemblyContaining<CreateAnimalValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter=true);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer("Admin",optipns => 
   {
       optipns.TokenValidationParameters = new()
       {
          
           ValidateAudience = true,
           ValidateIssuer = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,

           
           
           ValidAudience = builder.Configuration["Token:Audience"],
           ValidIssuer = builder.Configuration["Token:Issuer"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecorityKey"])),
           LifetimeValidator = (notBefore,expires, securityToken, validationParameters) => expires!=null? expires>DateTime.UtcNow:false,
           NameClaimType = ClaimTypes.Email

       };
   });

var app = builder.Build();


app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}   

app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHubs();

app.Run();
