using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Models.ModelsView
{
    public class NewUser
    {

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Hasło musi składać się z conajmniej {2} i maksymalnie {1} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Hasła nie poasjuą do siebie")]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }

        public GastronomicVenue GastronomicVenue {get;set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Musisz zaakceptować regulamin")]
        [Display(Name = "Regimen")]
        public bool Regimen { get; set; } 
    }
}
