using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;
using TravelBlog.ViewModels;
using System.Diagnostics;
using System.IO;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class ExperienceController : Controller
    {
        private TravelBlogContext db = new TravelBlogContext();

        public IActionResult Index(int id)
        {
           Location location = db.Locations.FirstOrDefault(l => l.Id == id);
           ICollection<Experience> experiences = db.Experiences.Where(e => e.LocationId == id).ToList();

           ExperienceListModel model = new ExperienceListModel(location, experiences);
           return View(model);
        }

		public IActionResult Edit(int id)
		{
			var thisItem = db.Experiences.FirstOrDefault(location => location.Id == id);

			return View(thisItem);
		}

        public IActionResult Details(int id) {

            Experience experience = db.Experiences.FirstOrDefault(e => e.Id == id);
            return View(experience);
        }

		[HttpPost]
        public IActionResult Edit(Experience experience)
		{
            int Locationid = experience.LocationId;
			db.Entry(experience).State = EntityState.Modified;
			db.SaveChanges();
            return RedirectToAction("Index", new { id = Locationid });
		}

		public ActionResult Delete(int id)
		{
            var thisItem = db.Experiences.FirstOrDefault(experience => experience.Id == id);
			return View(thisItem);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
            var thisItem = db.Experiences.FirstOrDefault(experience => experience.Id == id);
            int Locationid = thisItem.LocationId;
			db.Experiences.Remove(thisItem);
			db.SaveChanges();
            return RedirectToAction("Index", new { id = Locationid});
		}

	}
}
