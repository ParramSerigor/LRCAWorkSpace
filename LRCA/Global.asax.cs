using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace LRCA
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			ServicePointManager.DefaultConnectionLimit = 100;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
											| SecurityProtocolType.Tls11
											| SecurityProtocolType.Tls12
											| SecurityProtocolType.Ssl3;
		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
			//FormsIdentity identity = User.Identity as FormsIdentity;
			//if (identity == null) return;
		}

		protected void Application_Error(object sender, EventArgs e)
		{
			try
			{
				if (HttpContext.Current == null || HttpContext.Current.Session == null) return;
			}
			catch
			{
				throw;
			}
		}

		protected void Session_End(object sender, EventArgs e)
		{
			//FormsAuthentication.SignOut();
		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}