using LRCA.classes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LRCA.classes.Repositories
{
    public class SupervisorRepository : ISupervisorRepository
    {
        #region Constructor
        public SupervisorRepository(IGroupDataContext groupDataContext)
        {
            _context = groupDataContext;
        }
        #endregion

        private readonly IGroupDataContext _context;

        IReadOnlyCollection<Supervisor> ISupervisorRepository.All()
        {
            return _context.Supervisors.ToList();
        }

        void ISupervisorRepository.Add(Supervisor supervisor)
        {
            _context.Insert(supervisor);
        }

        void ISupervisorRepository.Update(Supervisor supervisor)
        {
            _context.Update(supervisor);
        }

        IReadOnlyCollection<LK_Experiences> ISupervisorRepository.AllExperiencesByStatus()
        {
            return _context.Experiences
                 .ToList();
        }

        LK_Experiences ISupervisorRepository.Get_Experience(int intExperienceId)
        {
            return _context.Experiences
               .FirstOrDefault(x => x.ExperienceId == intExperienceId);
        }

        IReadOnlyCollection<Form_Experience_Map> ISupervisorRepository.Form_Experience_Maps(int ACRDCatID)
        {
            return _context.Form_Experience_Map
				.Include(i=>i.Experience)
                .Where(x => x.ACRDCatID == ACRDCatID)
                .ToList();
        }

        Supervisor ISupervisorRepository.Get(int strSupervisorId)
        {
            return _context
                .Supervisors
				.Include(i=>i.SupervisorExperiences)
				.Include(i => i.SupervisorExperiences.Select(s=>s.Experience))
                .Include(i => i.Files)
                .FirstOrDefault(x => x.Id == strSupervisorId);
        }

		void ISupervisorRepository.AddExperience(Supervisor_Experiences exp)
		{
			_context.Insert(exp);
		}
        IQueryable<Supervisor> ISupervisorRepository.AssignToMDEApps(int id)
        {
            return _context
                .Supervisors
                .Include(i => i.ACRDCat)
                .Where(x => x.Approvals.Select(s => s.MDE_Owner_AuthorisedUserId).FirstOrDefault(e => e.Value == id) != null && (x.IsActive == 4 || x.IsActive == 2 || x.IsActive == 3));
        }

        IQueryable<Supervisor> ISupervisorRepository.PendingApps()
        {
            return _context
                .Supervisors
                .Include(i => i.ACRDCat)
                .Where(x => !x.Approvals.Select(s => s.SupervisorId).Contains(x.Id));
        }
        IQueryable<Supervisor> ISupervisorRepository.ApprovedApps()
        {
            return _context
                .Supervisors
                .Include(i => i.ACRDCat)
                .Where(x => x.IsActive == 1);
        }
        IQueryable<Supervisor> ISupervisorRepository.DisapprovedApps()
        {
            return _context
                .Supervisors
                .Include(i => i.ACRDCat)
                .Where(x => x.IsActive == 0);
        }
        void ISupervisorRepository.AddFile(Supervisor_File Supervisor_File)
        {
            _context.Insert(Supervisor_File);
        }
    }
}