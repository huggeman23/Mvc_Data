using Microsoft.AspNetCore.Mvc;
using Mvc_Data.Models;
using System.Linq;

namespace Mvc_Data.Controllers
{
    public class CityController : Controller
    {
        public readonly dbContext _context;
        public CityController(dbContext context) { _context = context; }
        public IActionResult City()
        {
            return View(_context.city.ToList());
        }
        [HttpPost]
        public IActionResult addCity(City CreateCity)
        {

           

            if (ModelState.IsValid)
            {
                
               
                _context.city.Add(CreateCity);
                _context.SaveChanges();

                return View("City", _context.city.ToList());
            }
            else
            {
                ViewBag.Message = "not valid";

                return View("City", _context.city.ToList());
            }
        }
        [HttpPost]
        public IActionResult Delet(string stuff)
        {


            int.TryParse(stuff, out int stu);


            _context.city.Remove(_context.city.Find(stu));
            _context.SaveChanges();

            return View("City", _context.city.ToList());
        }
    }
}
