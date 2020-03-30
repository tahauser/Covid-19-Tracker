using System;
using System.ComponentModel.DataAnnotations;

namespace Covid_19_Tracker.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
