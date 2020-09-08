
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class Instructor : DomainObject
    {
		#region Public Properties
		public string Instructor_FName { get; set; }
		public string Instructor_MName { get; set; }
		public string Instructor_LName { get; set; }
		public string Instructor_Suffix { get; set; }
		public string Instructor_Address_Line_1 { get; set; }
		public string Instructor_Address_Line_2 { get; set; }
		public string Instructor_City { get; set; }
		public string Instructor_State { get; set; }
		public string Instructor_ZipCode { get; set; }
		public string Instructor_City_2 { get; set; }
		public string Instructor_State_2 { get; set; }
		public string Instructor_ZipCode_2 { get; set; }
		public string Instructor_Phone { get; set; }
		public string Instructor_Email { get; set; }
		public byte[] Instructor_DOB { get; set; }
		public byte[] Instructor_SSN { get; set; }
		public string TP_Name { get; set; }
		public string TP_AcctNumber { get; set; }
		public string TP_Contact_FName { get; set; }
		public string TP_Contact_LName { get; set; }
		public string TP_Telephone { get; set; }
		public string TP_Address_Line_1 { get; set; }
		public string TP_City { get; set; }
		public string TP_State { get; set; }
		public string TP_ZipCode { get; set; }
		public int? IsRenewal { get; set; }
		public string AccreditationID { get; set; }
		public DateTime? AccreditationExpirationDate { get; set; }
		public int? ACRDCatID { get; set; }
		public string NewInitialTCard { get; set; }
		public DateTime? NewIT_StartDates { get; set; }
		public DateTime? NewIT_EndDates { get; set; }
		public string RenewalTCard { get; set; }
		public DateTime? RenewalLT_StartDates { get; set; }
		public DateTime? RenewalLT_EndDates { get; set; }
		public string NewInstructors_URL { get; set; }
		public string NewRenewal_InspecTech_AcctNumber { get; set; }
		public string NewRenewal_InspecTech_AcctExpiration { get; set; }
		public string NewInspectorTechnInstructors_URL { get; set; }
		public int? Agreed { get; set; }
		public string Instructor_Image { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public ICollection<Instructor_Approval> Approvals { get; internal set; }
		public Category ACRDCat { get; internal set; }
		public ICollection<Instructor_Comment> Comments { get; internal set; }
		public ICollection<Instructor_File> Files { get; internal set; }

		internal static Instructor Create(string vtxtLName, string vtxtSuffix, string vtxtFName, string vtxtMName, string vtxtAddress_1, string vtxtCity_1, string vtxtState_1, 
			string vtxtZipCode_1, string vtxtAddress_2, string vtxtCity_2, string vtxtState_2, string vtxtZipcode_2, string vtxtPhone, string vtxtEmailAddress, string vtxtDOB, 
			string vtxtSSNO, string vtxtInstructTP, string vtxtInstructAcctNum, string vtxtInstructContFN, string vtxtInstructContLN, string vtxtInstructContPhone, 
			string vtxtInstructContAddress, string vtxtInstructContCity, string vtxtInstructContState, string vtxtInstructContZipcode, int vdropIsRenewal, 
			string vtxtACCID, DateTime vtxtAccreditationExpirationDate, int vdropInstructCategory, string vtxtNewInitTrainingCard, DateTime vtxtNewInitStartDate, 
			DateTime vtxtNewInitEndDate, string vtxtRenewalTrainingCard, DateTime vtxtRenewalStartDate, DateTime vtxtRenewalEndDate, string vupload_1, string vtxtNewRenewAcctNum, 
			string vtxtNewRenewAcctExpireDate, string vupload_2, int vchkIAgree)
		{
			var result = new Instructor();
			result.Instructor_LName = vtxtLName;
			result.Instructor_Suffix = vtxtSuffix;
			result.Instructor_FName = vtxtFName;
			result.Instructor_MName = vtxtMName;
			result.Instructor_Address_Line_1 = vtxtAddress_1;
			result.Instructor_City = vtxtCity_1;
			result.Instructor_State = vtxtState_1;
			result.Instructor_ZipCode = vtxtZipCode_1;
			result.Instructor_Address_Line_2 = vtxtAddress_2;
			result.Instructor_City_2 = vtxtCity_2;
			result.Instructor_State_2 = vtxtState_2;
			result.Instructor_ZipCode_2 = vtxtZipcode_2;
			result.Instructor_Phone = vtxtPhone;
			result.Instructor_Email = vtxtEmailAddress;
			result.Instructor_DOB = vtxtDOB.ToByteArray();
			result.Instructor_SSN = vtxtSSNO.ToByteArray();
			result.TP_Name = vtxtInstructTP;
			result.TP_AcctNumber = vtxtInstructAcctNum;
			result.TP_Contact_FName = vtxtInstructContFN;
			result.TP_Contact_LName = vtxtInstructContLN;
			result.TP_Telephone = vtxtInstructContPhone;
			result.TP_Address_Line_1 = vtxtInstructContAddress;
			result.TP_City = vtxtInstructContCity;
			result.TP_State = vtxtInstructContState;
			result.TP_ZipCode = vtxtInstructContZipcode;
			result.IsRenewal = vdropIsRenewal;
			result.AccreditationID = vtxtACCID;
			result.AccreditationExpirationDate = vtxtAccreditationExpirationDate;
			result.ACRDCatID = vdropInstructCategory;
			result.NewInitialTCard = vtxtNewInitTrainingCard;
			result.NewIT_StartDates = vtxtNewInitStartDate;
			result.NewIT_EndDates = vtxtNewInitEndDate;
			result.RenewalTCard = vtxtRenewalTrainingCard;
			result.RenewalLT_StartDates = vtxtRenewalStartDate;
			result.RenewalLT_EndDates = vtxtRenewalEndDate;
			result.NewInstructors_URL = vupload_1;
			result.NewRenewal_InspecTech_AcctNumber = vtxtNewRenewAcctNum;
			result.NewRenewal_InspecTech_AcctExpiration = vtxtNewRenewAcctExpireDate;
			result.NewInspectorTechnInstructors_URL = vupload_2;
			result.Agreed = vchkIAgree;
            result.IsActive = 4;
			return result;
		}

		internal void Update(string vtxtLName, string vtxtSuffix, string vtxtFName, string vtxtMName, string vtxtAddress_1, string vtxtCity_1, string vtxtState_1, 
			string vtxtZipCode_1, string vtxtAddress_2, string vtxtCity_2, string vtxtState_2, string vtxtZipcode_2, string vtxtPhone, string vtxtEmailAddress, string vtxtDOB, 
			string vtxtSSNO, string vtxtInstructTP, string vtxtInstructAcctNum, string vtxtInstructContFN, string vtxtInstructContLN, string vtxtInstructContPhone, 
			string vtxtInstructContAddress, string vtxtInstructContCity, string vtxtInstructContState, string vtxtInstructContZipcode, int vdropIsRenewal, string vtxtACCID, 
			DateTime vAccreditationExpirationDate, int vdropInstructCategory, string vtxtNewInitTrainingCard, DateTime vtxtNewInitStartDate, DateTime vtxtNewInitEndDate,
			string vtxtRenewalTrainingCard, DateTime vtxtRenewalStartDate, DateTime vtxtRenewalEndDate, string vtxtNewRenewAcctNum, string vtxtNewRenewAcctExpireDate, int vchkIAgree)
		{
			Instructor_LName = vtxtLName;
			Instructor_Suffix = vtxtSuffix;
			Instructor_FName = vtxtFName;
			Instructor_MName = vtxtMName;
			Instructor_Address_Line_1 = vtxtAddress_1;
			Instructor_City = vtxtCity_1;
			Instructor_State = vtxtState_1;
			Instructor_ZipCode = vtxtZipCode_1;
			Instructor_Address_Line_2 = vtxtAddress_2;
			Instructor_City_2 = vtxtCity_2;
			Instructor_State_2 = vtxtState_2;
			Instructor_ZipCode_2 = vtxtZipcode_2;
			Instructor_Phone = vtxtPhone;
			Instructor_Email = vtxtEmailAddress;
			Instructor_DOB = vtxtDOB.ToByteArray();
			Instructor_SSN = vtxtSSNO.ToByteArray();
			TP_Name = vtxtInstructTP;
			TP_AcctNumber = vtxtInstructAcctNum;
			TP_Contact_FName = vtxtInstructContFN;
			TP_Contact_LName = vtxtInstructContLN;
			TP_Telephone = vtxtInstructContPhone;
			TP_Address_Line_1 = vtxtInstructContAddress;
			TP_City = vtxtInstructContCity;
			TP_State = vtxtInstructContState;
			TP_ZipCode = vtxtInstructContZipcode;
			IsRenewal = vdropIsRenewal;
			AccreditationID = vtxtACCID;
			AccreditationExpirationDate = vAccreditationExpirationDate;
			ACRDCatID = vdropInstructCategory;
			NewInitialTCard = vtxtNewInitTrainingCard;
			NewIT_StartDates = vtxtNewInitStartDate;
			NewIT_EndDates = vtxtNewInitEndDate;
			RenewalTCard = vtxtRenewalTrainingCard;
			RenewalLT_StartDates = vtxtRenewalStartDate;
			RenewalLT_EndDates = vtxtRenewalEndDate;
			//NewInstructors_URL = vupload_1;
			NewRenewal_InspecTech_AcctNumber = vtxtNewRenewAcctNum;
			NewRenewal_InspecTech_AcctExpiration = vtxtNewRenewAcctExpireDate;
			//NewInspectorTechnInstructors_URL = vupload_2;
			//Agreed = vchkIAgree;
			//IsActive = 4;
		}


		#endregion
	}
}
		
		
