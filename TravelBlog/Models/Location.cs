﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBlog.Models
{
	[Table("locations")]
	public class Location
	{
		public Location()
		{
			this.Experiences = new HashSet<Experience>();
		}
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
	}
}
