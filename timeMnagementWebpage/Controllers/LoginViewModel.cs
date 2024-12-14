using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace timeMnagementWebpage.Controllers
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; } // Username for login

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}