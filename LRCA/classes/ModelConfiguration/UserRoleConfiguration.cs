
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class UserRoleConfiguration : DomainObjectConfiguration<UserRole>
    {
	
		 public UserRoleConfiguration() : base("UserRoleId")
        {
            ToTable("tbl_UserRole");
		Property(t => t.RoleId).HasColumnName("RoleId"); 
		Property(t => t.AuthorizedUserId).HasColumnName("AuthorizedUserId"); 
		Property(t => t.IsActive).HasColumnName("IsActive"); 
		Property(t => t.Notes).HasColumnName("Notes").HasMaxLength(8000).IsOptional(); 
        }
	}
}
		
		
