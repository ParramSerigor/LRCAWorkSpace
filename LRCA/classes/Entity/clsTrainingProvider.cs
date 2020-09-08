
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsTrainingProvider
    {
		#region Public Properties
		public int? TPId { get; set; }
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
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
