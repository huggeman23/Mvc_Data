using Microsoft.AspNetCore.Mvc;
using Mvc_Data.Models;
using System.Linq;

namespace Mvc_Data.Controllers
{
    public class CounteryController : Controller
    {
        public readonly dbContext _context;
        public CounteryController(dbContext context) { _context = context; }
        public IActionResult Countery()
        {
            return View(_context.countery.ToList());
        }
        [HttpPost]
        public IActionResult addCountery(Countery CreateCountery)
        {
           

            if (ModelState.IsValid)
            {

                
                _context.countery.Add(CreateCountery);
                _context.SaveChanges();

                return RedirectToAction("Countery");
            }
            else
            {


                return RedirectToAction("Countery");
            }
        }
        [HttpPost]
        public IActionResult Delet(string stuff)
        {


            _context.countery.Remove(_context.countery.Find(stuff));
            _context.SaveChanges();

            return View("Countery", _context.countery.ToList());
        }
        public IActionResult UpdateCountery(string CounteryName)
        {
            Countery l = (from x in _context.countery.ToList()
                      where x.CounteryName == CounteryName
                      select x).First();
            return View(l);
        }
        [HttpPost]
        public IActionResult UpdateCountery(Countery upCountery)
        {

            if (ModelState.IsValid)
            {
                _context.countery.Update(upCountery);
                _context.SaveChanges();
                return RedirectToAction("Countery");
            }
            else
            {
                return RedirectToAction("UpdateCountery", new { CounteryName = upCountery.CounteryName });
            }
        }
    }
}
