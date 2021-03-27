using FluentValidation;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.FluentValidation
{
    public class MusteriValidator:AbstractValidator<Musteri>
    {
        public MusteriValidator()
        {
            RuleFor(c => c.Ad).Length(1, 30).WithMessage("Ad alanı [1-30] karakterden oluşmak zorundadır.").NotEmpty().WithMessage("Ad alanı boş geçilemez.");

            RuleFor(c => c.Soyad).Length(1, 30).WithMessage("Soyad alanı [1-30] karakterden oluşmak zorundadır.").NotEmpty().WithMessage("Soyad alanı boş geçilemez.");

            RuleFor(c => c.Mail).Length(1, 80).WithMessage("Mail alanı [1-80] karakterden oluşmak zorundadır.").NotEmpty().WithMessage("Mail alanı boş geçilemez.");

            RuleFor(c => c.Telefon).Length(1, 20).WithMessage("Telefon alanı [1-20] karakterden oluşmak zorundadır.").NotEmpty().WithMessage("Telefon alanı boş geçilemez.");

            RuleFor(c => c.Adres).Length(1, 250).WithMessage("Adres alanı [1-250] karakterden oluşmak zorundadır.").NotEmpty().WithMessage("Adres alanı boş geçilemez.");
        }
    }
}
