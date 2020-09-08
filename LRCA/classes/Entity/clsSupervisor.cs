
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsSupervisor
    {
		#region Public Properties
		public int? SupervisorId { get; set; }
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
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
