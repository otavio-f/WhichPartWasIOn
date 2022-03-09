using System.Collections.Generic;
using WhichPartWasIOn.Interface;
using WhichPartWasIOn.Model.Readable;
using System.Linq;

namespace WhichPartWasIOn.Repository
{
    public class ComicRepository : IRepository<Comic>
    {
        private HashSet<Comic> ComicBase = new HashSet<Comic>();

        public void Delete(long id)
        {
            var item = ComicBase.First(i => i.Id == id);
            ComicBase.Remove(item);
        }

        public long FindNextId()
        {
            uint id = 1;
            while(true)
            {
                if (ComicBase.FirstOrDefault(i => i.Id == id) == null)
                    return id;
                id++;
            }
        }

        public List<Comic> GetAll() => ComicBase.OrderBy(o => o.Id).ToList();

        public Comic GetById(long id) => ComicBase.First(i => i.Id == id);

        public void Insert(Comic entity)
        {
            entity.Id = FindNextId();
            ComicBase.Add(entity);
        }

        public void Update(Comic entity)
        {
            Delete(entity.Id);
            ComicBase.Add(entity);
        }
    }
}
