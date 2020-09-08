
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class TrainingCourse_Comment : DomainObject
    {
		#region Public Properties
		
		public int? TrainingCourseAppId { get; set; }
		public string Comment { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public TrainingCourse TrainingCourseApp { get; internal set; }

		#endregion
	}
}
		
		
