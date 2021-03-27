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
    public class UrunDal : EntityRepositoryBase<Urun, OnlineOtomasyonContext>, IUrunDal
    {
        public Urun Get(Expression<Func<Urun, bool>> filter)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return context.Urun.Include(c => c.Kategori).Include(c => c.FaturaKalemler).Include(c => c.SatisHareketleri).SingleOrDefault(filter);
            }
        }

        public List<Urun> List(Expression<Func<Urun, bool>> filter = null)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return filter == null ? context.Urun.Include(c => c.Kategori).Include(c => c.FaturaKalemler).Include(c => c.SatisHareketleri).ToList() : context.Urun.Include(c => c.Kategori).Include(c => c.FaturaKalemler).Include(c => c.SatisHareketleri).Where(filter).ToList();
            }
        }
    }
}
