
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class LK_RegionsConfiguration : EntityTypeConfiguration<LK_Regions>
    {
	
		 public LK_RegionsConfiguration()
        {
            ToTable("tbl_LK_Regions");
			HasKey(t => t.RegionId);
			Property(t => t.RegionId).HasColumnName("RegionId")
					.HasColumnOrder(1)
					.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		Property(t => t.RegionName).HasColumnName("RegionName").HasMaxLength(255).IsOptional(); 
		Property(t => t.Status).HasColumnName("Status"); 
        }
	}
}
		
		
