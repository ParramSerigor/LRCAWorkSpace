
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class RiskAssessor_Comment : DomainObject
    {
		#region Public Properties
		
		public int? InspectorRiskAssId { get; set; }
		public string Comment { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public Inspector_RiskAssessor InspectorRiskAss { get; internal set; }

		#endregion
	}
}
		
		
