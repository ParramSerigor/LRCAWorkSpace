
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	public class TrainingCourse : DomainObject
	{
		#region Public Properties

		public string TrainingProviderName { get; set; }
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
		public byte[] TP_TaxID { get; set; }
		public string AccreditationID { get; set; }
		public DateTime? AccreditationExpirationDate { get; set; }
		public int? TC_RiskAssessor { get; set; }
		public int? TC_InspectorTech { get; set; }
		public int? TC_VisualInspector { get; set; }
		public int? TC_Main_Repair { get; set; }
		public int? TC_Removal { get; set; }
		public int? TC_ProjectDesign { get; set; }
		public int? TC_AbatementWorkerEnglish { get; set; }
		public int? TC_AbatementWorkerSpanish { get; set; }
		public int? TC_StructSteelSuper { get; set; }
		public int? TC_StructSteelWorker { get; set; }
		public string DocURL_1 { get; set; }
		public string DocURL_2 { get; set; }
		public string DocURL_3 { get; set; }
		public string DocURL_4 { get; set; }
		public string DocURL_5 { get; set; }
		public string TPContactFirstName { get; set; }
		public string TPContactLastName { get; set; }
		public string TPContactTitle { get; set; }
		public int? Agreed { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
        public ICollection<TC_Approval> Approvals { get; internal set; }
		public ICollection<TrainingCourse_Comment> Comments { get; internal set; }
		public ICollection<TrainingCourse_File> Files { get; internal set; }

		internal static TrainingCourse Create(string vtxtTPName, string vtxtAddress_1, string vtxtCity_1, string vtxtState_1, string vtxtZipCode_1, string vtxtAddress_2, 
			string vtxtCity_2, string vtxtState_2, string vtxtZipcode_2, string vtxtPhone, string vtxtFax, string vtxtEmailAddress, string vtxtSSN, string vdropIsRenewal, 
			string vtxtACCID, DateTime vtxtAccreditationExpirationDate, int vchkRiskAssessor, int vchkInspectorTech, int vchkVisualInspector, 
			int vchkMainRepaint, int vchkRemoval, int vchkProjectDesign, int vchkAbatmentEnglish, int vchkAbatmentSpanish, int vchkStructSteelSuper, 
			int vchkStructSteelWorker, string vupload_1, string vupload_2, string vupload_3, string vupload_4, string vupload_5, string vtxtAuthRepContFName, 
			string vtxtAuthRepContLName, string vtxtAuthRepContTitle, int vchkIAgree)
		{
			var result = new TrainingCourse();
			result.TrainingProviderName = vtxtTPName;
			result.TP_Address_Line_1 = vtxtAddress_1;
			result.TP_City = vtxtCity_1;
			result.TP_State = vtxtState_1;
			result.TP_ZipCode = vtxtZipCode_1;
			result.TP_Address_Line_2 = vtxtAddress_2;
			result.TP_City_2 = vtxtCity_2;
			result.TP_State_2 = vtxtState_2;
			result.TP_Zipcode_2 = vtxtZipcode_2;
			result.TP_Telephone = vtxtPhone;
			result.TP_Fax = vtxtFax;
			result.TP_Email = vtxtEmailAddress;
			result.TP_TaxID = vtxtSSN.ToByteArray();
			//result. = vdropIsRenewal;
			result.AccreditationID = vtxtACCID;
			if (vtxtAccreditationExpirationDate != default(DateTime))
			{
				result.AccreditationExpirationDate = vtxtAccreditationExpirationDate;
			}
			result.TC_RiskAssessor = vchkRiskAssessor;
			result.TC_InspectorTech = vchkInspectorTech;
			result.TC_VisualInspector = vchkVisualInspector;
			result.TC_Main_Repair = vchkMainRepaint;
			result.TC_Removal = vchkRemoval;
			result.TC_ProjectDesign = vchkProjectDesign;
			result.TC_AbatementWorkerEnglish = vchkAbatmentEnglish;
			result.TC_AbatementWorkerSpanish = vchkAbatmentSpanish;
			result.TC_StructSteelSuper = vchkStructSteelSuper;
			result.TC_StructSteelWorker = vchkStructSteelWorker;
			result.DocURL_1 = vupload_1;
			result.DocURL_2 = vupload_2;
			result.DocURL_3 = vupload_3;
			result.DocURL_4 = vupload_4;
			result.DocURL_5 = vupload_5;
			result.TPContactFirstName = vtxtAuthRepContFName;
			result.TPContactLastName = vtxtAuthRepContLName;
			result.TPContactTitle = vtxtAuthRepContTitle;
			result.Agreed = vchkIAgree;
			result.IsActive = 4;
			return result;
		}

		internal void Update(string vtxtTPName, string vtxtAddress_1, string vtxtCity_1, string vtxtState_1, string vtxtZipCode_1, string vtxtAddress_2, string vtxtCity_2, string vtxtState_2, string vtxtZipcode_2, string vtxtPhone, string vtxtFax, string vtxtEmailAddress, string vtxtSSN, string vdropIsRenewal, string vtxtACCID, DateTime vtxtAccreditationExpirationDate, int vchkRiskAssessor, int vchkInspectorTech, int vchkVisualInspector, int vchkMainRepaint, int vchkRemoval, int vchkProjectDesign, int vchkAbatmentEnglish, int vchkAbatmentSpanish, int vchkStructSteelSuper, int vchkStructSteelWorker, string vtxtAuthRepContFName, string vtxtAuthRepContLName, string vtxtAuthRepContTitle, int vchkIAgree)
		{
			TrainingProviderName = vtxtTPName;
			TP_Address_Line_1 = vtxtAddress_1;
			TP_City = vtxtCity_1;
			TP_State = vtxtState_1;
			TP_ZipCode = vtxtZipCode_1;
			TP_Address_Line_2 = vtxtAddress_2;
			TP_City_2 = vtxtCity_2;
			TP_State_2 = vtxtState_2;
			TP_Zipcode_2 = vtxtZipcode_2;
			TP_Telephone = vtxtPhone;
			TP_Fax = vtxtFax;
			TP_Email = vtxtEmailAddress;
			TP_TaxID = vtxtSSN.ToByteArray();
			// = vdropIsRenewal;
			AccreditationID = vtxtACCID;
			if (vtxtAccreditationExpirationDate != default(DateTime))
			{
				AccreditationExpirationDate = vtxtAccreditationExpirationDate;
			}
			TC_RiskAssessor = vchkRiskAssessor;
			TC_InspectorTech = vchkInspectorTech;
			TC_VisualInspector = vchkVisualInspector;
			TC_Main_Repair = vchkMainRepaint;
			TC_Removal = vchkRemoval;
			TC_ProjectDesign = vchkProjectDesign;
			TC_AbatementWorkerEnglish = vchkAbatmentEnglish;
			TC_AbatementWorkerSpanish = vchkAbatmentSpanish;
			TC_StructSteelSuper = vchkStructSteelSuper;
			TC_StructSteelWorker = vchkStructSteelWorker;
			//DocURL_1 = vupload_1;
			//DocURL_2 = vupload_2;
			//DocURL_3 = vupload_3;
			//DocURL_4 = vupload_4;
			//DocURL_5 = vupload_5;
			TPContactFirstName = vtxtAuthRepContFName;
			TPContactLastName = vtxtAuthRepContLName;
			TPContactTitle = vtxtAuthRepContTitle;
			//Agreed = vchkIAgree;
			//IsActive = 4;
		}

		#endregion
	}
}


