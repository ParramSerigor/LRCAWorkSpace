using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRCA.classes.Models
{
	interface IContractorRepository
	{
		IReadOnlyCollection<SP_Contractor> All();
		void Add(SP_Contractor contractor);
		void Update(SP_Contractor contractor);
		IReadOnlyCollection<LK_Regions> AllRegionByStatus();
		IReadOnlyCollection<LK_ServicesOffered> AllServicesOfferedByStatus();
		void AddEmpList(Contractor_EmpList contractor_EmpList);
		void AddRegion(Contractor_Region region);
		void AddServiceOffered(Contractor_ServiceOffered contractor_ServiceOffered);
		void AddAddress(Contractor_Address contractor_Address);
		void AddUser(LK_Contractor_User objConUser);
		SP_Contractor Get(int strSPContractorID);
		void AddFile(Contractor_File contractor_File);
	}
}
