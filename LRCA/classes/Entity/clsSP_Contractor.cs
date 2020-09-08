
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsSP_Contractor
    {
		#region Public Properties
		public int? SPContractorID { get; set; }
		public int? IsRenewal { get; set; }
		public int? ACRDCatID { get; set; }
		public string SPName { get; set; }
		public string SDATDepartmentId { get; set; }
		public string SPTaxId { get; set; }
		public string SPFeeStatus { get; set; }
		public string SPMHICNumber { get; set; }
		public string AccreditationID { get; set; }
		public DateTime? AccreditationExpirationDate { get; set; }
		public int? PublishOnMDEWebsite { get; set; }
		public string SPPhone { get; set; }
		public string SPMobile { get; set; }
		public string SPWebSite { get; set; }
		public string SPEmail { get; set; }
		public string SPLogoURL { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public int? Wavier { get; set; }
		public string RepFirstName { get; set; }
		public string RepLastName { get; set; }
		public string RepTitle { get; set; }
		public string ContactFirstName { get; set; }
		public string ContactLastName { get; set; }
		public int? Agreed { get; set; }
		#endregion
	}
}
		
		
