
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class SupervisorConfiguration : DomainObjectConfiguration<Supervisor>
	{

		public SupervisorConfiguration() : base("SupervisorId")
		{
			ToTable("tbl_Supervisor");
			Property(t => t.SupervisorFirstName).HasColumnName("SupervisorFirstName").HasMaxLength(155).IsOptional();
			Property(t => t.SupervisorMiddleName).HasColumnName("SupervisorMiddleName").HasMaxLength(155).IsOptional();
			Property(t => t.SupervisorLastName).HasColumnName("SupervisorLastName").HasMaxLength(155).IsOptional();
			Property(t => t.SupervisorSuffix).HasColumnName("SupervisorSuffix").HasMaxLength(55).IsOptional();
			Property(t => t.Supervisor_Address_Line_1).HasColumnName("Supervisor_Address_Line_1").HasMaxLength(255).IsOptional();
			Property(t => t.Supervisor_Address_Line_2).HasColumnName("Supervisor_Address_Line_2").HasMaxLength(255).IsOptional();
			Property(t => t.Supervisor_City).HasColumnName("Supervisor_City").HasMaxLength(255).IsOptional();
			Property(t => t.Supervisor_State).HasColumnName("Supervisor_State").HasMaxLength(55).IsOptional();
			Property(t => t.Supervisor_ZipCode).HasColumnName("Supervisor_ZipCode").HasMaxLength(55).IsOptional();
			Property(t => t.Supervisor_City_2).HasColumnName("Supervisor_City_2").HasMaxLength(255).IsOptional();
			Property(t => t.Supervisor_State_2).HasColumnName("Supervisor_State_2").HasMaxLength(55).IsOptional();
			Property(t => t.Supervisor_ZipCode_2).HasColumnName("Supervisor_ZipCode_2").HasMaxLength(55).IsOptional();
			Property(t => t.SupervisorPhone).HasColumnName("SupervisorPhone").HasMaxLength(55).IsOptional();
			Property(t => t.SupervisorEmail).HasColumnName("SupervisorEmail").HasMaxLength(55).IsOptional();
			Property(t => t.SupervisorDOB).HasColumnName("SupervisorDOB");
			Property(t => t.SupervisorSSN).HasColumnName("SupervisorSSN");
			Property(t => t.IsRenewal).HasColumnName("IsRenewal");
			Property(t => t.AccreditationID).HasColumnName("AccreditationID").HasMaxLength(55).IsOptional();
			Property(t => t.AccreditationExpirationDate).HasColumnName("AccreditationExpirationDate");
			Property(t => t.ACRDCatID).HasColumnName("ACRDCatID");
			Property(t => t.TwoYearMinExperience_Start).HasColumnName("TwoYearMinExperience_Start");
			Property(t => t.TwoYearMinExperience_End).HasColumnName("TwoYearMinExperience_End");
			Property(t => t.ThirdPartyExamDate).HasColumnName("ThirdPartyExamDate");
			Property(t => t.EmployerNames).HasColumnName("EmployerNames").HasMaxLength(55).IsOptional();
			Property(t => t.SixMonthsMinExperience_Start).HasColumnName("SixMonthsMinExperience_Start");
			Property(t => t.SixMonthsMinExperience_End).HasColumnName("SixMonthsMinExperience_End");
			Property(t => t.Waiver).HasColumnName("Waiver");
			Property(t => t.CourseTrainingCardNum).HasColumnName("CourseTrainingCardNum").HasMaxLength(55).IsOptional();
			Property(t => t.CourseExpirationDate).HasColumnName("CourseExpirationDate").HasMaxLength(55).IsOptional();
			Property(t => t.CourseTPName).HasColumnName("CourseTPName").HasMaxLength(155).IsOptional();
			Property(t => t.CourseCatName).HasColumnName("CourseCatName").HasMaxLength(155).IsOptional();
			Property(t => t.CourseStartDate).HasColumnName("CourseStartDate");
			Property(t => t.CourseEndDate).HasColumnName("CourseEndDate");
			Property(t => t.SupervisorContractorName).HasColumnName("SupervisorContractorName").HasMaxLength(255).IsOptional();
			Property(t => t.SupervisorContractorAcctNum).HasColumnName("SupervisorContractorAcctNum").HasMaxLength(55).IsOptional();
			Property(t => t.SupervisorContractor_Address_Line_1).HasColumnName("SupervisorContractor_Address_Line_1").HasMaxLength(255).IsOptional();
			Property(t => t.SupervisorContractor_Address_Line_2).HasColumnName("SupervisorContractor_Address_Line_2").HasMaxLength(255).IsOptional();
			Property(t => t.SupervisorContractor_City).HasColumnName("SupervisorContractor_City").HasMaxLength(255).IsOptional();
			Property(t => t.SupervisorContractor_State).HasColumnName("SupervisorContractor_State").HasMaxLength(55).IsOptional();
			Property(t => t.SupervisorContractor_ZipCode).HasColumnName("SupervisorContractor_ZipCode").HasMaxLength(55).IsOptional();
			Property(t => t.SupervisorContractor_Phone).HasColumnName("SupervisorContractor_Phone").HasMaxLength(55).IsOptional();
			Property(t => t.SupervisorImage).HasColumnName("SupervisorImage").HasMaxLength(155).IsOptional();
			Property(t => t.SupervisorContactFirstName).HasColumnName("SupervisorContactFirstName").HasMaxLength(255).IsOptional();
			Property(t => t.SupervisorContactLastName).HasColumnName("SupervisorContactLastName").HasMaxLength(255).IsOptional();
			Property(t => t.Agreed).HasColumnName("Agreed");
			Property(t => t.CreatedDate).HasColumnName("CreatedDate");
			Property(t => t.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
			Property(t => t.UpdatedBy).HasColumnName("UpdatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasMany(m => m.SupervisorExperiences).WithOptional(t => t.Supervisor).WillCascadeOnDelete(false);
			HasMany(m => m.Comments).WithOptional(t => t.Supervisor).WillCascadeOnDelete(false);
			HasMany(m => m.Files).WithOptional(t => t.Supervisor).WillCascadeOnDelete(false);
		}
	}
}


