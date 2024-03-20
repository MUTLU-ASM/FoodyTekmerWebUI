using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerBusinessLayer.Concrete;
using FoodyTekmerDataAccessLayer.Abstract;
using FoodyTekmerDataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTekmerBusinessLayer.Container
{
    public static class ContextExtensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IAdminDal, EfAdminDal>();
            services.AddScoped<IAdminService, AdminManager>();

        }
    }
}
