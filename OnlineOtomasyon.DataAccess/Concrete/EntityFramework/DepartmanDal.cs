using OnlineOtomasyon.DataAccess.Abstract;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.DataAccess.Concrete.EntityFramework
{
    public class DepartmanDal : EntityRepositoryBase<Departman, OnlineOtomasyonContext>, IDepartmanDal
    {
        public Departman Get(Expression<Func<Departman, bool>> filter)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return context.Departman.Include(c => c.Personeller).SingleOrDefault(filter);
            }
        }

        public List<Departman> List(Expression<Func<Departman, bool>> filter = null)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return filter == null ? context.Departman.Include(c => c.Personeller).ToList() : context.Departman.Include(c => c.Personeller).Where(filter).ToList();
            }
        }
    }
}
