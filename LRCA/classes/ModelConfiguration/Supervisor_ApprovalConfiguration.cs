
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class Supervisor_ApprovalConfiguration : DomainObjectConfiguration<Supervisor_Approval>
    {
	
		 public Supervisor_ApprovalConfiguration() : base("MDESuperApprId")
        {
            ToTable("tbl_Supervisor_Approval");
		Property(t => t.SupervisorId).HasColumnName("SupervisorId"); 
		Property(t => t.MDE_Owner_AuthorisedUserId).HasColumnName("MDE_Owner_AuthorisedUserId"); 
		Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional(); 
		Property(t => t.IsActive).HasColumnName("IsActive"); 
        }
	}
}
		
		
