using System.Collections.Generic;
using WhichPartWasIOn.Interface;
using WhichPartWasIOn.Model.Watchable;
using System.Linq;

namespace WhichPartWasIOn.Repository
{
    public class AnimeRepository : IRepository<Anime>
    {
        private HashSet<Anime> AnimeBase = new HashSet<Anime>();

        public void Delete(long id)
        {
            var item = AnimeBase.First(i => i.Id == id);
            AnimeBase.Remove(item);
        }

        public long FindNextId()
        {
            uint id = 1;
            while(true)
            {
                if (AnimeBase.FirstOrDefault(i => i.Id == id) == null)
                    return id;
                id++;
            }
        }

        public List<Anime> GetAll() => AnimeBase.OrderBy(o => o.Id).ToList();

        public Anime GetById(long id) => AnimeBase.First(i => i.Id == id);

        public void Insert(Anime entity)
        {
            entity.Id = FindNextId();
            AnimeBase.Add(entity);
        }

        public void Update(Anime entity)
        {
            Delete(entity.Id);
            AnimeBase.Add(entity);
        }
    }
}
