using Contact.Application.Automapper;
using Contact.Application.Commands.CreateContact;
using Contact.Domain.AggregatesModel.ContactAggregate;
using Contact.Domain.SeedWork;
using Contact.Infrastructure;
using Contact.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(vf => vf.RegisterValidatorsFromAssemblyContaining<CreateContactCommand>());
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
    .AddDbContext<ContactContext>(opt
    => opt.UseSqlServer(builder.Configuration.GetConnectionString("AddressDatabase")));

builder.Services
    .AddMediatR(typeof(CreateContactCommandHandler).GetTypeInfo().Assembly);

builder.Services
    .AddAutoMapper(new Assembly[] { typeof(AutomapperProfile).GetTypeInfo().Assembly });

builder.Services
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact.API", Version = "v1" });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
