using BookHeaven.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Service.Validators
{
    public class CreateBookValidator : AbstractValidator<BookDto>
    {
        public CreateBookValidator() {

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş bırakmayınız.")
                    .MinimumLength(3)
                         .WithMessage("Lütfen ürün adını 3 karakterden fazla giriniz.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Ürün Açıklamasını boş bırakmayınız.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                   .WithMessage("Lütfen fiyat bilgisini boş bırakmayınız.")
                   .Must(s => s >= 0)
                        .WithMessage("Fiyat değeri negatif olamaz!");

            RuleFor(p => p.StockCode)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen stok bilgisini boş bırakmayınız");

            RuleFor(p => p.Manufacturer)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen Yazar bilgisini boş bırakmayınız.");

            

        }


    }
}
