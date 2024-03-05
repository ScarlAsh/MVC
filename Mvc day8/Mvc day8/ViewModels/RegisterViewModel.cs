using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Mvc_day8.ViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password" , ErrorMessage = "Password mismatch , try again")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "you must enter your username")]
        public string Username {  get; set; }


    }
}
