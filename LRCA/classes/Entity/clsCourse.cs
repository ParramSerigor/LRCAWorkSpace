
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsCourse
    {
		#region Public Properties
		public int? TrainingCourseId { get; set; }
		public int? TPId { get; set; }
		public string CourseTitle { get; set; }
		public int? ACRDCatID { get; set; }
		public string InstructionLanguage { get; set; }
		public string CourseDuration { get; set; }
		public string MeasurementUnit { get; set; }
		public string InitialOrRenewal { get; set; }
		public string AttendanceRequirement { get; set; }
		public string PassScore { get; set; }
		public DateTime? CreateDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
