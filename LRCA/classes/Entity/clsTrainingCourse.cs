
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsTrainingCourse
    {
		#region Public Properties
		public int? TrainingCourseAppId { get; set; }
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
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
