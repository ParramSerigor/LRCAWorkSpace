
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class Contractor_FileConfiguration : DomainObjectConfiguration<Contractor_File>
	{

		public Contractor_FileConfiguration() : base("ContractorFileId")
		{
			ToTable("tbl_Contractor_File");
			Property(t => t.SPContractorID).HasColumnName("SPContractorID");
			Property(t => t.FileLocation).HasColumnName("FileLocation").HasMaxLength(55).IsOptional();
			Property(t => t.CreatedDate).HasColumnName("CreatedDate");
			Property(t => t.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
			Property(t => t.UpdatedBy).HasColumnName("UpdatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasOptional(t => t.SPContractor).WithMany().Map(m => m.MapKey("SPContractorID")).WillCascadeOnDelete(false);
		}
	}
}


