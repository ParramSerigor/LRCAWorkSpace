using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class TC_ApprovalConfiguration : DomainObjectConfiguration<TC_Approval>
    {
        public TC_ApprovalConfiguration() : base("MDETCourseApprId")
        {
            ToTable("tbl_TrainingCourse_Approval");
            Property(t => t.TrainingCourseAppId).HasColumnName("TrainingCourseAppId");
            Property(t => t.MDE_Owner_AuthorisedUserId).HasColumnName("MDE_Owner_AuthorisedUserId");
            Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
            Property(t => t.IsActive).HasColumnName("IsActive");
            HasOptional(t => t.TrainingCourseApp).WithMany().WillCascadeOnDelete(false);
        }
    }
}