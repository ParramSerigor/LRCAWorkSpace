
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class Supervisor_CommentConfiguration : DomainObjectConfiguration<Supervisor_Comment>
	{

		public Supervisor_CommentConfiguration() : base("SupervisorCommentId")
		{
			ToTable("tbl_Supervisor_Comment");
			Property(t => t.SupervisorId).HasColumnName("SupervisorId");
			Property(t => t.Comment).HasColumnName("Comment").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasOptional(t => t.Supervisor).WithMany().WillCascadeOnDelete(false);
		}
	}
}


