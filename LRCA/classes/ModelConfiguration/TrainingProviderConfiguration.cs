
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class TrainingProviderConfiguration : DomainObjectConfiguration<TrainingProvider>
	{

		public TrainingProviderConfiguration() : base("TPId")
		{
			ToTable("tbl_TrainingProvider");
			Property(t => t.TP_Name).HasColumnName("TP_Name").HasMaxLength(255).IsOptional();
			Property(t => t.TP_WebSite).HasColumnName("TP_WebSite").HasMaxLength(255).IsOptional();
			Property(t => t.TP_Address_Line_1).HasColumnName("TP_Address_Line_1").HasMaxLength(255).IsOptional();
			Property(t => t.TP_Address_Line_2).HasColumnName("TP_Address_Line_2").HasMaxLength(255).IsOptional();
			Property(t => t.TP_City).HasColumnName("TP_City").HasMaxLength(255).IsOptional();
			Property(t => t.TP_State).HasColumnName("TP_State").HasMaxLength(55).IsOptional();
			Property(t => t.TP_ZipCode).HasColumnName("TP_ZipCode").HasMaxLength(55).IsOptional();
			Property(t => t.TP_City_2).HasColumnName("TP_City_2").HasMaxLength(255).IsOptional();
			Property(t => t.TP_State_2).HasColumnName("TP_State_2").HasMaxLength(55).IsOptional();
			Property(t => t.TP_Zipcode_2).HasColumnName("TP_Zipcode_2").HasMaxLength(55).IsOptional();
			Property(t => t.TP_Telephone).HasColumnName("TP_Telephone").HasMaxLength(55).IsOptional();
			Property(t => t.TP_Fax).HasColumnName("TP_Fax").HasMaxLength(55).IsOptional();
			Property(t => t.TP_Email).HasColumnName("TP_Email").HasMaxLength(55).IsOptional();
			Property(t => t.TP_PublicList).HasColumnName("TP_PublicList");
			Property(t => t.TP_SDAT).HasColumnName("TP_SDAT").HasMaxLength(55).IsOptional();
			Property(t => t.TP_TaxID).HasColumnName("TP_TaxID");
			Property(t => t.AccreditationID).HasColumnName("AccreditationID").HasMaxLength(55).IsOptional();
			Property(t => t.AccreditationExpirationDate).HasColumnName("AccreditationExpirationDate");
			Property(t => t.TP_Fee).HasColumnName("TP_Fee");
			Property(t => t.TP_TaxExempt).HasColumnName("TP_TaxExempt").HasMaxLength(55).IsOptional();
			Property(t => t.MDE_Advertise_URL).HasColumnName("MDE_Advertise_URL").HasMaxLength(255).IsOptional();
			Property(t => t.RiskAssessor).HasColumnName("RiskAssessor");
			Property(t => t.InspectorTech).HasColumnName("InspectorTech");
			Property(t => t.VisualInspector).HasColumnName("VisualInspector");
			Property(t => t.MainRepaint).HasColumnName("MainRepaint");
			Property(t => t.RemovalDemo).HasColumnName("RemovalDemo");
			Property(t => t.ProjectDesign).HasColumnName("ProjectDesign");
			Property(t => t.AbatWorkerEnglish).HasColumnName("AbatWorkerEnglish");
			Property(t => t.AbatWorkerSpanish).HasColumnName("AbatWorkerSpanish");
			Property(t => t.StructSteelSupervisor).HasColumnName("StructSteelSupervisor");
			Property(t => t.StructSteelWorker).HasColumnName("StructSteelWorker");
			Property(t => t.TPContactFirstName).HasColumnName("TPContactFirstName").HasMaxLength(255).IsOptional();
			Property(t => t.TPContactLastName).HasColumnName("TPContactLastName").HasMaxLength(255).IsOptional();
			Property(t => t.TPContactTitle).HasColumnName("TPContactTitle").HasMaxLength(55).IsOptional();
			Property(t => t.TPwebsiteVal).HasColumnName("TPwebsiteVal");
			Property(t => t.TPWebsiteURL).HasColumnName("TPWebsiteURL").HasMaxLength(255).IsOptional();
			Property(t => t.IsRenewal).HasColumnName("IsRenewal");
			Property(t => t.Agreed).HasColumnName("Agreed");
			Property(t => t.TP_Logo_URL).HasColumnName("TP_Logo_URL").HasMaxLength(55).IsOptional();
			Property(t => t.CreatedDate).HasColumnName("CreatedDate");
			Property(t => t.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
			Property(t => t.UpdatedBy).HasColumnName("UpdatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasMany(m => m.Approvals).WithOptional(t => t.TP).WillCascadeOnDelete(false);
			HasMany(m => m.Instructors).WithOptional(t => t.TP).WillCascadeOnDelete(false);
			HasMany(m => m.Locations).WithOptional(t => t.TP).WillCascadeOnDelete(false);
			HasMany(m => m.Comments).WithOptional(t => t.TP).WillCascadeOnDelete(false);
			HasMany(m => m.Files).WithOptional(t => t.TP).WillCascadeOnDelete(false);
		}
	}
}


