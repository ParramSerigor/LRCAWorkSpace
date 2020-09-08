using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LRCA
{
    public partial class Ad_Users_Mgmt : System.Web.UI.Page
    {
        CryptoJS objcryptoJS = new CryptoJS();
        protected void Page_init(object sender, EventArgs e)
        {
            string EmpId = HttpContext.Current.Session["UserAuthId"] == null ? string.Empty : HttpContext.Current.Session["UserAuthId"].ToString();
            if (EmpId.Length == 0)
            {
                GlobalMethods.logout();
            }

            string IsAdmin = HttpContext.Current.Session["IsAdmin"] == null ? string.Empty : HttpContext.Current.Session["IsAdmin"].ToString();
            if (IsAdmin.Length == 0)
            {
                GlobalMethods.logout();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<dynamic> lstValues;
                string strSQL = @"SELECT User.AuthorisedUserId, User.FName, User.LName, User.EmailId, User.CreatedDate, User.IsActive, Role.RoleName, User.IsAdmin
                                  FROM  Role INNER JOIN
                                  UserRole ON Role.RoleId = UserRole.RoleId RIGHT OUTER JOIN
                                  User ON UserRole.AuthorizedUserId = User.AuthorisedUserId";
                var objPar = new DynamicParameters();

                try
                {
                    //objPar.Add("@CompanyId", CompanyId, dbType: DbType.Int32);
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        lstValues = db.Query<dynamic>(strSQL, objPar, commandType: CommandType.Text).ToList();
                        if (lstValues != null)
                        {
                            if (lstValues.Count > 0)
                            {
                                for (int i = 0; i < lstValues.Count; i++)
                                {
                                    showTable(GlobalMethods.ValueIsNull(lstValues[i].FName), GlobalMethods.ValueIsNull(lstValues[i].LName), GlobalMethods.ValueIsNull(lstValues[i].EmailId), GlobalMethods.ValueIsNull(lstValues[i].CreatedDate), GlobalMethods.ValueIsNull(lstValues[i].RoleName), Convert.ToInt32(GlobalMethods.ValueIsNull(lstValues[i].IsActive)), Convert.ToInt32(GlobalMethods.ValueIsNull(lstValues[i].IsAdmin)), GlobalMethods.ValueIsNull(lstValues[i].AuthorisedUserId));
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
            }
        }
        protected void javaNotifyWait(string Msg, string MsgType, string MsgTime, int IsWaitOn, string URLTO)
        {
            int MsgTimeIn = Convert.ToInt32(MsgTime) + 1300;
            if (IsWaitOn == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script language=JavaScript>$(document).ready(function() { noty({ 'text': '" + Msg + "', 'theme': 'noty_theme_twitter', 'layout': 'center', 'type': '" + MsgType + "', 'animateOpen': { 'height': 'toggle' }, 'animateClose': { 'height': 'toggle' }, 'speed': 500, 'timeout':" + MsgTime + ", 'closeButton': false, 'closeOnSelfClick': true, 'closeOnSelfOver': false, 'modal': true }); });var t1 = setTimeout(function(){window.location.href = '" + URLTO + "'}," + MsgTimeIn + ");</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script language=JavaScript>$(document).ready(function() { noty({ 'text': '" + Msg + "', 'theme': 'noty_theme_twitter', 'layout': 'center', 'type': '" + MsgType + "', 'animateOpen': { 'height': 'toggle' }, 'animateClose': { 'height': 'toggle' }, 'speed': 500, 'timeout':" + MsgTime + ", 'closeButton': false, 'closeOnSelfClick': true, 'closeOnSelfOver': false, 'modal': true }); });</script>");
            }
        }
        protected void javaNotify(string Msg, string MsgType, string MsgTime)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script language=JavaScript>$(document).ready(function() { noty({ 'text': '" + Msg + "', 'theme': 'noty_theme_twitter', 'layout': 'center', 'type': '" + MsgType + "', 'animateOpen': { 'height': 'toggle' }, 'animateClose': { 'height': 'toggle' }, 'speed': 500, 'timeout':" + MsgTime + ", 'closeButton': false, 'closeOnSelfClick': true, 'closeOnSelfOver': false, 'modal': true }); });</script>");
        }
        /// <summary>
        /// This function is creating a table values.
        /// </summary>
        /// <param name="FName"></param>
        /// <param name="LName"></param>
        /// <param name="Email"></param>
        /// <param name="DateCreated"></param>
        /// <param name="RoleStatus">is Status of the ROLE this user is selected for. This can be Active or inactive</param>
        /// <param name="UserRoleId">This is the UserRoleId for Admin to disable the Role for a user.</param>
        /// <param name="AcctStatus">This is User Account Status.</param>
        protected void showTable(string FName, string LName, string Email, string DateCreated, string RoleName, int AcctStatus, int IsAdmin, string AuthorisedUserId)
        {
            AuthorisedUserId = objcryptoJS.AES_encrypt(AuthorisedUserId, AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(FName);
            strContent.Append("</td>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(LName);
            strContent.Append("</td>");
            strContent.Append("<td width='20%'nowrap>");
            strContent.Append(Email);
            strContent.Append("</td>");
            strContent.Append("<td width='10%' nowrap>");
            strContent.Append(DateCreated);
            strContent.Append("</td>");
            strContent.Append("<td width='20%' nowrap>");
            strContent.Append(GlobalMethods.AcctStatus(AcctStatus));
            strContent.Append("</td>");
            strContent.Append("<td width='20%'nowrap>");
            strContent.Append(RoleName);
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='10%' nowrap>");
            if (IsAdmin == 0)
            {
                strContent.Append("<a class='btn btn-xs btn-success open-DeleteVideoOff' href='#' data-id='");
                strContent.Append(System.Web.HttpUtility.UrlEncode(AuthorisedUserId));
                strContent.Append("' data-toggle='modal'> Admin On </a>");
            }
            else
            {
                strContent.Append("<a class='btn btn-xs btn-danger open-DeleteVideoOn' href='#' data-id='");
                strContent.Append(System.Web.HttpUtility.UrlEncode(AuthorisedUserId));
                strContent.Append("' data-toggle='modal'> Admin Off </a>");
            }
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='10%' nowrap>");
            if (AcctStatus.ToString() == "-1")
            {
                strContent.Append("<a class='btn btn-xs btn-success open-ActivateAcctOff' href='#' data-id='");
                strContent.Append(System.Web.HttpUtility.UrlEncode(AuthorisedUserId));
                strContent.Append("' data-toggle='modal'> Activate Account </a>");
            }
            else
            {
                strContent.Append("<a class='btn btn-xs btn-danger open-ActivateAcctOn' href='#' data-id='");
                strContent.Append(System.Web.HttpUtility.UrlEncode(AuthorisedUserId));
                strContent.Append("' data-toggle='modal'> Disable Account </a>");
            }
            strContent.Append("</td>");


            pnlVideos.Controls.Add(new LiteralControl(strContent.ToString()));

        }
        protected void AddTManual_Click(object sender, EventArgs e)
        {
            //Security objSecurity = new Security();

            #region "variables"
            //string vFName = objSecurity.KillChars(txtFName.Text);
            //string vLName = objSecurity.KillChars(txtLName.Text);
            //string vEmail = objSecurity.KillChars(txtEmail.Text);
            #endregion

            //if (LoginBAL.CheckEmailExsists(vEmail))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('This email address has been used by some other user. Please use another valid email!', '', 'danger', 'Ad_MDE_Mgmt.aspx?MDE=active');", true);
            //}
            //else
            //{
            //    if (LoginBAL.RegistrationByRole(vFName, vLName, vEmail, 1, Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString())))
            //    {

            //    }
            //}
        }

        [System.Web.Services.WebMethod(EnableSession = false)]
        public static string CallMgmtAcct(string cgi)
        {
            CryptoJS objcryptoJS = new CryptoJS();
            string AuthUserId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(cgi), AppConstants.secretKey, AppConstants.initVec).ToString();

            List<clsUserRole> lstURole = new List<clsUserRole>();
            lstURole = UserRoleDAL.SelectDynamicUserRole("UserRoleId = " + AuthUserId + "", "UserRoleId");
            if (lstURole != null)
            {
                if (lstURole.Count > 0)
                {
                    if (lstURole[0].IsActive == 0)
                    {
                        lstURole[0].IsActive = 1;
                    }
                    else
                    {
                        lstURole[0].IsActive = 0;
                    }


                    if (!UserRoleDAL.UpdateUserRole(lstURole[0]))
                    {

                    }
                }
            }

            return "Ad_MDE_Mgmt.aspx?MDE=active";
        }
    }
}