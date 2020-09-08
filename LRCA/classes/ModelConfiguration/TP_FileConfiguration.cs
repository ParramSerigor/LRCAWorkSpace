
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class TP_FileConfiguration : DomainObjectConfiguration<TP_File>
	{

		public TP_FileConfiguration() : base("TPFileId")
		{
			ToTable("tbl_TP_File");
			Property(t => t.TPId).HasColumnName("TPId");
			Property(t => t.FileLocation).HasColumnName("FileLocation").HasMaxLength(55).IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasOptional(t => t.TP).WithMany().Map(m => m.MapKey("TPId")).WillCascadeOnDelete(false);
		}
	}
}


