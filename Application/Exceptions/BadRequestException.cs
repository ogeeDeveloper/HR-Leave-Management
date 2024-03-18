using FluentValidation.Results;

namespace HRLeaveManagement.Application.Exceptions;

public class BadRequestException : Exception
{
        public BadRequestException(string message) : base(message)
        {
            
        }
    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        // Convert errors in a list of strings
        ValidationErrors = validationResult.ToDictionary();
    }

    public IDictionary<string, string[]> ValidationErrors { get; set; } 
}

