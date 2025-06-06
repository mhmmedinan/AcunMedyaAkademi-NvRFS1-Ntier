﻿using Core.Exceptions.Extensions;
using Core.Exceptions.HttpProblemDetails;
using Core.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace Core.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    private HttpResponse? _response;

    public HttpResponse Response
    {
        get=> _response ?? throw new ArgumentNullException(nameof(_response));
        set=> _response = value;
    }

    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new BusinessProblemDetails(businessException.Message).AsJson();
        return Response.WriteAsync(details);
    }

    protected override Task HandleException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        string details = new InternalServerErrorProblemDetails(exception.Message).AsJson();
        return Response.WriteAsync(details);
    }
}
