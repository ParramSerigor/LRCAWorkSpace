
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class RequirementMasterConfiguration : DomainObjectConfiguration<RequirementMaster>
    {
	
		 public RequirementMasterConfiguration() : base("ACRDReqID")
        {
            ToTable("tbl_RequirementMaster");
		Property(t => t.ACRDRequirementName).HasColumnName("ACRDRequirementName").HasMaxLength(255).IsOptional(); 
		Property(t => t.ReqDescription).HasColumnName("ReqDescription").HasMaxLength(5000).IsOptional(); 
		Property(t => t.ReqDisplayText).HasColumnName("ReqDisplayText").HasMaxLength(8000).IsOptional(); 
		Property(t => t.ReqEnforcement).HasColumnName("ReqEnforcement").HasMaxLength(8000).IsOptional(); 
		Property(t => t.Notes).HasColumnName("Notes").HasMaxLength(8000).IsOptional(); 
		Property(t => t.IsActive).HasColumnName("IsActive"); 
        }
	}
}
		
		
