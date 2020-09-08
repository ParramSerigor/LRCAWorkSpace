
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
		public class RiskAssessor_File : DomainObject
    {
		#region Public Properties
		
		public int? InspectorRiskAssId { get; set; }
		public string FileLocation { get; set; }
		public string Notes { get; set; }
		public int? IsActive { get; set; }
		public Inspector_RiskAssessor InspectorRiskAss { get; internal set; }

        internal static RiskAssessor_File Create(int contractorId, string path)
        {
            var result = new RiskAssessor_File();
            result.InspectorRiskAssId = contractorId;
            result.FileLocation = path;
            result.IsActive = 1;
            return result;
        }

        #endregion
    }
}
		
		
