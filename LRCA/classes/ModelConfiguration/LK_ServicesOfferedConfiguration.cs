
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class LK_ServicesOfferedConfiguration : EntityTypeConfiguration<LK_ServicesOffered>
    {
	
		 public LK_ServicesOfferedConfiguration()
        {
            ToTable("tbl_LK_ServicesOffered");
			HasKey(t => t.ServiceOfferId);
			Property(t => t.ServiceOfferId).HasColumnName("ServiceOfferId")
					.HasColumnOrder(1)
					.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		Property(t => t.ServiceOffered).HasColumnName("ServiceOffered").HasMaxLength(255).IsOptional(); 
		Property(t => t.Status).HasColumnName("Status"); 
        }
	}
}
		
		
