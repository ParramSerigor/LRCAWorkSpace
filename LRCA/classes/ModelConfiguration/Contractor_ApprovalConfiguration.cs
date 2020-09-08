
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class Contractor_ApprovalConfiguration : DomainObjectConfiguration<Contractor_Approval>
    {
	
		 public Contractor_ApprovalConfiguration() : base("MDEContApprId")
        {
            ToTable("tbl_Contractor_Approval");
		Property(t => t.SPContractorID).HasColumnName("SPContractorID"); 
		Property(t => t.MDE_Owner_AuthorisedUserId).HasColumnName("MDE_Owner_AuthorisedUserId"); 
		Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional(); 
		Property(t => t.IsActive).HasColumnName("IsActive"); 
        }
	}
}
		
		
