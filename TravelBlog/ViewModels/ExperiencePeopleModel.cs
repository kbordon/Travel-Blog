using System;
using System.Collections.Generic;
using TravelBlog.Models;

namespace TravelBlog.ViewModels
{
	public class ExperiencePeopleModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int ExperienceId { get; set; }
        public ExperiencePeopleModel(int experienceId)
		{
            ExperienceId = experienceId;
		}

        public ExperiencePeopleModel()
		{ }
	}
}
