
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class LK_Contractor_UserConfiguration : EntityTypeConfiguration<LK_Contractor_User>
    {
	
		 public LK_Contractor_UserConfiguration()
        {
            ToTable("tbl_LK_Contractor_User");
			HasKey(t => t.ContractorUserId);
		Property(t => t.ContractorUserId).HasColumnName("ContractorUserId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		Property(t => t.AuthorisedUserId).HasColumnName("AuthorisedUserId"); 
		Property(t => t.SPContractorID).HasColumnName("SPContractorID"); 
        }
	}
}
		
		
