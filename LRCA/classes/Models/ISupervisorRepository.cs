using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRCA.classes.Models
{
    interface ISupervisorRepository
    {
        IReadOnlyCollection<Supervisor> All();
        void Add(Supervisor supervisor);
        void Update(Supervisor supervisor);
        IReadOnlyCollection<LK_Experiences> AllExperiencesByStatus();
        IReadOnlyCollection<Form_Experience_Map> Form_Experience_Maps(int ACRDCatID);
        LK_Experiences Get_Experience(int intExperienceId);
        Supervisor Get(int SupervisorId);
		void AddExperience(Supervisor_Experiences exp);
        IQueryable<Supervisor> PendingApps();
        IQueryable<Supervisor> DisapprovedApps();
        IQueryable<Supervisor> AssignToMDEApps(int id);
        IQueryable<Supervisor> ApprovedApps();
        void AddFile(Supervisor_File Supervisor_File);
    }

   
}