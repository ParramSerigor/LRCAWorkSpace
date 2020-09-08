
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	
    public class TP_Approval
    {
		#region Public Properties
		public int? MDETPApprId { get; set; }
		public int? TPId { get; set; }
		public int? MDE_Owner_AuthorisedUserId { get; set; }
		public DateTime? CreateDate { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public TrainingProvider TP { get; internal set; }
		#endregion
	}
}
		
		
