using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

		public IActionResult Details(int id)
		{

			Person person = db.People.FirstOrDefault(p => p.Id == id);
			return View(person);
		}

		public IActionResult Edit(int id)
		{
            var thisPerson = db.People.FirstOrDefault(p => p.Id == id);

			return View(thisPerson);
		}

		[HttpPost]
		public IActionResult Edit(Person person)
		{
            int ExperienceId = person.ExperienceId;
			db.Entry(person).State = EntityState.Modified;
			db.SaveChanges();
            return RedirectToAction("Index", new { id = ExperienceId });
		}

		public ActionResult Delete(int id)
		{
			var thisPerson = db.People.FirstOrDefault(p => p.Id == id);
			return View(thisPerson);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var thisPerson = db.People.FirstOrDefault(p => p.Id == id);
            int ExperienceId = thisPerson.ExperienceId;
            db.People.Remove(thisPerson);
			db.SaveChanges();
            return RedirectToAction("Index", new { id = ExperienceId });
		}
    }
}
