using Microsoft.AspNetCore.Mvc;
using ComputerPart.Data;
using ComputerPart.Models;
using System.Collections.Generic;
using System.Linq;

namespace ComputerPart.Controllers
{
    public class ComputerPartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComputerPartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ComputerPart.Models.ComputerPart> objComputerList = _context.ComputerParts.ToList();
            return View(objComputerList);
        }
    }
}
