
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsLK_HB935
    {
		#region Public Properties
		public int? HB935Id { get; set; }
		public string TaxId { get; set; }
		public int? LiabilityExists { get; set; }
		public string Entity_Name { get; set; }
		public string Entity_Address_Line_1 { get; set; }
		public string Entity_City { get; set; }
		public string Entity_State { get; set; }
		public string Entity_ZipCode { get; set; }
		public string Entity_Telephone { get; set; }
		public string Entity_Fax { get; set; }
		public string Entity_Email { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
