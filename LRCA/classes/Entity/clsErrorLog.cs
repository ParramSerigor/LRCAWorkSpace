
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsErrorLog
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
		
		
