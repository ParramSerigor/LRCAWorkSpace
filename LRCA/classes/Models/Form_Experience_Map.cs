
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	public class Form_Experience_Map
	{
		#region Public Properties
		public int? ExperienceFormMappingId { get; set; }
		public string FormName { get; set; }
		public int? ACRDCatID { get; set; }
		public int? ExperienceId { get; set; }
		public LK_Experiences Experience { get; internal set; }
		#endregion
	}
}


