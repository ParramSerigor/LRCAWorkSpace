
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsMDE_Courses
    {
		#region Public Properties
		public int? CourseId { get; set; }
		public string CourseCode { get; set; }
		public int? ACRDCatID { get; set; }
		public string CourseDescription { get; set; }
		public string InstructionLanguage { get; set; }
		public int? CourseDuration { get; set; }
		public string DurationMeasurementUnit { get; set; }
		public string InitialOrRenewal { get; set; }
		public Decimal AttendanceRequirement { get; set; }
		public Decimal PassScore { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
