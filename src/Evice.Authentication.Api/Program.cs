using Evice.Authentication.Api.Extensions;
using Evice.Authentication.Infrastructure.IoC;

#region Builder

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices();

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

app.UseGlobalExceptionHandler();

app.MapControllers();

app.Run();

#endregion