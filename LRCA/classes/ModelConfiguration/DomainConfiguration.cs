using LRCA.classes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LRCA.classes.ModelConfiguration
{
	public abstract class DomainObjectConfiguration<T> : EntityTypeConfiguration<T> where T : DomainObject
	{
		protected DomainObjectConfiguration(string columnNamePrefix)
		{
			HasKey(t => t.Id);
			Property(t => t.Id)
				.HasColumnName(columnNamePrefix)
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.CreatedDate)
				.HasColumnName("createddate")
				.HasColumnOrder(2);
			Property(t => t.CreatedBy)
				.HasColumnName("createdby")
				.HasColumnOrder(3)
				.HasMaxLength(30)
				.IsRequired();
			Property(t => t.UpdatedDate)
				.HasColumnName("updateddate")
				.HasColumnOrder(4);
			Property(t => t.UpdatedBy)
				.HasColumnName("updatedby")
				.HasColumnOrder(5)
				.HasMaxLength(30)
				.IsRequired();
		}
	}
}