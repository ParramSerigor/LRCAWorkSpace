using LRCA.classes.Models;
using System.Linq;

namespace LRCA.classes
{
	public interface IGroupDataContext : IPersistenceContext
	{
		IQueryable<SP_Contractor> Contractors { get; }
		IQueryable<LK_Regions> Regions { get; }
		IQueryable<LK_ServicesOffered> ServicesOffered { get; }
		IQueryable<Contractor_Address> ContractorAddreses { get;}
		IQueryable<Contractor_Region> ContractorRegions { get; }
		IQueryable<Contractor_ServiceOffered> ContractorServices { get; }
		IQueryable<Contractor_EmpList> ContractorEmpList { get; }

        //*****************
        IQueryable<Supervisor> Supervisors { get; }
        IQueryable<LK_Experiences> Experiences { get; }
        IQueryable<Form_Experience_Map> Form_Experience_Map { get; }
        //*****************
        IQueryable<RiskAssessor_Approval> RiskAssesor_Approvals { get; }
		IQueryable<Inspector_RiskAssessor> RiskAssesors { get; }
		IQueryable<TrainingProvider> TrainingProviders { get; }
		IQueryable<Instructor> Instructors { get; }
		IQueryable<TrainingCourse> TrainingCourses { get; }
	}
}