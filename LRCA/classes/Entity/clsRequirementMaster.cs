
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsRequirementMaster
    {
		#region Public Properties
		public int? ACRDReqID { get; set; }
		public string ACRDRequirementName { get; set; }
		public string ReqDescription { get; set; }
		public string ReqDisplayText { get; set; }
		public string ReqEnforcement { get; set; }
		public DateTime? CreateDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
