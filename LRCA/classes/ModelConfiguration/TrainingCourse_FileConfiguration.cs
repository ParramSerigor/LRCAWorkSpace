
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class TrainingCourse_FileConfiguration : DomainObjectConfiguration<TrainingCourse_File>
	{

		public TrainingCourse_FileConfiguration() : base("TrainingCourseFileId")
		{
			ToTable("tbl_TrainingCourse_File");
			Property(t => t.TrainingCourseAppId).HasColumnName("TrainingCourseAppId");
			Property(t => t.FileLocation).HasColumnName("FileLocation").HasMaxLength(55).IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasOptional(t => t.TrainingCourseApp).WithMany().WillCascadeOnDelete(false);
		}
	}
}


