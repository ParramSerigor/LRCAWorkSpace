
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{

	public class Category
	{
		#region Public Properties
		public int? ACRDCatID { get; set; }
		public string CatTitle { get; set; }
		public string CatDescription { get; set; }
		public string ACRDCategory { get; set; }
		public int? ValidFor { get; set; }
		public int? ThirdPartyExam { get; set; }
		public int? PassScoreReq { get; set; }
		public string PassScore { get; set; }
		public int? AttendanceReq { get; set; }
		public DateTime? CreateDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion

		#region Fields
		public const int Inspection = 10;
		public const int Residential = 11;
		public const int Steel = 12;
		public const int VisualInspector = 1;
		public const int InspectorTechnician = 2;
		public const int RiskAccesor = 3;
		public const int StructuralSteelSupervisor = 4;
		public const int RemovalAndDemolition = 6;
		public const int MaintananceAndRepainting = 5;
		#endregion
	}
}


