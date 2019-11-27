using RateYourIdea.Core.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RateYourIdea.BL.Repos
{
    public interface IBaseRepository<T> where T : BaseModel, IEntity
    {
        T Add(T entity);

        T Update(T entity);

        T Delete(T entity);

        //void Delete(Expression<Func<T, bool>> where);

        T GetById(int id);

        T Get(Expression<Func<T, bool>> where);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
