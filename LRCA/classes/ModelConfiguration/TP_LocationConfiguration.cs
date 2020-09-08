
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class TP_LocationConfiguration : EntityTypeConfiguration<TP_Location>
	{

		public TP_LocationConfiguration()
		{
			ToTable("tbl_TP_Location");
			HasKey(t => t.TPLocationId);
			Property(t => t.TPLocationId)
				.HasColumnName("TPLocationId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.TPId).HasColumnName("TPId");
			Property(t => t.TP_Address_Line_1).HasColumnName("TP_Address_Line_1").HasMaxLength(255).IsOptional();
			Property(t => t.TP_City).HasColumnName("TP_City").HasMaxLength(155).IsOptional();
			Property(t => t.TP_State).HasColumnName("TP_State").HasMaxLength(55).IsOptional();
			Property(t => t.TP_ZipCode).HasColumnName("TP_ZipCode").HasMaxLength(22).IsOptional();
			HasOptional(t => t.TP).WithMany().WillCascadeOnDelete(false);
		}
	}
}


