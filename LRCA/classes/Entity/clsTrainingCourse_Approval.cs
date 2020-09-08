
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsTrainingCourse_Approval
    {
		#region Public Properties
		public int? MDETCourseApprId { get; set; }
		public int? TrainingCourseAppId { get; set; }
		public int? MDE_Owner_AuthorisedUserId { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
