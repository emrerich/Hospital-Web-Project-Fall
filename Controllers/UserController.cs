// UserController.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital_Web_Project_Fall.Data;
using Hospital_Web_Project_Fall.Models.Domain;

namespace Hospital_Web_Project_Fall.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.User != null ?
                      View(await _context.User.ToListAsync()) :
                      Problem("Entity set 'ApplicationDbContext.User' is null.");
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Create()
        {
            ViewData["Roles"] = new SelectList(_context.Role, "RolAdi", "RolAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,Ad,Soyad,Email,Sifre,Telefon,RolAdi")] User user)
        {
            if (ModelState.IsValid)
            {
                user.UserID = Guid.NewGuid();
                _context.Add(user);
                await _context.SaveChangesAsync();

                if (user.RolAdi == "Doktor")
                {
                    return RedirectToAction("Add", "Doktor", new { userId = user.UserID });
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["Roles"] = new SelectList(_context.Role, "RolAdi", "RolAdi", user.RolAdi);

            return View(user);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            ViewData["Roles"] = new SelectList(_context.Role, "RolAdi", "RolAdi", user.RolAdi);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UserID,Ad,Soyad,Email,Sifre,Telefon,RolAdi")] User user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    if (user.RolAdi == "Doktor")
                    {
                        return RedirectToAction("Add", "Doktor", new { userId = user.UserID });
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["Roles"] = new SelectList(_context.Role, "RolAdi", "RolAdi", user.RolAdi);

            return View(user);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'ApplicationDbContext.User' is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(Guid id)
        {
            return (_context.User?.Any(e => e.UserID == id)).GetValueOrDefault();
        }
    }
}
