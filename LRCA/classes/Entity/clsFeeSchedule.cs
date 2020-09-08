
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsFeeSchedule
    {
		#region Public Properties
		public int FeeScheduleId { get; set; }
		public int ACRDCatID { get; set; }
		public DateTime ApplicableFromDate { get; set; }
		public DateTime ApplicableTillDate { get; set; }
		public string IsCurrent { get; set; }
		public int FeeAmount { get; set; }
		public DateTime CreateDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int IsActive { get; set; }
		#endregion
	}
}
		
		
