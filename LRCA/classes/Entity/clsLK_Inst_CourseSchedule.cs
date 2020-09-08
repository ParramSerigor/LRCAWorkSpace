
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsLK_Inst_CourseSchedule
    {
		#region Public Properties
		public int? Inst_CourseSchId { get; set; }
		public int? AuthorisedUserId { get; set; }
		public int? TrainingCourseScheduleId { get; set; }
		public int? InstructorId { get; set; }
		public int? TP_AuthorisedUserId { get; set; }
		public int? IsApproved { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ApprovedOn { get; set; }
		#endregion
	}
}
		
		
