using System.Collections.Generic;
using WhichPartWasIOn.Interface;
using WhichPartWasIOn.Model.Watchable;
using System.Linq;

namespace WhichPartWasIOn.Repository
{
    public class MovieRepository : IRepository<Movie>
    {
        private HashSet<Movie> MovieBase = new HashSet<Movie>();

        public void Delete(long id)
        {
            var item = MovieBase.First(i => i.Id == id);
            MovieBase.Remove(item);
        }

        public long FindNextId()
        {
            uint id = 1;
            while(true)
            {
                if (MovieBase.FirstOrDefault(i => i.Id == id) == null)
                    return id;
                id++;
            }
        }

        public List<Movie> GetAll() => MovieBase.OrderBy(o => o.Id).ToList();

        public Movie GetById(long id) => MovieBase.First(i => i.Id == id);

        public void Insert(Movie entity)
        {
            entity.Id = FindNextId();
            MovieBase.Add(entity);
        }

        public void Update(Movie entity)
        {
            Delete(entity.Id);
            MovieBase.Add(entity);
        }
    }
}
