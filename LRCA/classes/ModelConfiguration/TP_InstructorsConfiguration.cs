
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class TP_InstructorsConfiguration : EntityTypeConfiguration<TP_Instructors>
	{

		public TP_InstructorsConfiguration()
		{
			ToTable("tbl_TP_Instructors");
			HasKey(t => t.TP_InstructorListId);
			Property(t => t.TP_InstructorListId)
				.HasColumnName("TP_InstructorListId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.TPId).HasColumnName("TPId");
			Property(t => t.TP_InstructorFN).HasColumnName("TP_InstructorFN").HasMaxLength(255).IsOptional();
			Property(t => t.TP_InstructorLN).HasColumnName("TP_InstructorLN").HasMaxLength(255).IsOptional();
			HasOptional(t => t.TP).WithMany().WillCascadeOnDelete(false);
		}
	}
}


