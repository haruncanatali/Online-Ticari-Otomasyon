using FluentValidation;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.FluentValidation
{
    public class FaturaKalemValidator:AbstractValidator<FaturaKalem>
    {
        public FaturaKalemValidator()
        {
            RuleFor(c => c.Miktar).NotEmpty().WithMessage("Miktar alanı boş geçilemez.");
            RuleFor(c => c.BirimFiyat).NotEmpty().WithMessage("Birim Fiyat alanı boş geçilemez.");
            RuleFor(c => c.Tutar).NotEmpty().WithMessage("Tutar alanı boş geçilemez.");
            RuleFor(c => c.FaturaId).NotEmpty().WithMessage("Fatura ID alanı boş geçilemez.");
            RuleFor(c => c.UrunId).NotEmpty().WithMessage("Urun ID alanı boş geçilemez.");
        }
    }
}
