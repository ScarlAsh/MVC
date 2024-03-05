using System.ComponentModel.DataAnnotations;

namespace Mvc_day8.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
