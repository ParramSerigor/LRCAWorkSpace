using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace LRCA.classes
{
	public class PageBase : Page
	{
		public readonly IUnitOfWork _uow;
		public readonly IGroupDataContext _context;
		private readonly IAuditor _auditor;
		public PageBase()
		{
			_context = new GroupDbContext();
			_auditor = new Auditor();
			_uow = new UnitOfWork(_context, _auditor);
		}
		public DefaultLogger Logger { get; private set; }

		#region OnInit
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			Logger = new DefaultLogger(LogManager.GetLogger(GetType().Name));
		}
        #endregion

        protected void Page_init(object sender, EventArgs e)
        {
            //string EmpId = HttpContext.Current.Session["UserAuthId"] == null ? string.Empty : HttpContext.Current.Session["UserAuthId"].ToString();
            //if (EmpId.Length == 0)
            //{
            //	GlobalMethods.logout();
            //}

        }
    }
}