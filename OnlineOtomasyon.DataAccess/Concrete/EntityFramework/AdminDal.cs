using OnlineOtomasyon.DataAccess.Abstract;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.DataAccess.Concrete.EntityFramework
{
    public class AdminDal : EntityRepositoryBase<Admin, OnlineOtomasyonContext>, IAdminDal
    {
        
        public Admin Get(Expression<Func<Admin, bool>> filter)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return context.Admin.SingleOrDefault(filter);
            }
        }

        public List<Admin> List(Expression<Func<Admin, bool>> filter = null)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return filter == null ? context.Admin.ToList() : context.Admin.Where(filter).ToList();
            }
        }
    }
}
