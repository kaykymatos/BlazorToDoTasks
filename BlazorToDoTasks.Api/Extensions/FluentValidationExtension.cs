using BlazorToDoTasks.Api.Models;
using FluentValidation;
using FluentValidation.Results;

namespace BlazorToDoTasks.Api.Extensions
{
    public static class FluentValidationExtension
    {
        public static IList<ErrorResponseModel> ToCustomValidationFailure(this IList<ValidationFailure> failures)
        {
            return failures.Select(x => new ErrorResponseModel(x.PropertyName, x.ErrorMessage)).ToList();
        }
        public static IRuleBuilderOptions<T, string> NonNullOrEmpty<T>(this IRuleBuilderInitial<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x=>!string.IsNullOrWhiteSpace(x))
                         .WithMessage("O campo '{PropertyName}' não pode ser nulo.");
        }
    }
}
