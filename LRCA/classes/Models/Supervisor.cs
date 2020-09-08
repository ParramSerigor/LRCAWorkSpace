
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class Supervisor : DomainObject
    {
		#region Public Properties
		public string SupervisorFirstName { get; set; }
		public string SupervisorMiddleName { get; set; }
		public string SupervisorLastName { get; set; }
		public string SupervisorSuffix { get; set; }
		public string Supervisor_Address_Line_1 { get; set; }
		public string Supervisor_Address_Line_2 { get; set; }
		public string Supervisor_City { get; set; }
		public string Supervisor_State { get; set; }
		public string Supervisor_ZipCode { get; set; }
		public string Supervisor_City_2 { get; set; }
		public string Supervisor_State_2 { get; set; }
		public string Supervisor_ZipCode_2 { get; set; }
		public string SupervisorPhone { get; set; }
		public string SupervisorEmail { get; set; }
		public byte[] SupervisorDOB { get; set; }
		public byte[] SupervisorSSN { get; set; }
		public int? IsRenewal { get; set; }
		public string AccreditationID { get; set; }
		public DateTime? AccreditationExpirationDate { get; set; }
		public int? ACRDCatID { get; set; }
		public DateTime? TwoYearMinExperience_Start { get; set; }
		public DateTime? TwoYearMinExperience_End { get; set; }
		public DateTime? ThirdPartyExamDate { get; set; }
		public string EmployerNames { get; set; }
		public DateTime? SixMonthsMinExperience_Start { get; set; }
		public DateTime? SixMonthsMinExperience_End { get; set; }
		public int? Waiver { get; set; }
		public string CourseTrainingCardNum { get; set; }
		public string CourseExpirationDate { get; set; }
		public string CourseTPName { get; set; }
		public string CourseCatName { get; set; }
		public DateTime? CourseStartDate { get; set; }
		public DateTime? CourseEndDate { get; set; }
		public string SupervisorContractorName { get; set; }
		public string SupervisorContractorAcctNum { get; set; }
		public string SupervisorContractor_Address_Line_1 { get; set; }
		public string SupervisorContractor_Address_Line_2 { get; set; }
		public string SupervisorContractor_City { get; set; }
		public string SupervisorContractor_State { get; set; }
		public string SupervisorContractor_ZipCode { get; set; }
		public string SupervisorContractor_Phone { get; set; }
		public string SupervisorImage { get; set; }
		public string SupervisorContactFirstName { get; set; }
		public string SupervisorContactLastName { get; set; }
		public int? Agreed { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
        public Category ACRDCat { get; set; }
        public ICollection<Supervisor_Approval> Approvals { get; internal set; }
		public ICollection<Supervisor_Experiences> SupervisorExperiences { get; internal set; }
		public ICollection<Supervisor_Comment> Comments { get; internal set; }
		public ICollection<Supervisor_File> Files { get; internal set; }

		internal static Supervisor Create(string vtxtLName, string vtxtSuffix, string vtxtFName, string vtxtMName, 
			string vtxtAddress_1, string vtxtCity_1, string vtxtState_1, string vtxtZipCode_1, string vtxtAddress_2, 
			string vtxtCity_2, string vtxtState_2, string vtxtZipcode_2, string vtxtPhone, string vtxtEmailAddress, 
			string vtxtDOB, string vtxtSSNO, int vdropIsRenewal, string vtxtACCID, DateTime vtxtAccreditationExpirationDate, 
			int vdropCategory, DateTime vtxtConstTradeSteelStartDate, DateTime vtxtConstTradeSteelEndDate, 
			string vtxtSteelSuperWorkedFor, DateTime vtxtThirdPartyRemovalDate, DateTime vtxtConstTradeRemovalStartDate, 
			DateTime vtxtConstTradeRemovalEndDate, string vtxtRemovalSuperWorkedFor, DateTime vtxtConstTradeRepaintStartDate, 
			DateTime vtxtConstTradeRepaintEndDate, string vtxtRepaintSuperWorkedFor, bool vchkWaiver, string vtxtTrainingCardNum, 
			string vtxtTrainCExpire, string vtxtTrainingProviderName, string vtxtCourseName, DateTime vtxtCourseStartDate, 
			DateTime vtxtCourseEndDate, string vtxtContractorName, string vtxtContractorAccdNum, string vtxtIC_Address_Line_1, 
			string vtxtIC_City, string vtxtIC_State, string vtxtIC_Zipcode, string vtxtICContactFName, string vtxtICContactLName, 
			string vtxtICContactPhone, bool vchkIAgree)
		{
			var result = new Supervisor();
			result.SupervisorLastName = vtxtLName;
			result.SupervisorSuffix = vtxtSuffix;
			result.SupervisorFirstName = vtxtFName;
			result.SupervisorMiddleName = vtxtMName;
			result.Supervisor_Address_Line_1 = vtxtAddress_1;
			result.Supervisor_City = vtxtCity_1;
			result.Supervisor_State = vtxtState_1;
			result.Supervisor_ZipCode = vtxtZipCode_1;
			result.Supervisor_Address_Line_2 = vtxtAddress_2;
			result.Supervisor_City_2 = vtxtCity_2;
			result.Supervisor_State_2 = vtxtState_2;
			result.Supervisor_ZipCode_2 = vtxtZipcode_2;
			result.SupervisorPhone = vtxtPhone;
			result.SupervisorEmail = vtxtEmailAddress;
			result.SupervisorDOB = vtxtDOB.ToByteArray();
			result.SupervisorSSN = vtxtSSNO.ToByteArray();
			result.IsRenewal = vdropIsRenewal;
			result.AccreditationID = vtxtACCID;
			if (vtxtAccreditationExpirationDate != default(DateTime))
			{
				result.AccreditationExpirationDate = vtxtAccreditationExpirationDate;
			}
			if (vdropCategory > 0) {
				result.ACRDCatID = vdropCategory;
				if(vdropCategory == Category.StructuralSteelSupervisor)
				{
					result.TwoYearMinExperience_Start = vtxtConstTradeSteelStartDate;
					result.TwoYearMinExperience_End = vtxtConstTradeSteelEndDate;
					result.EmployerNames = vtxtSteelSuperWorkedFor;
				}
				else if (vdropCategory == Category.RemovalAndDemolition)
				{
					result.TwoYearMinExperience_Start = vtxtConstTradeRemovalStartDate;
					result.TwoYearMinExperience_End = vtxtConstTradeRemovalEndDate;
					result.EmployerNames = vtxtRemovalSuperWorkedFor;
				}
				else if (vdropCategory == Category.MaintananceAndRepainting)
				{
					result.SixMonthsMinExperience_Start = vtxtConstTradeRepaintStartDate;
					result.SixMonthsMinExperience_End = vtxtConstTradeRepaintEndDate;
					result.EmployerNames = vtxtRepaintSuperWorkedFor;
				}
			}

			if (vtxtThirdPartyRemovalDate != default(DateTime))
			{
				result.ThirdPartyExamDate = vtxtThirdPartyRemovalDate;
			}

			if (vchkWaiver) {
				result.Waiver = 1;
			}
			result.CourseTrainingCardNum = vtxtTrainingCardNum;
			result.CourseExpirationDate = vtxtTrainCExpire;
			result.CourseTPName = vtxtTrainingProviderName;
			result.CourseCatName = vtxtCourseName;
			if (vtxtCourseStartDate != default(DateTime))
			{
				result.CourseStartDate = vtxtCourseStartDate;
			}
			if (vtxtCourseEndDate != default(DateTime))
			{
				result.CourseEndDate = vtxtCourseEndDate;
			}
			result.SupervisorContractorName = vtxtContractorName;
			result.SupervisorContractorAcctNum = vtxtContractorAccdNum;
			result.SupervisorContractor_Address_Line_1 = vtxtIC_Address_Line_1;
			result.SupervisorContractor_City = vtxtIC_City;
			result.SupervisorContractor_State = vtxtIC_State;
			result.SupervisorContractor_ZipCode = vtxtIC_Zipcode;
			result.SupervisorContactFirstName = vtxtICContactFName;
			result.SupervisorContactLastName = vtxtICContactLName;
			result.SupervisorContractor_Phone = vtxtICContactPhone;
			if (vchkIAgree) {
				result.Agreed = 1;
			}
			result.IsActive = 4;
			return result;
		}

		internal void Update(string vtxtLName, string vtxtSuffix, string vtxtFName, string vtxtMName, string vtxtAddress_1, string vtxtCity_1, string vtxtState_1, string vtxtZipCode_1, string vtxtAddress_2, string vtxtCity_2, string vtxtState_2, string vtxtZipcode_2, string vtxtPhone, string vtxtEmailAddress, string vtxtDOB, string vtxtSSNO, int vdropIsRenewal, string vtxtACCID, DateTime vtxtAccreditationExpirationDate, int vdropCategory, DateTime vtxtConstTradeSteelStartDate, DateTime vtxtConstTradeSteelEndDate, string vtxtSteelSuperWorkedFor, DateTime vtxtThirdPartyRemovalDate, DateTime vtxtConstTradeRemovalStartDate, DateTime vtxtConstTradeRemovalEndDate, string vtxtRemovalSuperWorkedFor, DateTime vtxtConstTradeRepaintStartDate, DateTime vtxtConstTradeRepaintEndDate, string vtxtRepaintSuperWorkedFor, bool vchkWaiver, string vtxtTrainingCardNum, string vtxtTrainCExpire, string vtxtTrainingProviderName, string vtxtCourseName, DateTime vtxtCourseStartDate, DateTime vtxtCourseEndDate, string vtxtContractorName, string vtxtContractorAccdNum, string vtxtIC_Address_Line_1, string vtxtIC_City, string vtxtIC_State, string vtxtIC_Zipcode, string vtxtICContactFName, string vtxtICContactLName, string vtxtICContactPhone, bool vchkIAgree)
		{
			SupervisorLastName = vtxtLName;
			SupervisorSuffix = vtxtSuffix;
			SupervisorFirstName = vtxtFName;
			SupervisorMiddleName = vtxtMName;
			Supervisor_Address_Line_1 = vtxtAddress_1;
			Supervisor_City = vtxtCity_1;
			Supervisor_State = vtxtState_1;
			Supervisor_ZipCode = vtxtZipCode_1;
			Supervisor_Address_Line_2 = vtxtAddress_2;
			Supervisor_City_2 = vtxtCity_2;
			Supervisor_State_2 = vtxtState_2;
			Supervisor_ZipCode_2 = vtxtZipcode_2;
			SupervisorPhone = vtxtPhone;
			SupervisorEmail = vtxtEmailAddress;
			SupervisorDOB = vtxtDOB.ToByteArray();
			SupervisorSSN = vtxtSSNO.ToByteArray();
			IsRenewal = vdropIsRenewal;
			AccreditationID = vtxtACCID;
			if (vtxtAccreditationExpirationDate != default(DateTime))
			{
				AccreditationExpirationDate = vtxtAccreditationExpirationDate;
			}
			if (vdropCategory > 0)
			{
				ACRDCatID = vdropCategory;
				if (vdropCategory == Category.StructuralSteelSupervisor)
				{
					TwoYearMinExperience_Start = vtxtConstTradeSteelStartDate;
					TwoYearMinExperience_End = vtxtConstTradeSteelEndDate;
					EmployerNames = vtxtSteelSuperWorkedFor;
				}
				else if (vdropCategory == Category.RemovalAndDemolition)
				{
					TwoYearMinExperience_Start = vtxtConstTradeRemovalStartDate;
					TwoYearMinExperience_End = vtxtConstTradeRemovalEndDate;
					EmployerNames = vtxtRemovalSuperWorkedFor;
				}
				else if (vdropCategory == Category.MaintananceAndRepainting)
				{
					SixMonthsMinExperience_Start = vtxtConstTradeRepaintStartDate;
					SixMonthsMinExperience_End = vtxtConstTradeRepaintEndDate;
					EmployerNames = vtxtRepaintSuperWorkedFor;
				}
			}

			if (vtxtThirdPartyRemovalDate != default(DateTime))
			{
				ThirdPartyExamDate = vtxtThirdPartyRemovalDate;
			}

			if (vchkWaiver)
			{
				Waiver = 1;
			}
			CourseTrainingCardNum = vtxtTrainingCardNum;
			CourseExpirationDate = vtxtTrainCExpire;
			CourseTPName = vtxtTrainingProviderName;
			CourseCatName = vtxtCourseName;
			if (vtxtCourseStartDate != default(DateTime))
			{
				CourseStartDate = vtxtCourseStartDate;
			}
			if (vtxtCourseEndDate != default(DateTime))
			{
				CourseEndDate = vtxtCourseEndDate;
			}
			SupervisorContractorName = vtxtContractorName;
			SupervisorContractorAcctNum = vtxtContractorAccdNum;
			SupervisorContractor_Address_Line_1 = vtxtIC_Address_Line_1;
			SupervisorContractor_City = vtxtIC_City;
			SupervisorContractor_State = vtxtIC_State;
			SupervisorContractor_ZipCode = vtxtIC_Zipcode;
			SupervisorContactFirstName = vtxtICContactFName;
			SupervisorContactLastName = vtxtICContactLName;
			SupervisorContractor_Phone = vtxtICContactPhone;
			//if (vchkIAgree)
			//{
			//	Agreed = 1;
			//}
			//IsActive = 4;
		}
		#endregion
	}
}
		
		
