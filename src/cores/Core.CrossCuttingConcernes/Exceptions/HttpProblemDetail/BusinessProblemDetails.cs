using Core.CrossCuttingConcernes.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class BusinessProblemDetails : ProblemDetails 
{
    public BusinessProblemDetails(string detail)
    {
        Title = "Business";
        Detail = detail;
        Status = StatusCodes.Status400BadRequest;
        Type = nameof(NotFoundException);
    }
}
