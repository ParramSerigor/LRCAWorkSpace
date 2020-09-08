
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsTP_Location
    {
		#region Public Properties
		public int? TPLocationId { get; set; }
		public int? TPId { get; set; }
		public string TP_Address_Line_1 { get; set; }
		public string TP_City { get; set; }
		public string TP_State { get; set; }
		public string TP_ZipCode { get; set; }
		#endregion
	}
}
		
		
