using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class MvcDataModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("[a-zA-Z ]*$", ErrorMessage = "Invalid Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter valid Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*).{8,15}$", ErrorMessage = "Make strong password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Mobile number is required")]
        [MinLength(10,ErrorMessage ="invalid number"), MaxLength(10, ErrorMessage = "invalid number")]
        public string Mobile { get; set; }
    }
}