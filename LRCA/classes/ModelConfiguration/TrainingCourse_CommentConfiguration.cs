
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class TrainingCourse_CommentConfiguration : DomainObjectConfiguration<TrainingCourse_Comment>
	{

		public TrainingCourse_CommentConfiguration() : base("TrainingCourseCommentId")
		{
			ToTable("tbl_TrainingCourse_Comment");
			Property(t => t.TrainingCourseAppId).HasColumnName("TrainingCourseAppId");
			Property(t => t.Comment).HasColumnName("Comment").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasOptional(t => t.TrainingCourseApp).WithMany().WillCascadeOnDelete(false);
		}
	}
}


