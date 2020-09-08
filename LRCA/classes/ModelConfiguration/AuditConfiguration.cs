using LRCA.classes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LRCA.classes.ModelConfiguration
{
	public sealed class AuditConfiguration : EntityTypeConfiguration<Audit>
	{
		public AuditConfiguration()
		{
			ToTable("tbl_audit").HasKey(t => t.Id);
			Property(t => t.Id).HasColumnName("auditid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.TableName).HasColumnName("tablename").HasMaxLength(50).IsUnicode(false).IsRequired();
			Property(t => t.RecordId).HasColumnName("recordid").HasMaxLength(50).IsUnicode(false).IsRequired();
			Property(t => t.ChangeType).HasColumnName("changetype");
			Property(t => t.UserName).HasColumnName("username").HasMaxLength(30).IsRequired();
			Property(t => t.RecordedOn).HasColumnName("recordedon");
			Property(t => t.CommitId).HasColumnName("txid");
			Property(t => t.Data).HasColumnName("data").IsMaxLength().IsRequired();
		}
	}
}