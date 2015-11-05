using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL
{
    public class Genres
    {
        [Key]
        public int GenreId { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public override string ToString()
        {
            return Genre;
        }

        public override bool Equals(object obj)
        {
            Genres temp = (Genres)obj;
            if (temp.GenreId == GenreId)
            {
                return true;
            }
            return false;
        }
    }
}
