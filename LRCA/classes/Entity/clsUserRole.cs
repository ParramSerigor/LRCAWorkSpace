
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsUserRole
    {
		#region Public Properties
		public int? UserRoleId { get; set; }
		public int? RoleId { get; set; }
		public int? AuthorizedUserId { get; set; }
		public int? IsActive { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		#endregion
	}
}
		
		
