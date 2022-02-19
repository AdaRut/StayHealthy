using Microsoft.EntityFrameworkCore;
using stayHealthy.DataAccess.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.DataAccess.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected StayHealthyContext StayHealthyContext { get; set; }

        public RepositoryBase(StayHealthyContext stayHealthyContext)
        {
            StayHealthyContext = stayHealthyContext;
        }

        public void Add(T entity)
        {
            StayHealthyContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            StayHealthyContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await StayHealthyContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await StayHealthyContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return (await StayHealthyContext.Set<T>().FindAsync(id)) != null;
        }

        public async Task SaveChangesAsync()
        {
            await StayHealthyContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            StayHealthyContext.Set<T>().Update(entity);
        }
    }
}
