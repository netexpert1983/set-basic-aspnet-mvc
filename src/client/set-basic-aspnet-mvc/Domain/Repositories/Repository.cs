using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using set_basic_aspnet_mvc.Domain.Entities;

namespace set_basic_aspnet_mvc.Domain.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> 
           where TEntity : BaseEntity
    {
        private IDbContext Context;

        public IDbSet<TEntity> Entities
        {
            get { return this.Context.Set<TEntity>(); }
        }

        public IDbContext GetContext()
        {
            return Context;
        }

        public Repository(IDbContext context)
        {
            this.Context = context;
        }

        public TEntity Create(TEntity entity)
        {
            Entities.Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            return entity;
        }

        public void SoftDelete(long id, int deletedBy)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(System.Linq.Expressions.Expression<Func<TEntity, bool>> where, int deletedBy)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            Entities.Remove(this.FindOne(x => x.Id == id));
        }

        public void Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }
       
        public TEntity FindOne(System.Linq.Expressions.Expression<Func<TEntity, bool>> where = null, params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Entities.Where(where).FirstOrDefault();
        }

        public IQueryable<TEntity> FindAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> where = null, params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Entities.AsQueryable();
        }

        public IQueryable<TEntity> AsQueryable(IQueryable<TEntity> existing, System.Linq.Expressions.Expression<Func<TEntity, bool>> where = null)
        {
            return Entities.AsQueryable();
        }

        public bool SaveChanges()
        {
            return this.Context.SaveChanges()>0;
        }
    }
}