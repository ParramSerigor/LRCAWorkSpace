
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class Instructor_CommentConfiguration : DomainObjectConfiguration<Instructor_Comment>
	{

		public Instructor_CommentConfiguration() : base("InstructorCommentId")
		{
			ToTable("tbl_Instructor_Comment");
			Property(t => t.InstructorId).HasColumnName("InstructorId");
			Property(t => t.Comment).HasColumnName("Comment").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.CreatedDate).HasColumnName("CreatedDate");
			Property(t => t.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
			Property(t => t.UpdatedBy).HasColumnName("UpdatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasOptional(t => t.Instructor).WithMany().WillCascadeOnDelete(false);
		}
	}
}


