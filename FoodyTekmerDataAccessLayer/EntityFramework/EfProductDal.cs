using FoodyTekmerDataAccessLayer.Abstract;
using FoodyTekmerDataAccessLayer.Context;
using FoodyTekmerDataAccessLayer.Repositories;
using FoodyTekmerEntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTekmerDataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        FoodyContext db = new FoodyContext();

        public List<Product> GetListCategory()
        {
            using (var context = new FoodyContext())
            {
                return context.Products.Include(x => x.Category).ToList();
            }
        }

        public List<Product> GetListProductWithAjax(int id)
        {
            return db.Products.Where(x => x.CategoryId == id).ToList();
        }
    }
}
