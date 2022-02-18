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
                
                            
            return View(_context.peapole.ToList());
        }
        [HttpPost]
        public IActionResult addPeapole(Person createPersonView)
        {
            

            if (ModelState.IsValid)
            {
                
                
                _context.peapole.Add(createPersonView);
                _context.SaveChanges();

                return PartialView("Pview",  _context.peapole.ToList());
            }
            else {
                                
                
                return PartialView("Pview", _context.peapole.ToList());
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
            List<CreatePersonViewModel> viewmod = (from s in _context.peapole.ToList()
                                                  join t in _context.city.ToList() on s.CityID equals t.CityID
                                                  join u in _context.countery.ToList() on t.CounteryName equals u.CounteryName
                                                  select new CreatePersonViewModel { Name = s.Name, CityID = s.CityID, Phone = s.Phone, Id = s.Id, CityName = t.Name, CounteryName = u.CounteryName }).ToList();

            return PartialView("Pview",viewmod);
        }
        [HttpPost]
        public IActionResult Details(string stuff)
        {
            int.TryParse(stuff, out int stu);
            
            List<CreatePersonViewModel> result= (from s in _context.peapole.ToList()
                         join t in _context.city.ToList() on s.CityID equals t.CityID
                         join u in _context.countery.ToList() on t.CounteryName equals u.CounteryName
                         where s.Id == stu
                         select new CreatePersonViewModel{Name=s.Name,CityID=s.CityID,Phone=s.Phone,Id=s.Id,CityName=t.Name,CounteryName=u.CounteryName} ).ToList();
                                 
            return PartialView("Pview", result);
        }
        [HttpPost]
        public IActionResult DeletJ(string stuff)
        {
            

            int.TryParse(stuff, out int stu);
            

            _context.peapole.Remove(_context.peapole.Find(stu));
            _context.SaveChanges();

            return PartialView("Pview", _context.peapole.ToList());
        }
    }
}
