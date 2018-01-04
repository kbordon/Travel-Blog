using System;
using System.Collections.Generic;
using TravelBlog.Models;

namespace TravelBlog.ViewModels
{
    public class PersonListModel
    {
        public Experience Experience { get; set; } 
        public Location Location { get; set; }
        public virtual ICollection<Person> People { get; set; }

        public PersonListModel(Experience experience, Location location, ICollection<Person> people)
        {
            Experience = experience;
            Location = location;
            People = people;
        }
    }
}
