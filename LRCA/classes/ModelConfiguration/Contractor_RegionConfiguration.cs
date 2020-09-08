
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class Contractor_RegionConfiguration : EntityTypeConfiguration<Contractor_Region>
	{

		public Contractor_RegionConfiguration()
		{
			ToTable("tbl_Contractor_Region");
			HasKey(t => t.ContractorRegionId);
			Property(t => t.ContractorRegionId)
				.HasColumnName("ContractorRegionId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.SPContractorID).HasColumnName("SPContractorID");
			Property(t => t.RegionId).HasColumnName("RegionId");
			HasOptional(t => t.Region).WithMany().WillCascadeOnDelete(false);
			HasOptional(t => t.SPContractor).WithMany().Map(m=>m.MapKey("SPContractorID")).WillCascadeOnDelete(false);
		}
	}
}


