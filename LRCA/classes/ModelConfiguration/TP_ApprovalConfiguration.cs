
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class TP_ApprovalConfiguration : EntityTypeConfiguration<TP_Approval>
	{

		public TP_ApprovalConfiguration()
		{
			ToTable("tbl_TP_Approval");
			HasKey(t => t.MDETPApprId);
			Property(t => t.MDETPApprId)
				.HasColumnName("MDETPApprId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.TPId).HasColumnName("TPId");
			Property(t => t.MDE_Owner_AuthorisedUserId).HasColumnName("MDE_Owner_AuthorisedUserId");
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasOptional(t => t.TP).WithMany().WillCascadeOnDelete(false);
		}
	}
}


