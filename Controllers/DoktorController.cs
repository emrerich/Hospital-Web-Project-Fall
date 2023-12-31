// DoktorController.cs

using System;
using System.Linq;
using System.Threading.Tasks;
using Hospital_Web_Project_Fall.Data;
using Hospital_Web_Project_Fall.Models.Doktor;
using Hospital_Web_Project_Fall.Models;
using Hospital_Web_Project_Fall.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Web_Project_Fall.Controllers
{
    public class DoktorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoktorController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var doktors = await _context.Doktor.ToListAsync();
            return View(doktors);
        }

        [HttpGet]
        public IActionResult Add(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return NotFound();
            }

            var user = _context.User.FirstOrDefault(u => u.UserID == userId);

            if (user == null)
            {
                return NotFound();
            }

            var model = new AddDoktorViewModel
            {
                DoktorAdi = user.Ad,
                DoktorSoyadi = user.Soyad,
                DoktorMail = user.Email,
                DoktorSifre = user.Sifre,
                DoktorTelefon = user.Telefon,

                // Diğer alanları da kullanıcı bilgilerine göre doldurabilirsiniz.
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDoktorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.User.FirstOrDefaultAsync(u => u.Ad == model.DoktorAdi && u.Soyad == model.DoktorSoyadi);

                if (user != null)
                {
                    Doktor doktor = new Doktor
                    {
                        DoktorAdi = model.DoktorAdi,
                        DoktorSoyadi = model.DoktorSoyadi,
                        DoktorBrans = model.DoktorBrans,
                        DoktorTelefon = model.DoktorTelefon,
                        DoktorMail = model.DoktorMail,
                        DoktorSifre = model.DoktorSifre,
                        DoktorUnvan = model.DoktorUnvan,
                        DoktorId = Guid.NewGuid()
                    };

                    _context.Doktor.Add(doktor);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var doktor = await _context.Doktor.FirstOrDefaultAsync(x => x.DoktorId == id);
            if (doktor != null)
            {
                _context.Doktor.Remove(doktor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult View(Guid id)
        {
            var doctor = _context.Doktor.FirstOrDefault(x => x.DoktorId.Equals(id));
            if (doctor != null)
            {
               UpdateDoktorViewModel updateDoktorViewModel = new UpdateDoktorViewModel();
                updateDoktorViewModel.DoktorId = doctor.DoktorId;
                updateDoktorViewModel.DoktorAdi = doctor.DoktorAdi;
                updateDoktorViewModel.DoktorSoyadi = doctor.DoktorSoyadi;
                updateDoktorViewModel.DoktorBrans = doctor.DoktorBrans;
                updateDoktorViewModel.DoktorTelefon = doctor.DoktorTelefon;
                updateDoktorViewModel.DoktorMail = doctor.DoktorMail;
                updateDoktorViewModel.DoktorSifre = doctor.DoktorSifre;
                updateDoktorViewModel.DoktorUnvan = doctor.DoktorUnvan;

                return base.View(updateDoktorViewModel);
            }
           return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateDoktorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doktor = await _context.Doktor.FirstOrDefaultAsync(x => x.DoktorId == model.DoktorId);
                if (doktor != null)
                {
                    doktor.DoktorAdi = model.DoktorAdi;
                    doktor.DoktorSoyadi = model.DoktorSoyadi;
                    doktor.DoktorBrans = model.DoktorBrans;
                    doktor.DoktorTelefon = model.DoktorTelefon;
                    doktor.DoktorMail = model.DoktorMail;
                    doktor.DoktorSifre = model.DoktorSifre;
                    doktor.DoktorUnvan = model.DoktorUnvan;
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
