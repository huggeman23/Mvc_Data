using Microsoft.AspNetCore.Mvc;
using Mvc_Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mvc_Data.Controllers
{
    public class HomeController : Controller
    {
        static List<Person> collect = new List<Person>();
        
        //static PeopoleViewModel peapole;
              
        public IActionResult Index()
        {
           
            return View(collect);
        }
        [HttpPost]
        public IActionResult addPeapole(CreatePersonViewModel createPersonView)
        {
            if (ModelState.IsValid)
            {
                
                Person person = new Person(createPersonView.Name, createPersonView.Phone, createPersonView.City);

                collect.Add(person);

                
                    ViewBag.Phrase = null;
                
                return PartialView("Pview",collect);
            }
            else {
                
                    ViewBag.Phrase = "-1";
                
                return PartialView("Pview", collect);
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
            return PartialView("Pview",collect);
        }
        [HttpPost]
        public IActionResult Details(string stuff)
        {
            ViewBag.Phrase = stuff;
            return PartialView("Pview", collect);
        }
        [HttpPost]
        public IActionResult DeletJ(string stuff)
        {
            int.TryParse(stuff, out int id);

            ViewBag.deletMessage = collect[id].Name+"was deleted";
            collect.RemoveAt(id);

            ViewBag.Phrase = "-1";

            return PartialView("Pview", collect);
        }
    }
}
