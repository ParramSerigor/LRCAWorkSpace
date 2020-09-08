
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{

	public class SP_Contractor : DomainObject
	{
		public static SP_Contractor Create(string vSPName, string vSDATDepartmentId,
			string vSPTaxId, bool vSPFeeStatus, string vSPMHICNumber,
			bool vPublishOnMDEWebsite,
			string vSPPhone, string vSPMobile, string vSPWebSite,
			string vSPEmail, string vAccreditationID, int vCourseCatID,
			DateTime vAccreditationExpirationDate, int vDropIsRenewal,
			int? vDropWaiverType, int? vDropPublicListing, string vContactFirstName,
			string vContactLastName, string vAuthFName, string vAuthLName, string vAuthTitle, bool vAgreed)
		{
			var result = new SP_Contractor();
			if (vDropIsRenewal > 0)
			{
				result.IsRenewal = vDropIsRenewal;
			}
			result.SPName = vSPName;
			result.SDATDepartmentId = vSDATDepartmentId;
			result.SPTaxId = vSPTaxId;
			if (vSPFeeStatus)
			{
				result.SPFeeStatus = "1";
			}
			else
			{
				result.SPFeeStatus = "0";
			}

			result.SPMHICNumber = vSPMHICNumber;
			//if (vPublishOnMDEWebsite)
			//{
			//	result.PublishOnMDEWebsite = 1;
			//}
			//else
			//{
			//	result.PublishOnMDEWebsite = 0;
			//}

			result.SPPhone = vSPPhone;
			result.SPMobile = vSPMobile;
			result.SPWebSite = vSPWebSite;
			result.SPEmail = vSPEmail;
			result.AccreditationID = vAccreditationID;
			if (vCourseCatID > 0)
			{
				result.ACRDCatID = vCourseCatID;
			}
			if (vAccreditationExpirationDate != default(DateTime))
			{
				result.AccreditationExpirationDate = vAccreditationExpirationDate;
			}
			result.SPLogoURL = "";
			result.Notes = "";
			result.IsActive = 4; // This is Pending Status
			if (vDropWaiverType.HasValue)
			{
				result.Waiver = vDropWaiverType;
			}
			if (vDropPublicListing.HasValue)
			{
				result.PublishOnMDEWebsite = vDropPublicListing;
			}
			result.ContactFirstName = vContactFirstName;
			result.ContactLastName = vContactLastName;
			result.RepFirstName = vAuthFName;
			result.RepLastName = vAuthLName;
			result.RepTitle = vAuthTitle;
			result.Agreed = vAgreed ? 1 : 0;
			return result;

		}
		#region Public Properties
		//public int? SPContractorID { get; set; }
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
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public int? Waiver { get; internal set; }
		public string RepFirstName { get; internal set; }
		public string RepLastName { get; internal set; }
		public string RepTitle { get; internal set; }
		public string ContactFirstName { get; internal set; }
		public string ContactLastName { get; internal set; }
		public int? Agreed { get; set; }
		public Category ACRDCat { get; internal set; }
		public ICollection<Contractor_Region> ContractorRegions { get; internal set; }
		public ICollection<Contractor_ServiceOffered> ContractorServices { get; internal set; }
		public ICollection<Contractor_Address> ContractorAddresses { get; internal set; }
		public ICollection<Contractor_EmpList> ContractorEmpList { get; internal set; }
		public ICollection<Contractor_Comment> ContractorComments { get; internal set; }
		public ICollection<Contractor_File> ContractorFiles { get; internal set; }

		internal void Update(string vSPName, string vSDATDepartmentId, string vSPTaxId, bool vSPFeeStatus, string vSPMHICNumber, bool vPublishOnMDEWebsite, 
			string vSPPhone, string vSPMobile, string vSPWebSite, string vSPEmail, string vAccreditationID, int vCourseCatID, DateTime vAccreditationExpirationDate, 
			int vDropIsRenewal, int? vDropWaiverType, int? vDropPublicListing, string vContactFirstName, string vContactLastName, string vAuthFName, string vAuthLName, 
			string vAuthTitle, bool vAgreed)
		{
			if (vDropIsRenewal > 0)
			{
				IsRenewal = vDropIsRenewal;
			}
			SPName = vSPName;
			SDATDepartmentId = vSDATDepartmentId;
			SPTaxId = vSPTaxId;
			if (vSPFeeStatus)
			{
				SPFeeStatus = "1";
			}
			else
			{
				SPFeeStatus = "0";
			}

			SPMHICNumber = vSPMHICNumber;
			//if (vPublishOnMDEWebsite)
			//{
			//	PublishOnMDEWebsite = 1;
			//}
			//else
			//{
			//	PublishOnMDEWebsite = 0;
			//}

			SPPhone = vSPPhone;
			SPMobile = vSPMobile;
			SPWebSite = vSPWebSite;
			SPEmail = vSPEmail;
			AccreditationID = vAccreditationID;
			if (vCourseCatID > 0)
			{
				ACRDCatID = vCourseCatID;
			}
			if (vAccreditationExpirationDate != default(DateTime))
			{
				AccreditationExpirationDate = vAccreditationExpirationDate;
			}
			SPLogoURL = "";
			Notes = "";
			IsActive = 4; // This is Pending Status
			if (vDropWaiverType.HasValue)
			{
				Waiver = vDropWaiverType;
			}
			if (vDropPublicListing.HasValue)
			{
				PublishOnMDEWebsite = vDropPublicListing;
			}
			ContactFirstName = vContactFirstName;
			ContactLastName = vContactLastName;
			RepFirstName = vAuthFName;
			RepLastName = vAuthLName;
			RepTitle = vAuthTitle;
			Agreed = vAgreed ? 1 : 0;
		}
		#endregion
	}
}


