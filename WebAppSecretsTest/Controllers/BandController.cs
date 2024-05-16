using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppSecretsTest.Data;
using WebAppSecretsTest.Models;

namespace WebAppSecretsTest.Controllers
{
    public class BandController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BandController(ApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<IActionResult> Bands()
        {
            var bands = await _context.Bands.ToListAsync();
            return View(bands);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Band band)
        {
            if (ModelState.IsValid)
            {
                _context.Add(band);
                await _context.SaveChangesAsync();

                return RedirectToAction("Confirm", band);
            }
            return View();
            
        }

        public IActionResult Confirm(Band band)
        {
            return View(band);
        }

    }
}
