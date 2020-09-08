
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsContractor_EmpList
    {
		#region Public Properties
		public int? ContractorUserListId { get; set; }
		public int? SPContractorID { get; set; }
		public string EmpFName { get; set; }
		public string EmpLName { get; set; }
		public string AccreditedId { get; set; }
		public string AccreditedExpire { get; set; }
		public int? IsApplying { get; set; }
		public int? ACRDCatID { get; set; }
		#endregion
	}
}
		
		
