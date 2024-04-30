using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Exceptions;

public class ValidationException : Exception
{
    public List<string> ValidationErrors { get; }
    public ValidationException(ValidationResult validationResults)
    {
        ValidationErrors = new List<string>();

        foreach (var error in validationResults.Errors)
        {
            ValidationErrors.Add(error.ErrorMessage);
        }
    }
}
