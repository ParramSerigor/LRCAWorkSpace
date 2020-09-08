
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsRiskAssessor_Approval
    {
		#region Public Properties
		public int? MDEInspRiskAssApprovalId { get; set; }
		public int? InspectorRiskAssId { get; set; }
		public int? MDE_Owner_AuthorisedUserId { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
