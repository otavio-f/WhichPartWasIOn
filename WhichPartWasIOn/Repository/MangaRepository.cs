using System.Collections.Generic;
using WhichPartWasIOn.Interface;
using WhichPartWasIOn.Model.Readable;
using System.Linq;

namespace WhichPartWasIOn.Repository
{
    public class MangaRepository : IRepository<Manga>
    {
        private HashSet<Manga> MangaBase = new HashSet<Manga>();

        public void Delete(long id)
        {
            var item = MangaBase.First(i => i.Id == id);
            MangaBase.Remove(item);
        }

        public long FindNextId()
        {
            uint id = 1;
            while(true)
            {
                if (MangaBase.FirstOrDefault(i => i.Id == id) == null)
                    return id;
                id++;
            }
        }

        public List<Manga> GetAll() => MangaBase.OrderBy(o => o.Id).ToList();

        public Manga GetById(long id) => MangaBase.First(i => i.Id == id);

        public void Insert(Manga entity)
        {
            entity.Id = FindNextId();
            MangaBase.Add(entity);
        }

        public void Update(Manga entity)
        {
            Delete(entity.Id);
            MangaBase.Add(entity);
        }
    }
}
