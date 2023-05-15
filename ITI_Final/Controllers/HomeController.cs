using ITI_Final.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITI_Final.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
       NewsWebsiteContext db= new NewsWebsiteContext(); 

        public IActionResult Index()
        {
            var result =db.Categories.ToList();
            return View(result);
        }

        public IActionResult Messages()
        {
            var result=db.ContactUs.ToList();   
            return View(result);
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult DeleteNews(int id )
        {
            var r = db.News.Find(id);
            if (r != null)
            {
                db.News.Remove(r);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public IActionResult News(int id)
        {
            Category c=db.Categories.Find(id);
            ViewBag.cat= c.Name;
            var result=db.News.Where(x=>x.IdCat==id).OrderByDescending(x=>x.Date).ToList();    
            return View(result);
        }

        [HttpPost]
        public IActionResult SaveContact(ContactUs model)
        {
            db.ContactUs.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}