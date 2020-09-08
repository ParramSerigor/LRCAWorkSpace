
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class Instructor_ApprovalConfiguration : EntityTypeConfiguration<Instructor_Approval>
	{

		public Instructor_ApprovalConfiguration()
		{
			ToTable("tbl_Instructor_Approval");
			HasKey(t => t.MDEInsApprId);
			Property(t => t.MDEInsApprId)
				.HasColumnName("MDEInsApprId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.InstructorId).HasColumnName("InstructorId");
			Property(t => t.MDE_Owner_AuthorisedUserId).HasColumnName("MDE_Owner_AuthorisedUserId");
			Property(t => t.TPId).HasColumnName("TPId");
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
		}
	}
}


