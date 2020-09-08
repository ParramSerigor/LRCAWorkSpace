
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class ErrorLogConfiguration : EntityTypeConfiguration<ErrorLog>
    {
	
		 public ErrorLogConfiguration()
        {
            ToTable("tbl_ErrorLog");
			HasKey(t => t.errorId);
			Property(t => t.errorId)
				.HasColumnName("errorId")
				.HasColumnOrder(1)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			Property(t => t.ApplicationName).HasColumnName("ApplicationName").HasMaxLength(150).IsOptional(); 
		Property(t => t.FunctionName).HasColumnName("FunctionName").HasMaxLength(150).IsOptional(); 
		Property(t => t.errorMessage).HasColumnName("errorMessage").HasMaxLength(16).IsOptional(); 
		Property(t => t.DateGenerated).HasColumnName("DateGenerated"); 
        }
	}
}
		
		
