using Destek.Application.Features.Commands.Department.UpdateDepartment;
using FluentValidation;

namespace Destek.Application.Validatiors.Departments
{
    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentCommandRequest>
    {
        public UpdateDepartmentValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen Birim adını giriniz.")
                .MaximumLength(100)
                .MinimumLength(5)
                .WithMessage("Birim adı 5 ile 100 karakter arasında olmalı.");
        }
    }
}
