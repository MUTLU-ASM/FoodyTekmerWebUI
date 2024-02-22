using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerDataAccessLayer.Abstract;
using FoodyTekmerDataAccessLayer.EntityFramework;
using FoodyTekmerEntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyTekmerBusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TAdd(Contact entity)
        {
            _contactDal.Add(entity);
        }

        public void TDelete(int id)
        {
            _contactDal.Delete(id);
        }

        public List<Contact> TGetAllList()
        {
           return _contactDal.GetAllList();
        }

        public Contact TGetById(int id)
        {
           return _contactDal.GetById(id);
        }

        public void TUpdate(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
