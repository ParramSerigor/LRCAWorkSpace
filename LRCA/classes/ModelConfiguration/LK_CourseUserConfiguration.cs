
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class LK_CourseUserConfiguration : DomainObjectConfiguration<LK_CourseUser>
    {
	
		 public LK_CourseUserConfiguration() : base("CourseUserMapID")
        {
            ToTable("tbl_LK_CourseUser");
		Property(t => t.TrainingCourseScheduleID).HasColumnName("TrainingCourseScheduleID"); 
		Property(t => t.IndividualUserID).HasColumnName("IndividualUserID").HasColumnType("varchar(max)").IsOptional(); 
		Property(t => t.TrainingProviderAcceptance).HasColumnName("TrainingProviderAcceptance").HasMaxLength(10).IsOptional(); 
		Property(t => t.Notes).HasColumnName("Notes").HasMaxLength(8000).IsOptional(); 
		Property(t => t.IsActive).HasColumnName("IsActive"); 
        }
	}
}
		
		
