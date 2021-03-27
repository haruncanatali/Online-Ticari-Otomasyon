using FluentValidation;
using OnlineOtomasyon.Business.Abstract;
using OnlineOtomasyon.Business.FluentValidation;
using OnlineOtomasyon.DataAccess.Abstract;
using OnlineOtomasyon.DataAccess.Concrete.EntityFramework;
using OnlineOtomasyon.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Business.Concrete
{
    public class ServiceRepository<TEntity, TDal,TValidator> : IServiceRepository<TEntity> where TEntity : class, IEntity, new() where TDal : IEntityRepository<TEntity>,IGetEntitiesOrEntity<TEntity> where TValidator:IValidator
    {

        TDal dal;
        TValidator validator;

        public ServiceRepository(TDal x,TValidator y)
        {
            this.dal = x;
            this.validator = y;
        }

        public void Add(TEntity entity)
        {
            ValidationTool.Validate(validator, entity);
            dal.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            dal.Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return dal.Get(filter);
        }

        public List<TEntity> List(Expression<Func<TEntity, bool>> filter)
        {
            return dal.List(filter);
        }

        public void Update(TEntity entity)
        {
            ValidationTool.Validate(validator, entity);
            dal.Update(entity);
        }
    }
}
