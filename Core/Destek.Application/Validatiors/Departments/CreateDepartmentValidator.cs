using Destek.Application.DTOs.Department;
using Destek.Application.Features.Commands.Department.CreateDepartment;
using FluentValidation;

namespace Destek.Application.Validatiors.Departments
{
    public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentCommandRequest>
    {
        public CreateDepartmentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Birim adını giriniz.")
                .MaximumLength(100)
                .MinimumLength(5)
                    .WithMessage("Birim adı 5 ile 100 karakter arasında olmalı.");

        }
    }
}
