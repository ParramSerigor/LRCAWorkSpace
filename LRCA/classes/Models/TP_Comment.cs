
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class TP_Comment : DomainObject
    {
		#region Public Properties
		
		public int? TPId { get; set; }
		public string Comment { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public TrainingProvider TP { get; internal set; }

		#endregion
	}
}
		
		
