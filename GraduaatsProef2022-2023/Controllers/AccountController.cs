using GraduaatsProef2022_2023.Data;
using GraduaatsProef2022_2023.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace GraduaatsProef2022_2023.Controllers
{
    public class AccountController : Controller
    {
        private GraduaatsProefDbContext _context;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<IdentityUser> _signInManager;

        public AccountController(GraduaatsProefDbContext dbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _context = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            IdentityUser user = new IdentityUser()
            {
                UserName = account.Email,
                Email = account.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(user, account.Password);

            if (!result.Succeeded)
            {
                ViewData["Error"] = result.Errors.First().Description;
                return View(account);
            }

            Account gebruiker = new Account()
            {
                Email = account.Email,
                Password = account.Password,
            };
            _context.Add(gebruiker);
            _context.SaveChanges();

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(account.Email, account.Password, true, false);
            if (!result.Succeeded)
            {
                ViewData["Error"] = "Email of paswoord was incorrect!";
                return View(account);
            }

            return RedirectToAction("Index", "Website");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
