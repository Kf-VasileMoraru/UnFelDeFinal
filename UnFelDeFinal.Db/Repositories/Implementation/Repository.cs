using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using InternProj.Db;
using InternProj.Domain;
using InternProj.Db.Repositories.Interfaces;
using System.Collections.Generic;

namespace InternProj.Db.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly EServicesDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(EServicesDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public T Find(int id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IList<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> data = _dbSet.Where(predicate);
            return data.ToList();
        }

        public IList<T> GetAll()
        {
            IQueryable<T> data = _dbSet;

            return data.ToList();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        public T Update(T entity)
        {
            T t = _dbSet.Update(entity).Entity;
            Save();
            return t;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}
