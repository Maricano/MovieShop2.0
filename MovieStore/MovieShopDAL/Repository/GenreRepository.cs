using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repository
{
    public class GenreRepository : ICrudRepository<Genres>
    {
        public void Create(Genres Genre)
        {
            using (var Context = new ContextMovieStore())
            {
                Context.Set<Genres>().Add(Genre);
                Context.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (var Context = new ContextMovieStore())
            {
                Genres Genre = Context.Set<Genres>().Where(g => g.GenreId == Id).FirstOrDefault();
                if (Genre != null)
                {
                    Context.Set<Genres>().Remove(Genre);
                }
                Context.SaveChanges();
            }
        }

        public Genres Read(int Id)
        {
            Genres Genre = null;
            using (var Context = new ContextMovieStore())
            {
                Genre = Context.Set<Genres>().Where(g => g.GenreId == Id).FirstOrDefault();
                if (Genre != null)
                {
                    return Genre;
                }
                else
                {
                    throw new Exception("There is no genre with this ID ");
                }
            }
        }

        public List<Genres> ReadAll()
        {
            using (var Context = new ContextMovieStore())
            {
                List<Genres> GenreList = Context.Set<Genres>().ToList();
                return GenreList;
            }
        }

        public void Update(Genres genre)
        {
            using (var Context = new ContextMovieStore())
            {
                Genres Genres = Context.Set<Genres>().Where(g => g.GenreId == genre.GenreId).FirstOrDefault();
                if (Genres != null)
                {
                    Genres.Genre = genre.Genre;
                   
                }
                Context.SaveChanges();
            }
        }
    }
}
