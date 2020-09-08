
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	public class Inspector_RiskAssessor : DomainObject
	{
		#region Public Properties
		public string InspectorFirstName { get; set; }
		public string InspectorMiddleName { get; set; }
		public string InspectorLastName { get; set; }
		public string Suffix { get; set; }
		public string InspectorPhone { get; set; }
		public string InspectorEmail { get; set; }
		public byte[] InspectorDOB { get; set; }
		public byte[] InspectorSSN { get; set; }
		public int? IsRenewal { get; set; }
		public string AccreditationID { get; set; }
		public DateTime? AccreditationExpirationDate { get; set; }
		public int? ACRDCatID { get; set; }
		public DateTime? ThirdPartyExamDate { get; set; }
		public DateTime? OneYearMinExperience_Start { get; set; }
		public DateTime? OneYearMinExperience_End { get; set; }
		public DateTime? InspectorTechThirdPartyExamDate { get; set; }
		public string InspectorTechAccreditationId { get; set; }
		public int? Waiver { get; set; }
		public string CourseTrainingCardNum { get; set; }
		public string CourseExpirationDate { get; set; }
		public string CourseTPName { get; set; }
		public string CourseName { get; set; }
		public DateTime? CourseStartDate { get; set; }
		public DateTime? CourseEndDate { get; set; }
		public string InspectorContractorName { get; set; }
		public string InspectorContractorAcctNum { get; set; }
		public string InspectorContractor_Address_Line_1 { get; set; }
		public string InspectorContractor_Address_Line_2 { get; set; }
		public string InspectorContractor_City { get; set; }
		public string InspectorContractor_State { get; set; }
		public string InspectorContractor_ZipCode { get; set; }
		public string InspectorContractor_City_2 { get; set; }
		public string InspectorContractor_State_2 { get; set; }
		public string InspectorContractor_ZipCode_2 { get; set; }
		public string InspectorContractor_Phone { get; set; }
		public string InspectorImage { get; set; }
		public string InspectorContactFirstName { get; set; }
		public string InspectorContactLastName { get; set; }
		public int? Agreed { get; set; }
		public string RiskAssessorExperi_URL { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public Category ACRDCat { get; set; }
		public ICollection<RiskAssessor_Approval> Approvals { get; internal set; }
		public ICollection<RiskAssessor_Comment> Comments { get; internal set; }
		public ICollection<RiskAssessor_File> Files { get; internal set; }

		public static Inspector_RiskAssessor Create(string vtxtLName, string vtxtSuffix, string vtxtFName, string vtxtMName,
			string vtxtAddress_1, string vtxtCity_1, string vtxtState_1, string vtxtZipCode_1,
			string vtxtAddress_2, string vtxtCity_2, string vtxtState_2, string vtxtZipcode_2,
			string vtxtPhone, string vtxtEmailAddress, byte[] vtxtDOB, byte[] vtxtSSNO, string vtxtACCID,
			string vtxtAccreditationExpirationDate, string vtxtThirdPartyInspTechExamDate,
			string vtxtThirdPartyRiskAssExamDate, string vtxtMinEx_Start, string vtxtMinEx_End,
			string vtxtInTechAccred, bool vchkWaiver, string vtxtTrainingCardNum, string vtxtTrainCExpire,
			string vtxtTrainingProviderName, string vtxtCourseName, string vtxtCourseStartDate, string vtxtCourseEndDate,
			string vtxtContractorName, string vtxtContractorAccdNum, string vtxtIC_Address_Line_1, string vtxtIC_City,
			string vtxtIC_State, string vtxtIC_Zipcode, string vtxtICContactFName, string vtxtICContactLName,
			string vtxtICContactPhone, bool vchkIAgree, int vdropIsRenewal, string vdropCategory,string experienceFileurl)
		{
			var result = new Inspector_RiskAssessor();
			result.InspectorLastName = vtxtLName;
			result.Suffix = vtxtSuffix;
			result.InspectorFirstName = vtxtFName;
			result.InspectorMiddleName = vtxtMName;
			result.InspectorContractor_Address_Line_1 = vtxtAddress_1;
			result.InspectorContractor_City = vtxtCity_1;
			result.InspectorContractor_State = vtxtState_1;
			result.InspectorContractor_ZipCode = vtxtZipCode_1;
			result.InspectorContractor_Address_Line_2 = vtxtAddress_2;
			result.InspectorContractor_City_2 = vtxtCity_2;
			result.InspectorContractor_State_2 = vtxtState_2;
			result.InspectorContractor_ZipCode_2 = vtxtZipcode_2;
			result.InspectorPhone = vtxtPhone;
			result.InspectorEmail = vtxtEmailAddress;
			result.InspectorDOB = vtxtDOB;
			result.InspectorSSN = vtxtSSNO;
			result.AccreditationID = vtxtACCID;
			if (!string.IsNullOrWhiteSpace(vtxtAccreditationExpirationDate))
			{
				result.AccreditationExpirationDate = DateTime.Parse(vtxtAccreditationExpirationDate);
			}
			if (!string.IsNullOrWhiteSpace(vtxtThirdPartyInspTechExamDate))
			{
				result.ThirdPartyExamDate = DateTime.Parse(vtxtThirdPartyInspTechExamDate);
			}
            else if(!string.IsNullOrWhiteSpace(vtxtThirdPartyRiskAssExamDate))
            {
                result.ThirdPartyExamDate = DateTime.Parse(vtxtThirdPartyRiskAssExamDate);
            }
			if (!string.IsNullOrWhiteSpace(vtxtMinEx_Start))
			{
				result.OneYearMinExperience_Start = DateTime.Parse(vtxtMinEx_Start);
			}
			if (!string.IsNullOrWhiteSpace(vtxtMinEx_End))
			{
				result.OneYearMinExperience_End = DateTime.Parse(vtxtMinEx_End);
			}
			result.InspectorTechAccreditationId = vtxtInTechAccred;
			result.Waiver = vchkWaiver ? 1 : 0;
			result.CourseTrainingCardNum = vtxtTrainingCardNum;
			result.CourseExpirationDate = vtxtTrainCExpire;
			result.CourseTPName = vtxtTrainingProviderName;
			result.CourseName = vtxtCourseName;
			if (!string.IsNullOrWhiteSpace(vtxtCourseStartDate))
			{
				result.CourseStartDate = DateTime.Parse(vtxtCourseStartDate);
			}
			if (!string.IsNullOrWhiteSpace(vtxtCourseEndDate))
			{
				result.CourseEndDate = DateTime.Parse(vtxtCourseEndDate);
			}
			result.InspectorContractorName = vtxtContractorName;
			result.InspectorContractorAcctNum = vtxtContractorAccdNum;
			result.InspectorContactFirstName = vtxtICContactFName;
			result.InspectorContactLastName = vtxtICContactLName;
			result.InspectorContractor_Phone = vtxtICContactPhone;
			result.Agreed = vchkIAgree ? 1 : 0;
			int pdropCategory;
			if (int.TryParse(vdropCategory, out pdropCategory))
			{
				result.ACRDCatID = pdropCategory;
			}
			if (!string.IsNullOrWhiteSpace(experienceFileurl))
			{
				result.RiskAssessorExperi_URL = experienceFileurl;
			}
			result.IsActive = 4;
			result.IsRenewal = vdropIsRenewal;
			if (!string.IsNullOrWhiteSpace(vtxtThirdPartyRiskAssExamDate))
			{
				result.InspectorTechThirdPartyExamDate = DateTime.Parse(vtxtThirdPartyRiskAssExamDate);
			}
			return result;
		}

		internal void Update(string vtxtLName, string vtxtSuffix, string vtxtFName, string vtxtMName, string vtxtAddress_1, string vtxtCity_1, string vtxtState_1, 
			string vtxtZipCode_1, string vtxtAddress_2, string vtxtCity_2, string vtxtState_2, string vtxtZipcode_2, string vtxtPhone, string vtxtEmailAddress, 
			byte[] vtxtDOB, byte[] vtxtSSNO, string vtxtACCID, string vtxtAccreditationExpirationDate, string vtxtThirdPartyInspTechExamDate, string vtxtThirdPartyRiskAssExamDate,
			string vtxtMinEx_Start, string vtxtMinEx_End, string vtxtInTechAccred, bool vchkWaiver, string vtxtTrainingCardNum, string vtxtTrainCExpire, 
			string vtxtTrainingProviderName, string vtxtCourseName, string vtxtCourseStartDate, string vtxtCourseEndDate, string vtxtContractorName, 
			string vtxtContractorAccdNum, string vtxtIC_Address_Line_1, string vtxtIC_City, string vtxtIC_State, string vtxtIC_Zipcode, string vtxtICContactFName,
			string vtxtICContactLName, string vtxtICContactPhone, bool vchkIAgree, int vdropIsRenewal, string vdropCategory)
		{
			InspectorLastName = vtxtLName;
			Suffix = vtxtSuffix;
			InspectorFirstName = vtxtFName;
			InspectorMiddleName = vtxtMName;
			InspectorContractor_Address_Line_1 = vtxtAddress_1;
			InspectorContractor_City = vtxtCity_1;
			InspectorContractor_State = vtxtState_1;
			InspectorContractor_ZipCode = vtxtZipCode_1;
			InspectorContractor_Address_Line_2 = vtxtAddress_2;
			InspectorContractor_City_2 = vtxtCity_2;
			InspectorContractor_State_2 = vtxtState_2;
			InspectorContractor_ZipCode_2 = vtxtZipcode_2;
			InspectorPhone = vtxtPhone;
			InspectorEmail = vtxtEmailAddress;
			InspectorDOB = vtxtDOB;
			InspectorSSN = vtxtSSNO;
			AccreditationID = vtxtACCID;
			if (!string.IsNullOrWhiteSpace(vtxtAccreditationExpirationDate))
			{
				AccreditationExpirationDate = DateTime.Parse(vtxtAccreditationExpirationDate);
			}
			if (!string.IsNullOrWhiteSpace(vtxtThirdPartyInspTechExamDate))
			{
				ThirdPartyExamDate = DateTime.Parse(vtxtThirdPartyInspTechExamDate);
			}
			else if (!string.IsNullOrWhiteSpace(vtxtThirdPartyRiskAssExamDate))
			{
				ThirdPartyExamDate = DateTime.Parse(vtxtThirdPartyRiskAssExamDate);
			}
			if (!string.IsNullOrWhiteSpace(vtxtMinEx_Start))
			{
				OneYearMinExperience_Start = DateTime.Parse(vtxtMinEx_Start);
			}
			if (!string.IsNullOrWhiteSpace(vtxtMinEx_End))
			{
				OneYearMinExperience_End = DateTime.Parse(vtxtMinEx_End);
			}
			InspectorTechAccreditationId = vtxtInTechAccred;
			Waiver = vchkWaiver ? 1 : 0;
			CourseTrainingCardNum = vtxtTrainingCardNum;
			CourseExpirationDate = vtxtTrainCExpire;
			CourseTPName = vtxtTrainingProviderName;
			CourseName = vtxtCourseName;
			if (!string.IsNullOrWhiteSpace(vtxtCourseStartDate))
			{
				CourseStartDate = DateTime.Parse(vtxtCourseStartDate);
			}
			if (!string.IsNullOrWhiteSpace(vtxtCourseEndDate))
			{
				CourseEndDate = DateTime.Parse(vtxtCourseEndDate);
			}
			InspectorContractorName = vtxtContractorName;
			InspectorContractorAcctNum = vtxtContractorAccdNum;
			InspectorContactFirstName = vtxtICContactFName;
			InspectorContactLastName = vtxtICContactLName;
			InspectorContractor_Phone = vtxtICContactPhone;
			Agreed = vchkIAgree ? 1 : 0;
			int pdropCategory;
			if (int.TryParse(vdropCategory, out pdropCategory))
			{
				ACRDCatID = pdropCategory;
			}
			//if (!string.IsNullOrWhiteSpace(experienceFileurl))
			//{
			//	RiskAssessorExperi_URL = experienceFileurl;
			//}
			IsActive = 4;
			IsRenewal = vdropIsRenewal;
			if (!string.IsNullOrWhiteSpace(vtxtThirdPartyRiskAssExamDate))
			{
				InspectorTechThirdPartyExamDate = DateTime.Parse(vtxtThirdPartyRiskAssExamDate);
			}
		}
		#endregion
	}
}


