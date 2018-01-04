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

        public IActionResult Index()
        {
           Experience experience = db.Experiences.FirstOrDefault(l => l.Id == id);
           ICollection<Person> people = db.People.Where(e => e.ExperienceId == id).ToList();

           PersonListModel model = new PersonListModel(experience, people);
           return View(model);
        }
    }
}
