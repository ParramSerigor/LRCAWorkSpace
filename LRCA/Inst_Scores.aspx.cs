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
    public partial class Inst_Scores : System.Web.UI.Page
    {
        CryptoJS objcryptoJS = new CryptoJS();
        protected void Page_init(object sender, EventArgs e)
        {
            string EmpId = HttpContext.Current.Session["UserAuthId"] == null ? string.Empty : HttpContext.Current.Session["UserAuthId"].ToString();
            if (EmpId.Length == 0)
            {
                GlobalMethods.logout();
            }
            if (!AccessRightsBAL.IsInstructor(Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString())))
            {
                GlobalMethods.logout();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strTCSID = string.Empty;
                string strTCid = string.Empty;
                try
                {
                    strTCSID = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                    if (GlobalMethods.ValueIsNull(strTCSID).Length > 0)
                    {
                        strTCSID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                    }

                    #region Getting Class Details
                    clsCourseSchedule objCS = new clsCourseSchedule();
                    objCS = CourseScheduleDAL.SelectCourseScheduleById(Convert.ToInt32(strTCSID));
                    if (objCS != null)
                    {
                        lblCrouseName.Text = objCS.ClassTitle;
                    }
                    #endregion

                    #region Showing all the Courses added to the list. 
                    List<dynamic> lstValues;
                    string strSQL = @"SELECT        tbl_LK_Inst_CourseSchedule.CreatedDate, tbl_User.FName, tbl_User.LName, tbl_User.EmailId, tbl_LK_Inst_CourseSchedule.IsApproved, tbl_LK_Inst_CourseSchedule.TrainingCourseScheduleId, 
                         tbl_LK_Inst_CourseSchedule.AuthorisedUserId, tbl_LK_Inst_CourseSchedule.Inst_CourseSchId, tbl_LK_Inst_CourseSchedule.TP_AuthorisedUserId, tbl_LK_Inst_CourseSchedule.InstructorId, tbl_Instructor.Instructor_FName, 
                         tbl_Instructor.Instructor_LName,  tbl_CourseSchedule.StartDate, tbl_CourseSchedule.EndDate,tbl_CourseSchedule.CourseId
FROM            tbl_LK_Inst_CourseSchedule INNER JOIN
                         tbl_User ON tbl_LK_Inst_CourseSchedule.AuthorisedUserId = tbl_User.AuthorisedUserId INNER JOIN
                         tbl_Instructor ON tbl_LK_Inst_CourseSchedule.InstructorId = tbl_Instructor.InstructorId INNER JOIN
                         tbl_CourseSchedule ON tbl_LK_Inst_CourseSchedule.TrainingCourseScheduleId = tbl_CourseSchedule.TrainingCourseScheduleId INNER JOIN
                         tbl_TP_Location ON tbl_CourseSchedule.TPLocationId = tbl_TP_Location.TPLocationId
                                     WHERE        (tbl_LK_Inst_CourseSchedule.TrainingCourseScheduleId = @TCSId)";
                    var objPar = new DynamicParameters();
                    objPar.Add("@TCSId", Convert.ToInt32(strTCSID), DbType.Int32);
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
                                        if (i == 0)
                                        {
                                            strTCid = GlobalMethods.ValueIsNull(lstValues[i].TrainingCourseId);
                                        }
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
                    strTCid = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(strTCid.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                    pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'>" + GlobalMethods.ContractorAppStatus(9, "bar", "Inst_MgmtCourses.aspx?dash=active") + "</div>"));

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
            strContent.Append("<td width='15%' nowrap><a href='Inst_SaveScores.aspx?dash=active&cgi=" + strSPContractorID + "' >");
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
            //    strContent.Append("<a href='#' class='btn btn-xs btn-default'>Records Saved</a>");
            //}
            //else
            //{
                strContent.Append("<a href='Inst_SaveScores.aspx?dash=active&cgi="+ strSPContractorID + "' class='btn btn-xs btn-success'>Attendence Log</a>");
           // }

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