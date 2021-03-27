using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.DataAccess.Abstract
{
    public interface IUrunDal:IEntityRepository<Urun>,IGetEntitiesOrEntity<Urun>
    {
    }
}
