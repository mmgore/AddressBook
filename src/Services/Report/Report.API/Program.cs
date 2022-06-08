using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Report.API.Application.Automapper;
using Report.API.Application.Interfaces;
using Report.API.Application.Services;
using Report.API.Domain.Interfaces;
using Report.API.Infrastructure;
using Report.API.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services
    .AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services
    .AddScoped<IContactItemRepository, ContactItemRepository>();
builder.Services
    .AddScoped<IContactInformationRepository, ContactInformationRepository>();
builder.Services
    .AddScoped<IReportAppService, ReportAppService>();
builder.Services
    .AddDbContext<ReportContext>(opt
    => opt.UseSqlServer(builder.Configuration.GetConnectionString("AddressDatabase")));
builder.Services
    .AddAutoMapper(new Assembly[] { typeof(AutomapperProfile).GetTypeInfo().Assembly });
builder.Services
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Report.API", Version = "v1" });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Report.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
