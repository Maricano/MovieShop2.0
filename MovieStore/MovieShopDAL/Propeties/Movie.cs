using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL
{
    public class Movie
    {
        public Movie()
        {
            Genres = new List<Genres>();
            ShoppingCartItems = new List<ShoppingCartItem>();
        }

        [Key]
        public int MovieId { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public string Title { get; set; }

        [Display(Name = "Udgivelses dato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public string TrailerURL { get; set; }

        public virtual ICollection<Genres> Genres { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }


    }
}
