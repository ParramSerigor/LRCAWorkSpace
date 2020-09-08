
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsExamRule
    {
		#region Public Properties
		public int ExamRuleID { get; set; }
		public int ACRDCatID { get; set; }
		public DateTime ValidityStartDate { get; set; }
		public DateTime ValidityEndDate { get; set; }
		public int InStateFlag { get; set; }
		public Decimal PassScore { get; set; }
		public DateTime CreateDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public int IsActive { get; set; }
		public string Notes { get; set; }
		#endregion
	}
}
		
		
