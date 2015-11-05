using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopUI.Models
{
    public class MovieViewModel
    {
        public MovieShopDAL.Movie Movie { get; set; }
        public List<MovieShopDAL.Genres> GenreList { get; set; }
    }
}