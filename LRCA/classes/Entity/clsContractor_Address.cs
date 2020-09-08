
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsContractor_Address
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
		public int? Publiclisting { get; set; }
		#endregion
	}
}
		
		
