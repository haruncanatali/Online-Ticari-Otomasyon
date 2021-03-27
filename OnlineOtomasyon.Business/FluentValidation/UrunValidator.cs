using FluentValidation;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.FluentValidation
{
    public class UrunValidator:AbstractValidator<Urun>
    {
        public UrunValidator()
        {
            RuleFor(c => c.Ad).Length(1, 100).WithMessage("Ürün adı alanı [1-100] karakter uzunluğunda olmalıdır.").NotEmpty().WithMessage("Ürün adı alanı boş geçilemez.");
            RuleFor(c => c.Marka).Length(1, 100).WithMessage("Marka alanı [1-100] karakter uzunluğunda olmalıdır.").NotEmpty().WithMessage("Marka alanı boş geçilemez.");
            RuleFor(c => c.Stok).NotEmpty().WithMessage("Stok alanı boş geçilemez.");
            RuleFor(c => c.AlisFiyat).NotEmpty().WithMessage("Alış fiyatı alanı boş geçilemez.");
            RuleFor(c => c.SatisFiyat).NotEmpty().WithMessage("Satış fiyatı alanı boş geçilemez.");
            RuleFor(c => c.KategoriId).NotEmpty().WithMessage("Kategori alanı boş geçilemez.");
        }
    }
}
