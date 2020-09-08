
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class Course_Result
    {
		#region Public Properties
		public int? ClassResultId { get; set; }
		public int? Inst_CourseSchId { get; set; }
		public int? AuthorisedUserId { get; set; }
		public int? TrainingCourseScheduleId { get; set; }
		public int? InstructorId { get; set; }
		public int? MDE_AuthorisedUserId { get; set; }
		public int? TPLocationId { get; set; }
		public int? TPId { get; set; }
		public int? SPContractorID { get; set; }
		public int? Inst_PASSFAIL { get; set; }
		public int? Inst_Attendence { get; set; }
		public string Inst_ScorePercent { get; set; }
		public string Inst_TrainingCard { get; set; }
		public int? MDE_EmployerVeri { get; set; }
		public int? MDE_BackGround { get; set; }
		public int? MDE_PaymentVeri { get; set; }
		public string PaymentAmount { get; set; }
		public int? Acct_Term { get; set; }
		public int? MDE_F_Decision { get; set; }
		public string MDE_F_Notes { get; set; }
		public string MDE_Acct_Certificate { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
