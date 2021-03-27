using FluentValidation;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.FluentValidation
{
    public class FaturaValidator:AbstractValidator<Fatura>
    {
        public FaturaValidator()
        {
            RuleFor(c => c.SeriNo).Length(0, 1).WithMessage("SeriNO alanı [0-1] karakterden oluşmak zorundadır.").NotEmpty().WithMessage("SeriNO alanı boş geçilemez.");
            RuleFor(c => c.SiraNo).Length(0, 10).WithMessage("SıraNO alanı [0-10] karakterden oluşmak zorundadır.").NotEmpty().WithMessage("SıraNO alanı boş geçilemez.");
            RuleFor(c => c.VergiDairesi).Length(0, 100).WithMessage("Vergi dairesi alanı [0-100] karakterden oluşmak zorundadır.").NotEmpty().WithMessage("Vergi dairesi alanı boş geçilemez.");
            RuleFor(c => c.Tarih).NotEmpty().WithMessage("Tarih alanı boş geçilemez.");
            RuleFor(c => c.PersonelId).NotEmpty().WithMessage("Personel ID alanı boş geçilemez.");
            RuleFor(c => c.MusteriId).NotEmpty().WithMessage("Müşteri ID alanı boş geçilemez.");
        }
    }
}
