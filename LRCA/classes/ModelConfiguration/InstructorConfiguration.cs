
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
	public class InstructorConfiguration : DomainObjectConfiguration<Instructor>
	{

		public InstructorConfiguration() : base("InstructorId")
		{
			ToTable("tbl_Instructor");
			Property(t => t.Instructor_FName).HasColumnName("Instructor_FName").HasMaxLength(255).IsOptional();
			Property(t => t.Instructor_MName).HasColumnName("Instructor_MName").HasMaxLength(255).IsOptional();
			Property(t => t.Instructor_LName).HasColumnName("Instructor_LName").HasMaxLength(255).IsOptional();
			Property(t => t.Instructor_Suffix).HasColumnName("Instructor_Suffix").HasMaxLength(55).IsOptional();
			Property(t => t.Instructor_Address_Line_1).HasColumnName("Instructor_Address_Line_1").HasMaxLength(255).IsOptional();
			Property(t => t.Instructor_Address_Line_2).HasColumnName("Instructor_Address_Line_2").HasMaxLength(255).IsOptional();
			Property(t => t.Instructor_City).HasColumnName("Instructor_City").HasMaxLength(255).IsOptional();
			Property(t => t.Instructor_State).HasColumnName("Instructor_State").HasMaxLength(55).IsOptional();
			Property(t => t.Instructor_ZipCode).HasColumnName("Instructor_ZipCode").HasMaxLength(55).IsOptional();
			Property(t => t.Instructor_City_2).HasColumnName("Instructor_City_2").HasMaxLength(255).IsOptional();
			Property(t => t.Instructor_State_2).HasColumnName("Instructor_State_2").HasMaxLength(55).IsOptional();
			Property(t => t.Instructor_ZipCode_2).HasColumnName("Instructor_ZipCode_2").HasMaxLength(55).IsOptional();
			Property(t => t.Instructor_Phone).HasColumnName("Instructor_Phone").HasMaxLength(55).IsOptional();
			Property(t => t.Instructor_Email).HasColumnName("Instructor_Email").HasMaxLength(155).IsOptional();
			Property(t => t.Instructor_DOB).HasColumnName("Instructor_DOB");
			Property(t => t.Instructor_SSN).HasColumnName("Instructor_SSN");
			Property(t => t.TP_Name).HasColumnName("TP_Name").HasMaxLength(255).IsOptional();
			Property(t => t.TP_AcctNumber).HasColumnName("TP_AcctNumber").HasMaxLength(55).IsOptional();
			Property(t => t.TP_Contact_FName).HasColumnName("TP_Contact_FName").HasMaxLength(255).IsOptional();
			Property(t => t.TP_Contact_LName).HasColumnName("TP_Contact_LName").HasMaxLength(255).IsOptional();
			Property(t => t.TP_Telephone).HasColumnName("TP_Telephone").HasMaxLength(55).IsOptional();
			Property(t => t.TP_Address_Line_1).HasColumnName("TP_Address_Line_1").HasMaxLength(255).IsOptional();
			Property(t => t.TP_City).HasColumnName("TP_City").HasMaxLength(255).IsOptional();
			Property(t => t.TP_State).HasColumnName("TP_State").HasMaxLength(55).IsOptional();
			Property(t => t.TP_ZipCode).HasColumnName("TP_ZipCode").HasMaxLength(55).IsOptional();
			Property(t => t.IsRenewal).HasColumnName("IsRenewal");
			Property(t => t.AccreditationID).HasColumnName("AccreditationID").HasMaxLength(55).IsOptional();
			Property(t => t.AccreditationExpirationDate).HasColumnName("AccreditationExpirationDate");
			Property(t => t.ACRDCatID).HasColumnName("ACRDCatID");
			HasOptional(t => t.ACRDCat).WithMany().WillCascadeOnDelete(false);
			Property(t => t.NewInitialTCard).HasColumnName("NewInitialTCard").HasMaxLength(55).IsOptional();
			Property(t => t.NewIT_StartDates).HasColumnName("NewIT_StartDates");
			Property(t => t.NewIT_EndDates).HasColumnName("NewIT_EndDates");
			Property(t => t.RenewalTCard).HasColumnName("RenewalTCard").HasMaxLength(55).IsOptional();
			Property(t => t.RenewalLT_StartDates).HasColumnName("RenewalLT_StartDates");
			Property(t => t.RenewalLT_EndDates).HasColumnName("RenewalLT_EndDates");
			Property(t => t.NewInstructors_URL).HasColumnName("NewInstructors_URL").HasMaxLength(255).IsOptional();
			Property(t => t.NewRenewal_InspecTech_AcctNumber).HasColumnName("NewRenewal_InspecTech_AcctNumber").HasMaxLength(55).IsOptional();
			Property(t => t.NewRenewal_InspecTech_AcctExpiration).HasColumnName("NewRenewal_InspecTech_AcctExpiration").HasMaxLength(55).IsOptional();
			Property(t => t.NewInspectorTechnInstructors_URL).HasColumnName("NewInspectorTechnInstructors_URL").HasMaxLength(255).IsOptional();
			Property(t => t.Agreed).HasColumnName("Agreed");
			Property(t => t.Instructor_Image).HasColumnName("Instructor_Image").HasMaxLength(255).IsOptional();
			Property(t => t.CreatedDate).HasColumnName("CreatedDate");
			Property(t => t.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
			Property(t => t.UpdatedBy).HasColumnName("UpdatedBy").HasMaxLength(255).IsOptional();
			Property(t => t.Notes).HasColumnName("Notes").HasColumnType("varchar(max)").IsOptional();
			Property(t => t.IsActive).HasColumnName("IsActive");
			HasMany(m => m.Approvals).WithOptional(t => t.Instructor).WillCascadeOnDelete(false);
			HasMany(m => m.Comments).WithOptional(t => t.Instructor).WillCascadeOnDelete(false);
			HasMany(m => m.Files).WithOptional(t => t.Instructor).WillCascadeOnDelete(false);
		}
	}
}


