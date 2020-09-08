
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class Contractor_EmpListConfiguration : EntityTypeConfiguration<Contractor_EmpList>
	{

		public Contractor_EmpListConfiguration()
		{
			ToTable("tbl_Contractor_EmpList");
			HasKey(t => t.ContractorUserListId);
			Property(t => t.ContractorUserListId)
				.HasColumnName("ContractorUserListId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.SPContractorID).HasColumnName("SPContractorID");
			Property(t => t.EmpFName).HasColumnName("EmpFName").HasMaxLength(255).IsOptional();
			Property(t => t.EmpLName).HasColumnName("EmpLName").HasMaxLength(255).IsOptional();
			Property(t => t.AccreditedId).HasColumnName("AccreditedId").HasMaxLength(50).IsOptional();
			Property(t => t.AccreditedExpire).HasColumnName("AccreditedExpire").HasMaxLength(50).IsOptional();
			Property(t => t.IsApplying).HasColumnName("IsApplying");
			Property(t => t.ACRDCatID).HasColumnName("ACRDCatID");
			HasOptional(t => t.SPContractor).WithMany().Map(m => m.MapKey("SPContractorID")).WillCascadeOnDelete(false);
		}
	}
}


