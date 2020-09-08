
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsSignOnLog
    {
		#region Public Properties
		public int? SigninId { get; set; }
		public int? AuthorisedUserId { get; set; }
		public DateTime? SignedOn { get; set; }
		#endregion
	}
}
		
		
