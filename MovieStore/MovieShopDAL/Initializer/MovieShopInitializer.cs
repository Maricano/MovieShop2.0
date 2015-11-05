using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieShopDAL.Initializer
{
    class MovieShopInitializer : DropCreateDatabaseAlways<ContextMovieStore>
    {

        private Genres _action = new Genres { GenreId = 1, Genre = "Action" };
        private Genres _adventure = new Genres { GenreId = 2, Genre = "Adventure" };
        private Genres _scifi = new Genres { GenreId = 3, Genre = "Sci-Fi" };
        private List<Genres> genres = new List<Genres>();
      
        private List<Movie> MovieList = new List<Movie>();

        protected override void Seed(ContextMovieStore context)
        {
            genres.Add(_action);
            genres.Add(_adventure);
            genres.Add(_scifi);

            Movie myMovie = new Movie
            {
                Genres = genres,
                MovieId = 1,
                Price = 200,
                Title = "The Martian",
                ImageURL = "http://ia.media-imdb.com/images/M/MV5BMTc2MTQ3MDA1Nl5BMl5BanBnXkFtZTgwODA3OTI4NjE@._V1_SY317_CR0,0,214,317_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/ej3ioOneTy8",
                ReleaseDate = DateTime.Today
            };

            Movie myMovie2 = new Movie
            {
                Genres = genres,
                MovieId = 1,
                Price = 200,
                Title = "Maybe Tomorrow",
                ImageURL = "http://ia.media-imdb.com/images/M/MV5BMTc2MTQ3MDA1Nl5BMl5BanBnXkFtZTgwODA3OTI4NjE@._V1_SY317_CR0,0,214,317_AL_.jpg",
                TrailerURL = "https://www.youtube.com/embed/ej3ioOneTy8",
                ReleaseDate = DateTime.Today
            };

            MovieList.Add(myMovie);
            MovieList.Add(myMovie2);

            Customer customer = new Customer
            {
                CustomerId = 1,
                Email = "kenneth_fallesen@hotmail.om",
                FirstName = "Kenneth Fallesen",
                LastName = "Jørgensen",
                StreetName = "Stormgade",
                HouseNumber = "23 3 th",
                Zipcode = 6700,
                Country = "DK",
            };

            Customer customer2 = new Customer
            {
                CustomerId = 2,
                Email = "sivane@live.dk",
                FirstName = "Frederik",
                LastName = "Sørensen",
                StreetName = "Jyllandsgade",
                HouseNumber = "29 3 ",
                Zipcode = 6700,
                Country = "DK",
            };

            Customer customer3 = new Customer
            {
                CustomerId = 3,
                Email = "jonasdanpedersen@gmail.com",
                FirstName = "Jonas",
                LastName = "Pedersen",
                StreetName = "Skovkanten",
                HouseNumber = "2C 2TH",
                Zipcode = 6700,
                Country = "DK",
            };

            Orders order = new Orders
            {
                Customer = customer3,
                //OrderId = 1,
                OrderTime = DateTime.Now,
                ShoppingCartItems = new List<ShoppingCartItem>()
                {
                    new ShoppingCartItem()
                    {
                        Movie = myMovie,
                        Quantity = 1
                    }
                }
            };

            context.Genre.Add(_action);
            context.Genre.Add(_adventure);
            context.Genre.Add(_scifi);
            context.Movie.Add(myMovie);
            context.Movie.Add(myMovie2);
            context.Customer.Add(customer);
            context.Customer.Add(customer2);
            context.Customer.Add(customer3);
            context.Order.Add(order);
            base.Seed(context);
        }
    }
}
