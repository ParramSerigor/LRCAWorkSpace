using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRCA.classes.Models
{
	interface ITPRepository
	{
		void Add(TrainingProvider tp);
		void AddLocation(TP_Location tP_Location);
		void AddInstrutor(TP_Instructors tP_Instructors);
		IQueryable<TrainingProvider> PendingApps();
		TrainingProvider Get(int id);
		IQueryable<TrainingProvider> AssignToMDEApps(int id);
		IQueryable<TrainingProvider> ApprovedApps();
		IQueryable<TrainingProvider> DisapprovedApps();
		void Update(TrainingProvider  trainingProvider);
        void AddFile(TP_File TP_File);
    }


}