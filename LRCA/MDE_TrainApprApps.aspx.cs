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
    public partial class MDE_TrainApprApps : PageBase
    {
        CryptoJS objcryptoJS = new CryptoJS();
        private readonly IRiskAssessorRepository _riskAssessorRepository;
        public MDE_TrainApprApps()
        {
            _riskAssessorRepository = new RiskAssessorRepository(_context);
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
                var pendingApps = _riskAssessorRepository.ApprovedApps();
                foreach (var each in pendingApps)
                {
                    showTable(pnlVideos, each);
                }

                var mdeApps = _riskAssessorRepository.DisapprovedApps();
                foreach (var each in mdeApps)
                {
                    showTable(pnlDisapproved, each);
                }

            }
        }
        protected void showTable(Panel pnlName, Inspector_RiskAssessor inspector_RiskAssessor)
        {
            var id = objcryptoJS.AES_encrypt(inspector_RiskAssessor.Id.ToString(), AppConstants.secretKey, AppConstants.initVec);
            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a style='text-decoration: underline;' href='MDE_TrainAppView.aspx?TrainApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(id) + "' >");
            strContent.Append(inspector_RiskAssessor.InspectorFirstName + " " + inspector_RiskAssessor.InspectorLastName);
            strContent.Append("</a></td>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(inspector_RiskAssessor.ACRDCat.CatTitle);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(inspector_RiskAssessor.InspectorContactFirstName + " " + inspector_RiskAssessor.InspectorContactLastName);
            strContent.Append("</td>");
            strContent.Append("<td width='10%' nowrap>");
            strContent.Append(inspector_RiskAssessor.InspectorContractor_Phone);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(inspector_RiskAssessor.CreatedDate.ToShortDateString());
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-success' href='MDE_TrainAppView.aspx?TrainApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(id) + "'>View</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
    }
}