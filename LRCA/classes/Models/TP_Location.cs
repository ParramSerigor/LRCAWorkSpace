
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class TP_Location
    {
		#region Public Properties
		
		public int? TPLocationId { get; set; }
		public int? TPId { get; set; }
		public string TP_Address_Line_1 { get; set; }
		public string TP_City { get; set; }
		public string TP_State { get; set; }
		public string TP_ZipCode { get; set; }
		public TrainingProvider TP { get; internal set; }

		internal static TP_Location Create(int TPId, string vtxtLocation_Address_1, string vtxtLocation_City_1, string vtxtLocation_State_1, string vtxtLocation_ZipCode_1)
		{
			var result = new TP_Location();
			result.TPId = TPId;
			result.TP_Address_Line_1 = vtxtLocation_Address_1;
			result.TP_City = vtxtLocation_City_1;
			result.TP_State = vtxtLocation_State_1;
			result.TP_ZipCode = vtxtLocation_ZipCode_1;
			return result;
		}

		#endregion
	}
}
		
		
