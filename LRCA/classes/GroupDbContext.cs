using LRCA.classes.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LRCA.classes
{
	public class GroupDbContext : PersistenceContextBase, IGroupDataContext
	{
		#region Constructor
		public GroupDbContext()
			: base(ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString)
		{
		}
		#endregion

		#region OnModelCreating
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			var configurations = modelBuilder.Configurations;
			configurations.AddFromAssembly(Assembly.Load("LRCA"));
			base.OnModelCreating(modelBuilder);
		}
		#endregion

		#region Properties Contractor
		IQueryable<SP_Contractor> IGroupDataContext.Contractors { get { return Set<SP_Contractor>(); } }
		IQueryable<LK_Regions> IGroupDataContext.Regions { get { return Set<LK_Regions>(); } }
		IQueryable<LK_ServicesOffered> IGroupDataContext.ServicesOffered { get { return Set<LK_ServicesOffered>(); } }
		IQueryable<Contractor_Address> IGroupDataContext.ContractorAddreses { get { return Set<Contractor_Address>(); } }

		IQueryable<Contractor_Region> IGroupDataContext.ContractorRegions { get { return Set<Contractor_Region>(); } }
		IQueryable<Contractor_ServiceOffered> IGroupDataContext.ContractorServices { get { return Set<Contractor_ServiceOffered>(); } }
		IQueryable<Contractor_EmpList> IGroupDataContext.ContractorEmpList { get { return Set<Contractor_EmpList>(); } }
        #endregion

        #region Properties Supervisor 
        IQueryable<Supervisor> IGroupDataContext.Supervisors { get { return Set<Supervisor>(); } }
        IQueryable<LK_Experiences> IGroupDataContext.Experiences { get { return Set<LK_Experiences>(); } }
        IQueryable<Form_Experience_Map> IGroupDataContext.Form_Experience_Map { get { return Set<Form_Experience_Map>(); } }
        #endregion

        #region Properties RiskAssesor Approval
        IQueryable<RiskAssessor_Approval> IGroupDataContext.RiskAssesor_Approvals { get { return Set<RiskAssessor_Approval>(); } }
		IQueryable<Inspector_RiskAssessor> IGroupDataContext.RiskAssesors { get { return Set<Inspector_RiskAssessor>(); } }
		#endregion

		IQueryable<TrainingProvider> IGroupDataContext.TrainingProviders { get { return Set<TrainingProvider>(); } }
		IQueryable<Instructor> IGroupDataContext.Instructors { get { return Set<Instructor>(); } }
		IQueryable<TrainingCourse> IGroupDataContext.TrainingCourses { get { return Set<TrainingCourse>(); } }
	}
}