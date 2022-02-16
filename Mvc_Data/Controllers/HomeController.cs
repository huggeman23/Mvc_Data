using Microsoft.AspNetCore.Mvc;
using Mvc_Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace Mvc_Data.Controllers
{
    public class HomeController : Controller
    {
        
        public readonly dbContext _context;
        public HomeController(dbContext context) { _context = context; }
        //static PeopoleViewModel peapole;
              
        public IActionResult Index()
        {
            
            
                /*var per = new CreatePersonViewModel() { City = "lol", Name = "sl", Phone = 222 };
                _context.PersonViewModels.Add(per);
                _context.SaveChanges();*/
                
                            
            return View(_context.PersonViewModels.ToList());
        }
        [HttpPost]
        public IActionResult addPeapole(CreatePersonViewModel createPersonView)
        {
            

            if (ModelState.IsValid)
            {
                
                var per = new CreatePersonViewModel() { City = createPersonView.City, Name = createPersonView.Name, Phone = createPersonView.Phone };
                _context.PersonViewModels.Add(per);
                _context.SaveChanges();

                return PartialView("Pview",  _context.PersonViewModels.ToList());
            }
            else {
                                
                
                return PartialView("Pview", _context.PersonViewModels.ToList());
            }
        }
       /* [HttpPost]
        public IActionResult Serch(string sertch) {
            peapole = new PeopoleViewModel(sertch);
            
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            collect.RemoveAt(Id);

            return RedirectToAction("Index");
        }*/
                [HttpGet]
        public IActionResult Partial()
        {
            
            return PartialView("Pview",_context.PersonViewModels.ToList());
        }
        [HttpPost]
        public IActionResult Details(string stuff)
        {
            int.TryParse(stuff, out int stu);
            
            var result = from s in _context.PersonViewModels.ToList()
                         where s.Id == stu
                         select s;
                                 
            return PartialView("Pview", result.ToList());
        }
        [HttpPost]
        public IActionResult DeletJ(string stuff)
        {
            

            int.TryParse(stuff, out int stu);
            

            _context.PersonViewModels.Remove(_context.PersonViewModels.Find(stu));
            _context.SaveChanges();

            return PartialView("Pview", _context.PersonViewModels.ToList());
        }
    }
}
