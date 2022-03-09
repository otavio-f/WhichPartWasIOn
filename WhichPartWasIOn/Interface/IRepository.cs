using System.Collections.Generic;

namespace WhichPartWasIOn.Interface
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(long id);
        void Insert(T entity);
        void Delete(long id);
        void Update(T entity);
        long FindNextId();
    }
}
