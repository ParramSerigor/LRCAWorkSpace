
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class Evidence_Contractor_ApprovalConfiguration : DomainObjectConfiguration<Evidence_Contractor_Approval>
    {
	
		 public Evidence_Contractor_ApprovalConfiguration() : base("ContractorEvidenceId")
        {
            ToTable("tbl_Evidence_Contractor_Approval");
		Property(t => t.SPContractorID).HasColumnName("SPContractorID"); 
		Property(t => t.FormatType).HasColumnName("FormatType").HasMaxLength(55).IsOptional(); 
		Property(t => t.EvidenceLocation).HasColumnName("EvidenceLocation").HasMaxLength(155).IsOptional(); 
		Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional(); 
        }
	}
}
		
		
