
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class Contractor_ServiceOfferedConfiguration : EntityTypeConfiguration<Contractor_ServiceOffered>
	{

		public Contractor_ServiceOfferedConfiguration()
		{
			ToTable("tbl_Contractor_ServiceOffered");
			HasKey(t => t.ContractorServiceOfferId);
			Property(t => t.ContractorServiceOfferId)
				.HasColumnName("ContractorServiceOfferId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.SPContractorID).HasColumnName("SPContractorID");
			Property(t => t.ServiceOfferId).HasColumnName("ServiceOfferId");
			HasOptional(t => t.ServiceOffer).WithMany().WillCascadeOnDelete(false);
			HasOptional(t => t.SPContractor).WithMany().Map(m => m.MapKey("SPContractorID")).WillCascadeOnDelete(false);
		}
	}
}


