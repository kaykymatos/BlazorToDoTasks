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
                .MaximumLength(100).WithMessage("O campo '{PropertyName}' não pode ser maior que {MaxLenght}!")
                .MinimumLength(1).WithMessage("O campo '{PropertyName}' não pode ser menor que {MinLenght}!");

            RuleFor(x => x.Description).NonNullOrEmpty()
                .MaximumLength(500).WithMessage("O campo '{PropertyName}' não pode ser maior que {MaxLenght}!")
                .MinimumLength(1).WithMessage("O campo '{PropertyName}' não pode ser menor que {MinLenght}!");

            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("A data não pode ser menor que a data atual!")
                .LessThanOrEqualTo(x=>x.StartDate).WithMessage("A data não pode ser maior que a data de início!");
        }
    }
}
