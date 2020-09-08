
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class TP_File : DomainObject
    {
		#region Public Properties
		
		public int? TPId { get; set; }
		public string FileLocation { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public TrainingProvider TP { get; internal set; }
        internal static TP_File Create(int contractorId, string path)
        {
            var result = new TP_File();
            result.TPId = contractorId;
            result.FileLocation = path;
            result.IsActive = 1;
            return result;
        }
        #endregion
    }
}
		
		
