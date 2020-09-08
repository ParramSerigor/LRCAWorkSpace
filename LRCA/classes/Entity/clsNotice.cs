
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsNotice
    {
		#region Public Properties
		public int? NoticeId { get; set; }
		public int? RoleId { get; set; }
		public int? RoleApplicationId { get; set; }
		public int? AuthorisedUserId { get; set; }
		public string MessageOut { get; set; }
		public DateTime? DateCreated { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
