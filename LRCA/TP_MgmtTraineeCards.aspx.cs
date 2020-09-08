using Dapper;
using LRCA.classes;
using LRCA.classes.BAL;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
    public partial class TP_MgmtTraineeCards : System.Web.UI.Page
    {
        CryptoJS objcryptoJS = new CryptoJS();
        protected void Page_init(object sender, EventArgs e)
        {
            string EmpId = HttpContext.Current.Session["UserAuthId"] == null ? string.Empty : HttpContext.Current.Session["UserAuthId"].ToString();
            if (EmpId.Length == 0)
            {
                GlobalMethods.logout();
            }
            if (!AccessRightsBAL.IsTP(Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString())))
            {
                GlobalMethods.logout();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strTPID = string.Empty;
                string strTCid = string.Empty;
                try
                {
                    strTPID = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                    if (GlobalMethods.ValueIsNull(strTPID).Length > 0)
                    {
                        strTPID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                    }

                    #region Showing all the Courses added to the list. 
                    List<dynamic> lstValues;
                    string strSQL = @"SELECT        tbl_TrainingProvider.TPId, tbl_TrainingProvider.TP_Name, tbl_TrainingProvider.TP_Logo_URL, tbl_TrainingProvider.TP_WebSite, tbl_TrainingProvider.TP_Telephone, tbl_TrainingProvider.CreatedDate, 
                         tbl_TrainingProvider.CreatedBy, tbl_TrainingProvider.UpdatedDate, tbl_TrainingProvider.UpdatedBy, tbl_TrainingProvider.Notes, tbl_TrainingProvider.IsActive, tbl_Course_Result.AuthorisedUserId, 
                         tbl_LK_Inst_CourseSchedule.IsApproved, tbl_User.FName, tbl_User.LName, tbl_User.EmailId, tbl_LK_Inst_CourseSchedule.ApprovedOn, tbl_Instructor.Instructor_FName, tbl_Instructor.Instructor_LName, 
                         tbl_CourseSchedule.StartDate, tbl_CourseSchedule.EndDate, tbl_LK_Inst_CourseSchedule.Inst_CourseSchId
FROM            tbl_Course_Result INNER JOIN
                         tbl_TrainingProvider ON tbl_Course_Result.TPId = tbl_TrainingProvider.TPId INNER JOIN
                         tbl_LK_Inst_CourseSchedule ON tbl_Course_Result.AuthorisedUserId = tbl_LK_Inst_CourseSchedule.AuthorisedUserId INNER JOIN
                         tbl_User ON tbl_Course_Result.AuthorisedUserId = tbl_User.AuthorisedUserId INNER JOIN
                         tbl_TP_Location ON tbl_Course_Result.TPLocationId = tbl_TP_Location.TPLocationId INNER JOIN
                         tbl_Instructor ON tbl_Course_Result.InstructorId = tbl_Instructor.InstructorId INNER JOIN
                         tbl_CourseSchedule ON tbl_Course_Result.TrainingCourseScheduleId = tbl_CourseSchedule.TrainingCourseScheduleId
WHERE        (tbl_TrainingProvider.TPId = @TPID) AND (tbl_LK_Inst_CourseSchedule.IsApproved = 1)";
                    var objPar = new DynamicParameters();
                    objPar.Add("@TPID", Convert.ToInt32(strTPID), DbType.Int32);
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
                                        showTable(pnlVideos, GlobalMethods.ValueIsNull(lstValues[i].FName), GlobalMethods.ValueIsNull(lstValues[i].LName), GlobalMethods.ValueIsNull(lstValues[i].EmailId), "", GlobalMethods.ValueIsNull(lstValues[i].Instructor_FName) + " " + GlobalMethods.ValueIsNull(lstValues[i].Instructor_LName), Convert.ToDateTime(GlobalMethods.ValueIsNull(lstValues[i].StartDate)).ToShortDateString() + "-" + Convert.ToDateTime(GlobalMethods.ValueIsNull(lstValues[i].EndDate)).ToShortDateString(), Convert.ToInt32(GlobalMethods.ValueIsNull(lstValues[i].IsApproved)), Convert.ToInt32(GlobalMethods.ValueIsNull(lstValues[i].Inst_CourseSchId)));
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
                    strTCid = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode("2".ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                    pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'>" + GlobalMethods.ContractorAppStatus(9, "bar", "RoleDesc.aspx?Dash=active&cgi="+ strTCid  + "") + "</div>"));

                }
                catch (Exception)
                {
                    ErrorHandler.ErrorPage();
                }
            }
        }

        protected void showTable(Panel pnlName, string FName, string LName, string Email, string Location, string Instructor, string StartEnds, int IsActive, int CourseId)
        {
            string strSPContractorID = objcryptoJS.AES_encrypt(CourseId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(FName);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(LName);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Email);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");

            strContent.Append(Location);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Instructor);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(StartEnds);
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            //if (IsActive == 1)
            //{
            //    strContent.Append("<a href='#' class='btn btn-xs btn-default'>Enrolled</a>");
            //}
            //else
            //{
                strContent.Append("<a class='btn btn-xs btn-success download' title='Download as PDF' href='/" + objcryptoJS.AES_encrypt("TrainingCard", AppConstants.secretKey, AppConstants.initVec) + ".cert' target='_blank' >Generate Training Card</a>");
            //}

            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }

        [System.Web.Services.WebMethod(EnableSession = false)]
        public static string Enroll(string cgi)
        {
            CryptoJS objcryptoJS = new CryptoJS();
            string strURL = string.Empty;
            string CourseSchdId = string.Empty;
            string CourseId = string.Empty;
            try
            {
                CourseSchdId = cgi.ToString() == null ? string.Empty : cgi.ToString();
                if (GlobalMethods.ValueIsNull(CourseSchdId).Length > 0)
                {
                    CourseSchdId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(cgi), AppConstants.secretKey, AppConstants.initVec).ToString();
                }


                clsLK_Inst_CourseSchedule objISC = new clsLK_Inst_CourseSchedule();
                objISC = LK_Inst_CourseScheduleDAL.SelectLK_Inst_CourseScheduleById(Convert.ToInt32(CourseSchdId));
                if (objISC != null)
                {
                    objISC.TP_AuthorisedUserId = Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString());
                    objISC.IsApproved = 1;
                    CourseId = objISC.TrainingCourseScheduleId.ToString();
                    if (!LK_Inst_CourseScheduleDAL.UpdateLK_Inst_CourseSchedule(objISC))
                    { }
                }
                CourseId = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(CourseId), AppConstants.secretKey, AppConstants.initVec).ToString();
            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }


            return "Inst_Scores.aspx?dash=active&cgi=" + CourseId + "";
        }
    }
}