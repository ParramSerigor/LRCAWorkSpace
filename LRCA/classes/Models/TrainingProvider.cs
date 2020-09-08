
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class TrainingProvider : DomainObject
    {
		#region Public Properties
		public string TP_Name { get; set; }
		public string TP_WebSite { get; set; }
		public string TP_Address_Line_1 { get; set; }
		public string TP_Address_Line_2 { get; set; }
		public string TP_City { get; set; }
		public string TP_State { get; set; }
		public string TP_ZipCode { get; set; }
		public string TP_City_2 { get; set; }
		public string TP_State_2 { get; set; }
		public string TP_Zipcode_2 { get; set; }
		public string TP_Telephone { get; set; }
		public string TP_Fax { get; set; }
		public string TP_Email { get; set; }
		public int? TP_PublicList { get; set; }
		public string TP_SDAT { get; set; }
		public byte[] TP_TaxID { get; set; }
		public string AccreditationID { get; set; }
		public DateTime? AccreditationExpirationDate { get; set; }
		public int? TP_Fee { get; set; }
		public string TP_TaxExempt { get; set; }
		public string MDE_Advertise_URL { get; set; }
		public int? RiskAssessor { get; set; }
		public int? InspectorTech { get; set; }
		public int? VisualInspector { get; set; }
		public int? MainRepaint { get; set; }
		public int? RemovalDemo { get; set; }
		public int? ProjectDesign { get; set; }
		public int? AbatWorkerEnglish { get; set; }
		public int? AbatWorkerSpanish { get; set; }
		public int? StructSteelSupervisor { get; set; }
		public int? StructSteelWorker { get; set; }
		public string TPContactFirstName { get; set; }
		public string TPContactLastName { get; set; }
		public string TPContactTitle { get; set; }
		public int? TPwebsiteVal { get; set; }
		public string TPWebsiteURL { get; set; }
		public int? IsRenewal { get; set; }
		public int? Agreed { get; set; }
		public string TP_Logo_URL { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public ICollection<TP_Approval> Approvals { get; internal set; }
		public ICollection<TP_Instructors> Instructors { get; internal set; }
		public ICollection<TP_Location> Locations { get; internal set; }
		public ICollection<TP_Comment> Comments { get; internal set; }
		public ICollection<TP_File> Files { get; internal set; }

		internal static TrainingProvider Create(string vtxtName, string vtxtSDATNum, string vtxtAddress_1, string vtxtCity_1, string vtxtState_1, string vtxtZipCode_1, 
			string vtxtAddress_2, string vtxtCity_2, string vtxtState_2, string vtxtZipcode_2, int vdropPublicList, string vtxtPhone, string vtxtFax, string vtxtEmailAddress, 
			string vtxtEIN, int vdropIsRenewal, string vtxtACCID, DateTime vtxtAccreditationExpirationDate, int vchkChargeFee, int vchkTaxExempt, string vtxtTaxExempt, 
			int vchkTPwebsiteYES, string vtxtTPwebsiteURL, int vchkTPwebsiteNO, int vchkCORiskAssessor, int vchkCOProjectDesigner, int vchkCOInspectorTech, int vchkCOAbatWorkEnglish, 
			int vchkCOVisualInspector, int vchkCOAbatWorkSpanish, int vchkCOMainRepaintSup, int vchkCOStructSteelSup, int vchkCORemovalSup, int vchkStructSteelWork, 
			string vtxtAuthRepContFName, string vtxtAuthRepContLName, 
			string vtxtAuthRepContTitle, int vchkIAgree)
		{
			var result = new TrainingProvider();
			result.TP_Name = vtxtName;
			result.TP_SDAT = vtxtSDATNum;
			result.TP_Address_Line_1 = vtxtAddress_1;
			result.TP_City = vtxtCity_1;
			result.TP_State = vtxtState_1;
			result.TP_ZipCode = vtxtZipCode_1;
			result.TP_Address_Line_2 = vtxtAddress_2;
			result.TP_City_2 = vtxtCity_2;
			result.TP_State_2 = vtxtState_2;
			result.TP_Zipcode_2 = vtxtZipcode_2;
			result.TP_PublicList = vdropPublicList;
			result.TP_Telephone = vtxtPhone;
			result.TP_Fax = vtxtFax;
			result.TP_Email = vtxtEmailAddress;
			result.TP_TaxID = vtxtEIN.ToByteArray();
			result.IsRenewal = vdropIsRenewal;
			result.AccreditationID = vtxtACCID;
			if (vtxtAccreditationExpirationDate != default(DateTime))
			{
				result.AccreditationExpirationDate = vtxtAccreditationExpirationDate;
			}
			result.TP_Fee = vchkChargeFee;
			//result.t = vchkTaxExempt;
			if (vchkTaxExempt == 1)
			{
				result.TP_TaxExempt = "1";
			}
			result.TPwebsiteVal = vchkTPwebsiteYES;
			if (vchkTPwebsiteYES == 1)
			{
				result.TPWebsiteURL = vtxtTPwebsiteURL;
			}
			//result. = vchkTPwebsiteNO;

			result.RiskAssessor = vchkCORiskAssessor;
			result.ProjectDesign = vchkCOProjectDesigner;
			result.InspectorTech = vchkCOInspectorTech;
			result.AbatWorkerEnglish = vchkCOAbatWorkEnglish;
			result.VisualInspector = vchkCOVisualInspector;
			result.AbatWorkerSpanish = vchkCOAbatWorkSpanish;
			result.MainRepaint = vchkCOMainRepaintSup;
			result.StructSteelSupervisor = vchkCOStructSteelSup;
			result.RemovalDemo = vchkCORemovalSup;
			result.StructSteelWorker = vchkStructSteelWork;
			result.TPContactFirstName = vtxtAuthRepContFName;
			result.TPContactLastName = vtxtAuthRepContLName;
			result.TPContactTitle = vtxtAuthRepContTitle;
			result.Agreed = vchkIAgree;
			return result;
		}

		internal void Update(string vtxtName, string vtxtSDATNum, string vtxtAddress_1, string vtxtCity_1, string vtxtState_1, string vtxtZipCode_1, string vtxtAddress_2, 
			string vtxtCity_2, string vtxtState_2, string vtxtZipcode_2, int vdropPublicList, string vtxtPhone, string vtxtFax, string vtxtEmailAddress, string vtxtEIN, 
			int vdropIsRenewal, string vtxtACCID, DateTime vAccreditationExpirationDate, int vchkChargeFee, int vchkTaxExempt, string vtxtTaxExempt, int vchkTPwebsiteYES, 
			string vtxtTPwebsiteURL, int vchkTPwebsiteNO, int vchkCORiskAssessor, int vchkCOProjectDesigner, int vchkCOInspectorTech, int vchkCOAbatWorkEnglish, 
			int vchkCOVisualInspector, int vchkCOAbatWorkSpanish, int vchkCOMainRepaintSup, int vchkCOStructSteelSup, int vchkCORemovalSup, int vchkStructSteelWork, 
			string vtxtAuthRepContFName, string vtxtAuthRepContLName, string vtxtAuthRepContTitle, int vchkIAgree)
		{
			TP_Name = vtxtName;
			TP_SDAT = vtxtSDATNum;
			TP_Address_Line_1 = vtxtAddress_1;
			TP_City = vtxtCity_1;
			TP_State = vtxtState_1;
			TP_ZipCode = vtxtZipCode_1;
			TP_Address_Line_2 = vtxtAddress_2;
			TP_City_2 = vtxtCity_2;
			TP_State_2 = vtxtState_2;
			TP_Zipcode_2 = vtxtZipcode_2;
			TP_PublicList = vdropPublicList;
			TP_Telephone = vtxtPhone;
			TP_Fax = vtxtFax;
			TP_Email = vtxtEmailAddress;
			TP_TaxID = vtxtEIN.ToByteArray();
			IsRenewal = vdropIsRenewal;
			AccreditationID = vtxtACCID;
			if (vAccreditationExpirationDate != default(DateTime))
			{
				AccreditationExpirationDate = vAccreditationExpirationDate;
			}
			TP_Fee = vchkChargeFee;
			//t = vchkTaxExempt;
			if (vchkTaxExempt == 1)
			{
				TP_TaxExempt = vtxtTaxExempt;
			}
            else
            {
                TP_TaxExempt = null;
            }

			TPwebsiteVal = vchkTPwebsiteYES;
			if (vchkTPwebsiteYES == 1)
			{
				TPWebsiteURL = vtxtTPwebsiteURL;
			}
			// = vchkTPwebsiteNO;

			RiskAssessor = vchkCORiskAssessor;
			ProjectDesign = vchkCOProjectDesigner;
			InspectorTech = vchkCOInspectorTech;
			AbatWorkerEnglish = vchkCOAbatWorkEnglish;
			VisualInspector = vchkCOVisualInspector;
			AbatWorkerSpanish = vchkCOAbatWorkSpanish;
			MainRepaint = vchkCOMainRepaintSup;
			StructSteelSupervisor = vchkCOStructSteelSup;
			RemovalDemo = vchkCORemovalSup;
			StructSteelWorker = vchkStructSteelWork;
			TPContactFirstName = vtxtAuthRepContFName;
			TPContactLastName = vtxtAuthRepContLName;
			TPContactTitle = vtxtAuthRepContTitle;
			//Agreed = vchkIAgree;
		}

		#endregion
	}
}
		
		
