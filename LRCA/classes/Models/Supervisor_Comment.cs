
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class Supervisor_Comment : DomainObject
    {
		#region Public Properties
		
		public int? SupervisorId { get; set; }
		public string Comment { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public Supervisor Supervisor { get; internal set; }

		#endregion
	}
}
		
		
