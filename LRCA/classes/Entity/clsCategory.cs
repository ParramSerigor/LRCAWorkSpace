
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsCategory
    {
		#region Public Properties
		public int? ACRDCatID { get; set; }
		public string CatTitle { get; set; }
		public string CatDescription { get; set; }
		public string ACRDCategory { get; set; }
		public int? ValidFor { get; set; }
		public int? ThirdPartyExam { get; set; }
		public int? PassScoreReq { get; set; }
		public string PassScore { get; set; }
		public int? AttendanceReq { get; set; }
		public DateTime? CreateDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
