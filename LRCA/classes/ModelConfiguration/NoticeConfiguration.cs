
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using LRCA.classes.Models;

namespace LRCA.classes.ModelConfiguration
{
    public class NoticeConfiguration : EntityTypeConfiguration<Notice>
    {
	
		 public NoticeConfiguration()
        {
            ToTable("tbl_Notice");
			HasKey(t => t.NoticeId);
			Property(t => t.NoticeId).HasColumnName("NoticeId")
					.HasColumnOrder(1)
					.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
		Property(t => t.RoleId).HasColumnName("RoleId"); 
		Property(t => t.RoleApplicationId).HasColumnName("RoleApplicationId"); 
		Property(t => t.AuthorisedUserId).HasColumnName("AuthorisedUserId"); 
		Property(t => t.MessageOut).HasColumnName("MessageOut").HasColumnType("varchar(max)").IsOptional(); 
		Property(t => t.DateCreated).HasColumnName("DateCreated"); 
		Property(t => t.IsActive).HasColumnName("IsActive"); 
        }
	}
}
		
		
