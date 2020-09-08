
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsLK_AccdRules
    {
		#region Public Properties
		public int? AccdRulesId { get; set; }
		public int? ACRDCatID { get; set; }
		public int? AccdRequired { get; set; }
		public int? TrainingRequiredForNewApplicant { get; set; }
		public int? TrainingRequiredForRenewalApplicant { get; set; }
		public int? AdditionalExamRequiredForNewApplicant { get; set; }
		public int? AdditionalExamRequiredForRenewalApplicant { get; set; }
		public int? EmployerVerificationRequired { get; set; }
		public int? DifferentPathForOutOfStateAccredited { get; set; }
		public string TrainingRequiredForOutOfState { get; set; }
		public int? ExamRequiredForOutOfState { get; set; }
		public Decimal CertificationValidity { get; set; }
		public string CertificationValidityMeasure { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
