
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class TrainingCourse_File : DomainObject
    {
		#region Public Properties
		
		public int? TrainingCourseAppId { get; set; }
		public string FileLocation { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public TrainingCourse TrainingCourseApp { get; internal set; }
        internal static TrainingCourse_File Create(int contractorId, string path)
        {
            var result = new TrainingCourse_File();
            result.TrainingCourseAppId = contractorId;
            result.FileLocation = path;
            result.IsActive = 1;
            return result;
        }
        #endregion
    }
}
		
		
