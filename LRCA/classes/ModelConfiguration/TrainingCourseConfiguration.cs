
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class TrainingCourseConfiguration : DomainObjectConfiguration<TrainingCourse>
	{

		public TrainingCourseConfiguration() : base("TrainingCourseAppId")
		{
			ToTable("tbl_TrainingCourse");
			Property(t => t.TrainingProviderName).HasColumnName("TrainingProviderName").HasMaxLength(255).IsOptional();
			Property(t => t.TP_Address_Line_1).HasColumnName("TP_Address_Line_1").HasMaxLength(255).IsOptional();
			Property(t => t.TP_Address_Line_2).HasColumnName("TP_Address_Line_2").HasMaxLength(255).IsOptional();
			Property(t => t.TP_City).HasColumnName("TP_City").HasMaxLength(255).IsOptional();
			Property(t => t.TP_State).HasColumnName("TP_State").HasMaxLength(55).IsOptional();
			Property(t => t.TP_ZipCode).HasColumnName("TP_ZipCode").HasMaxLength(55).IsOptional();
			Property(t => t.TP_City_2).HasColumnName("TP_City_2").HasMaxLength(55).IsOptional();
			Property(t => t.TP_State_2).HasColumnName("TP_State_2").HasMaxLength(55).IsOptional();
			Property(t => t.TP_Zipcode_2).HasColumnName("TP_Zipcode_2").HasMaxLength(55).IsOptional();
			Property(t => t.TP_Telephone).HasColumnName("TP_Telephone").HasMaxLength(55).IsOptional();
			Property(t => t.TP_Fax).HasColumnName("TP_Fax").HasMaxLength(55).IsOptional();
			Property(t => t.TP_Email).HasColumnName("TP_Email").HasMaxLength(55).IsOptional();
			Property(t => t.TP_TaxID).HasColumnName("TP_TaxID");
			Property(t => t.AccreditationID).HasColumnName("AccreditationID").HasMaxLength(55).IsOptional();
			Property(t => t.AccreditationExpirationDate).HasColumnName("AccreditationExpirationDate");
			Property(t => t.TC_RiskAssessor).HasColumnName("TC_RiskAssessor");
			Property(t => t.TC_InspectorTech).HasColumnName("TC_InspectorTech");
			Property(t => t.TC_VisualInspector).HasColumnName("TC_VisualInspector");
			Property(t => t.TC_Main_Repair).HasColumnName("TC_Main_Repair");
			Property(t => t.TC_Removal).HasColumnName("TC_Removal");
			Property(t => t.TC_ProjectDesign).HasColumnName("TC_ProjectDesign");
			Property(t => t.TC_AbatementWorkerEnglish).HasColumnName("TC_AbatementWorkerEnglish");
			Property(t => t.TC_AbatementWorkerSpanish).HasColumnName("TC_AbatementWorkerSpanish");
			Property(t => t.TC_StructSteelSuper).HasColumnName("TC_StructSteelSuper");
			Property(t => t.TC_StructSteelWorker).HasColumnName("TC_StructSteelWorker");
			Property(t => t.DocURL_1).HasColumnName("DocURL_1").HasMaxLength(155).IsOptional();
			Property(t => t.DocURL_2).HasColumnName("DocURL_2").HasMaxLength(155).IsOptional();
			Property(t => t.DocURL_3).HasColumnName("DocURL_3").HasMaxLength(155).IsOptional();
			Property(t => t.DocURL_4).HasColumnName("DocURL_4").HasMaxLength(155).IsOptional();
			Property(t => t.DocURL_5).HasColumnName("DocURL_5").HasMaxLength(155).IsOptional();
			Property(t => t.TPContactFirstName).HasColumnName("TPContactFirstName").HasMaxLength(255).IsOptional();
			Property(t => t.TPContactLastName).HasColumnName("TPContactLastName").HasMaxLength(255).IsOptional();
			Property(t => t.TPContactTitle).HasColumnName("TPContactTitle").HasMaxLength(55).IsOptional();
			Property(t => t.Agreed).HasColumnName("Agreed");
			Property(t => t.CreatedDate).HasColumnName("CreatedDate");
			Property(t => t.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
			Property(t => t.UpdatedBy).HasColumnName("UpdatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
            HasMany(m => m.Approvals).WithOptional(t => t.TrainingCourseApp).WillCascadeOnDelete(false);
			HasMany(m => m.Comments).WithOptional(t => t.TrainingCourseApp).WillCascadeOnDelete(false);
			HasMany(m => m.Files).WithOptional(t => t.TrainingCourseApp).WillCascadeOnDelete(false);
		}
	}
}


