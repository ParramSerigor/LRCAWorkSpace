
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class Contractor_Region
    {
		#region Public Properties
		public int? ContractorRegionId { get; set; }
		public int? SPContractorID { get; set; }
		public int? RegionId { get; set; }
		public SP_Contractor SPContractor { get; set; }
		public LK_Regions Region { get; set; }

		internal static Contractor_Region Create(int contractorId,int regionId)
		{
			return new Contractor_Region
			{
				RegionId = regionId,
				SPContractorID = contractorId
			};
		}
		#endregion
	}
}
		
		
