using Microsoft.AspNetCore.Mvc;
using Mvc_Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mvc_Data.Controllers
{
    public class CityController : Controller
    {
        public readonly dbContext _context;
        public CityController(dbContext context) { _context = context; }
        public IActionResult City()
        {
            ListViewModel listViewModel = new ListViewModel() { cityList=_context.city.ToList(), counteryList = _context.countery.ToList()};
            return View(listViewModel);
        }
        public IActionResult UpdateCity(int CityID)
        {
            List<City> l = (from x in _context.city.ToList()
                        where x.CityID == CityID
                        select x).ToList();
            ListViewModel listViewModel = new ListViewModel() { cityList = l, counteryList = _context.countery.ToList() };
            return View(listViewModel);
        }
        [HttpPost]
        public IActionResult addCity(City CreateCity)
        {

           

            if (ModelState.IsValid)
            {
                
               
                _context.city.Add(CreateCity);
                _context.SaveChanges();

                return View("City");
            }
            else
            {
                ViewBag.Message = "not valid";

                return View("City");
            }
        }
        [HttpPost]
        public IActionResult Delet(string stuff)
        {


            int.TryParse(stuff, out int stu);


            _context.city.Remove(_context.city.Find(stu));
            _context.SaveChanges();

            return View("City");
        }
        [HttpPost]
        public IActionResult UpdateCity(City upCity)
        {
            
            if (ModelState.IsValid)
            {
                _context.city.Update(upCity);
                _context.SaveChanges();
                return RedirectToAction("City");
            }
            else
            {
                return RedirectToAction("UpdateCity", new {CityID = upCity.CityID});
            }
        }
    }
}
