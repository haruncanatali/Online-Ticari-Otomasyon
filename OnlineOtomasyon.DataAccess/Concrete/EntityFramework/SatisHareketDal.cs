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
    public class SatisHareketDal : EntityRepositoryBase<SatisHareket, OnlineOtomasyonContext>, ISatisHareketDal
    {
        public SatisHareket Get(Expression<Func<SatisHareket, bool>> filter)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return context.SatisHareket.Include(c => c.Urun).Include(c => c.Musteri).Include(c => c.Personel).SingleOrDefault(filter);
            }
        }

        public List<SatisHareket> List(Expression<Func<SatisHareket, bool>> filter = null)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return filter == null ? context.SatisHareket.Include(c => c.Urun).Include(c => c.Musteri).Include(c => c.Personel).ToList() : context.SatisHareket.Include(c => c.Urun).Include(c => c.Musteri).Include(c => c.Personel).Where(filter).ToList();
            }
        }
    }
}
