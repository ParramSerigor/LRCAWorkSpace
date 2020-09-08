
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class Supervisor_File : DomainObject
    {
		#region Public Properties
		
		public int? SupervisorId { get; set; }
		public string FileLocation { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public Supervisor Supervisor { get; internal set; }
        internal static Supervisor_File Create(int contractorId, string path)
        {
            var result = new Supervisor_File();
            result.SupervisorId = contractorId;
            result.FileLocation = path;
            result.IsActive = 1;
            return result;
        }
        #endregion
    }
}
		
		
