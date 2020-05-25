using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Services.Middlewares
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await ExceptionHandler(context, ex);
            }

        }

        private static async Task ExceptionHandler(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            if (ex.InnerException is DominioException)
            {
                var dominioException = (DominioException)ex.InnerException;
                var result = await Result<string>.Fail(false, dominioException.Errors.ToArray());
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { data = result.Data, success = result.Success, errors = result.Errors }));
            }
            else
            {
                var result = await Result<string>.Fail(false, ex.Message);
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { data = result.Data, success = result.Success, errors = result.Errors }));
            }

        }
    }
}
