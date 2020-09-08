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
    public partial class AppTrainee : System.Web.UI.Page
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
                string strInstID = string.Empty;
                string strTPID = string.Empty;
                string strLocation = string.Empty;
                try
                {

                    #region Showing all the Courses added to the list. 
                    List<clsCourseSchedule> lstCS = new List<clsCourseSchedule>();
                    lstCS = CourseScheduleDAL.SelectDynamicCourseSchedule("(CAST(StartDate AS Date) >= CAST('"+ Convert.ToDateTime(DateTime.Now).ToShortDateString() +"' AS Date))", "TrainingCourseScheduleId");
                            if (lstCS != null)
                            {
                                if (lstCS.Count > 0)
                                {
                                    for (int i = 0; i < lstCS.Count; i++)
                                    {
                                        clsTP_Location objLoc = new clsTP_Location();
                                        objLoc = TP_LocationDAL.SelectTP_LocationById(lstCS[i].TPLocationId);
                                        if(objLoc != null)
                                        {
                                            strLocation = "";
                                        }
                                    
                                        showTable(pnlVideos, GlobalMethods.ValueIsNull(lstCS[i].ClassTitle), GlobalMethods.ValueIsNull(lstCS[i].StartDate) + " - " + GlobalMethods.ValueIsNull(lstCS[i].EndDate), GlobalMethods.ValueIsNull(lstCS[i].InstructionLanguage), GlobalMethods.ValueIsNull(lstCS[i].RegistrationLimit), GlobalMethods.ValueIsNull(lstCS[i].ExpectedEnrollment), GlobalMethods.ValueIsNull(strLocation), GlobalMethods.ValueIsNull(lstCS[i].CreateDate), Convert.ToInt32(GlobalMethods.ValueIsNull(lstCS[i].TrainingCourseScheduleId)));
                                    }
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
        protected void showTable(Panel pnlName, string CourseTitle, string Category, string Language, string Duration, string Attendence, string Passing, string DateCreated, int CourseId)
        {
            string strSPContractorID = objcryptoJS.AES_encrypt(CourseId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a href='MDE_TPAppView.aspx?approvetpapp=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "' >");
            strContent.Append(CourseTitle);
            strContent.Append("</a></td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Category);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Language);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");

            strContent.Append(Duration);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Attendence);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Passing);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Convert.ToDateTime(DateCreated).ToShortDateString());
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-primary open-Register' href='#' data-id='" + strSPContractorID + "' data-toggle='modal' title='Click Here To Register'>Click Here to Register</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
        protected void AddTManual_Click(object sender, EventArgs e)
        {
            Security objSecurity = new Security();
            string strTPID = string.Empty;
            string strInstID = string.Empty;
            try
            {
                strInstID = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                if (GlobalMethods.ValueIsNull(strInstID).Length > 0)
                {
                    strInstID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                }

                #region Getting TPId using the InstructorId
                List<clsTP_Instructors> lstTPInst = new List<clsTP_Instructors>();
                lstTPInst = TP_InstructorsDAL.SelectDynamicTP_Instructors("InstructorId = " + strInstID + "", "TPId");
                if (lstTPInst != null)
                {
                    if (lstTPInst.Count > 0)
                    {
                        strTPID = lstTPInst[0].TPId.ToString();
                    }
                }
                #endregion

                #region "variables"
                string vTrainingCourseId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(dropCourses.SelectedItem.Value), AppConstants.secretKey, AppConstants.initVec).ToString();
                string vTPId = strTPID;
                string vInstID = strInstID;
                string vCName = objSecurity.KillChars(txtCTitle.Text);
                //string vCDesc = objSecurity.KillChars(txtCDesc.Text);
                //string vStartDate = objSecurity.KillChars(txtStartDate.Text.ToString());
                //string vEndDate = objSecurity.KillChars(txtEndDate.Text.ToString());
                //string vRegistrationLimit = objSecurity.KillChars(txtRegisterLimit.Text);
                //string vExpectedEnrollment = objSecurity.KillChars(txtMinEnroll.Text);
                //string vCLanguage = dropLanguage.SelectedItem.Value;
                //string vDesc = objSecurity.KillChars(txtCDesc.Text.ToString());
                #endregion

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('You have successfully schedule a class!', '', 'success', 'Inst_ScheduleClass.aspx?desh=active&cgi=" + Request["cgi"] + "');", true);

            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }


        }
    }
}