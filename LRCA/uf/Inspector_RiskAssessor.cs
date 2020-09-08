
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class Inspector_RiskAssessor : DomainObject
    {
		#region Public Properties
		public int? InspectorRiskAssId { get; set; }
		public string InspectorFirstName { get; set; }
		public string InspectorMiddleName { get; set; }
		public string InspectorLastName { get; set; }
		public string Suffix { get; set; }
		public string InspectorPhone { get; set; }
		public string InspectorEmail { get; set; }
		public byte[] InspectorDOB { get; set; }
		public byte[] InspectorSSN { get; set; }
		public string AccreditationID { get; set; }
		public DateTime? AccreditationExpirationDate { get; set; }
		public int? ACRDCatID { get; set; }
		public DateTime? ThirdPartyExamDate { get; set; }
		public DateTime? OneYearMinExperience_Start { get; set; }
		public DateTime? OneYearMinExperience_End { get; set; }
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
		public string InspectorImage { get; set; }
		public string InspectorContactFirstName { get; set; }
		public string InspectorContactLastName { get; set; }
		public int? Agreed { get; set; }
		public string RiskAssessorExperi_URL { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
