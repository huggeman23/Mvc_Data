using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc_Data.Models;
using System.Collections.Generic;
using System.Linq;


namespace Mvc_Data.Controllers
{
    public class HomeController : Controller
    {
        
        public readonly dbContext _context;
        public HomeController(dbContext context) { _context = context; }
       
              
        public IActionResult Index()
        {


            /*var per = new CreatePersonViewModel() { City = "lol", Name = "sl", Phone = 222 };
            _context.PersonViewModels.Add(per);
            _context.SaveChanges();*/
            ListViewModel result = new ListViewModel() { peapoleList=_context.peapole.ToList(),languageList=_context.language.ToList(), cityList = _context.city.ToList()};


            return View(result);
        }
        public IActionResult UpdatePeapole(int Id)
        {
            List<Person> l =( from x in _context.peapole.ToList()
                    where x.Id == Id
                    select x).ToList();

            List<Language> lang =( from t in _context.language.ToList()
                    join x in _context.personlanguage.ToList() on t.LanguageID equals x.LanguageID
                        where x.Id == Id
                        select new Language { LanguageID =t.LanguageID, LanguageName = t.LanguageName}).ToList();

            ListViewModel result = new ListViewModel() {peapoleList= l, languageList = lang, cityList = _context.city.ToList() };

           
            return View(result);
        }
        [HttpPost]
        public IActionResult addPeapole(Person createPersonView)
        {
            ViewBag.Message = "view";

            if (ModelState.IsValid)
            {
                
                
                _context.peapole.Add(createPersonView);
                _context.SaveChanges();
                List<CreatePersonViewModel> viewmod = (from s in _context.peapole.ToList()
                                                       join t in _context.city.ToList() on s.CityID equals t.CityID
                                                       join u in _context.countery.ToList() on t.CounteryName equals u.CounteryName
                                                       join l in _context.personlanguage.ToList() on s.Id equals l.Id into lp
                                                       from l in lp.DefaultIfEmpty()
                                                       join a in _context.language.ToList() on l == null ? 0 : l.LanguageID equals a.LanguageID into ap
                                                       from a in ap.DefaultIfEmpty()
                                                       select new CreatePersonViewModel { Name = s.Name, CityID = s.CityID, Phone = s.Phone, Id = s.Id, CityName = t.Name, CounteryName = u.CounteryName, LanguageID = l?.LanguageID ?? 0, LanguageName = a?.LanguageName ?? string.Empty }).ToList();


                return PartialView("Pview",  viewmod);
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
                                                   join l in _context.personlanguage.ToList() on s.Id equals l.Id into lp
                                                   from l in lp.DefaultIfEmpty()
                                                   join a in _context.language.ToList() on l==null ? 0 : l.LanguageID equals a.LanguageID into ap
                                                   from a in ap.DefaultIfEmpty()
                                                   select new CreatePersonViewModel { Name = s.Name, CityID = s.CityID, Phone = s.Phone, Id = s.Id, CityName = t.Name, CounteryName = u.CounteryName, LanguageID=l?.LanguageID ?? 0, LanguageName=a?.LanguageName ?? string.Empty }).ToList();

            return PartialView("Pview",viewmod);
        }
        [HttpPost]
        public IActionResult Details(string stuff)
        {
            int.TryParse(stuff, out int stu);
            
            List<CreatePersonViewModel> result= (from s in _context.peapole.ToList()
                         join t in _context.city.ToList() on s.CityID equals t.CityID
                         join u in _context.countery.ToList() on t.CounteryName equals u.CounteryName
                                                 join l in _context.personlanguage.ToList() on s.Id equals l.Id into lp
                                                 from l in lp.DefaultIfEmpty()
                                                 join a in _context.language.ToList() on l == null ? 0 : l.LanguageID equals a.LanguageID into ap
                                                 from a in ap.DefaultIfEmpty()
                                                 where s.Id == stu
                                                 select new CreatePersonViewModel { Name = s.Name, CityID = s.CityID, Phone = s.Phone, Id = s.Id, CityName = t.Name, CounteryName = u.CounteryName, LanguageID = l?.LanguageID ?? 0, LanguageName = a?.LanguageName ?? string.Empty }).ToList();

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
        [HttpPost]
        public IActionResult GivLanguage(PersonLanguage pl)
        {

            if (ModelState.IsValid)
            {

                _context.personlanguage.Add(pl);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult RemoveLanguage(PersonLanguage pl)
        {
            
            //_context.Entry(pl).State = EntityState.Deleted;
            _context.personlanguage.Remove(pl);
                _context.SaveChanges();
            

            return RedirectToAction("UpdatePeapole", new { Id = pl.Id });
        }
        [HttpPost]
        public IActionResult UpdatePerson(Person upPerson)
        {
            
            if (ModelState.IsValid)
            {

                _context.peapole.Update(upPerson);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("UpdatePeapole", new {Id = upPerson.Id});
            }
        }
    }
}
