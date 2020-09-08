
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class Instructor_File : DomainObject
    {
		#region Public Properties
		
		public int? InstructorId { get; set; }
		public string FileLocation { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public Instructor Instructor { get; internal set; }
        internal static Instructor_File Create(int contractorId, string path)
        {
            var result = new Instructor_File();
            result.InstructorId = contractorId;
            result.FileLocation = path;
            result.IsActive = 1;
            return result;
        }
        #endregion
    }
}
		
		
