using System;
using System.Collections.Generic;
using TravelBlog.Models;

namespace TravelBlog.ViewModels
{
    public class PersonListModel
    {
        public Experience Experience { get; set; } 
        public virtual ICollection<Person> People { get; set; }

        public PersonListModel(Experience experience, ICollection<Person> people)
        {
            Experience = experience;
            People = people;
        }
    }
}
