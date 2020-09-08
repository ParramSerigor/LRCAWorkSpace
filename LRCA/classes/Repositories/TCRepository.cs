using LRCA.classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace LRCA.classes.Repositories
{
    public class TCRepository : ITCRepository
    {
        #region Constructor
        public TCRepository(IGroupDataContext groupDataContext)
        {
            _context = groupDataContext;
        }
        #endregion

        private readonly IGroupDataContext _context;

		void ITCRepository.Add(TrainingCourse tc)
		{
			_context.Insert(tc);
		}

		IQueryable<TrainingCourse> ITCRepository.PendingApps()
		{
			return _context
				.TrainingCourses
                .Where(x => !x.Approvals.Select(s => s.TrainingCourseAppId).Contains(x.Id));
        }

		IQueryable<TrainingCourse> ITCRepository.AssignToMDEApps(int id)
		{
			return _context
				.TrainingCourses
                .Where(x => x.Approvals.Select(s => s.MDE_Owner_AuthorisedUserId).FirstOrDefault(e => e.Value == id) != null && (x.IsActive == 4 || x.IsActive == 2 || x.IsActive == 3)); ;
        }

		TrainingCourse ITCRepository.Get(int id)
		{
			return _context
				.TrainingCourses
                .Include(i => i.Files)
                .FirstOrDefault(x => x.Id == id);
		}
        IQueryable<TrainingCourse> ITCRepository.ApprovedApps()
        {
            return _context
               .TrainingCourses
               .Where(x => x.IsActive == 1);
        }

        IQueryable<TrainingCourse> ITCRepository.DisapprovedApps()
        {
            return _context
               .TrainingCourses
               .Where(x => x.IsActive == 0);
        }

		void ITCRepository.Update(TrainingCourse trainingCourse)
		{
			_context.Update(trainingCourse);
		}
        void ITCRepository.AddFile(TrainingCourse_File TrainingCourse_File)
        {
            _context.Insert(TrainingCourse_File);
        }
    }
}