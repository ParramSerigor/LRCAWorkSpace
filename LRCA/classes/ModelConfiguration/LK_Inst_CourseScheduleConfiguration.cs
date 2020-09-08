
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class LK_Inst_CourseScheduleConfiguration : EntityTypeConfiguration<LK_Inst_CourseSchedule>
    {
	
		 public LK_Inst_CourseScheduleConfiguration()
        {
            ToTable("tbl_LK_Inst_CourseSchedule");
			HasKey(t => t.Inst_CourseSchId);
		Property(t => t.Inst_CourseSchId).HasColumnName("Inst_CourseSchId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); 
		Property(t => t.AuthorisedUserId).HasColumnName("AuthorisedUserId"); 
		Property(t => t.TrainingCourseScheduleId).HasColumnName("TrainingCourseScheduleId"); 
		Property(t => t.InstructorId).HasColumnName("InstructorId"); 
		Property(t => t.TP_AuthorisedUserId).HasColumnName("TP_AuthorisedUserId"); 
		Property(t => t.IsApproved).HasColumnName("IsApproved"); 
		Property(t => t.CreatedDate).HasColumnName("CreatedDate"); 
		Property(t => t.ApprovedOn).HasColumnName("ApprovedOn"); 
        }
	}
}
		
		
