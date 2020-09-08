using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace LRCA.classes
{
	public class AuthenticationTicketHelper
	{
		#region CreateAuthenticationTicket
		public static HttpCookie CreateAuthenticationTicket(string username, bool isPersistent, string userData)
		{
			FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, username, DateTime.Now, DateTime.Now.AddHours(12), isPersistent, userData);
			String encryptedTicket = System.Web.Security.FormsAuthentication.Encrypt(ticket);
			HttpCookie cookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, encryptedTicket);
			return cookie;
		}
		#endregion
	}
}