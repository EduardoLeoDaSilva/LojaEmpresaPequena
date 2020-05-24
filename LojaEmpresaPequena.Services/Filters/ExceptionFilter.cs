using LojaEmpresaPequena.Domain.Entities.Api;
using LojaEmpresaPequena.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Services.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DominioException)
            {
                var exception = (DominioException)context.Exception;
                var msgForResponse = new Result(false, exception.Errors);
                context.Result = new BadRequestObjectResult(msgForResponse);

            }
            else
            {
                var errosList = new List<string>();
                errosList.Add(context.Exception.Message);
                context.Result = new BadRequestObjectResult(new Result(false, errosList));
            }


            context.HttpContext.Response.StatusCode = 400;
            context.HttpContext.Response.ContentType = "appplication/json";
            context.ExceptionHandled = true;
        }
    }
}
