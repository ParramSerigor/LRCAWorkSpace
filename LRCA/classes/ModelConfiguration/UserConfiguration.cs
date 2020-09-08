
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class UserConfiguration : DomainObjectConfiguration<User>
    {
	
		 public UserConfiguration() : base("AuthorisedUserId")
        {
            ToTable("tbl_User");
		Property(t => t.FName).HasColumnName("FName").HasMaxLength(255).IsOptional(); 
		Property(t => t.LName).HasColumnName("LName").HasMaxLength(255).IsOptional(); 
		Property(t => t.Password).HasColumnName("Password").HasMaxLength(50).IsOptional(); 
		Property(t => t.TempPassword).HasColumnName("TempPassword").HasMaxLength(50).IsOptional(); 
		Property(t => t.salt).HasColumnName("salt").HasMaxLength(50).IsOptional(); 
		Property(t => t.EmailId).HasColumnName("EmailId").HasMaxLength(255).IsOptional(); 
		Property(t => t.IsCurrent).HasColumnName("IsCurrent"); 
		Property(t => t.IndividualUserID).HasColumnName("IndividualUserID"); 
		Property(t => t.Notes).HasColumnName("Notes").HasMaxLength(8000).IsOptional(); 
		Property(t => t.ImageURL).HasColumnName("ImageURL").HasMaxLength(299).IsOptional(); 
		Property(t => t.IsAdmin).HasColumnName("IsAdmin"); 
		Property(t => t.IsActive).HasColumnName("IsActive"); 
        }
	}
}
		
		
