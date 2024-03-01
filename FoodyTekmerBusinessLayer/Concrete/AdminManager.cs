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
	public class AdminManager : IAdminService
	{
		private readonly IAdminDal _adminDal;

		public AdminManager(IAdminDal adminDal)
		{
            _adminDal = adminDal;
		}

		public void TAdd(Admin entity)
		{
            _adminDal.Add(entity);
		}

		public void TDelete(int id)
		{
            _adminDal.Delete(id);
		}

		public List<Admin> TGetAllList()
		{
			return _adminDal.GetAllList();
		}

		public Admin TGetById(int id)
		{
			return _adminDal.GetById(id);
		}

		public void TUpdate(Admin entity)
		{
            _adminDal.Update(entity);
		}
	}
}
