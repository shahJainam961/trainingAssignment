using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Register.Models
{
    public class Student
    {
        
        [Required(ErrorMessage ="UserName is mandatory")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }


        [RegularExpression(".+@.+\\..+", ErrorMessage = "Email Format is Invalid")]
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage ="Confirm Password and Password should be same")]
        public string ConfirmPassword { get; set; }

        [Range(10,21)]
        [Required]
        public int Age { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [Display(Name= "Agree To Terms & Conditions")]
        [ValidateTNC(ErrorMessage =  "You must agree to Terms & Conditions to proceed")]
        public bool Agree { get; set;}
        public class ValidateTNC : RequiredAttribute
        {
            public override bool IsValid(object value)
            {
                return (bool)value;
            }
        }


    }
}