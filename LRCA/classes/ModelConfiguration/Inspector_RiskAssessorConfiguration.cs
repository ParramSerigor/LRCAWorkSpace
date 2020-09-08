
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class Inspector_RiskAssessorConfiguration : DomainObjectConfiguration<Inspector_RiskAssessor>
	{

		public Inspector_RiskAssessorConfiguration() : base("InspectorRiskAssId")
		{
			ToTable("tbl_Inspector_RiskAssessor");
			Property(t => t.InspectorFirstName).HasColumnName("InspectorFirstName").HasMaxLength(155).IsOptional();
			Property(t => t.InspectorMiddleName).HasColumnName("InspectorMiddleName").HasMaxLength(155).IsOptional();
			Property(t => t.InspectorLastName).HasColumnName("InspectorLastName").HasMaxLength(155).IsOptional();
			Property(t => t.Suffix).HasColumnName("Suffix").HasMaxLength(55).IsOptional();
			Property(t => t.InspectorPhone).HasColumnName("InspectorPhone").HasMaxLength(55).IsOptional();
			Property(t => t.InspectorEmail).HasColumnName("InspectorEmail").HasMaxLength(55).IsOptional();
			Property(t => t.InspectorDOB).HasColumnName("InspectorDOB");
			Property(t => t.InspectorSSN).HasColumnName("InspectorSSN");
			Property(t => t.IsRenewal).HasColumnName("IsRenewal");
			Property(t => t.AccreditationID).HasColumnName("AccreditationID").HasMaxLength(55).IsOptional();
			Property(t => t.AccreditationExpirationDate).HasColumnName("AccreditationExpirationDate");
			Property(t => t.ACRDCatID).HasColumnName("ACRDCatID");
			Property(t => t.ThirdPartyExamDate).HasColumnName("ThirdPartyExamDate");
			Property(t => t.OneYearMinExperience_Start).HasColumnName("OneYearMinExperience_Start");
			Property(t => t.OneYearMinExperience_End).HasColumnName("OneYearMinExperience_End");
			Property(t => t.InspectorTechThirdPartyExamDate).HasColumnName("InspectorTechThirdPartyExamDate");
			Property(t => t.InspectorTechAccreditationId).HasColumnName("InspectorTechAccreditationId").HasMaxLength(55).IsOptional();
			Property(t => t.Waiver).HasColumnName("Waiver");
			Property(t => t.CourseTrainingCardNum).HasColumnName("CourseTrainingCardNum").HasMaxLength(55).IsOptional();
			Property(t => t.CourseExpirationDate).HasColumnName("CourseExpirationDate").HasMaxLength(55).IsOptional();
			Property(t => t.CourseTPName).HasColumnName("CourseTPName").HasMaxLength(155).IsOptional();
			Property(t => t.CourseName).HasColumnName("CourseName").HasMaxLength(155).IsOptional();
			Property(t => t.CourseStartDate).HasColumnName("CourseStartDate");
			Property(t => t.CourseEndDate).HasColumnName("CourseEndDate");
			Property(t => t.InspectorContractorName).HasColumnName("InspectorContractorName").HasMaxLength(255).IsOptional();
			Property(t => t.InspectorContractorAcctNum).HasColumnName("InspectorContractorAcctNum").HasMaxLength(55).IsOptional();
			Property(t => t.InspectorContractor_Address_Line_1).HasColumnName("InspectorContractor_Address_Line_1").HasMaxLength(255).IsOptional();
			Property(t => t.InspectorContractor_Address_Line_2).HasColumnName("InspectorContractor_Address_Line_2").HasMaxLength(255).IsOptional();
			Property(t => t.InspectorContractor_City).HasColumnName("InspectorContractor_City").HasMaxLength(255).IsOptional();
			Property(t => t.InspectorContractor_State).HasColumnName("InspectorContractor_State").HasMaxLength(55).IsOptional();
			Property(t => t.InspectorContractor_ZipCode).HasColumnName("InspectorContractor_ZipCode").HasMaxLength(55).IsOptional();
			Property(t => t.InspectorContractor_City_2).HasColumnName("InspectorContractor_City_2").HasMaxLength(55).IsOptional();
			Property(t => t.InspectorContractor_State_2).HasColumnName("InspectorContractor_State_2").HasMaxLength(55).IsOptional();
			Property(t => t.InspectorContractor_ZipCode_2).HasColumnName("InspectorContractor_ZipCode_2").HasMaxLength(55).IsOptional();
			Property(t => t.InspectorContractor_Phone).HasColumnName("InspectorContractor_Phone").HasMaxLength(55).IsOptional();
			Property(t => t.InspectorImage).HasColumnName("InspectorImage").HasMaxLength(155).IsOptional();
			Property(t => t.InspectorContactFirstName).HasColumnName("InspectorContactFirstName").HasMaxLength(255).IsOptional();
			Property(t => t.InspectorContactLastName).HasColumnName("InspectorContactLastName").HasMaxLength(255).IsOptional();
			Property(t => t.Agreed).HasColumnName("Agreed");
			Property(t => t.RiskAssessorExperi_URL).HasColumnName("RiskAssessorExperi_URL").HasMaxLength(155).IsOptional();
			Property(t => t.CreatedDate).HasColumnName("CreatedDate");
			Property(t => t.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
			Property(t => t.UpdatedBy).HasColumnName("UpdatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasOptional(t => t.ACRDCat).WithMany().WillCascadeOnDelete(false);
			HasMany(m => m.Approvals).WithOptional(t => t.InspectorRiskAss).WillCascadeOnDelete(false);
			HasMany(m => m.Comments).WithOptional(t => t.InspectorRiskAss).WillCascadeOnDelete(false);
			HasMany(m => m.Files).WithOptional(t => t.InspectorRiskAss).WillCascadeOnDelete(false);
        }
	}
}


