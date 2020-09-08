
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class CourseConfiguration : DomainObjectConfiguration<Course>
    {
	
		 public CourseConfiguration() : base("TrainingCourseId")
        {
            ToTable("tbl_Course");
		Property(t => t.TPId).HasColumnName("TPId"); 
		Property(t => t.CourseTitle).HasColumnName("CourseTitle").HasMaxLength(255).IsOptional(); 
		Property(t => t.ACRDCatID).HasColumnName("ACRDCatID"); 
		Property(t => t.InstructionLanguage).HasColumnName("InstructionLanguage").HasMaxLength(255).IsOptional(); 
		Property(t => t.CourseDuration).HasColumnName("CourseDuration").HasMaxLength(255).IsOptional(); 
		Property(t => t.MeasurementUnit).HasColumnName("MeasurementUnit").HasMaxLength(255).IsOptional(); 
		Property(t => t.InitialOrRenewal).HasColumnName("InitialOrRenewal").HasMaxLength(255).IsOptional(); 
		Property(t => t.AttendanceRequirement).HasColumnName("AttendanceRequirement").HasMaxLength(55).IsOptional(); 
		Property(t => t.PassScore).HasColumnName("PassScore").HasMaxLength(55).IsOptional(); 
		Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional(); 
		Property(t => t.IsActive).HasColumnName("IsActive"); 
        }
	}
}
		
		
