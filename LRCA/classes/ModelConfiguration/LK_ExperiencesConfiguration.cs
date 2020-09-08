
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class LK_ExperiencesConfiguration : EntityTypeConfiguration<LK_Experiences>
	{

		public LK_ExperiencesConfiguration()
		{
			ToTable("tbl_LK_Experiences");
			HasKey(t => t.ExperienceId);
			Property(t => t.ExperienceId)
				.HasColumnName("ExperienceId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.ExperienceId).HasColumnName("ExperienceId");
			Property(t => t.ExperienceTitle).HasColumnName("ExperienceTitle").HasMaxLength(55).IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
		}
	}
}


