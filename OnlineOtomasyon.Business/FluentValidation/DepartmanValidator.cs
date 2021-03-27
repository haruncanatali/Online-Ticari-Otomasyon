using FluentValidation;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.FluentValidation
{
    public class DepartmanValidator:AbstractValidator<Departman>
    {
        public DepartmanValidator()
        {
            RuleFor(c => c.DepartmanAd).Length(1, 150).WithMessage("Departman adı [1-150] karakter uzunluğunda olmalıdır.").NotEmpty().WithMessage("Departman adı boş geçilemez.");
        }
    }
}
