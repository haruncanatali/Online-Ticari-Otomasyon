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
    public class KategoriDal : EntityRepositoryBase<Kategori, OnlineOtomasyonContext>, IKategoriDal
    {
        public Kategori Get(Expression<Func<Kategori, bool>> filter)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return context.Kategori.Include(c => c.Urunler).SingleOrDefault(filter);
            }
        }

        public List<Kategori> List(Expression<Func<Kategori, bool>> filter = null)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return filter == null ? context.Kategori.Include(c => c.Urunler).ToList() : context.Kategori.Include(c => c.Urunler).Where(filter).ToList();
            }
        }
    }
}
