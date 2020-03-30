using System;
using System.ComponentModel.DataAnnotations;

namespace Covid_19_Tracker.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,15}$", ErrorMessage = "Le mot de passe doit être entre 6 et 15 caractères.\n Doit contenir au moins 1 chiffre, 1 lettre miniscule et une lettre majuscule.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Les deux mots de passes ne sont pas identique.")]
        public string ConfirmPassword { get; set;}
        [Required]
        public string Role { get; set; }
    }
}
