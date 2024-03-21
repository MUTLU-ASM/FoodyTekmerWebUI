using FluentValidation;
using FoodyTekmerEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTekmerBusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz...!");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("En az 10 karakter giriniz...!");
            RuleFor(x => x.Description).MaximumLength(120).WithMessage("En fazla 120 karakter giriniz...!");
            RuleFor(x => x.ImageUrl).NotNull().WithMessage("Bu alanı boş geçemezsiniz...!");
        }
    }
}
