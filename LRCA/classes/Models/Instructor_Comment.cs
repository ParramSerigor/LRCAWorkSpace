
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class Instructor_Comment : DomainObject
    {
		#region Public Properties
		
		public int? InstructorId { get; set; }
		public string Comment { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public Instructor Instructor { get; internal set; }

		#endregion
	}
}
		
		
