
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class TP_CommentConfiguration : DomainObjectConfiguration<TP_Comment>
	{

		public TP_CommentConfiguration() : base("TPCommentId")
		{
			ToTable("tbl_TP_Comment");
			Property(t => t.TPId).HasColumnName("TPId");
			Property(t => t.Comment).HasColumnName("Comment").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasOptional(t => t.TP).WithMany().Map(m => m.MapKey("TPId")).WillCascadeOnDelete(false);
		}
	}
}


