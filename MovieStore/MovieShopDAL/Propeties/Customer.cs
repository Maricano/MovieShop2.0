using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDAL
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name ="Fornavn")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Efternavn")]
        public string LastName { get; set; }
        [Required]
        [Display(Name ="Adresse")]
        public string StreetName { get; set; }
        [Required]
        [Display(Name ="Husnummer")]
        public string HouseNumber { get; set; }
        [Required]
        [Display(Name ="Postnummer")]
        public int Zipcode { get; set; }
        [Required]
        [Display(Name ="Land")]
        public string Country { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

    }
}
