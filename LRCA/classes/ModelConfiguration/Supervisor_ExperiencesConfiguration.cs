
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class Supervisor_ExperiencesConfiguration : EntityTypeConfiguration<Supervisor_Experiences>
	{

		public Supervisor_ExperiencesConfiguration()
		{
			ToTable("tbl_Supervisor_Experiences");
			HasKey(t => t.SupervisorExperienceId);
			Property(t => t.SupervisorExperienceId)
				.HasColumnName("SupervisorExperienceId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.SupervisorId).HasColumnName("SupervisorId");
			Property(t => t.ExperienceId).HasColumnName("ExperienceId");
			Property(t => t.ExperienceTitle).HasColumnName("ExperienceTitle").HasMaxLength(55).IsOptional();
			HasOptional(t => t.Supervisor).WithMany().WillCascadeOnDelete(false);
			HasOptional(t => t.Experience).WithMany().WillCascadeOnDelete(false);
		}
	}
}


