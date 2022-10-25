using ApiProdutos.Domain.Contracts.Repositories;
using ApiProdutos.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        public virtual void Create(TEntity entity)
        {
            using (var context = new SqlServerContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var context = new SqlServerContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using (var context = new SqlServerContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public virtual List<TEntity> GetAll()
        {
            using (var context = new SqlServerContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public virtual TEntity? Get(Guid id)
        {
            using (var context = new SqlServerContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }
    }
}
