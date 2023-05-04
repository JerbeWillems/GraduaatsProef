using GraduaatsProef2022_2023.Data;
using GraduaatsProef2022_2023.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GraduaatsProef2022_2023.Controllers
{
    public class HomeController : Controller
    {
        private readonly GraduaatsProefDbContext _db;
        public HomeController(GraduaatsProefDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Onderwerpen.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}