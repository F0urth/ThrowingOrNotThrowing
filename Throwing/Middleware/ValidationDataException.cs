namespace Throwing.Middleware;

using FluentValidation.Results;

public class ValidationDataException : Exception
{
    public List<ValidationFailure> Failures { get; }

    public ValidationDataException(List<ValidationFailure> failures)
    {
        Failures = failures;
    }
}