using System;
using System.ComponentModel.DataAnnotations;

namespace Covid_19_Tracker.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set;}
        [Required]
        public string Role { get; set; }
    }
}
