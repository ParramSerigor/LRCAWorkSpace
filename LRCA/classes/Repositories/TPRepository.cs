using LRCA.classes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LRCA.classes.Repositories
{
	public class TPRepository : ITPRepository
	{
		#region Constructor
		public TPRepository(IGroupDataContext groupDataContext)
		{
			_context = groupDataContext;
		}
		#endregion

		private readonly IGroupDataContext _context;

		void ITPRepository.Add(TrainingProvider tp)
		{
			_context.Insert(tp);
		}

		void ITPRepository.AddLocation(TP_Location tP_Location)
		{
			_context.Insert(tP_Location);
		}

		void ITPRepository.AddInstrutor(TP_Instructors tP_Instructors)
		{
			_context.Insert(tP_Instructors);
		}

		IQueryable<TrainingProvider> ITPRepository.PendingApps()
		{
			return _context
				.TrainingProviders
				.Where(x => !x.Approvals.Select(s => s.TPId).Contains(x.Id));
		}

		TrainingProvider ITPRepository.Get(int id)
		{
			return _context
				.TrainingProviders
				.Include(i => i.Locations)
				.Include(i => i.Instructors)
                 .Include(i => i.Files)
                .FirstOrDefault(x => x.Id == id);
		}

		IQueryable<TrainingProvider> ITPRepository.AssignToMDEApps(int id)
		{
			return _context
				.TrainingProviders
				.Where(x => x.Approvals.Select(s => s.MDE_Owner_AuthorisedUserId).FirstOrDefault(e => e.Value == id) != null && (x.IsActive == 4 || x.IsActive == 2 || x.IsActive == 3)); ;
		}

		IQueryable<TrainingProvider> ITPRepository.ApprovedApps()
		{
			return _context
			   .TrainingProviders
			   .Where(x => x.IsActive == 1);
		}

		IQueryable<TrainingProvider> ITPRepository.DisapprovedApps()
		{
			return _context
			   .TrainingProviders
			   .Where(x => x.IsActive == 0);
		}

		void ITPRepository.Update(TrainingProvider trainingProvider)
		{
			_context.Update(trainingProvider);
		}
        void ITPRepository.AddFile(TP_File TP_File)
        {
            _context.Insert(TP_File);
        }
    }
}