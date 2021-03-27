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
    public class MusteriDal : EntityRepositoryBase<Musteri, OnlineOtomasyonContext>, IMusteriDal
    {
        public Musteri Get(Expression<Func<Musteri, bool>> filter)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return context.Musteri.Include(c => c.Faturalar).Include(c => c.SatisHareketleri).SingleOrDefault(filter);
            }
        }

        public List<Musteri> List(Expression<Func<Musteri, bool>> filter = null)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return filter == null ? context.Musteri.Include(c=>c.Faturalar).Include(c=>c.SatisHareketleri).ToList() : context.Musteri.Where(filter).Include(c => c.Faturalar).Include(c => c.SatisHareketleri).ToList();
            }
        }
    }
}
