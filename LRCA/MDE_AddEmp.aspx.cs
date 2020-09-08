using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using LRCA.classes.BAL;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LRCA
{
    public partial class MDE_AddEmp : System.Web.UI.Page
    {
        CryptoJS objcryptoJS = new CryptoJS();
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
                List<dynamic> lstValues;
                string strSQL = @"SELECT tbl_User.AuthorisedUserId, tbl_User.FName, tbl_User.LName, tbl_User.EmailId, tbl_User.IsActive, tbl_UserRole.RoleId, tbl_UserRole.IsActive AS RoleStatus, tbl_UserRole.CreatedDate, tbl_UserRole.UserRoleId
                                FROM            tbl_User INNER JOIN
                                tbl_UserRole ON tbl_User.AuthorisedUserId = tbl_UserRole.AuthorizedUserId
                                WHERE        (tbl_UserRole.RoleId = 1)";
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
                                    showTable(GlobalMethods.ValueIsNull(lstValues[i].FName), GlobalMethods.ValueIsNull(lstValues[i].LName), GlobalMethods.ValueIsNull(lstValues[i].EmailId), GlobalMethods.ValueIsNull(lstValues[i].CreatedDate), GlobalMethods.ValueIsNull(lstValues[i].RoleStatus), GlobalMethods.ValueIsNull(lstValues[i].UserRoleId), Convert.ToInt32(lstValues[i].IsActive));
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
        protected void showTable(string FName, string LName, string Email, string DateCreated, string RoleStatus, string UserRoleId, int AcctStatus)
        {
            UserRoleId = objcryptoJS.AES_encrypt(UserRoleId, AppConstants.secretKey, AppConstants.initVec).ToString();

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
            strContent.Append(GlobalMethods.IsActive(RoleStatus.ToString()));
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='10%' nowrap>");
            if (RoleStatus == "0")
            {
                strContent.Append("<a class='btn btn-xs btn-success open-DeleteVideo' href='#' data-id='");
                strContent.Append(System.Web.HttpUtility.UrlEncode(UserRoleId));
                strContent.Append("' data-toggle='modal'> Activate Role </a>");
            }
            else
            {
                strContent.Append("<a class='btn btn-xs btn-danger open-DeleteVideo' href='#' data-id='");
                strContent.Append(System.Web.HttpUtility.UrlEncode(UserRoleId));
                strContent.Append("' data-toggle='modal'> Deactivate Role </a>");
            }
            strContent.Append("</td>");


            pnlVideos.Controls.Add(new LiteralControl(strContent.ToString()));

        }
        protected void AddTManual_Click(object sender, EventArgs e)
        {
            Security objSecurity = new Security();

            #region "variables"
            string vFName = objSecurity.KillChars(txtFName.Text);
            string vLName = objSecurity.KillChars(txtLName.Text);
            string vEmail = objSecurity.KillChars(txtEmail.Text);
            #endregion

            if (LoginBAL.CheckEmailExsists(vEmail))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('This email address has been used by some other user. Please use another valid email!', '', 'danger', 'Ad_MDE_Mgmt.aspx?MDE=active');", true);
            }
            else
            {
                if (LoginBAL.RegistrationByRole(vFName, vLName, vEmail, 1, Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString())))
                {

                }
            }
        }

        [System.Web.Services.WebMethod(EnableSession = false)]
        public static string CallMgmtRole(string cgi)
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

            return "MDE_AddEmp.aspx?mdeacct=active";
        }
    }
}