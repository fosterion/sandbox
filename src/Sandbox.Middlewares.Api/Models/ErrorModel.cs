using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.Middlewares.Api.Models;

public class ErrorModel
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Details { get; set; }

    public ErrorModel(int statusCode, string? message, string? details = null)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }
}
