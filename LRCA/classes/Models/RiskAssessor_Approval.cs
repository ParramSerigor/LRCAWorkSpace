
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class RiskAssessor_Approval
    {
		#region Public Properties
		
		public int? MDEInspRiskAssApprovalId { get; set; }
		public int? InspectorRiskAssId { get; set; }
		public int? MDE_Owner_AuthorisedUserId { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public Inspector_RiskAssessor InspectorRiskAss { get; set; }

		#endregion
	}
}
		
		
