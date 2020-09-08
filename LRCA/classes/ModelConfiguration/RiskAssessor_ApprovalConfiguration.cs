
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class RiskAssessor_ApprovalConfiguration : EntityTypeConfiguration<RiskAssessor_Approval>
	{

		public RiskAssessor_ApprovalConfiguration()
		{
			ToTable("tbl_RiskAssessor_Approval");
			HasKey(t => t.MDEInspRiskAssApprovalId);
			Property(t => t.MDEInspRiskAssApprovalId)
				.HasColumnName("MDEInspRiskAssApprovalId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.InspectorRiskAssId).HasColumnName("InspectorRiskAssId");
			Property(t => t.MDE_Owner_AuthorisedUserId).HasColumnName("MDE_Owner_AuthorisedUserId");
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasOptional(t => t.InspectorRiskAss).WithMany().WillCascadeOnDelete(false);
		}
	}
}


