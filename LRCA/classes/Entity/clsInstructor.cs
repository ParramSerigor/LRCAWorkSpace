
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsInstructor
    {
		#region Public Properties
		public int? InstructorId { get; set; }
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
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
