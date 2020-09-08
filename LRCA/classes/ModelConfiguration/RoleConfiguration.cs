
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class RoleConfiguration : DomainObjectConfiguration<Role>
    {
	
		 public RoleConfiguration() : base("RoleId")
        {
            ToTable("tbl_Role");
		Property(t => t.MDEInternalExternal).HasColumnName("MDEInternalExternal"); 
		Property(t => t.RoleName).HasColumnName("RoleName").HasMaxLength(255).IsOptional(); 
		Property(t => t.RoleDispName).HasColumnName("RoleDispName").HasMaxLength(255).IsOptional(); 
		Property(t => t.RoleIcon).HasColumnName("RoleIcon").HasMaxLength(50).IsOptional(); 
		Property(t => t.RoleRegisterURL).HasColumnName("RoleRegisterURL").HasMaxLength(50).IsOptional(); 
		Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional(); 
		Property(t => t.DisplayOrder).HasColumnName("DisplayOrder"); 
		Property(t => t.IsActive).HasColumnName("IsActive"); 
        }
	}
}
		
		
