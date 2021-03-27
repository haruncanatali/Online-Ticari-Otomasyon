using OnlineOtomasyon.Business.Abstract;
using OnlineOtomasyon.Business.FluentValidation;
using OnlineOtomasyon.DataAccess.Abstract;
using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.Concrete
{
    public class KategoriManager:ServiceRepository<Kategori,IKategoriDal,KategoriValidator>,IKategoriService
    {
        public KategoriManager(IKategoriDal x, KategoriValidator y) :base(x,y)
        {

        }
    }
}
