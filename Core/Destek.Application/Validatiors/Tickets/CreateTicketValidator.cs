using Destek.Application.Features.Commands.Ticket.CreateTicket;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Validatiors.Tickets
{
    public class CreateTicketValidator : AbstractValidator<CreateTicketCommandRequest>
    {
        public CreateTicketValidator()
        {
            RuleFor(x => x.Title)
               .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen Başlık giriniz.")
                .MaximumLength(300)
                .MinimumLength(5)
                .WithMessage("Kategori adı 5 ile 300 karakter arasında olmalı.");

            RuleFor(x => x.DepartmentId)
              .NotNull()
               .NotEmpty()
               .WithMessage("Biriminizi giriniz.");

            RuleFor(x => x.SubCategoryId)
             .NotNull()
              .NotEmpty()
              .WithMessage("Kategori giriniz.");
            //RuleFor(f => f.SequenceNumber)
            //  .NotEmpty()
            //    .WithMessage("Sıra Numarası boş olamaz.")
            //  .InclusiveBetween(1, 500)
            //     .WithMessage("Kabul edilen Sıra Numarası 1-500 arasıdır.");
        }
    }
}
