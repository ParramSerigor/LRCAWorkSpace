
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class ErrorLog
    {
		#region Public Properties
		public int? errorId { get; set; }
		public string ApplicationName { get; set; }
		public string FunctionName { get; set; }
		public string errorMessage { get; set; }
		public DateTime? DateGenerated { get; set; }
		#endregion
	}
}
		
		
