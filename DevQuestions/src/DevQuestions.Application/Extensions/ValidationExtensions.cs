using FluentValidation.Results;
using Shared;

namespace DevQuestions.Application.Extensions;

public static class ValidationExtensions
{
    public static Error[] ToErrors(this List<ValidationFailure> failures)
        => failures.Select(a => Error.Validation(a.ErrorCode, a.ErrorMessage, a.PropertyName)).ToArray();

}