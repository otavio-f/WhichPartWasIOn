using System.Collections.Generic;
using WhichPartWasIOn.Interface;
using WhichPartWasIOn.Model.Readable;
using System.Linq;

namespace WhichPartWasIOn.Repository
{
    public class BookRepository : IRepository<Book>
    {
        private HashSet<Book> BookBase = new HashSet<Book>();

        public void Delete(long id)
        {
            var item = BookBase.First(i => i.Id == id);
            BookBase.Remove(item);
        }

        public long FindNextId()
        {
            uint id = 1;
            while(true)
            {
                if (BookBase.FirstOrDefault(i => i.Id == id) == null)
                    return id;
                id++;
            }
        }

        public List<Book> GetAll() => BookBase.OrderBy(o => o.Id).ToList();

        public Book GetById(long id) => BookBase.First(i => i.Id == id);

        public void Insert(Book entity)
        {
            entity.Id = FindNextId();
            BookBase.Add(entity);
        }

        public void Update(Book entity)
        {
            Delete(entity.Id);
            BookBase.Add(entity);
        }
    }
}
