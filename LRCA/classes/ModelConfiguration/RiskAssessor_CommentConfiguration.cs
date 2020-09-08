
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class RiskAssessor_CommentConfiguration : DomainObjectConfiguration<RiskAssessor_Comment>
	{

		public RiskAssessor_CommentConfiguration() : base("RiskAssessorCommentId")
		{
			ToTable("tbl_RiskAssessor_Comment");
			Property(t => t.InspectorRiskAssId).HasColumnName("InspectorRiskAssId");
			Property(t => t.Comment).HasColumnName("Comment").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasOptional(t => t.InspectorRiskAss).WithMany().WillCascadeOnDelete(false);
		}
	}
}


