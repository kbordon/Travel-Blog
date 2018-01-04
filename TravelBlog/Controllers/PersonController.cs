using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using TravelBlog.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBlog.Controllers
{
    public class PersonController : Controller
    {

        private TravelBlogContext db = new TravelBlogContext();
        public IActionResult Index(int id)
        {
           Experience experience = db.Experiences.FirstOrDefault(e => e.Id == id);
           Location location = db.Locations.FirstOrDefault(l => l.Id == experience.LocationId);
           
            ICollection<Person> people = db.People.Where(e => e.ExperienceId == id).ToList();

           PersonListModel model = new PersonListModel(experience, location, people);
           return View(model);
        }

		public IActionResult Edit(int id)
		{
			var thisItem = db.Experiences.FirstOrDefault(location => location.Id == id);

			return View(thisItem);
		}

		//public IActionResult Details(int id)
		//{

		//	Experience experience = db.Experiences.FirstOrDefault(e => e.Id == id);
		//	return View(experience);
		//}

		//[HttpPost]
		//public IActionResult Edit(Experience experience)
		//{
		//	int Locationid = experience.LocationId;
		//	db.Entry(experience).State = EntityState.Modified;
		//	db.SaveChanges();
		//	return RedirectToAction("Index", new { id = Locationid });
		//}

		//public ActionResult Delete(int id)
		//{
		//	var thisItem = db.Experiences.FirstOrDefault(experience => experience.Id == id);
		//	return View(thisItem);
		//}

		//[HttpPost, ActionName("Delete")]
		//public IActionResult DeleteConfirmed(int id)
		//{
		//	var thisItem = db.Experiences.FirstOrDefault(experience => experience.Id == id);
		//	int Locationid = thisItem.LocationId;
		//	db.Experiences.Remove(thisItem);
		//	db.SaveChanges();
		//	return RedirectToAction("Index", new { id = Locationid });
		//}
    }
}
