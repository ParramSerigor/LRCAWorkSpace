using LRCA.classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Repositories
{
    public class RiskAssessor_ApprovalRepository: IRiskAssessor_ApprovalRepository
    {
        #region Constructor
        public RiskAssessor_ApprovalRepository(IGroupDataContext groupDataContext)
        {
            _context = groupDataContext;
        }
        #endregion

        private readonly IGroupDataContext _context;

        IReadOnlyCollection<RiskAssessor_Approval> IRiskAssessor_ApprovalRepository.All()
        {
            throw new NotImplementedException();
        }

        void IRiskAssessor_ApprovalRepository.Add(RiskAssessor_Approval riskAssessor_approver)
        {
            _context.Insert(riskAssessor_approver);
        }

        void IRiskAssessor_ApprovalRepository.Update(RiskAssessor_Approval riskAssessor_approver)
        {
            _context.Update(riskAssessor_approver);
        }

        //RiskAssessor_Approval IRiskAssessor_ApprovalRepository.Get(int intMDEInspRiskAssApprovalId)
        //{
        //    return _context
        //    .RiskAssesor_Approvals
        //    .FirstOrDefault(x => x.MDEInspRiskAssApprovalId == intMDEInspRiskAssApprovalId);
        //}
    }
}