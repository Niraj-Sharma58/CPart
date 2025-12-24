using Microsoft.AspNetCore.Mvc;
using ComputerPart.Data;
using ComputerPart.Models;
using System.Linq;
using System.Collections.Generic;

namespace ComputerPart.Controllers
{
    public class ComputerPartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComputerPartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ
        public IActionResult Index()
        {
            List<ComputerPart.Models.ComputerPartModel> objComputerList =
                _context.ComputerParts.ToList();

            return View(objComputerList);
        }

        // GET: Create
        public IActionResult NewComPart()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewComPart(ComputerPart.Models.ComputerPartModel obj)
        {
            if (ModelState.IsValid)
            {
                _context.ComputerParts.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
