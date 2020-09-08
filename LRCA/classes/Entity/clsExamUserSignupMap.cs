
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsExamUserSignupMap
    {
		#region Public Properties
		public int ExamUserMapId { get; set; }
		public int ExamScheduleId { get; set; }
		public DateTime CreateDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int IsActive { get; set; }
		#endregion
	}
}
		
		
