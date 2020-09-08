
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class CourseSchedule : DomainObject
    {
		#region Public Properties
		public int? TrainingCourseScheduleId { get; set; }
        public int? CourseId { get; set; }
        public int? TPId { get; set; }
		public int? InstructorId { get; set; }
		public int? TPLocationId { get; set; }
		public string ClassTitle { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string InstructionLanguage { get; set; }
		public int? RegistrationLimit { get; set; }
		public string ExpectedEnrollment { get; set; }
		public string CourseCost { get; set; }
		public string CourseCancelled { get; set; }
		public string CancellationReason { get; set; }
		public DateTime? CreateDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
