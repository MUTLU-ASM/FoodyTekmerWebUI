using FoodyTekmerDataAccessLayer.Abstract;
using FoodyTekmerDataAccessLayer.Context;
using FoodyTekmerDataAccessLayer.Repositories;
using FoodyTekmerEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTekmerDataAccessLayer.EntityFramework
{
    public class EfContactDal :GenericRepository<Contact>,IContactDal
    {
        public List<Contact> GetListUnreadMessage()
        {
            using (var context = new FoodyContext())
            {
                return context.Contacts.Where(x => x.Status == false).OrderByDescending(m => m.dateTime).ToList();
            }
        }
    }
}
