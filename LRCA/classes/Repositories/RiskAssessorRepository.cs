using LRCA.classes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LRCA.classes.Repositories
{
	public class RiskAssessorRepository : IRiskAssessorRepository
	{
		private readonly IGroupDataContext _context;

		public RiskAssessorRepository(IGroupDataContext groupDataContext)
		{
			_context = groupDataContext;
		}
		void IRiskAssessorRepository.Add(Inspector_RiskAssessor riskAccessor)
		{
			_context.Insert(riskAccessor);
		}

		IQueryable<Inspector_RiskAssessor> IRiskAssessorRepository.AssignToMDEApps(int id)
		{
			return _context
				.RiskAssesors
				.Include(i => i.ACRDCat)
				.Where(x => x.Approvals.Select(s => s.MDE_Owner_AuthorisedUserId).FirstOrDefault(e=>e.Value == id) != null && (x.IsActive == 4 || x.IsActive == 2 || x.IsActive == 3));
		}

		Inspector_RiskAssessor IRiskAssessorRepository.Get(int id)
		{
			return _context
				.RiskAssesors
				.Include(i => i.ACRDCat)
                .Include(i => i.Files)
                .FirstOrDefault(x => x.Id == id);
		}

		IQueryable<Inspector_RiskAssessor> IRiskAssessorRepository.PendingApps()
		{
			return _context
				.RiskAssesors
				.Include(i=>i.ACRDCat)
				.Where(x => !x.Approvals.Select(s => s.InspectorRiskAssId).Contains(x.Id));
		}
        IQueryable<Inspector_RiskAssessor> IRiskAssessorRepository.ApprovedApps()
        {
            return _context
                .RiskAssesors
                .Include(i => i.ACRDCat)
                .Where(x => x.IsActive == 1);
        }
        IQueryable<Inspector_RiskAssessor> IRiskAssessorRepository.DisapprovedApps()
        {
            return _context
                .RiskAssesors
                .Include(i => i.ACRDCat)
                .Where(x => x.IsActive == 0);
        }

		void IRiskAssessorRepository.Update(Inspector_RiskAssessor  inspector_RiskAssessor)
		{
			_context.Update(inspector_RiskAssessor);
		}
        void IRiskAssessorRepository.AddFile(RiskAssessor_File RiskAssessor_File)
        {
            _context.Insert(RiskAssessor_File);
        }
    }
}