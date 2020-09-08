using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes
{
	public class DefaultLogger : IDefaultLogger
	{
		public DefaultLogger(Logger logger)
		{
			_logger = logger;
		}
		public void Dispose()
		{
			
		}

		public void LogFailure(string message)
		{
			_logger.Error(message);
		}

		public void LogFailure(Exception exception)
		{
			_logger.Error(exception);
		}

		public void LogInfo(string message)
		{
			_logger.Trace(message);
		}

		public void LogSuccess(string message)
		{
			_logger.Info(message);
		}

		private readonly Logger _logger;
	}
}