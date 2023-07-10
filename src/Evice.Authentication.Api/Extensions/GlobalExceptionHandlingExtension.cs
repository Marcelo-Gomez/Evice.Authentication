using Evice.Authentication.Domain.SeedWork.Bases;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Evice.Authentication.Api.Extensions
{
    public static class GlobalExceptionHandlingExtension
    {
        public static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        var exception = exceptionHandlerFeature.Error;

                        var response = new ResponseBase<object>();

                        if (exception is ValidationException validationException)
                        {
                            response.AddError(HttpStatusCode.BadRequest, validationException.Message);
                        }
                        else if (exception is BadHttpRequestException badHttpRequestException)
                        {
                            response.AddError(HttpStatusCode.BadRequest, badHttpRequestException.Message);
                        }
                        else if (exception is NotImplementedException)
                        {
                            response.AddError(HttpStatusCode.NotImplemented, exception.Message);
                        }
                        else
                        {
                            response.AddError(HttpStatusCode.InternalServerError, "The server encountered an unexpected condition that prevented it from fulfilling the request.");
                        }

                        context.Response.StatusCode = (int)response.HttpStatusCode;
                        context.Response.ContentType = "application/problem+json";

                        await context.Response.WriteAsync(JsonSerializer.Serialize<object>(response));
                    }
                });
            });
        }
    }
}