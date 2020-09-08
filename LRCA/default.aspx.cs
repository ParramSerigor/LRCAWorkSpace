using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Dapper;
using LRCA.classes;
using LRCA.classes.BAL;

namespace LRCA
{
	public partial class _default : System.Web.UI.Page
	{
		CryptoJS objcryptoJS = new CryptoJS();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (AppConstants.isLive)
				{
                    //    setSecureProtocol(true);

                }
                ClassGrid();
                lblNotice.Visible = false;
			}
		}
        protected void ClassGrid()
        {
            StringBuilder strContent = new StringBuilder("");
            List<dynamic> lstValues;
            string strSQL = @"SELECT DISTINCT 
                         tbl_CourseSchedule.TrainingCourseScheduleId, tbl_MDE_Courses.CourseDescription, tbl_MDE_Courses.InitialOrRenewal, tbl_TrainingProvider.TP_Name, tbl_TP_Instructors.TP_InstructorFN, tbl_TP_Instructors.TP_InstructorLN, 
                         tbl_CourseSchedule.CourseCost, tbl_MDE_Courses.InstructionLanguage, tbl_MDE_Courses.CourseDuration, tbl_MDE_Courses.PassScore, tbl_Category.ACRDCategory, tbl_TP_Location.TP_Address_Line_1, 
                         tbl_TP_Location.TP_City, tbl_TP_Location.TP_State, tbl_TP_Location.TP_ZipCode, tbl_TrainingProvider.TP_Telephone
FROM            tbl_CourseSchedule INNER JOIN
                         tbl_TrainingProvider ON tbl_CourseSchedule.TPId = tbl_TrainingProvider.TPId INNER JOIN
                         tbl_MDE_Courses ON tbl_CourseSchedule.CourseId = tbl_MDE_Courses.CourseId INNER JOIN
                         tbl_Category ON tbl_MDE_Courses.ACRDCatID = tbl_Category.ACRDCatID INNER JOIN
                         tbl_TP_Instructors ON tbl_TrainingProvider.TPId = tbl_TP_Instructors.TPId INNER JOIN
                         tbl_TP_Location ON tbl_CourseSchedule.TPLocationId = tbl_TP_Location.TPLocationId";
            var objPar = new DynamicParameters();
            objPar.Add("@CurrentDateTime", DateTime.Now.ToShortDateString(), DbType.String);

            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    lstValues = db.Query<dynamic>(strSQL, objPar, commandType: CommandType.Text).ToList();
                    if (lstValues != null)
                    {
                        if (lstValues.Count > 0)
                        {
                            for (int i = 0; i < lstValues.Count; i++)
                            {
                                strContent.Append("<div class='element-item transition metal ' data-category='" + GlobalMethods.ValueIsNull(lstValues[i].CatTitle) + "'>");

                                if (GlobalMethods.ValueIsNull(lstValues[i].Notes).Length > 75)
                                {
                                    strContent.Append("<h3 class='name'>" + GlobalMethods.ValueIsNull(lstValues[i].Notes).Substring(0, 80) + "..." + "</h3>");
                                }
                                else
                                {
                                    strContent.Append("<h3 class='name'>" + GlobalMethods.ValueIsNull(lstValues[i].Notes)  + "</h3>");
                                }
                                strContent.Append("<p class='symbol'><a href='CDetails.aspx?cgi=" + objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(lstValues[i].TrainingCourseScheduleId.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString() + "' title='" + GlobalMethods.ValueIsNull(lstValues[i].CourseTitle) + "'>"+ GlobalMethods.ValueIsNull(lstValues[i].CourseTitle) + "</a></p>");

                                if (GlobalMethods.ValueIsNull(lstValues[i].TP_Name).Length > 23)
                                {
                                    strContent.Append("<p class='number'>" + GlobalMethods.ValueIsNull(lstValues[i].TP_Name).Substring(0, 25) + "</p>");
                                }
                                else
                                {
                                    strContent.Append("<p class='number'>" + GlobalMethods.ValueIsNull(lstValues[i].TP_Name) + "</p>");
                                }
                                strContent.Append("<p class='weight' style='align-content:center'><a href='#' data-toggle='modal' data-target='#RegisterClassModal' class='btn btn-xs btn-default' data-theVideo='RegisterClass.aspx' title='Register Class'>Register</a>&nbsp;<a href='CDetails.aspx?cgi="+ objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(lstValues[i].TrainingCourseScheduleId.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString() + "' class='btn btn-xs btn-primary'>Details</a></p>");
                                strContent.Append("</div>");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            
            pnlClassGrid.Controls.Add(new LiteralControl(strContent.ToString()));
        }

		protected void btn_signin_Click(object sender, EventArgs e)
		{
			string strLoginMsg = string.Empty;
            
            string encryptUsername = objcryptoJS.AES_encrypt(txt_email.Text.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();
			string encryptPass = objcryptoJS.AES_encrypt(txt_password.Text.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();
			strLoginMsg = LoginBAL.Login(encryptUsername, encryptPass);

			if (strLoginMsg.Contains(".aspx"))
			{
				string userData = string.Format("{0}", txt_email.Text.ToString());
				HttpCookie cookie = AuthenticationTicketHelper.CreateAuthenticationTicket(txt_email.Text.ToString(), true, userData);
				if (!Request.Url.Host.Contains("localhost"))
				{
					cookie.Domain = FormsAuthentication.CookieDomain;
				}
				cookie.HttpOnly = true;
				Response.Cookies.Add(cookie);
				SetThreadPrinciple(txt_email.Text);
				Response.Redirect(strLoginMsg);
			}
			else
			{
				lblNotice.Text = "<div  class='alert alert-danger fade in' style='font-size:12px;'><button data-dismiss='alert' class='close' type='button'>×</button>" + strLoginMsg + "</div>";
				Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
				Response.StatusDescription = "";
				Response.Flush();
				Response.SuppressContent = true;
				Response.SuppressFormsAuthenticationRedirect = true;
			}
		}

		#region SetThreadPrinciple
		private void SetThreadPrinciple(string userName)
		{
			var identity = new GenericIdentity(userName);
			var principal = new GenericPrincipal(identity, default(string[]));
			Thread.CurrentPrincipal = principal;
		}
		#endregion

		public string GetUserIP()
		{
			string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			if (!string.IsNullOrEmpty(ipList))
			{
				return ipList.Split(',')[0];
			}

			return Request.ServerVariables["REMOTE_ADDR"];
		}
		public static void setSecureProtocol(bool bSecure)
		{

			string redirectUrl = null;
			HttpContext context = HttpContext.Current;


			// if we want HTTPS and it is currently HTTP
			if (bSecure && !context.Request.IsSecureConnection)
				redirectUrl = context.Request.Url.ToString().Replace("http:", "https:");

			else
				// if we want HTTP and it is currently HTTPS
				if (!bSecure && context.Request.IsSecureConnection)
				redirectUrl = context.Request.Url.ToString().Replace("https:", "http:");

			//else

			// in all other cases we don't need to redirect

			// check if we need to redirect, and if so use redirectUrl to do the job
			if (redirectUrl != null)
				context.Response.Redirect(redirectUrl);

		}
	}
}