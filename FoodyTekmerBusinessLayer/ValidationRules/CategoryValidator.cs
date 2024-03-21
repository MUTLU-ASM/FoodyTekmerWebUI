using FluentValidation;
using FoodyTekmerEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTekmerBusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz...!");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Lütfen 2 Karekterden fazla giriniz...!");
        }
    }
}
