using Cinema.ApplicationLogic.Abstractions;
using Cinema.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.DataAccess.Repositories
{
    public class EFBaseRepository<T> : IBaseRepository<T> where T : DataEntity
    {
        protected readonly CinemaDbContext dbContext;

        public EFBaseRepository(CinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Add(T entity)
        {
            this.dbContext.Add<T>(entity);
            this.dbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbContext.Set<T>();
        }

        public T GetById(Guid id)
        {
            return this.dbContext.Set<T>().Where(entity => entity.Id == id).SingleOrDefault();
        }

        public bool Remove(Guid id)
        {
            var entityToRemove = GetById(id);
            if (entityToRemove == null) return false;
            this.dbContext.Remove<T>(entityToRemove);
            this.dbContext.SaveChanges();
            return true;
        }

        public T Update(T entity)
        {
            this.dbContext.Update<T>(entity);
            this.dbContext.SaveChanges();
            return entity;
        }
    }
}
