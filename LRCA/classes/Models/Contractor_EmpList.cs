
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class Contractor_EmpList
    {
		#region Public Properties
		public int? ContractorUserListId { get; set; }
		public int? SPContractorID { get; set; }
		public string EmpFName { get; set; }
		public string EmpLName { get; set; }
		public string AccreditedId { get; set; }
		public string AccreditedExpire { get; set; }
		public int? IsApplying { get; set; }
		public int? ACRDCatID { get; internal set; }
		public SP_Contractor SPContractor { get; internal set; }
		#endregion

		public static Contractor_EmpList Create(string fName, string lName, string AcctId,string AccreditedExpire,int SPContractorID, int isActive,int category)
		{
			var result = new Contractor_EmpList();
			result.EmpFName = fName;
			result.EmpLName = lName;
			result.AccreditedId = AcctId;
			result.AccreditedExpire = AccreditedExpire;
			result.IsApplying = isActive;
			result.SPContractorID = SPContractorID;
			result.ACRDCatID = category;
			return result;
		}
	}
}
		
		
