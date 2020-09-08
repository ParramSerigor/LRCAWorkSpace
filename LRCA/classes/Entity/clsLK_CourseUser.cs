
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsLK_CourseUser
    {
		#region Public Properties
		public int? CourseUserMapID { get; set; }
		public int? TrainingCourseScheduleID { get; set; }
		public string IndividualUserID { get; set; }
		public string TrainingProviderAcceptance { get; set; }
		public DateTime? CreateDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
