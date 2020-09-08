
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace LRCA.classes.Entity
{
	
    public class clsInstructor_File
    {
		#region Public Properties
		public int? InstructorFileId { get; set; }
		public int? InstructorId { get; set; }
		public string FileLocation { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		#endregion
	}
}
		
		
