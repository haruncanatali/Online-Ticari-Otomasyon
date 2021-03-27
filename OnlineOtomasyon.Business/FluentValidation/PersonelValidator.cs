using FluentValidation;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.FluentValidation
{
    public class PersonelValidator:AbstractValidator<Personel>
    {
        public PersonelValidator()
        {
            RuleFor(c => c.Ad).Length(1, 30).WithMessage("Ad alanı [1-30] karakterden oluşmak zorundadır.").NotEmpty().WithMessage("Ad alanı boş geçilemez.");

            RuleFor(c => c.Soyad).Length(1, 30).WithMessage("Soyad alanı [1-30] karakterden oluşmak zorundadır.").NotEmpty().WithMessage("Soyad alanı boş geçilemez.");

            RuleFor(c => c.Gorsel).Length(1, 30).WithMessage("Görsel alanı [1-250] karakterden oluşmak zorundadır.");

            RuleFor(c => c.DepartmanId).NotEmpty().WithMessage("Departman ID alanı boş geçilemez.");
        }
    }
}
