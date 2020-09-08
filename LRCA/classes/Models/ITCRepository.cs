using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRCA.classes.Models
{
	interface ITCRepository
	{
		void Add(TrainingCourse tc);
		IQueryable<TrainingCourse> PendingApps();
		IQueryable<TrainingCourse> AssignToMDEApps(int id);
		TrainingCourse Get(int id);
        IQueryable<TrainingCourse> ApprovedApps();
        IQueryable<TrainingCourse> DisapprovedApps();
		void Update(TrainingCourse trainingCourse);
        void AddFile(TrainingCourse_File TrainingCourse_File);
    }


}