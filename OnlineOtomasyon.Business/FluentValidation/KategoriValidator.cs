using FluentValidation;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.FluentValidation
{
    public class KategoriValidator : AbstractValidator<Kategori>
    {
        public KategoriValidator()
        {
            RuleFor(c => c.KategoriAdi).Length(1, 100).WithMessage("Kategori Adı alanı [1-100] karakter uzunluğunda olmalıdır.").NotEmpty().WithMessage("Kategori Adı alanı boş geçilemez.");
        }
    }
}
