using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using InternProj.Domain;

namespace InternProj.Db.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Find(int id);

        T Find(Expression<Func<T, bool>> predicate);

        IList<T> FindAll(Expression<Func<T, bool>> predicate);
        IList<T> GetAll();

        void Delete(T entity);

        void Add(T entity);

        T Update(T entity);



        void Save();
    }
}
