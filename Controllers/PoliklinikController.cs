using Hospital_Web_Project_Fall.Data;
using Hospital_Web_Project_Fall.Models;
using Hospital_Web_Project_Fall.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Hospital_Web_Project_Fall.Controllers
{
    public class PoliklinikController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoliklinikController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new AddPoliklinikViewModel
            {
                AnaBilimDallari = _context.AnaBilimDali.ToList()
            };

            return View(viewModel);
        }



        [HttpPost]
        public IActionResult Index(AddPoliklinikViewModel viewModel)
        {
         
                var anaBilimDali = _context.AnaBilimDali
                    .Include(a => a.Poliklinikler)
                    .FirstOrDefault(a => a.AnaBilimDaliID == viewModel.SelectedAnaBilimDaliID);

                if (anaBilimDali != null)
                {
                    var siraNo = anaBilimDali.Poliklinikler.Any() ? anaBilimDali.Poliklinikler.Max(p => p.SiraNo) + 1 : 1;

                    // Poliklinik nesnesi oluşturuldu
                    var poliklinik = new Poliklinik
                    {
                        Ad = anaBilimDali.Ad + " Poliklinik " + siraNo,
                        SiraNo = siraNo,
                        AnaBilimDaliID = anaBilimDali.AnaBilimDaliID,
                        PoliklinikID = Guid.NewGuid()

              
                    };

                    // Poliklinik nesnesi veritabanına eklenmeli
                    _context.Poliklinik.Add(poliklinik);
                    _context.SaveChanges();
                }

                return RedirectToAction("Index", "Home");
        }


    }

}
