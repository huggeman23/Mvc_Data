using Microsoft.AspNetCore.Mvc;
using Mvc_Data.Models;
using System.Linq;

namespace Mvc_Data.Controllers
{
    public class LanguageController : Controller
    {
        public readonly dbContext _context;
        public LanguageController(dbContext context) { _context = context; }
        public IActionResult Language()
        {
            return View(_context.language.ToList());
        }
        public IActionResult addLanguage(Language CreateLanguage)
        {

            if (ModelState.IsValid)
            {


                _context.language.Add(CreateLanguage);
                _context.SaveChanges();

                return View("Language", _context.language.ToList());
            }
            else
            {
                ViewBag.Message = "not valid";

                return View("Language", _context.language.ToList());
            }
        }
        [HttpPost]
        public IActionResult Delet(string stuff)
        {


            int.TryParse(stuff, out int stu);


            _context.language.Remove(_context.language.Find(stu));
            _context.SaveChanges();

            return View("Language", _context.language.ToList());
        }
    }
}
