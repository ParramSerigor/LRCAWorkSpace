
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class SP_ContractorConfiguration : DomainObjectConfiguration<SP_Contractor>
	{

		public SP_ContractorConfiguration() : base("SPContractorID")
		{
			ToTable("tbl_SP_Contractor");
			Property(t => t.IsRenewal).HasColumnName("IsRenewal");
			Property(t => t.ACRDCatID).HasColumnName("ACRDCatID");
			HasOptional(t => t.ACRDCat).WithMany().WillCascadeOnDelete(false);
			Property(t => t.SPName).HasColumnName("SPName").HasMaxLength(255).IsOptional();
			Property(t => t.SDATDepartmentId).HasColumnName("SDATDepartmentId").HasMaxLength(255).IsOptional();
			Property(t => t.SPTaxId).HasColumnName("SPTaxId").HasMaxLength(255).IsOptional();
			Property(t => t.SPFeeStatus).HasColumnName("SPFeeStatus").HasMaxLength(255).IsOptional();
			Property(t => t.SPMHICNumber).HasColumnName("SPMHICNumber").HasMaxLength(255).IsOptional();
			Property(t => t.AccreditationID).HasColumnName("AccreditationID").HasMaxLength(55).IsOptional();
			Property(t => t.AccreditationExpirationDate).HasColumnName("AccreditationExpirationDate");
			Property(t => t.PublishOnMDEWebsite).HasColumnName("PublishOnMDEWebsite");
			Property(t => t.SPPhone).HasColumnName("SPPhone").HasMaxLength(55).IsOptional();
			Property(t => t.SPMobile).HasColumnName("SPMobile").HasMaxLength(55).IsOptional();
			Property(t => t.SPWebSite).HasColumnName("SPWebSite").HasMaxLength(20).IsOptional();
			Property(t => t.SPEmail).HasColumnName("SPEmail").HasMaxLength(50).IsOptional();
			Property(t => t.SPLogoURL).HasColumnName("SPLogoURL").HasMaxLength(150).IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			Property(t => t.Waiver).HasColumnName("Wavier");
			Property(t => t.RepFirstName).HasColumnName("RepFirstName").HasMaxLength(50).IsOptional();
			Property(t => t.RepLastName).HasColumnName("RepLastName").HasMaxLength(50).IsOptional();
			Property(t => t.RepTitle).HasColumnName("RepTitle").HasMaxLength(50).IsOptional();
			Property(t => t.ContactFirstName).HasColumnName("ContactFirstName").HasMaxLength(50).IsOptional();
			Property(t => t.ContactLastName).HasColumnName("ContactLastName").HasMaxLength(50).IsOptional();
			Property(t => t.Agreed).HasColumnName("Agreed");
			HasMany(m => m.ContractorRegions).WithOptional(t => t.SPContractor).WillCascadeOnDelete(false);
			HasMany(m => m.ContractorServices).WithOptional(t => t.SPContractor).WillCascadeOnDelete(false);
			HasMany(m => m.ContractorAddresses).WithOptional(t => t.SPContractor).WillCascadeOnDelete(false);
			HasMany(m => m.ContractorEmpList).WithOptional(t => t.SPContractor).WillCascadeOnDelete(false);
			HasMany(m => m.ContractorComments).WithOptional(t => t.SPContractor).WillCascadeOnDelete(false);
			HasMany(m => m.ContractorFiles).WithOptional(t => t.SPContractor).WillCascadeOnDelete(false);
		}
	}
}


