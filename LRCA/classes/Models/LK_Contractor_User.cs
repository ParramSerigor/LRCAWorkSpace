
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class LK_Contractor_User
    {
		public static LK_Contractor_User Create(int contractorId)
		{
			var result = new LK_Contractor_User();
			result.AuthorisedUserId = Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString());
			result.SPContractorID = contractorId;
			return result;
		}
		#region Public Properties
		public int? ContractorUserId { get; set; }
		public int? AuthorisedUserId { get; set; }
		public int? SPContractorID { get; set; }
		#endregion
	}
}
		
		
