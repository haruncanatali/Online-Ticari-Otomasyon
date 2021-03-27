using FluentValidation;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.FluentValidation
{
    public class SatisHareketValidator:AbstractValidator<SatisHareket>
    {
        public SatisHareketValidator()
        {
            RuleFor(c => c.Tarih).NotEmpty().WithMessage("Tarih alanı boş geçilemez.");
            RuleFor(c => c.Adet).NotEmpty().WithMessage("Adet alanı boş geçilemez.");
            RuleFor(c => c.Fiyat).NotEmpty().WithMessage("Fiyat alanı boş geçilemez.");
            RuleFor(c => c.ToplamTutar).NotEmpty().WithMessage("ToplamTutar alanı boş geçilemez.");
            RuleFor(c => c.UrunId).NotEmpty().WithMessage("Urun alanı boş geçilemez.");
            RuleFor(c => c.PersonelId).NotEmpty().WithMessage("Personel alanı boş geçilemez.");
            RuleFor(c => c.MusteriId).NotEmpty().WithMessage("Musteri alanı boş geçilemez.");
        }
    }
}
