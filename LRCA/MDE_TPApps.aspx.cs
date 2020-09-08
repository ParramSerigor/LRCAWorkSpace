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
    public partial class MDE_TPApps : PageBase
    {
        CryptoJS objcryptoJS = new CryptoJS();
        private readonly ITPRepository _tpRepository;
        public MDE_TPApps()
        {
            _tpRepository = new TPRepository(_context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				var pendingApps = _tpRepository.PendingApps();
				foreach (var each in pendingApps)
				{
					showTable(pnlVideos, each);
				}

				var mdeApps = _tpRepository.AssignToMDEApps(int.Parse(HttpContext.Current.Session["UserAuthId"].ToString()));
				foreach (var each in mdeApps)
				{
					showTable(pnlMyContApps, each);
				}
			}
        }
        protected void showTable(Panel pnlName, TrainingProvider trainingProvider)
        {
            var id = objcryptoJS.AES_encrypt(trainingProvider.Id.ToString(), AppConstants.secretKey, AppConstants.initVec);
            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a style='text-decoration: underline;' href='MDE_TPAppView.aspx?tpApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(id) + "' >");
            strContent.Append(trainingProvider.TP_Name);
            strContent.Append("</a></td>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(trainingProvider.TPContactFirstName +" "+ trainingProvider.TPContactLastName);
            strContent.Append("</td>");
            strContent.Append("<td width='10%' nowrap>");
            strContent.Append(trainingProvider.TP_Telephone);
            strContent.Append("</td>");
            if (pnlName.ID.ToString() == "pnlMyContApps")
            {
                strContent.Append("<td width='10%' nowrap>");
                strContent.Append(GlobalMethods.AppStatus(Convert.ToInt32(trainingProvider.IsActive)));
                strContent.Append("</td>");
            }
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(trainingProvider.CreatedDate.ToShortDateString());
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-success' href='MDE_TPAppView.aspx?tpApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(id) + "'>View</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
    }
}