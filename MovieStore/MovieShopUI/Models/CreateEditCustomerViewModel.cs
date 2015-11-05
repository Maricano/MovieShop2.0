using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieShopUI.Models
{
    public class CreateEditCustomerViewModel
    {
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
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Den indtastede email matcher ikke")]
        [Display(Name ="Confirm Email")]
        [Compare("Email")]

        public string ConfirmEmail { get; set; }
    }
}