using OnlineOtomasyon.Business.Abstract;
using OnlineOtomasyon.Business.FluentValidation;
using OnlineOtomasyon.DataAccess.Abstract;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.Concrete
{
    public class AdminManager:ServiceRepository<Admin,IAdminDal,AdminValidator> ,IAdminService
    {
        public AdminManager(IAdminDal x,AdminValidator y):base(x,y)
        {

        }
    }
}
