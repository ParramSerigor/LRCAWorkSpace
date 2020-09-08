using LRCA.classes;
using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LRCA.classes.Models;
using LRCA.classes.Repositories;

namespace LRCA
{
    public partial class MDE_SuperApprApps : PageBase
    {
        CryptoJS objcryptoJS = new CryptoJS();
        private readonly ISupervisorRepository _supervisorRepository;
        public MDE_SuperApprApps()
        {
            _supervisorRepository = new SupervisorRepository(_context);
        }
        protected void Page_init(object sender, EventArgs e)
        {
            string EmpId = HttpContext.Current.Session["UserAuthId"] == null ? string.Empty : HttpContext.Current.Session["UserAuthId"].ToString();
            if (EmpId.Length == 0)
            {
                GlobalMethods.logout();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var pendingApps = _supervisorRepository.ApprovedApps();
                foreach (var each in pendingApps)
                {
                    showTable(pnlVideos, each);
                }

                var mdeApps = _supervisorRepository.DisapprovedApps();
                foreach (var each in mdeApps)
                {
                    showTable(pnlDisapproved, each);
                }

            }
        }
        protected void showTable(Panel pnlName, Supervisor supervisor)
        {
            var id = objcryptoJS.AES_encrypt(supervisor.Id.ToString(), AppConstants.secretKey, AppConstants.initVec);
            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a style='text-decoration: underline;' href='MDESuperAppView.aspx?SuperApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(id) + "' >");
            //strContent.Append(supervisor.InspectorFirstName + " " + supervisor.InspectorLastName);
            strContent.Append("</a></td>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(supervisor.ACRDCat.CatTitle);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            //strContent.Append(supervisor.InspectorContactFirstName + " " + supervisor.InspectorContactLastName);
            strContent.Append("</td>");
            strContent.Append("<td width='10%' nowrap>");
            //strContent.Append(supervisor.InspectorContractor_Phone);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(supervisor.CreatedDate.ToShortDateString());
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-success' href='MDESuperAppView.aspx?SuperApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(id) + "'>View</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
    }
}