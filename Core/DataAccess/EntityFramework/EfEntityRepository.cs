using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, Ient, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity Entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(Entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
            Console.WriteLine(Entity);
        }

        public void Delete(TEntity Entity)
        {
            using (TContext context = new TContext())
            {
                var DeletedEntity = context.Entry(Entity);
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                if (filter != null)
                {
                    return context.Set<TEntity>().Where(filter).ToList();
                }
                else
                {
                    return context.Set<TEntity>().ToList();
                }
            }
        }

        public void Update(TEntity Entity, string name)
        {
            using (TContext context = new TContext())
            {
                var UptadedEntity = context.Entry(Entity);
                UptadedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
