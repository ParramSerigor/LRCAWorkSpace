
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class LK_RiskAssessor_ExperienceConfiguration : EntityTypeConfiguration<LK_RiskAssessor_Experience>
	{

		public LK_RiskAssessor_ExperienceConfiguration()
		{
			ToTable("tbl_LK_RiskAssessor_Experience");
			HasKey(t => t.RiskAssessorExperienceId);
			Property(t => t.RiskAssessorExperienceId)
				.HasColumnName("RiskAssessorExperienceId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.RiskAssessorExperienceId).HasColumnName("RiskAssessorExperienceId");
			Property(t => t.InspectorRiskAssId).HasColumnName("InspectorRiskAssId");
			Property(t => t.Number).HasColumnName("Number").HasMaxLength(55).IsOptional();
			Property(t => t.DatePerformed).HasColumnName("DatePerformed");
			Property(t => t.Address_1).HasColumnName("Address_1").HasMaxLength(255).IsOptional();
			Property(t => t.Address_2).HasColumnName("Address_2").HasMaxLength(255).IsOptional();
			Property(t => t.City).HasColumnName("City").HasMaxLength(55).IsOptional();
			Property(t => t.State).HasColumnName("State").HasMaxLength(55).IsOptional();
			Property(t => t.Zipcode).HasColumnName("Zipcode").HasMaxLength(55).IsOptional();
			Property(t => t.TypeOfInspection).HasColumnName("TypeOfInspection").HasMaxLength(155).IsOptional();
		}
	}
}


