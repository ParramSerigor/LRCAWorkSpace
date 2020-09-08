
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class LK_RiskAssessor_Experience
    {
		#region Public Properties
		public int? RiskAssessorExperienceId { get; set; }
		public int? InspectorRiskAssId { get; set; }
		public string Number { get; set; }
		public DateTime? DatePerformed { get; set; }
		public string Address_1 { get; set; }
		public string Address_2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zipcode { get; set; }
		public string TypeOfInspection { get; set; }
		#endregion
	}
}
		
		
