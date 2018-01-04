using System;
using System.Collections.Generic;
using TravelBlog.Models;

namespace TravelBlog.ViewModels
{
    public class ExperienceListModel
    {
        public Location Location { get; set; } 
        public virtual ICollection<Experience> Experiences { get; set; }

        public ExperienceListModel(Location location, ICollection<Experience> experiences)
        {
            Location = location;
            Experiences = experiences;
        }
    }
}
