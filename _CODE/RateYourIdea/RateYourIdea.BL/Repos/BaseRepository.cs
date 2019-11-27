using RateYourIdea.Core.BaseModels;
using RateYourIdea.Core.Session;
using RateYourIdea.Entity.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RateYourIdea.BL.Repos
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseModel, IEntity
    {
        private DBContext dataContext;
        private readonly IDbSet<T> dbSet;
        UserInfo userInfo;

        protected BaseRepository(DBContext context)
        {
            dataContext = context;
            dbSet = dataContext.Set<T>();
            userInfo = new SessionBusiness().GetSessionUser();
        }

        public T Add(T entity)
        {
            entity.CreateDate = DateTime.Now;
            //entity.CreateUserID = userInfo.ID;
            dbSet.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            entity.UpdateDate = DateTime.Now;
            //entity.UpdateUserID = userInfo.ID;
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual T Delete(T entity)
        {
            entity.IsDeleted = true;
            entity = Update(entity);
            return entity;
            //dbSet.Remove(entity);
        }

        //public virtual void Delete(Expression<Func<T, bool>> where)
        //{
        //    IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
        //    foreach (T obj in objects)
        //        dbSet.Remove(obj);
        //}

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.Where(x => x.IsDeleted == false).ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).Where(x => x.IsDeleted == false).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }
    }
}
