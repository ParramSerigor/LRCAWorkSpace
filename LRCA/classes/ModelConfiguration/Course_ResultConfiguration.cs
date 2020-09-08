
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class Course_ResultConfiguration : EntityTypeConfiguration<Course_Result>
	{

		public Course_ResultConfiguration()
		{
			ToTable("tbl_Course_Result");
			HasKey(t => t.ClassResultId);
			Property(t => t.ClassResultId)
				.HasColumnName("ClassResultId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.Inst_CourseSchId).HasColumnName("Inst_CourseSchId");
			Property(t => t.AuthorisedUserId).HasColumnName("AuthorisedUserId");
			Property(t => t.TrainingCourseScheduleId).HasColumnName("TrainingCourseScheduleId");
			Property(t => t.InstructorId).HasColumnName("InstructorId");
			Property(t => t.MDE_AuthorisedUserId).HasColumnName("MDE_AuthorisedUserId");
			Property(t => t.TPLocationId).HasColumnName("TPLocationId");
			Property(t => t.TPId).HasColumnName("TPId");
			Property(t => t.SPContractorID).HasColumnName("SPContractorID");
			Property(t => t.Inst_PASSFAIL).HasColumnName("Inst_PASSFAIL");
			Property(t => t.Inst_Attendence).HasColumnName("Inst_Attendence");
			Property(t => t.Inst_ScorePercent).HasColumnName("Inst_ScorePercent").HasMaxLength(55).IsOptional();
			Property(t => t.Inst_TrainingCard).HasColumnName("Inst_TrainingCard").HasMaxLength(255).IsOptional();
			Property(t => t.MDE_EmployerVeri).HasColumnName("MDE_EmployerVeri");
			Property(t => t.MDE_BackGround).HasColumnName("MDE_BackGround");
			Property(t => t.MDE_PaymentVeri).HasColumnName("MDE_PaymentVeri");
			Property(t => t.PaymentAmount).HasColumnName("PaymentAmount").HasMaxLength(15).IsOptional();
			Property(t => t.Acct_Term).HasColumnName("Acct_Term");
			Property(t => t.MDE_F_Decision).HasColumnName("MDE_F_Decision");
			Property(t => t.MDE_F_Notes).HasColumnName("MDE_F_Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.MDE_Acct_Certificate).HasColumnName("MDE_Acct_Certificate").HasMaxLength(255).IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
		}
	}
}


