using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerDataAccessLayer.Abstract;
using FoodyTekmerEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTekmerBusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryService;

        public CategoryManager(ICategoryDal categoryService)
        {
            _categoryService = categoryService;
        }

        public void TAdd(Category entity)
        {
            _categoryService.Add(entity);
        }

        public void TDelete(int id)
        {
            _categoryService.Delete(id);
        }

        public List<Category> TGetAllList()
        {
            return _categoryService.GetAllList();
        }

        public Category TGetById(int id)
        {
            return _categoryService.GetById(id);
        }

        public void TUpdate(Category entity)
        {
            _categoryService.Update(entity);
        }
    }
}
