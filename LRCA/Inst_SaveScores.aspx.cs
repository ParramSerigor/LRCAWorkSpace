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
    public partial class Inst_SaveScores : System.Web.UI.Page
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
                    clsLK_Inst_CourseSchedule objCS = new clsLK_Inst_CourseSchedule();
                    objCS = LK_Inst_CourseScheduleDAL.SelectLK_Inst_CourseScheduleById(Convert.ToInt32(strTCSID));
                    if (objCS != null)
                    {
                        clsUser objUser = new clsUser();
                        objUser = UserDAL.SelectUserById(objCS.AuthorisedUserId);
                        if(objUser != null)
                        {
                            lblCrouseName.Text = objUser.FName + " " + objUser.LName;
                        }
                    }
                    #endregion

                    #region Checking if this records is already saved.
                    List<clsCourse_Result> objCRsave = new List<clsCourse_Result>();
                    objCRsave = Course_ResultDAL.SelectDynamicCourse_Result("Inst_CourseSchId = "+ strTCSID + "", "ClassResultId");
                    if(objCRsave != null)
                    {
                        if(objCRsave.Count > 0)
                        {
                            // this records already exsistes
                            btnAddTManual.Enabled = false;
                            dropAttendence.Enabled = false;
                            dropPassFail.Enabled = false;
                            dropScore.Enabled = false;
                        }
                        else
                        {
                            btnAddTManual.Enabled = true;
                            dropAttendence.Enabled = true;
                            dropPassFail.Enabled = true;
                            dropScore.Enabled = true;
                        }
                        
                    }
                   
                    #endregion

                    //strTCid = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(strTCid.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                    pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'>" + GlobalMethods.ContractorAppStatus(9, "bar", "Inst_MgmtCourses.aspx?dash=active") + "</div>"));

                }
                catch (Exception)
                {
                    ErrorHandler.ErrorPage();
                }
            }
        }
        protected void AddTManual_Click(object sender, EventArgs e)
        {
            Security objSecurity = new Security();

            #region "variables"
            string vPassFail = dropPassFail.SelectedItem.Value;
            string vtxtAttendence = dropAttendence.SelectedItem.Value;
            string vScore = dropScore.SelectedItem.Value;
            string vAuthorisedUserId = string.Empty;
            string vTrainingCourseScheduleId = string.Empty;
            string vInstructorId = string.Empty;
            string vTPLocationId = string.Empty;
            string vTPId = string.Empty;
            string vSPContractorID = string.Empty;

            #endregion

            string strTCSID = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
            if (GlobalMethods.ValueIsNull(strTCSID).Length > 0)
            {
                strTCSID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
            }

            #region Getting rest of the values.
            List<dynamic> lstCourses;
            string strSQLC = @"SELECT        tbl_LK_Inst_CourseSchedule.Inst_CourseSchId, tbl_LK_Inst_CourseSchedule.AuthorisedUserId, tbl_LK_Inst_CourseSchedule.TrainingCourseScheduleId, tbl_LK_Inst_CourseSchedule.InstructorId, 
                               tbl_LK_Inst_CourseSchedule.TP_AuthorisedUserId, tbl_CourseSchedule.CourseId, tbl_LK_Inst_CourseSchedule.IsApproved, tbl_CourseSchedule.TPLocationId, tbl_CourseSchedule.TPId
                              FROM            tbl_LK_Inst_CourseSchedule INNER JOIN
                              tbl_CourseSchedule ON tbl_LK_Inst_CourseSchedule.TrainingCourseScheduleId = tbl_CourseSchedule.TrainingCourseScheduleId INNER JOIN
                              tbl_TrainingProvider ON tbl_CourseSchedule.TPId = tbl_TrainingProvider.TPId
                              WHERE        (tbl_LK_Inst_CourseSchedule.Inst_CourseSchId = @CourseSchId)";
            var objParC = new DynamicParameters();
            objParC.Add("@CourseSchId", strTCSID, DbType.String);
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    lstCourses = db.Query<dynamic>(strSQLC, objParC, commandType: CommandType.Text).ToList();
                    if (lstCourses != null)
                    {
                        if (lstCourses.Count > 0)
                        {
                            vAuthorisedUserId = GlobalMethods.ValueIsNull(lstCourses[0].AuthorisedUserId);
                            vTrainingCourseScheduleId = GlobalMethods.ValueIsNull(lstCourses[0].TrainingCourseScheduleId);
                            vInstructorId = GlobalMethods.ValueIsNull(lstCourses[0].InstructorId);
                            vTPLocationId = GlobalMethods.ValueIsNull(lstCourses[0].TPLocationId);
                            vTPId = GlobalMethods.ValueIsNull(lstCourses[0].TPId);
                            vSPContractorID = GlobalMethods.ValueIsNull(lstCourses[0].SPContractorID);
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

            #region Checking if this is IsApproved ... if not Updating the value with TPID to LK_Inst_CourseSchedule
            List<clsLK_Inst_CourseSchedule> lstICS = new List<clsLK_Inst_CourseSchedule>();
            lstICS = LK_Inst_CourseScheduleDAL.SelectDynamicLK_Inst_CourseSchedule("Inst_CourseSchId = "+ strTCSID + " and AuthorisedUserId = " + vAuthorisedUserId + " and IsApproved = 1", "Inst_CourseSchId");
            if(lstICS != null)
            {
                if(lstICS.Count > 0)
                {

                }
                else
                {
                    clsLK_Inst_CourseSchedule objICS = new clsLK_Inst_CourseSchedule();
                    objICS = LK_Inst_CourseScheduleDAL.SelectLK_Inst_CourseScheduleById(Convert.ToInt32(strTCSID));
                    if(objICS != null)
                    {
                        objICS.IsApproved = 1;
                        objICS.TP_AuthorisedUserId = Convert.ToInt32(vTPId);
                        if (!LK_Inst_CourseScheduleDAL.UpdateLK_Inst_CourseSchedule(objICS))
                        { }
                    }
                }
            }
            #endregion


            clsCourse_Result objCR = new clsCourse_Result();
            objCR.Inst_CourseSchId = Convert.ToInt32(strTCSID);
            objCR.AuthorisedUserId = Convert.ToInt32(vAuthorisedUserId);
            objCR.TrainingCourseScheduleId = Convert.ToInt32(vTrainingCourseScheduleId);
            objCR.InstructorId = Convert.ToInt32(vInstructorId);
            objCR.MDE_AuthorisedUserId = 0;
            objCR.TPLocationId = Convert.ToInt32(vTPLocationId);
            objCR.TPId = Convert.ToInt32(vTPId);
            objCR.SPContractorID =0;
            objCR.Inst_PASSFAIL = Convert.ToInt32(vPassFail);
            objCR.Inst_Attendence = Convert.ToInt32(vtxtAttendence);
            objCR.Inst_ScorePercent = vScore;
            objCR.Inst_TrainingCard = "";
            objCR.MDE_EmployerVeri =0;
            objCR.MDE_BackGround = 0;
            objCR.MDE_PaymentVeri =0;
            objCR.PaymentAmount = "";
            objCR.Acct_Term = 0;
            objCR.MDE_F_Decision = 0;
            objCR.MDE_F_Notes = "";
            objCR.MDE_Acct_Certificate = "";
            objCR.CreatedDate = DateTime.Now;
            objCR.Notes = "";
            objCR.IsActive = -1;

            if (Course_ResultDAL.InsertCourse_Result(objCR))
            {
                strTCSID = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(strTCSID.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Saved successfully!', '', 'success', 'Inst_SaveScores.aspx?dash=active&cgi="+ strTCSID + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Error: Cannot Save Records!', '', 'danger', '#');", true);
            }

        }
    }
}