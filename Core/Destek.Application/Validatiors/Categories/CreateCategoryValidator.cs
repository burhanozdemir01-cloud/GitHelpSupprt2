using Destek.Application.Features.Commands.Category.CreateCategory;
using FluentValidation;

namespace Destek.Application.Validatiors.Categories
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
               .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen Kategori adını giriniz.")
                .MaximumLength(200)
                .MinimumLength(3)
                .WithMessage("Kategori adı 3 ile 200 karakter arasında olmalı.");

            RuleFor(f => f.SequenceNumber)
              .NotEmpty()
                .WithMessage("Sıra Numarası boş olamaz.")
              .InclusiveBetween(1, 500)
                 .WithMessage("Kabul edilen Sıra Numarası 1-500 arasıdır.");

        }
    }
}
