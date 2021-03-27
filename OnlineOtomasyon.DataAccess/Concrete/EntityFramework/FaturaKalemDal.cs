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
    public class FaturaKalemDal : EntityRepositoryBase<FaturaKalem, OnlineOtomasyonContext>, IFaturaKalemDal
    {
        public FaturaKalem Get(Expression<Func<FaturaKalem, bool>> filter)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return context.FaturaKalem.Include(c => c.Urun).Include(c => c.Fatura).SingleOrDefault(filter);
            }
        }

        public List<FaturaKalem> List(Expression<Func<FaturaKalem, bool>> filter = null)
        {
            using (OnlineOtomasyonContext context = new OnlineOtomasyonContext())
            {
                return filter == null ? context.FaturaKalem.Include(c => c.Urun).Include(c => c.Fatura).ToList() : context.FaturaKalem.Include(c => c.Urun).Include(c => c.Fatura).Where(filter).ToList();
            }
        }
    }
}
