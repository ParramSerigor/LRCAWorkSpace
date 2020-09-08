
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class Evidence_Contractor_Approval : DomainObject
    {
		#region Public Properties
		public int? ContractorEvidenceId { get; set; }
		public int? SPContractorID { get; set; }
		public string FormatType { get; set; }
		public string EvidenceLocation { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		#endregion
	}
}
		
		
