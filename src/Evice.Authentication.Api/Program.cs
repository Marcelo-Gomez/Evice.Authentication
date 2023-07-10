using Evice.Authentication.Api.Extensions;
using Evice.Authentication.Application.Commands.Requests;
using Evice.Authentication.Application.Queries;
using Evice.Authentication.Application.Queries.Interfaces;
using Evice.Authentication.Application.Validators.User;
using Evice.Authentication.Domain.AggregatesModel.UserAggregate;
using Evice.Authentication.Infrastructure.IoC;
using Evice.Authentication.Infrastructure.Repositories;
using FluentValidation;

#region Builder

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IValidator<AddUserRequest>, AddUserRequestValidator>();
builder.Services.AddScoped<IUserQuery, UserQuery>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var assembly = AppDomain.CurrentDomain.Load("Evice.Authentication.Application");
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
builder.Services.AddAutoMapper(assembly);

DependencyContainer.RegisterServices(builder.Services);

#endregion

#region App

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseProblemDetailsExceptionHandler();

app.MapControllers();

app.Run();

#endregion