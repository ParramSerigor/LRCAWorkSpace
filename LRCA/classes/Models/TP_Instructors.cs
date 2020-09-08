
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	public class TP_Instructors
	{
		#region Public Properties

		public int? TP_InstructorListId { get; set; }
		public int? TPId { get; set; }
		public string TP_InstructorFN { get; set; }
		public string TP_InstructorLN { get; set; }
		public TrainingProvider TP { get; internal set; }

		internal static TP_Instructors Create(int id, string vtxtInstructorFN_1, string vtxtInstructorLN_1)
		{
			var result = new TP_Instructors();
			result.TPId = id;
			result.TP_InstructorFN = vtxtInstructorFN_1;
			result.TP_InstructorLN = vtxtInstructorLN_1;
			return result;
		}

		#endregion
	}
}


