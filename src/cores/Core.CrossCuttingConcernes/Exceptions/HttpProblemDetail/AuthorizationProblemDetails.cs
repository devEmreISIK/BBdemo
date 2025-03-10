using Core.CrossCuttingConcernes.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class AuthorizationProblemDetails : ProblemDetails
{
    public List<string> Errors { get; set; }
    public AuthorizationProblemDetails(List<string> errors)
    {
        Title = "Authorization";
        Status = StatusCodes.Status400BadRequest;
        Type = nameof(AuthorizationException);
        Errors = errors;
    }

    public AuthorizationProblemDetails(string message)
    {
        Title = "Authorization";
        Status = StatusCodes.Status400BadRequest;
        Type = nameof(AuthorizationException);
        Detail = message;
    }
}
