
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	public class Supervisor_Experiences
	{
		#region Public Properties
		public int? SupervisorExperienceId { get; set; }
		public int? SupervisorId { get; set; }
		public int? ExperienceId { get; set; }
		public string ExperienceTitle { get; set; }
		public Supervisor Supervisor { get; internal set; }
		public LK_Experiences Experience { get; internal set; }

		internal static Supervisor_Experiences Create(int id, int? expId, string title)
		{
			var result = new Supervisor_Experiences()
			{
				SupervisorId = id
			};
			if (expId.HasValue && title == string.Empty)
			{
				result.ExperienceId = expId;
			}
			else
			{
				result.ExperienceTitle = "Other";
			}
			return result;
		}
		#endregion
	}
}


