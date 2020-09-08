using LRCA.classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace LRCA
{
    public partial class MDE_CertApps : System.Web.UI.Page
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
                #region Calling first table with all the pending 
                List<dynamic> lstValues;
                string strSQL = @"SELECT        tbl_Course_Result.ClassResultId, tbl_Course_Result.CreatedDate, tbl_Course_Result.Notes, tbl_Course_Result.IsActive, tbl_User.FName, tbl_User.LName, tbl_CourseSchedule.InstructionLanguage, 
                         tbl_TrainingProvider.TP_Name, tbl_CourseSchedule.ClassTitle, tbl_Course_Result.Acct_Term, tbl_Course_Result.PaymentAmount, tbl_Course_Result.MDE_AuthorisedUserId
FROM            tbl_Course_Result INNER JOIN
                         tbl_User ON tbl_Course_Result.AuthorisedUserId = tbl_User.AuthorisedUserId INNER JOIN
                         tbl_CourseSchedule ON tbl_Course_Result.TrainingCourseScheduleId = tbl_CourseSchedule.TrainingCourseScheduleId INNER JOIN
                         tbl_TrainingProvider ON tbl_Course_Result.TPId = tbl_TrainingProvider.TPId
WHERE        (CAST(tbl_Course_Result.Acct_Term AS int) > 0) AND (tbl_Course_Result.IsActive = - 1) AND (tbl_Course_Result.MDE_AuthorisedUserId = 0)";
                var objPar = new DynamicParameters();

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
                                    showTable(pnlVideos, GlobalMethods.ValueIsNull(lstValues[i].FName)+" "+ GlobalMethods.ValueIsNull(lstValues[i].LName), GlobalMethods.ValueIsNull(lstValues[i].ClassTitle), GlobalMethods.ValueIsNull(lstValues[i].TP_Name), GlobalMethods.ValueIsNull(lstValues[i].InstructionLanguage), GlobalMethods.ValueIsNull(lstValues[i].CreatedDate), Convert.ToInt32(GlobalMethods.ValueIsNull(lstValues[i].ClassResultId)));
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
                #endregion

                #region Calling Assigned To Me
                List<dynamic> lstAssigned;
                string strSQL1 = @"SELECT        tbl_Course_Result.ClassResultId, tbl_Course_Result.CreatedDate, tbl_Course_Result.Notes, tbl_Course_Result.IsActive, tbl_User.FName, tbl_User.LName, tbl_CourseSchedule.InstructionLanguage, 
                         tbl_TrainingProvider.TP_Name, tbl_CourseSchedule.ClassTitle, tbl_Course_Result.Acct_Term, tbl_Course_Result.PaymentAmount, tbl_Course_Result.MDE_AuthorisedUserId
FROM            tbl_Course_Result INNER JOIN
                         tbl_User ON tbl_Course_Result.AuthorisedUserId = tbl_User.AuthorisedUserId INNER JOIN
                         tbl_CourseSchedule ON tbl_Course_Result.TrainingCourseScheduleId = tbl_CourseSchedule.TrainingCourseScheduleId INNER JOIN
                         tbl_TrainingProvider ON tbl_Course_Result.TPId = tbl_TrainingProvider.TPId
WHERE        (CAST(tbl_Course_Result.Acct_Term AS int) > 0) AND (tbl_Course_Result.IsActive = - 1) AND (tbl_Course_Result.MDE_AuthorisedUserId > 0)";
                var objPar1 = new DynamicParameters();

                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        lstAssigned = db.Query<dynamic>(strSQL1, objPar1, commandType: CommandType.Text).ToList();
                        if (lstAssigned != null)
                        {
                            if (lstAssigned.Count > 0)
                            {
                                for (int i = 0; i < lstAssigned.Count; i++)
                                {
                                    showTable(pnlMyContApps, GlobalMethods.ValueIsNull(lstAssigned[i].FName) + " " + GlobalMethods.ValueIsNull(lstAssigned[i].LName), GlobalMethods.ValueIsNull(lstAssigned[i].ClassTitle), GlobalMethods.ValueIsNull(lstAssigned[i].TP_Name), GlobalMethods.ValueIsNull(lstAssigned[i].InstructionLanguage), GlobalMethods.ValueIsNull(lstAssigned[i].CreatedDate), Convert.ToInt32(GlobalMethods.ValueIsNull(lstAssigned[i].ClassResultId)));
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
                #endregion

            }
        }
        protected void showTable(Panel pnlName, string CompName, string Category, string ACRDID, string ACRDDateExpire, string DateCreated, int SPContractorID)
        {
            string strSPContractorID = objcryptoJS.AES_encrypt(SPContractorID.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a href='MDEFinalCA.aspx?certapps=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "' >");
            strContent.Append(CompName);
            strContent.Append("</a></td>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(Category);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(ACRDID);
            strContent.Append("</td>");
            strContent.Append("<td width='10%' nowrap>");
            strContent.Append(ACRDDateExpire);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Convert.ToDateTime(DateCreated).ToShortDateString());
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-primary' href='MDEFinalCA.aspx?certapps=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "'>View Details</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
    }
}