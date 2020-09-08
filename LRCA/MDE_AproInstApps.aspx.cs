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
    public partial class MDE_AproInstApps : PageBase
    {
        CryptoJS objcryptoJS = new CryptoJS();
        private readonly IInstructorRepository _instructorRepository;
        public MDE_AproInstApps()
        {
            _instructorRepository = new InstructorRepository(_context);
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
                var pendingApps = _instructorRepository.ApprovedApps();
                foreach (var each in pendingApps)
                {
                    showTable(pnlVideos, each);
                }

                var mdeApps = _instructorRepository.DisapprovedApps();
                foreach (var each in mdeApps)
                {
                    showTable(pnlDisapproved, each);
                }

            }
        }
        protected void showTable(Panel pnlName, Instructor inspector_RiskAssessor)
        {
            var id = objcryptoJS.AES_encrypt(inspector_RiskAssessor.Id.ToString(), AppConstants.secretKey, AppConstants.initVec);
            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a style='text-decoration: underline;' href='MDE_InstructorAppView.aspx?InstructApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(id) + "' >");
            strContent.Append(inspector_RiskAssessor.Instructor_FName + " " + inspector_RiskAssessor.Instructor_LName);
            strContent.Append("</a></td>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(inspector_RiskAssessor.TP_Name);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(inspector_RiskAssessor.TP_Contact_FName + " " + inspector_RiskAssessor.TP_Contact_LName);
            strContent.Append("</td>");
            strContent.Append("<td width='10%' nowrap>");
            strContent.Append(inspector_RiskAssessor.Instructor_Phone);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(inspector_RiskAssessor.CreatedDate.ToShortDateString());
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-success' href='MDE_InstructorAppView.aspx?InstructApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(id) + "'>View</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
    }
}