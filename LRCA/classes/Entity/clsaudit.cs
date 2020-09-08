
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsaudit
    {
		#region Public Properties
		public int? auditid { get; set; }
		public string tablename { get; set; }
		public string recordid { get; set; }
		public int? changetype { get; set; }
		public string username { get; set; }
		public DateTime? recordedon { get; set; }
		public Guid txid { get; set; }
		public string data { get; set; }
		#endregion
	}
}
		
		
