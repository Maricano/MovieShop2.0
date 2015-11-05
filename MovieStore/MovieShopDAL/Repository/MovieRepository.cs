using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL.Repository
{
    public class MovieRepository : ICrudRepository<Movie>,IManyToMany,IGenreSearch<Movie>
    {
        public void AddManytoMany(int genreId, int movieId)
        {
            using (var context = new ContextMovieStore())
            {
                Genres genre = context.Set<Genres>().Where(g => g.GenreId == genreId).FirstOrDefault();
                Movie movie = context.Set<Movie>().Where(m => m.MovieId == movieId).FirstOrDefault();
                if (genre != null && movie != null)
                {
                    genre.Movies.Add(null);
                }
                context.SaveChanges();
            }
        }

        public void Create(Movie NewMovie)
        {
            using (var Context = new ContextMovieStore())
            {
                Context.Set<Movie>().Add(NewMovie);

                List<Genres> Genre = NewMovie.Genres.ToList();
                NewMovie.Genres.Clear();
                foreach (Genres genre in Genre)
                {
                    NewMovie.Genres.Add(Context.Genre.Single(g => g.GenreId == genre.GenreId));
                }

                Context.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (var Context = new ContextMovieStore())
            {
                Movie Movie = Context.Set<Movie>().Where(m => m.MovieId == Id).FirstOrDefault();
                if(Movie != null)
                {
                    Context.Set<Movie>().Remove(Movie);
                }
                Context.SaveChanges();
            }
        }

        public void DeleteManyToMany(int genreId, int movieId)
        {
            using (var context = new ContextMovieStore())
            {
                Genres genre = context.Set<Genres>().Where(g => g.GenreId == genreId).FirstOrDefault();
                Movie movie = context.Set<Movie>().Where(m => m.MovieId == movieId).FirstOrDefault();
                if (genre != null && movie != null)
                {
                    genre.Movies.Remove(null);
                }
                context.SaveChanges();
            }
        }

        public Movie Read(int Id)
        {
            Movie Movie = null;
            using (var Context = new ContextMovieStore())
            {
                Movie = Context.Movie.Include(m => m.Genres).Where(m => m.MovieId == Id).FirstOrDefault();
                if(Movie != null)
                {
                    return Movie;
                }
                else
                {
                    throw new Exception("There is no movie with this ID ");
                }
            }
        }

        public List<Movie> ReadAll()
        {
            using (var Context = new ContextMovieStore())
            {
                List<Movie> MovieList = Context.Set<Movie>().ToList();
                return MovieList;
            }
        }

        public List<Movie> search(int value)
        {
            using (var Context = new ContextMovieStore())
            {
                Genres genre = Context.Genre.SingleOrDefault(g => g.GenreId == value);
                return Context.Movie.Include(m => m.Genres).Where(m => m.Genres.Select(g => g.GenreId).Contains(genre.GenreId)).ToList();


            }
        }

        public void Update(Movie NewMovie)
        {
            using (var Context = new ContextMovieStore())
            {
                Movie Movie = Context.Set<Movie>().Where(m => m.MovieId == NewMovie.MovieId).FirstOrDefault();
                if(Movie != null)
                {
                    Movie.Price = NewMovie.Price;
                    Movie.Title = NewMovie.Title;
                    Movie.ReleaseDate = NewMovie.ReleaseDate;
                    Movie.TrailerURL = NewMovie.TrailerURL;
                    Movie.ImageURL = NewMovie.ImageURL;
                    
                    Movie.Genres.Clear();
                    foreach (Genres item in NewMovie.Genres)
                    {
                        Movie.Genres.Add(Context.Genre.Single(g => g.GenreId == item.GenreId));
                    }
                }
                Context.SaveChanges();
            }
        }
    }
}
