
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	public class Contractor_Comment : DomainObject
	{
		#region Public Properties

		public int? SPContractorID { get; set; }
		public string Comment { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public SP_Contractor SPContractor { get; internal set; }

		#endregion
	}
}


