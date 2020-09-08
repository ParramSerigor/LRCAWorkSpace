using LRCA.classes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LRCA.classes.Repositories
{
    public class InstructorRepository : IInstructorRepository
	{
        #region Constructor
        public InstructorRepository(IGroupDataContext groupDataContext)
        {
            _context = groupDataContext;
        }
        #endregion

        private readonly IGroupDataContext _context;

		void IInstructorRepository.Add(Instructor instructor)
		{
			_context.Insert(instructor);
		}

		Instructor IInstructorRepository.Get(int id)
		{
			return _context
				.Instructors
                .Include(i => i.Files)
                .FirstOrDefault(x => x.Id == id);
		}

		IQueryable<Instructor> IInstructorRepository.PendingApps()
		{
			return _context
				.Instructors
				.Include(i=>i.ACRDCat)
				.Where(x => !x.Approvals.Select(s => s.InstructorId).Contains(x.Id));
		}

		IQueryable<Instructor> IInstructorRepository.AssignToMDEApps(int id)
		{
			return _context
				.Instructors
				.Include(i => i.ACRDCat)
				.Where(x => x.Approvals.Select(s => s.MDE_Owner_AuthorisedUserId).FirstOrDefault(e => e.Value == id) != null && (x.IsActive == 4 || x.IsActive == 2 || x.IsActive == 3));
		}
        IQueryable<Instructor> IInstructorRepository.ApprovedApps()
        {
            return _context
               .Instructors
                .Include(i => i.ACRDCat)
                .Where(x => x.IsActive == 1);
        }
        IQueryable<Instructor> IInstructorRepository.DisapprovedApps()
        {
            return _context
               .Instructors
                .Include(i => i.ACRDCat)
                .Where(x => x.IsActive == 0);
        }

		void IInstructorRepository.Update(Instructor instructor)
		{
			_context.Update(instructor);
		}
        void IInstructorRepository.AddFile(Instructor_File Instructor_File)
        {
            _context.Insert(Instructor_File);
        }
    }
}