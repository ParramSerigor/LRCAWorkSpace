
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class Supervisor_Approval : DomainObject
    {
		#region Public Properties
		
		public int? MDESuperApprId { get; set; }
		public int? SupervisorId { get; set; }
		public int? MDE_Owner_AuthorisedUserId { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		
		#endregion
	}
}
		
		
