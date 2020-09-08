
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class Contractor_File : DomainObject
    {
		#region Public Properties
		
		public int? SPContractorID { get; set; }
		public string FileLocation { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public SP_Contractor SPContractor { get; internal set; }

		internal static Contractor_File Create(int contractorId, string path)
		{
			var result = new Contractor_File();
			result.SPContractorID = contractorId;
			result.FileLocation = path;
			result.IsActive = 1;
			return result;
		}

		#endregion
	}
}
		
		
