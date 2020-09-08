
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class RiskAssessor_FileConfiguration : DomainObjectConfiguration<RiskAssessor_File>
	{

		public RiskAssessor_FileConfiguration() : base("RiskAssessorFileId")
		{
			ToTable("tbl_RiskAssessor_File");
			Property(t => t.InspectorRiskAssId).HasColumnName("InspectorRiskAssId");
			Property(t => t.FileLocation).HasColumnName("FileLocation").HasMaxLength(55).IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasOptional(t => t.InspectorRiskAss).WithMany().WillCascadeOnDelete(false);
		}
	}
}


