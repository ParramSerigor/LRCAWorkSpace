
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsExamResult
    {
		#region Public Properties
		public int ExamResultId { get; set; }
		public int ExamUserMapId { get; set; }
		public int Attended { get; set; }
		public Decimal ExamScorePercent { get; set; }
		public int TotalQuestions { get; set; }
		public int CorrectAnswers { get; set; }
		public int ExamPassed { get; set; }
		public DateTime CreateDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int IsActive { get; set; }
		#endregion
	}
}
		
		
