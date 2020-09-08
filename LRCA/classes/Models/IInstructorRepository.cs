using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRCA.classes.Models
{
	interface IInstructorRepository
	{
		void Add(Instructor instructor);
		Instructor Get(int id);
		IQueryable<Instructor> PendingApps();
		IQueryable<Instructor> AssignToMDEApps(int v);
        IQueryable<Instructor> ApprovedApps();
        IQueryable<Instructor> DisapprovedApps();
		void Update(Instructor instructor);
        void AddFile(Instructor_File Instructor_File);
    }
}