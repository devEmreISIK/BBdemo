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

    public AuthorizationException(List<string> errors)
    {
        Errors = errors;
    }
}
