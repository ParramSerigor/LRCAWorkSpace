
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class SignOnLog
    {
		#region Public Properties
		public int? SigninId { get; set; }
		public int? AuthorisedUserId { get; set; }
		public DateTime? SignedOn { get; set; }
		#endregion
	}
}
		
		
