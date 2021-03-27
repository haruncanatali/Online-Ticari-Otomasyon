using FluentValidation;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.FluentValidation
{
    public class AdminValidator:AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(c => c.KullaniciAdi).Length(1, 10).WithMessage("Kullanıcı adı [1-10] karakter uzunluğunda olmalıdır.").NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");

            RuleFor(c => c.Sifre).Length(1, 10).WithMessage("Şifre [1-10] karakter uzunluğunda olmalıdır.").NotEmpty().WithMessage("Şifre boş geçilemez.");

            RuleFor(c => c.Yetki).Length(1, 50).WithMessage("Yetki [1-50] karakter uzunluğunda olmalıdır.").NotEmpty().WithMessage("Yetki boş geçilemez.");
        }
    }
}
