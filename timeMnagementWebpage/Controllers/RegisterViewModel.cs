using System.ComponentModel.DataAnnotations;

namespace timeMnagementWebpage.Controllers
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; } // First Name

        [Required]
        public string Surname { get; set; } // Last Name

        [Required]
        public string StudentNumber { get; set; } // Student Number

        [Required]
        public string UserName { get; set; } // Username for login

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}