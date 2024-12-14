using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using timeMnagementWebpage.Models; // Replace with the namespace containing RegisterViewModel and LoginViewModel

namespace timeMnagementWebpage.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        // Constructor for dependency injection
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Display the register page
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Handle form submission for registration
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Return the view with validation errors
            }

            var user = new IdentityUser
            {
                UserName = model.UserName // Identity uses UserName for login
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false); // Automatically log in the user
                return RedirectToAction("Index", "Home"); // Redirect to the home page
            }

            // Add error messages to the model state
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model); // Return the view with errors if registration fails
        }

        // GET: Display the login page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Handle login form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Return the view with validation errors
            }

            var result = await _signInManager.PasswordSignInAsync(
                model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home"); // Redirect to the home page
            }

            // Add error messages for invalid login attempts
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

        // POST: Handle user logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account"); // Redirect to the login page after logout
        }
    }
}
