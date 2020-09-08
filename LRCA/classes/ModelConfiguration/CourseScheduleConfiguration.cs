
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class CourseScheduleConfiguration : DomainObjectConfiguration<CourseSchedule>
    {
	
		 public CourseScheduleConfiguration() : base("TrainingCourseScheduleId")
        {
            ToTable("tbl_CourseSchedule");
		Property(t => t.CourseId).HasColumnName("CourseId");
        Property(t => t.TPId).HasColumnName("TPId");
        Property(t => t.InstructorId).HasColumnName("InstructorId"); 
		Property(t => t.TPLocationId).HasColumnName("TPLocationId"); 
		Property(t => t.ClassTitle).HasColumnName("ClassTitle").HasMaxLength(255).IsOptional(); 
		Property(t => t.StartDate).HasColumnName("StartDate"); 
		Property(t => t.EndDate).HasColumnName("EndDate"); 
		Property(t => t.InstructionLanguage).HasColumnName("InstructionLanguage").HasMaxLength(255).IsOptional(); 
		Property(t => t.RegistrationLimit).HasColumnName("RegistrationLimit"); 
		Property(t => t.ExpectedEnrollment).HasColumnName("ExpectedEnrollment").HasMaxLength(5).IsOptional(); 
		Property(t => t.CourseCost).HasColumnName("CourseCost").HasMaxLength(55).IsOptional(); 
		Property(t => t.CourseCancelled).HasColumnName("CourseCancelled").HasMaxLength(5).IsOptional(); 
		Property(t => t.CancellationReason).HasColumnName("CancellationReason").HasMaxLength(200).IsOptional(); 
		Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional(); 
		Property(t => t.IsActive).HasColumnName("IsActive"); 
        }
	}
}
		
		
