using Canteen_Management_System.Core.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_Management_System.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        protected AppDBContext context;
        internal DbSet<T> dbSet;

        public Repository(AppDBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();

        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual bool Delete(int id)
        {
            var entity = dbSet.Find(id);
            if (entity == null)
                return false;
            else
            {
                dbSet.Remove(entity);
                return true;
            }
        }

        public virtual bool Update(T entity)
        {
            dbSet.Update(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }
    }
}
