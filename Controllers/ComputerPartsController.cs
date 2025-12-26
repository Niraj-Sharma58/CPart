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

         // ================= EDIT (GET) =================
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var partFromDb = _context.ComputerParts.Find(id);

            if (partFromDb == null)
            {
                return NotFound();
            }

            return View(partFromDb);
        }

        // ================= EDIT (POST) =================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ComputerPartModel obj)
        {
            if (ModelState.IsValid)
            {
                _context.ComputerParts.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // ================= DELETE (GET) =================
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var partFromDb = _context.ComputerParts.Find(id);

            if (partFromDb == null)
            {
                return NotFound();
            }

            return View(partFromDb);
        }

        // ================= DELETE (POST) =================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var obj = _context.ComputerParts.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _context.ComputerParts.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
