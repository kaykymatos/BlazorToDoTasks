using BlazorToDoTasks.Api.Models;
using FluentValidation;
using BlazorToDoTasks.Api.Extensions;

namespace BlazorToDoTasks.Api.Validation
{
    public class TaskValidation : AbstractValidator<TaskModel>
    {
        public TaskValidation()
        {
            RuleFor(x => x.Title).NonNullOrEmpty()
                .MaximumLength(100).WithMessage("O campo '{PropertyName}' não pode ser maior que {MaxLength}!");

            RuleFor(x => x.Description).NonNullOrEmpty()
                .MaximumLength(500).WithMessage("O campo '{PropertyName}' não pode ser maior que {MaxLength}!");

        }
    }
}
