using Microsoft.AspNetCore.Mvc;
using Mvc_Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mvc_Data.Controllers
{
    public class HomeController : Controller
    {
        static List<Person> collect = new List<Person>();
        
        static PeopoleViewModel peapole;
              
        public IActionResult Index()
        {
            /*Person person = new Person("hugo",3467,"marsta");
            collect.Add(person);
            Person perso = new Person("hu", 3467, "marsta");
            peapole = new PeopoleViewModel("");
            pe.Add(perso);*/
            if (peapole != null)
            {
                ViewBag.Phrase = peapole.sertchPhrase;
            }
            return View(collect);
        }
        [HttpPost]
        public IActionResult Index(CreatePersonViewModel createPersonView)
        {
            if (ModelState.IsValid)
            {
                
                Person person = new Person(createPersonView.Name, createPersonView.Phone, createPersonView.City);

                collect.Add(person);

                
                    ViewBag.Phrase = null;
                
                return View(collect);
            }
            else {
                if (peapole != null)
                {
                    ViewBag.Phrase = peapole.sertchPhrase;
                }


                return View(collect);
            }
        }
        [HttpPost]
        public IActionResult Serch(string sertch) {
            peapole = new PeopoleViewModel(sertch);
            
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            collect.RemoveAt(Id);

            return RedirectToAction("Index");
        }
    }
}
