using FluentValidation;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.FluentValidation
{
    public class GiderValidator:AbstractValidator<Gider>
    {
        public GiderValidator()
        {
            RuleFor(c => c.Aciklama).Length(1, 1500).WithMessage("Açıklama alanı [1-1500] karakter uzunluğunda olmalıdır.").NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
            RuleFor(c => c.Tarih).NotEmpty().WithMessage("Tarih alanı boş geçilemez.");
            RuleFor(c => c.Tutar).NotEmpty().WithMessage("Tutar alanı boş geçilemez.");
        }
    }
}
