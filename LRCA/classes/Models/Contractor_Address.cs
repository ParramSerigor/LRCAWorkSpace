
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class Contractor_Address 
    {
		#region Public Properties
		public int? ContractorAddressId { get; set; }
		public int? SPContractorID { get; set; }
		public int? AddressType { get; set; }
		public string Address_Line_1 { get; set; }
		public string Address_Line_2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public int? PublicListing { get; set; }
		public SP_Contractor SPContractor { get; internal set; }

		internal static Contractor_Address Create(int type,string vSPAddress_Line_1, string vSPCity, string vSPState, string vSPZipCode,int contractorId, int? dropList)
		{
			var result = new Contractor_Address
			{
				SPContractorID = contractorId,
				Address_Line_1 = vSPAddress_Line_1,
				AddressType = type,
				City = vSPCity,
				State = vSPState,
				ZipCode = vSPZipCode
			};
			if (dropList.HasValue)
			{
				result.PublicListing = dropList;
			}
			return result;
		}
		#endregion
	}
}
		
		
