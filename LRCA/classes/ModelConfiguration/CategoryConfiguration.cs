
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class CategoryConfiguration : EntityTypeConfiguration<Category>
	{

		public CategoryConfiguration()
		{
			ToTable("tbl_Category");
			HasKey(t => t.ACRDCatID);
			Property(t => t.ACRDCatID)
				.HasColumnName("ACRDCatID")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.CatTitle).HasColumnName("CatTitle").HasMaxLength(255).IsOptional();
			Property(t => t.CatDescription).HasColumnName("CatDescription").HasMaxLength(1000).IsOptional();
			Property(t => t.ACRDCategory).HasColumnName("ACRDCategory").HasMaxLength(255).IsOptional();
			Property(t => t.ValidFor).HasColumnName("ValidFor");
			Property(t => t.ThirdPartyExam).HasColumnName("ThirdPartyExam");
			Property(t => t.PassScoreReq).HasColumnName("PassScoreReq");
			Property(t => t.PassScore).HasColumnName("PassScore").HasMaxLength(55).IsOptional();
			Property(t => t.AttendanceReq).HasColumnName("AttendanceReq");
			Property(t => t.Notes).HasColumnName("Notes").HasMaxLength(8000).IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
		}
	}
}


