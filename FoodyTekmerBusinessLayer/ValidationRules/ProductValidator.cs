using FluentValidation;
using FoodyTekmerEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTekmerBusinessLayer.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün ismini boş geçemezsiniz...!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Ürün resmini boş geçemezsiniz...!");
        }
    }
}
