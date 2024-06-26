﻿using FoodyTekmerEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTekmerDataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        List<Product> GetListCategory();
        List<Product> GetListProductWithAjax(int id);
    }
}
