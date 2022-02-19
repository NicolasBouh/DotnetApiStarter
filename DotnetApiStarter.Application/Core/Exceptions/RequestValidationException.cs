using FluentValidation.Results;

namespace DotnetApiStarter.Application.Core.Exceptions;

public class RequestValidationException : Exception
{
    private static string _defaultMessage = "One or more validation failures have occurred.";
    
    public RequestValidationException()
        : base(_defaultMessage)
    {
        Errors = new Dictionary<string, string[]>();
    }

    public RequestValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}