using LRCA.classes;
using LRCA.classes.Models;
using LRCA.classes.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
    public partial class MDE_SuperApps : PageBase
    {
        CryptoJS objcryptoJS = new CryptoJS();
        private readonly ISupervisorRepository _supervisorRepository;
        public MDE_SuperApps()
        {
            _supervisorRepository = new SupervisorRepository(_context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var pendingApps = _supervisorRepository.PendingApps();
                foreach (var each in pendingApps)
                {
                    showTable(pnlVideos, each);
                }

                var mdeApps = _supervisorRepository.AssignToMDEApps(int.Parse(HttpContext.Current.Session["UserAuthId"].ToString()));
                foreach (var each in mdeApps)
                {
                    showTable(pnlMyContApps, each);
                }
            }
        }
        protected void showTable(Panel pnlName, Supervisor Supervisor)
        {
            var id = objcryptoJS.AES_encrypt(Supervisor.Id.ToString(), AppConstants.secretKey, AppConstants.initVec);
            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a style='text-decoration: underline;' href='MDESuperAppView.aspx?SuperApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(id) + "' >");
            strContent.Append(Supervisor.SupervisorFirstName + " " + Supervisor.SupervisorLastName);
            strContent.Append("</a></td>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(Supervisor.ACRDCat.CatTitle);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Supervisor.SupervisorContactFirstName + " " + Supervisor.SupervisorContactLastName);
            strContent.Append("</td>");
            strContent.Append("<td width='10%' nowrap>");
            strContent.Append(Supervisor.SupervisorContractor_Phone);
            strContent.Append("</td>");
            if (pnlName.ID.ToString() == "pnlMyContApps")
            {
                strContent.Append("<td width='10%' nowrap>");
                strContent.Append(GlobalMethods.AppStatus(Convert.ToInt32(Supervisor.IsActive)));
                strContent.Append("</td>");
            }
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Supervisor.CreatedDate.ToShortDateString());
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-success' href='MDESuperAppView.aspx?SuperApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(id) + "'>View</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
    }
}