using Destek.Application.Features.Commands.Product.Create;
using FluentValidation;
using System.Data;

namespace Destek.Application.Validatiors.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductValidator()
        {

            RuleFor(x => x.WarehouseCategoryId)
           .NotNull()
            .NotEmpty()
            .WithMessage("Kategori giriniz.");


            RuleFor(x => x.BrandId)
           .NotNull()
            .NotEmpty()
            .WithMessage("Marka giriniz.");

            RuleFor(x => x.Name)
              .NotNull()
               .NotEmpty()
               .WithMessage("Lütfen Ürün adını giriniz.")
               .MaximumLength(200)
               .MinimumLength(3)
               .WithMessage("Ürün adı 3 ile 200 karakter arasında olmalı.");

            //RuleFor(x => x.Barcode)
            // .NotNull()
            //  .NotEmpty()
            //  .WithMessage("Barkod numarasını giriniz.")
            //  .MaximumLength(200)
            //  .MinimumLength(3)
            //  .WithMessage("Barkod numarası 10 ile 200 karakter arasında olmalı.");

            RuleFor(x => x.SerialNumber)
             .NotNull()
              .NotEmpty()
              .WithMessage("Seri Numarası giriniz.")
              .MaximumLength(200)
              .MinimumLength(3)
              .WithMessage("Seri Numarası 10 ile 200 karakter arasında olmalı.");

            RuleFor(x => x.UnitOfMeasureType)
             .NotNull()
              .NotEmpty()
              .WithMessage("Lütfen Ölçü Birimi Giriniz..");


        }
    }
}
