
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class Contractor_ServiceOffered
    {
		#region Public Properties
		public int? ContractorServiceOfferId { get; set; }
		public int? SPContractorID { get; set; }
		public int? ServiceOfferId { get; set; }
		public SP_Contractor SPContractor { get; internal set; }
		public LK_ServicesOffered ServiceOffer { get; internal set; }

		internal static Contractor_ServiceOffered Create(int id, int value)
		{
			return new Contractor_ServiceOffered
			{
				ServiceOfferId = value,
				SPContractorID = id
			};
		}
		#endregion
	}
}
		
		
