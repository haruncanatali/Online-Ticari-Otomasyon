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
    public class FaturaDal : EntityRepositoryBase<Fatura, OnlineOtomasyonContext>, IFaturaDal
    {
        public Fatura Get(Expression<Func<Fatura, bool>> filter)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return context.Fatura.Include(c => c.Personel).Include(c => c.Musteri).Include(c => c.FaturaKalemler).SingleOrDefault(filter);
            }
        }

        public List<Fatura> List(Expression<Func<Fatura, bool>> filter = null)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return filter == null ? context.Fatura.Include(c => c.Personel).Include(c => c.Musteri).Include(c => c.FaturaKalemler).ToList() : context.Fatura.Include(c => c.Personel).Include(c => c.Musteri).Include(c => c.FaturaKalemler).Where(filter).ToList();
            }
        }
    }
}
