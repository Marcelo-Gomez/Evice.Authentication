using Evice.Authentication.Domain.SeedWork.Bases;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Evice.Authentication.Api.Extensions
{
    public static class GlobalExceptionHandlingExtension
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
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

                        switch (exception)
                        {
                            case ValidationException:
                            case BadHttpRequestException:
                                response.AddError(HttpStatusCode.BadRequest, exception.Message);
                                break;
                            case NotImplementedException:
                                response.AddError(HttpStatusCode.NotImplemented, exception.Message);
                                break;
                            default:
                                response.AddError(HttpStatusCode.InternalServerError, "The server encountered an unexpected condition that prevented it from fulfilling the request.");
                                break;
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