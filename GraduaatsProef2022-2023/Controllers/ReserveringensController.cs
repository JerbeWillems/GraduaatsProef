using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GraduaatsProef2022_2023.Data;
using GraduaatsProef2022_2023.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using GraduaatsProef2022_2023.Models.ViewModel;

namespace GraduaatsProef2022_2023.Views.Reservations
{
    public class ReserveringensController : Controller
    {
        private readonly GraduaatsProefDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReserveringensController(GraduaatsProefDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reserveringens
        public async Task<IActionResult> Index()
        {
            return _context.Reserveringen != null ?
                        View(await _context.Reserveringen.ToListAsync()) :
                        Problem("Entity set 'GraduaatsProefDbContext.Reserveringen'  is null.");
        }
        public async Task<IActionResult> ShowUserIndex(int id)
        {
            
            IdentityUser user = await _userManager.GetUserAsync(User);
            Account? account = await _context.Account.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (account != null)
            {
                if (id != 0)
                {
                    Reserveringen reservering = _context.Reserveringen.FirstOrDefault(x => x.ReserveringsId == id);
                    if (reservering != null)
                    {
                        UserIndex index = new UserIndex()
                        {
                            Email = account.Email,
                            Naam = reservering.Naam,
                            Omschrijving = reservering.Omschrijving,
                            Datum = reservering.Datum,
                            Hoelang = reservering.Hoelang,
                            GeheimeCode = reservering.GeheimeCode,
                            Prijs = reservering.Prijs
                        };
                        _context.Add(index);
                        _context.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction("Index", "Reserveringens");
                }
                else
                {
                    var lijstAccount = _context.Account.Where(x=> x.Email == user.Email).ToList();
                    List<UserIndex> userIndexLijst = _context.UserIndex.ToList();
                    var query = from a in lijstAccount
                                join u in userIndexLijst on a.Email equals u.Email into tabel1
                                from g in tabel1.ToList()
                                select new UserIndexViewModel()
                                {
                                    UserIndex = g
                                };
                    return View(query);
                }
            }
            else
            {
                return RedirectToAction("Index", "Reserveringens");
            }
            
            
        }
    }
}
