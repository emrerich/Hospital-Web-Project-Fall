using Hospital_Web_Project_Fall.Data;
using Hospital_Web_Project_Fall.Models;
using Hospital_Web_Project_Fall.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Web_Project_Fall.Controllers
{
    public class DoktorController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public DoktorController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var doktors = await applicationDbContext.Doktor.ToListAsync();
            return View(doktors);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Add(AddDoktorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Doktor doktor = new Doktor();
                doktor.DoktorAdi = model.DoktorAdi;
                doktor.DoktorSoyadi = model.DoktorSoyadi;
                doktor.DoktorBrans = model.DoktorBrans;
                doktor.DoktorTelefon = model.DoktorTelefon;
                doktor.DoktorMail = model.DoktorMail;
                doktor.DoktorSifre = model.DoktorSifre;
                doktor.DoktorUnvan = model.DoktorUnvan;
                doktor.DoktorId = Guid.NewGuid();
                await applicationDbContext.Doktor.AddAsync(doktor);
                await applicationDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var doktor = await applicationDbContext.Doktor.FirstOrDefaultAsync(x => x.DoktorId == id);
            if (doktor != null)
            {
                applicationDbContext.Doktor.Remove(doktor);
                await applicationDbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult View(Guid id)
        {
            var doctor = applicationDbContext.Doktor.FirstOrDefault(x => x.DoktorId.Equals(id));
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
                var doktor = await applicationDbContext.Doktor.FirstOrDefaultAsync(x => x.DoktorId == model.DoktorId);
                if (doktor != null)
                {
                    doktor.DoktorAdi = model.DoktorAdi;
                    doktor.DoktorSoyadi = model.DoktorSoyadi;
                    doktor.DoktorBrans = model.DoktorBrans;
                    doktor.DoktorTelefon = model.DoktorTelefon;
                    doktor.DoktorMail = model.DoktorMail;
                    doktor.DoktorSifre = model.DoktorSifre;
                    doktor.DoktorUnvan = model.DoktorUnvan;
                    await applicationDbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
