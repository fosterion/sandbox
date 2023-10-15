using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sandbox.Filters.Api.Models;

namespace Sandbox.Filters.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var error = new ErrorModel
        (
            500,
            context.Exception.Message,
            context.Exception.StackTrace?.ToString()
        );

        context.Result = new JsonResult(error);
    }
}
