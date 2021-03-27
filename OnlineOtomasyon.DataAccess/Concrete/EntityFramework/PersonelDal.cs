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
    public class PersonelDal : EntityRepositoryBase<Personel, OnlineOtomasyonContext>, IPersonelDal
    {
        public Personel Get(Expression<Func<Personel, bool>> filter)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return context.Personel.Include(c => c.Departman).Include(c => c.Faturalar).Include(c => c.SatisHareketleri).SingleOrDefault(filter);
            }
        }

        public List<Personel> List(Expression<Func<Personel, bool>> filter = null)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return filter == null ? context.Personel.Include(c => c.Departman).Include(c => c.Faturalar).Include(c => c.SatisHareketleri).ToList() : context.Personel.Include(c => c.Departman).Include(c => c.Faturalar).Include(c => c.SatisHareketleri).Where(filter).ToList();
            }
        }
    }
}
