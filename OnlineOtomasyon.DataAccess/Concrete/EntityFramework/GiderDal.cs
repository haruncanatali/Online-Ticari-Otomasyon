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
    public class GiderDal : EntityRepositoryBase<Gider, OnlineOtomasyonContext>, IGiderDal
    {
        public Gider Get(Expression<Func<Gider, bool>> filter)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return context.Gider.SingleOrDefault(filter);
            }
        }

        public List<Gider> List(Expression<Func<Gider, bool>> filter = null)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return filter == null ? context.Gider.ToList() : context.Gider.Where(filter).ToList();
            }
        }
    }
}
