
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class Contractor_Approval : DomainObject
    {
		#region Public Properties
		public int? MDEContApprId { get; set; }
		public int? SPContractorID { get; set; }
		public int? MDE_Owner_AuthorisedUserId { get; set; }
		public DateTime? CreateDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
