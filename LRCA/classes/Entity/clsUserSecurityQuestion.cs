
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsUserSecurityQuestion
    {
		#region Public Properties
		public int? UserSecurityQuestionId { get; set; }
		public int? SecurityQuestionId { get; set; }
		public int? AuthorisedUserId { get; set; }
		public string UserAnswer { get; set; }
		public int? IsActive { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		#endregion
	}
}
		
		
