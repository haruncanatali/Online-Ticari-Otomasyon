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
    public class FaturaManager:ServiceRepository<Fatura,IFaturaDal,FaturaValidator>,IFaturaService
    {
        public FaturaManager(IFaturaDal x, FaturaValidator y) :base(x,y)
        {

        }
    }
}
