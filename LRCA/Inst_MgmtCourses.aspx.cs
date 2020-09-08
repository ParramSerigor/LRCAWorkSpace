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
    public partial class Inst_MgmtCourses : System.Web.UI.Page
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
                string strInstID = string.Empty;
                string strTPID = string.Empty;
                string strUserEmail = string.Empty;

                try
                {
                    #region Getting User Email 
                    clsUser objUser = new clsUser();
                    objUser = UserDAL.SelectUserById(Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString()));
                    if (objUser != null)
                    {
                        strUserEmail = objUser.EmailId;
                    }
                    #endregion

                    #region Showing all the Courses added to the list. 
                    List<dynamic> lstValues;
                    //                    string strSQL = @"SELECT DISTINCT 
                    //                         tbl_CourseSchedule.TrainingCourseScheduleId, tbl_CourseSchedule.CourseId, tbl_CourseSchedule.InstructorId, tbl_CourseSchedule.ClassTitle, tbl_CourseSchedule.StartDate, tbl_CourseSchedule.EndDate, 
                    //                         tbl_CourseSchedule.InstructionLanguage, tbl_CourseSchedule.RegistrationLimit, tbl_CourseSchedule.ExpectedEnrollment, tbl_CourseSchedule.CourseCancelled, tbl_CourseSchedule.CancellationReason, 
                    //                         tbl_CourseSchedule.CreateDate, tbl_CourseSchedule.CreatedBy, tbl_CourseSchedule.UpdatedDate, tbl_CourseSchedule.UpdatedBy, tbl_CourseSchedule.Notes, tbl_CourseSchedule.IsActive, tbl_CourseSchedule.TPId, 
                    //                         tbl_TrainingProvider.CreatedBy AS UserCreatedTP, tbl_CourseSchedule.CourseCost, tbl_TrainingProvider.TP_Name
                    //FROM            tbl_CourseSchedule INNER JOIN
                    //                         tbl_TP_Location ON tbl_CourseSchedule.TPId = tbl_TP_Location.TPId INNER JOIN
                    //                         tbl_TrainingProvider ON tbl_CourseSchedule.TPId = tbl_TrainingProvider.TPId
                    //WHERE        (tbl_CourseSchedule.InstructorId = @InstructorId)";
                    string strSQL = @"SELECT DISTINCT 
                         tbl_CourseSchedule.TrainingCourseScheduleId, tbl_CourseSchedule.CourseId, tbl_CourseSchedule.InstructorId, tbl_CourseSchedule.ClassTitle, tbl_CourseSchedule.StartDate, tbl_CourseSchedule.EndDate, 
                         tbl_CourseSchedule.InstructionLanguage, tbl_CourseSchedule.RegistrationLimit, tbl_CourseSchedule.ExpectedEnrollment, tbl_CourseSchedule.CourseCancelled, tbl_CourseSchedule.CancellationReason, 
                         tbl_CourseSchedule.CreateDate, tbl_CourseSchedule.CreatedBy, tbl_CourseSchedule.UpdatedDate, tbl_CourseSchedule.UpdatedBy, tbl_CourseSchedule.Notes, tbl_CourseSchedule.IsActive, tbl_CourseSchedule.TPId, 
                         tbl_TrainingProvider.CreatedBy AS UserCreatedTP, tbl_CourseSchedule.CourseCost, tbl_TrainingProvider.TP_Name, tbl_LK_TP_Instructor.Instructor_AuthoriseUserId, tbl_CourseSchedule.TPLocationId, 
                         tbl_TP_Location.TP_Address_Line_1, tbl_TP_Location.TP_City, tbl_TP_Location.TP_State, tbl_TP_Location.TP_ZipCode
                         FROM            tbl_CourseSchedule INNER JOIN
                         tbl_TrainingProvider ON tbl_CourseSchedule.TPId = tbl_TrainingProvider.TPId INNER JOIN
                         tbl_LK_TP_Instructor ON tbl_CourseSchedule.InstructorId = tbl_LK_TP_Instructor.InstructorId AND tbl_CourseSchedule.TPId = tbl_LK_TP_Instructor.TPId INNER JOIN
                         tbl_TP_Location ON tbl_CourseSchedule.TPLocationId = tbl_TP_Location.TPLocationId
                         WHERE        (tbl_LK_TP_Instructor.Instructor_AuthoriseUserId = @InstructorId)";
                    var objPar = new DynamicParameters();
                    objPar.Add("@InstructorId", Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString()), DbType.Int32);
                    
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
                                        showTable(pnlVideos, GlobalMethods.ValueIsNull(lstValues[i].TP_Name), GlobalMethods.ValueIsNull(lstValues[i].ClassTitle), Convert.ToDateTime(GlobalMethods.ValueIsNull(lstValues[i].StartDate)).ToShortDateString() + "-" + Convert.ToDateTime(GlobalMethods.ValueIsNull(lstValues[i].EndDate)).ToShortDateString(), GlobalMethods.ValueIsNull(lstValues[i].InstructionLanguage), GlobalMethods.ValueIsNull(lstValues[i].CourseCost), GlobalMethods.ValueIsNull(lstValues[i].TP_Address_Line_1) +" / "+ GlobalMethods.ValueIsNull(lstValues[i].TP_City), Convert.ToInt32(GlobalMethods.ValueIsNull(lstValues[i].TrainingCourseScheduleId)));
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

                    string strTCid = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode("3"), AppConstants.secretKey, AppConstants.initVec).ToString();
                    pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'>" + GlobalMethods.ContractorAppStatus(9, "bar", "RoleDesc.aspx?Dash=active&cgi=" + strTCid + "") + "</div>"));

                }
                catch (Exception)
                {
                    ErrorHandler.ErrorPage();
                }
            }
        }
        protected void Populate_Instructors(object sender, EventArgs e)
        {
            //string vTP = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(dropTPs.SelectedItem.Value.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();

            #region Getting InstructorId by User Email.

            #endregion

           
        }
        protected void showTable(Panel pnlName, string TP, string Title, string StartEnd, string Language, string Cost, string locTitle, int CourseId)
        {
            string strSPContractorID = objcryptoJS.AES_encrypt(CourseId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a href='Inst_Scores.aspx?dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "' >");
            strContent.Append(TP);
            strContent.Append("</a></td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Title);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(StartEnd);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");

            strContent.Append(Language);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Cost);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(locTitle);
            strContent.Append("</td>");
          
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-primary' href='Inst_Scores.aspx?dash=active&cgi="+ System.Web.HttpUtility.UrlEncode(strSPContractorID) + "'>View Trainess</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
    }
}