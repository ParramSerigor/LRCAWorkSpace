
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class Form_Experience_MapConfiguration : EntityTypeConfiguration<Form_Experience_Map>
	{

		public Form_Experience_MapConfiguration()
		{
			ToTable("tbl_Form_Experience_Map");
			HasKey(t => t.ExperienceFormMappingId);
			Property(t => t.ExperienceFormMappingId)
				.HasColumnName("ExperienceFormMappingId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.FormName).HasColumnName("FormName").HasMaxLength(55).IsOptional();
			Property(t => t.ACRDCatID).HasColumnName("ACRDCatID");
			Property(t => t.ExperienceId).HasColumnName("ExperienceId");
			HasOptional(t => t.Experience).WithMany().WillCascadeOnDelete(false);
		}
	}
}


