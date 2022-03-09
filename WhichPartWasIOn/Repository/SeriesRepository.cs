using System.Collections.Generic;
using WhichPartWasIOn.Interface;
using WhichPartWasIOn.Model.Watchable;
using System.Linq;

namespace WhichPartWasIOn.Repository
{
    public class SeriesRepository : IRepository<Series>
    {
        private HashSet<Series> SeriesBase = new HashSet<Series>();

        public void Delete(long id)
        {
            var item = SeriesBase.First(i => i.Id == id);
            SeriesBase.Remove(item);
        }

        public long FindNextId()
        {
            uint id = 1;
            while(true)
            {
                if (SeriesBase.FirstOrDefault(i => i.Id == id) == null)
                    return id;
                id++;
            }
        }

        public List<Series> GetAll() => SeriesBase.OrderBy(o => o.Id).ToList();

        public Series GetById(long id) => SeriesBase.First(i => i.Id == id);

        public void Insert(Series entity)
        {
            entity.Id = FindNextId();
            SeriesBase.Add(entity);
        }

        public void Update(Series entity)
        {
            Delete(entity.Id);
            SeriesBase.Add(entity);
        }
    }
}
