using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRCA.classes
{
	interface IDefaultLogger: IDisposable
	{
		void LogInfo(string message);
		void LogSuccess(string message);
		void LogFailure(string message);
		void LogFailure(Exception exception);
	}
}
