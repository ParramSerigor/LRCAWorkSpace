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
    public partial class MDE_RiskApps : PageBase
    {
        CryptoJS objcryptoJS = new CryptoJS();
		private readonly IRiskAssessorRepository _riskAssessorRepository;
		public MDE_RiskApps()
		{
			_riskAssessorRepository = new RiskAssessorRepository(_context);
		}
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
				var pendingApps = _riskAssessorRepository.PendingApps();
				foreach (var each in pendingApps)
				{
					showTable(pnlVideos, each);
				}

				var mdeApps = _riskAssessorRepository.AssignToMDEApps(int.Parse(HttpContext.Current.Session["UserAuthId"].ToString()));
				foreach (var each in mdeApps)
				{
					showTable(pnlMyContApps, each);
				}
			}
        }
		protected void showTable(Panel pnlName, Inspector_RiskAssessor inspector_RiskAssessor)
		{
			var id = objcryptoJS.AES_encrypt(inspector_RiskAssessor.Id.ToString(), AppConstants.secretKey, AppConstants.initVec);
			StringBuilder strContent = new StringBuilder("<tr>");
			strContent.Append("<td width='15%' nowrap><a style='text-decoration: underline;' href='MDERiskAppView.aspx?RiskApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(id) + "' >");
			strContent.Append(inspector_RiskAssessor.InspectorFirstName +" "+ inspector_RiskAssessor.InspectorLastName);
			strContent.Append("</a></td>");
			strContent.Append("<td width='15%' nowrap>");
			strContent.Append(inspector_RiskAssessor.ACRDCat.CatTitle);
			strContent.Append("</td>");
			strContent.Append("<td width='10%'nowrap>");
			strContent.Append(inspector_RiskAssessor.InspectorContactFirstName +" "+ inspector_RiskAssessor.InspectorContactLastName);
			strContent.Append("</td>");
			strContent.Append("<td width='10%' nowrap>");
			strContent.Append(inspector_RiskAssessor.InspectorContractor_Phone);
			strContent.Append("</td>");
            if (pnlName.ID.ToString() == "pnlMyContApps")
            {
                strContent.Append("<td width='10%' nowrap>");
                strContent.Append(GlobalMethods.AppStatus(Convert.ToInt32(inspector_RiskAssessor.IsActive)));
                strContent.Append("</td>");
            }
            strContent.Append("<td width='10%'nowrap>");
			strContent.Append(inspector_RiskAssessor.CreatedDate.ToShortDateString());
			strContent.Append("</td>");
			//***************************************
			strContent.Append("<td width='5%' nowrap>");
			strContent.Append("<a class='btn btn-xs btn-success' href='MDERiskAppView.aspx?RiskApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(id) + "'>View</a>");
			strContent.Append("</td>");

			pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

		}
		protected void showTable(Panel pnlName, string CompName, string Category, string ACRDID, string ACRDDateExpire, string DateCreated, int SPContractorID)
        {
            string strSPContractorID = objcryptoJS.AES_encrypt(SPContractorID.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a href='MDERiskAppView.aspx?RiskApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "' >");
            strContent.Append(CompName);
            strContent.Append("</a></td>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(Category);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(ACRDID);
            strContent.Append("</td>");
            strContent.Append("<td width='10%' nowrap>");
            strContent.Append(Convert.ToDateTime(ACRDDateExpire).ToShortDateString());
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Convert.ToDateTime(DateCreated).ToShortDateString());
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-success' href='MDERiskAppView.aspx?RiskApps=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "'>View</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
    }
}