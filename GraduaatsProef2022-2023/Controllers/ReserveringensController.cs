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
using Microsoft.AspNetCore.Authorization;
using System.Data;

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
            if (user == null)
            {
                return RedirectToAction("Register", "Account");
            }
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

        // GET: Reserveringens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reserveringen == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reserveringen
                .FirstOrDefaultAsync(m => m.ReserveringsId == id);
            if (reservering == null)
            {
                return NotFound();
            }

            return View(reservering);
        }

        // GET: Reserveringens/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reserverings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ReserveringsId,Naam,Datum,Hoelang,GeheimeCode,Prijs,Omschrijving")] Reserveringen reservering)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservering);
        }

        // GET: Reserveringens/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reserveringen == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reserveringen.FindAsync(id);
            if (reservering == null)
            {
                return NotFound();
            }
            return View(reservering);
        }

        // POST: Reserveringens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ReserveringsId,Naam,Datum,Hoelang,GeheimeCode,Prijs,Omschrijving")] Reserveringen reservering)
        {
            if (id != reservering.ReserveringsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReserveringExist(reservering.ReserveringsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Reserveringens");
            }
            return View(reservering);
        }

        // GET: Reserveringens/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reserveringen == null)
            {
                return NotFound();
            }

            var reservering = await _context.Reserveringen
                .FirstOrDefaultAsync(m => m.ReserveringsId == id);
            if (reservering == null)
            {
                return NotFound();
            }

            return View(reservering);
        }

        // POST: Onderwerpens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reserveringen == null)
            {
                return Problem("Entity set 'GraduaatsProefDbContext.Reserveringen'  is null.");
            }
            var reservering = await _context.Reserveringen.FindAsync(id);
            if (reservering != null)
            {
                _context.Reserveringen.Remove(reservering);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        private bool ReserveringExist(int id)
        {
            return (_context.Reserveringen?.Any(e => e.ReserveringsId == id)).GetValueOrDefault();
        }
    }
}
