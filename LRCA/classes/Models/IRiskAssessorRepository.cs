using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRCA.classes.Models
{
	public interface IRiskAssessorRepository
	{
		void Add(Inspector_RiskAssessor riskAccessor);
		IQueryable<Inspector_RiskAssessor> PendingApps();
		IQueryable<Inspector_RiskAssessor> AssignToMDEApps(int id);
        IQueryable<Inspector_RiskAssessor> ApprovedApps();
        Inspector_RiskAssessor Get(int id);
        IQueryable<Inspector_RiskAssessor> DisapprovedApps();
		void Update(Inspector_RiskAssessor subject);
        void AddFile(RiskAssessor_File RiskAssessor_File);
    }
}
