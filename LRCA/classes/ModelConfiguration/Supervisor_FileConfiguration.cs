
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class Supervisor_FileConfiguration : DomainObjectConfiguration<Supervisor_File>
	{

		public Supervisor_FileConfiguration() : base("SupervisorFileId")
		{
			ToTable("tbl_Supervisor_File");
			Property(t => t.SupervisorId).HasColumnName("SupervisorId");
			Property(t => t.FileLocation).HasColumnName("FileLocation").HasMaxLength(55).IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasOptional(t => t.Supervisor).WithMany().WillCascadeOnDelete(false);
		}
	}
}


