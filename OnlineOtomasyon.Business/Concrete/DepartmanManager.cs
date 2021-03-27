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
    public class DepartmanManager:ServiceRepository<Departman,IDepartmanDal,DepartmanValidator>,IDepartmanService
    {
        public DepartmanManager(IDepartmanDal x,DepartmanValidator y):base(x,y)
        {

        }
    }
}
