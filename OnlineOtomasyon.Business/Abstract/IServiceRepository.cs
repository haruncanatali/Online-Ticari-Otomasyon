using OnlineOtomasyon.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.Abstract
{
    public interface IServiceRepository<TEntity> where TEntity:class,IEntity,new()
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        List<TEntity> List(Expression<Func<TEntity, bool>> filter);
    }
}
