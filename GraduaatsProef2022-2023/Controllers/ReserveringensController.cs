using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GraduaatsProef2022_2023.Data;
using GraduaatsProef2022_2023.Models;

namespace GraduaatsProef2022_2023.Views.Reservations
{
    public class ReserveringensController : Controller
    {
        private readonly GraduaatsProefDbContext _context;

        public ReserveringensController(GraduaatsProefDbContext context)
        {
            _context = context;
        }

        // GET: Reserveringens

        public async Task<IActionResult> Testing()
        {
            return View();
        }
        public async Task<IActionResult> TestAuthomation()
        {
            return View();
        }
        public async Task<IActionResult> SecurityTesting()
        {
            return View();
        }
        public async Task<IActionResult> FlexTesting()
        {
            return View();
        }
        public async Task<IActionResult> PerformanceTesting()
        {
            return View();
        }
        public async Task<IActionResult> ScalabilityTesting()
        {
            return View();
        }
    }
}
