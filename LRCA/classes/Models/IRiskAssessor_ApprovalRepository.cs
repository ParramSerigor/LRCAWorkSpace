using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRCA.classes.Models
{
    public interface IRiskAssessor_ApprovalRepository
    {
        IReadOnlyCollection<RiskAssessor_Approval> All();
        void Add(RiskAssessor_Approval riskAssessor_approver);
        void Update(RiskAssessor_Approval riskAssessor_approver);
      //  RiskAssessor_Approval Get(int intMDEInspRiskAssApprovalId);
    }
}