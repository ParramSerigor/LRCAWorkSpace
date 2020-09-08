
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class SignOnLogConfiguration : EntityTypeConfiguration<SignOnLog>
    {
	
		 public SignOnLogConfiguration()
        {
            ToTable("tbl_SignOnLog");
			HasKey(t => t.SigninId);
			Property(t => t.SigninId).HasColumnName("SigninId")
					.HasColumnOrder(1)
					.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		Property(t => t.AuthorisedUserId).HasColumnName("AuthorisedUserId"); 
		Property(t => t.SignedOn).HasColumnName("SignedOn"); 
        }
	}
}
		
		
