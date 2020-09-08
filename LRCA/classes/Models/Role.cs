
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class Role : DomainObject
    {
		#region Public Properties
		public int? RoleId { get; set; }
		public int? MDEInternalExternal { get; set; }
		public string RoleName { get; set; }
		public string RoleDispName { get; set; }
		public string RoleIcon { get; set; }
		public string RoleRegisterURL { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? DisplayOrder { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
