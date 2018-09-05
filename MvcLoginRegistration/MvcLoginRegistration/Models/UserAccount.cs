using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;

namespace MvcLoginRegistration.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
       [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
ErrorMessage = "Please enter correct email address")]
    public string Email { get; set; }
        [Required(ErrorMessage ="username is required.")]
        public string Username { get; set; }
       [Required(ErrorMessage ="password is required.")]
       [DataType(DataType.Password)]
        public string Password { get; set; }
    [Compare("Password",ErrorMessage ="Please confirm your password.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
        public string Role { get; set; }

    }
}