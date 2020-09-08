
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class User : DomainObject
    {
		#region Public Properties
		public int? AuthorisedUserId { get; set; }
		public string FName { get; set; }
		public string LName { get; set; }
		public string Password { get; set; }
		public string TempPassword { get; set; }
		public string salt { get; set; }
		public string EmailId { get; set; }
		public int? IsCurrent { get; set; }
		public int? IndividualUserID { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public string ImageURL { get; set; }
		public int? IsAdmin { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
