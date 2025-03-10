using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcernes.Exceptions;

public class AuthorizationException : Exception
{
    public List<string> Errors { get; set; } = new List<string>();
    public AuthorizationException(string message) : base(message)
    {
        Errors.Add(message);
    }

    public AuthorizationException(List<string> errors) : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }

    private static string BuildErrorMessage(List<string> errors)
    {
        return string.Join("\n", errors);
    }
}
