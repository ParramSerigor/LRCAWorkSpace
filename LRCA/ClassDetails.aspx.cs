using Dapper;
using LRCA.classes;
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
    public partial class ClassDetails : System.Web.UI.Page
    {
        CryptoJS objcryptoJS = new CryptoJS();
        public static string CourseTitle = string.Empty;
        public static string CourseDesc = string.Empty;
        public static string AttendenceReq = string.Empty;
        public static string language = string.Empty;
        public static string strStartDate = string.Empty;
        public static string strEndDate = string.Empty;
        public static string strDuration = string.Empty;
        public static string strInstructor = string.Empty;
        public static string strLocation = string.Empty;
        public static string strCost = string.Empty;
        public static string strPhone = string.Empty;

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
                string strCourseScheduleId = string.Empty;
                try
                {
                    strCourseScheduleId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                    if (GlobalMethods.ValueIsNull(strCourseScheduleId).Length > 0)
                    {
                        strCourseScheduleId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                    }

                    #region Getting Course Information
                    clsCourseSchedule objCourse = new clsCourseSchedule();
                    objCourse = CourseScheduleDAL.SelectCourseScheduleById(Convert.ToInt32(strCourseScheduleId));
                    if (objCourse != null)
                    {
                        CourseTitle = objCourse.ClassTitle;
                        CourseDesc = objCourse.Notes;
                        AttendenceReq = objCourse.RegistrationLimit.ToString();
                        language = objCourse.InstructionLanguage;
                        strStartDate = Convert.ToDateTime(objCourse.StartDate).ToShortDateString();
                        strEndDate = Convert.ToDateTime(objCourse.EndDate).ToShortDateString();
                        strDuration = "5 hours";// objCourse.InstructionLanguage;
                        strInstructor = "-";
                        strLocation = "-";
                        strCost = "75.00";
                        strPhone = "Instructor Phone";
                    }
                    #endregion

                    #region Checking if this course is already registered.
                    List<clsLK_Inst_CourseSchedule> objInstCS = new List<clsLK_Inst_CourseSchedule>();
                    objInstCS = LK_Inst_CourseScheduleDAL.SelectDynamicLK_Inst_CourseSchedule("TrainingCourseScheduleId = " + strCourseScheduleId + " and AuthorisedUserId = " + HttpContext.Current.Session["UserAuthId"].ToString() + "", "Inst_CourseSchId");
                    if (objInstCS != null)
                    {
                        if (objInstCS.Count > 0)
                        {
                            if (objInstCS[0].IsApproved == 0)
                            {
                                // Applied but not approved
                                pnlAddButton.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a></div><div class='alert alert-warning' style='padding:8px !important;'><b>Applied but Pending Approval</b></div></div>"));
                            }
                            else if (objInstCS[0].IsApproved == 1)
                            {
                                // This has been enrolled.
                                pnlAddButton.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a></div><div class='alert alert-success' style='padding:8px !important;'><b>Enrolled</b></div></div>"));
                            }
                        }
                        else
                        {
                            // User should apply for the class.
                            pnlAddButton.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a><a href='#' class='btn btn-success open-Enroll' data-id='" + Request["cgi"].ToString() + "' data-toggle='modal'>Apply for Enrollment</a></div><div class='alert alert-success' style='padding:8px !important;'>&nbsp;</div></div>"));
                        }
                    }

                    #endregion

                }
                catch (Exception)
                {
                    ErrorHandler.ErrorPage();
                }
            }
        }
        protected void showTable(Panel pnlName, string ClassTitle, string StartDateEndDate, string InstructionLanguage, string TP_Name, string Loc_Ti, string InstName, int CourseId)
        {
            string strSPContractorID = objcryptoJS.AES_encrypt(CourseId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a href='ClassDetails.aspx?dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "' >");
            strContent.Append(ClassTitle);
            strContent.Append("</a></td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(StartDateEndDate);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(InstructionLanguage);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(TP_Name);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append("");
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(InstName);
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-successfull' href='ClassDetails.aspx?dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "'>View Details</a>");
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
                int intInstId = 0;

                #region Getting Instructor Id.
                clsCourseSchedule objCourseSch = new clsCourseSchedule();
                objCourseSch = CourseScheduleDAL.SelectCourseScheduleById(Convert.ToInt32(CourseSchdId));
                if (objCourseSch != null)
                {
                    intInstId = objCourseSch.InstructorId.HasValue ? objCourseSch.InstructorId.Value : 0;
                  //  CourseId = objCourseSch.TrainingCourseId.ToString();
                }
                #endregion

                CourseId = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(CourseId), AppConstants.secretKey, AppConstants.initVec).ToString();

                #region Adding to LK_Inst_CourseSchedule
                clsLK_Inst_CourseSchedule objInstCS = new clsLK_Inst_CourseSchedule();
                objInstCS.AuthorisedUserId = Convert.ToInt32(HttpContext.Current.Session["UserAuthId"]);
                objInstCS.TrainingCourseScheduleId = Convert.ToInt32(CourseSchdId);
                objInstCS.InstructorId = intInstId;
                objInstCS.TP_AuthorisedUserId = 0;
                objInstCS.IsApproved = 0;
                objInstCS.CreatedDate = DateTime.Now;
                objInstCS.ApprovedOn = Convert.ToDateTime("1/1/1900");
                if (!LK_Inst_CourseScheduleDAL.InsertLK_Inst_CourseSchedule(objInstCS))
                { }
                #endregion

            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }
            return "CourseDetails.aspx?dash=active&cgi=" + CourseId + "";
        }
    }
}