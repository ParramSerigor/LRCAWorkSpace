
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class UserSecurityQuestionConfiguration : EntityTypeConfiguration<UserSecurityQuestion>
    {
	
		 public UserSecurityQuestionConfiguration()
        {
            ToTable("tbl_UserSecurityQuestion");
			HasKey(t => t.UserSecurityQuestionId);
			Property(t => t.UserSecurityQuestionId).HasColumnName("UserSecurityQuestionId")
					.HasColumnOrder(1)
					.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		Property(t => t.SecurityQuestionId).HasColumnName("SecurityQuestionId"); 
		Property(t => t.AuthorisedUserId).HasColumnName("AuthorisedUserId"); 
		Property(t => t.UserAnswer).HasColumnName("UserAnswer").HasMaxLength(255).IsOptional(); 
		Property(t => t.IsActive).HasColumnName("IsActive"); 
		Property(t => t.CreatedDate).HasColumnName("CreatedDate"); 
		Property(t => t.UpdatedDate).HasColumnName("UpdatedDate"); 
        }
	}
}
		
		
