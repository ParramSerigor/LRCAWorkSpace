
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class Contractor_AddressConfiguration : EntityTypeConfiguration<Contractor_Address>
	{

		public Contractor_AddressConfiguration()
		{
			ToTable("tbl_Contractor_Address");
			HasKey(t => t.ContractorAddressId);
			Property(t => t.ContractorAddressId)
				.HasColumnName("ContractorAddressId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.SPContractorID).HasColumnName("SPContractorID");
			Property(t => t.AddressType).HasColumnName("AddressType");
			Property(t => t.Address_Line_1).HasColumnName("Address_Line_1").HasMaxLength(255).IsOptional();
			Property(t => t.Address_Line_2).HasColumnName("Address_Line_2").HasMaxLength(255).IsOptional();
			Property(t => t.City).HasColumnName("City").HasMaxLength(255).IsOptional();
			Property(t => t.State).HasColumnName("State").HasMaxLength(55).IsOptional();
			Property(t => t.ZipCode).HasColumnName("ZipCode").HasMaxLength(55).IsOptional();
			Property(t => t.PublicListing).HasColumnName("PublicListing");
			HasOptional(t => t.SPContractor).WithMany().Map(m => m.MapKey("SPContractorID")).WillCascadeOnDelete(false);
		}
	}
}


