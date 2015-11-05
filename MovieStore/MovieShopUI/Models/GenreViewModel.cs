using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopUI.Models
{
    public class GenreViewModel
    {
        public MovieShopDAL.Genres Genre { get; set; }
        public List<MovieShopDAL.Movie> MovieList { get; set; }

    }
}