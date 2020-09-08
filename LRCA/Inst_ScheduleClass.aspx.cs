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
    public partial class Inst_ScheduleClass : System.Web.UI.Page
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
                string strInstID = string.Empty;
                string strTPID = string.Empty;
                try
                {
                    #region Getting approved Training Provider list
                    List<clsTrainingProvider> lstTPs = new List<clsTrainingProvider>();
                    lstTPs = TrainingProviderDAL.SelectDynamicTrainingProvider("(IsActive = 1) and (CreatedBy = '" + HttpContext.Current.Session["UserAuthId"].ToString() + "')", "TPId");
                    if (lstTPs != null)
                    {
                        if (lstTPs.Count > 0)
                        {
                            dropTPs.Items.Add(new ListItem(
                                            String.Format("{0}", SQLHelper.TrimAndReplaceEOF("Select a Training Provider")), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(objcryptoJS.AES_encrypt("0".ToString(), AppConstants.secretKey, AppConstants.initVec).ToString()))));
                            for (int i = 0; i < lstTPs.Count; i++)
                            {
                                dropTPs.Items.Add(new ListItem(
                                            String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstTPs[i].TP_Name.ToString())), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(objcryptoJS.AES_encrypt(lstTPs[i].TPId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString()))));
                            }
                        }
                    }
                    #endregion

                   
                    #region Showing all the Courses added to the list. 
                    List<dynamic> lstValues;
                    string strSQL = @"SELECT        tbl_CourseSchedule.TrainingCourseScheduleId, tbl_CourseSchedule.CourseId, tbl_CourseSchedule.ClassTitle, tbl_CourseSchedule.StartDate, tbl_CourseSchedule.EndDate, tbl_CourseSchedule.InstructionLanguage, 
                         tbl_CourseSchedule.RegistrationLimit, tbl_CourseSchedule.ExpectedEnrollment, tbl_CourseSchedule.CourseCancelled, tbl_CourseSchedule.CancellationReason, tbl_CourseSchedule.CreateDate, tbl_CourseSchedule.CreatedBy, 
                         tbl_CourseSchedule.UpdatedDate, tbl_CourseSchedule.UpdatedBy, tbl_CourseSchedule.Notes, tbl_CourseSchedule.IsActive, tbl_TrainingProvider.CreatedBy AS UserCreatedTP, tbl_CourseSchedule.CourseCost, 
                         tbl_CourseSchedule.TPLocationId, tbl_Instructor.Instructor_FName, tbl_Instructor.Instructor_LName, tbl_TrainingProvider.TP_Name, tbl_TP_Location.TP_Address_Line_1, tbl_TP_Location.TP_City, tbl_TP_Location.TP_State, 
                         tbl_TP_Location.TP_ZipCode
                        FROM            tbl_CourseSchedule INNER JOIN
                         tbl_TP_Location ON tbl_CourseSchedule.TPLocationId = tbl_TP_Location.TPLocationId INNER JOIN
                         tbl_TrainingProvider ON tbl_CourseSchedule.TPId = tbl_TrainingProvider.TPId INNER JOIN
                         tbl_Instructor ON tbl_CourseSchedule.InstructorId = tbl_Instructor.InstructorId";
                    var objPar = new DynamicParameters();
                    objPar.Add("@AuthorisedUserId", Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString()), DbType.Int32);
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
                                          showTable(pnlVideos, GlobalMethods.ValueIsNull(lstValues[i].ClassTitle), GlobalMethods.ValueIsNull(lstValues[i].StartDate) +" - "+ GlobalMethods.ValueIsNull(lstValues[i].EndDate), GlobalMethods.ValueIsNull(lstValues[i].InstructionLanguage), GlobalMethods.ValueIsNull(lstValues[i].RegistrationLimit), GlobalMethods.ValueIsNull(lstValues[i].CourseCost), "", GlobalMethods.ValueIsNull(lstValues[i].CreateDate), Convert.ToInt32(GlobalMethods.ValueIsNull(lstValues[i].TrainingCourseScheduleId)));
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
                    string IsRole = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode("2"), AppConstants.secretKey, AppConstants.initVec).ToString();
                    pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'>" + GlobalMethods.ContractorAppStatus(9, "bar", "RoleDesc.aspx?Dash=active&cgi=" + IsRole + "") + "</div>"));

                }
                catch (Exception)
                {
                    ErrorHandler.ErrorPage();
                }
            }
        }
        protected void Populate_Instructors(object sender, EventArgs e)
        {
            string vTP = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(dropTPs.SelectedItem.Value.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();

            #region Getting All the locations from this Training Provider.
            //dropLocation
            List<dynamic> lstLocations;
            string strSQLL = @"SELECT DISTINCT tbl_TP_Location.TP_Address_Line_1, tbl_TP_Location.TPLocationId
                               FROM            tbl_TrainingProvider INNER JOIN
                               tbl_TP_Location ON tbl_TrainingProvider.TPId = tbl_TP_Location.TPId
                              WHERE        (tbl_TP_Location.TPId = " + vTP + ")";
            var objParL = new DynamicParameters();

            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    lstLocations = db.Query<dynamic>(strSQLL, objParL, commandType: CommandType.Text).ToList();
                    if (lstLocations != null)
                    {
                        if (lstLocations.Count > 0)
                        {
                            for (int i = 0; i < lstLocations.Count; i++)
                            {

                                dropLocation.Items.Add(new ListItem(
                                                        String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstLocations[i].TP_Address_Line_1.ToString())), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(objcryptoJS.AES_encrypt(lstLocations[i].TPLocationId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString()))));
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

            #region Getting TPId using the InstructorId
            List<dynamic> lstTPInst;
            string strSQLTP = @"SELECT        tbl_LK_TP_Instructor.TP_InstructorsId, tbl_LK_TP_Instructor.IsActive, tbl_Instructor.Instructor_FName, tbl_Instructor.Instructor_LName, tbl_Instructor.InstructorId
FROM            tbl_LK_TP_Instructor INNER JOIN
                         tbl_Instructor ON tbl_LK_TP_Instructor.InstructorId = tbl_Instructor.InstructorId
WHERE        (tbl_LK_TP_Instructor.TPId = @TPID) AND (tbl_LK_TP_Instructor.IsActive = 1)";
            var objParTP = new DynamicParameters();
            objParTP.Add("@TPID", vTP, DbType.Int32);
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    lstTPInst = db.Query<dynamic>(strSQLTP, objParTP, commandType: CommandType.Text).ToList();
                    if (lstTPInst != null)
                    {
                        if (lstTPInst.Count > 0)
                        {
                            dropInst.Items.Add(new ListItem(
                                                               String.Format("{0}",SQLHelper.TrimAndReplaceEOF("Select Instructor")), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(objcryptoJS.AES_encrypt("0".ToString(), AppConstants.secretKey, AppConstants.initVec).ToString()))));
                            for (int i = 0; i < lstTPInst.Count; i++)
                            {
                                dropInst.Items.Add(new ListItem(
                                                                String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstTPInst[i].Instructor_FName.ToString()) + " " + SQLHelper.TrimAndReplaceEOF(lstTPInst[i].Instructor_LName.ToString())), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(objcryptoJS.AES_encrypt(lstTPInst[i].InstructorId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString()))));
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

            #region Getting all the Courses
            List<clsMDE_Courses> lstCats = new List<clsMDE_Courses>();
            lstCats = MDE_CoursesDAL.SelectDynamicMDE_Courses("IsActive = 1", "CourseId");
            if (lstCats != null)
            {
                if (lstCats.Count > 0)
                {
                    for (int i = 0; i < lstCats.Count; i++)
                    {
                        dropCourses.Items.Add(new ListItem(
                                                       String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstCats[i].CourseDescription.ToString()) +" - "+ SQLHelper.TrimAndReplaceEOF(lstCats[i].InstructionLanguage.ToString()) + " - " + SQLHelper.TrimAndReplaceEOF(lstCats[i].InitialOrRenewal.ToString())), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(objcryptoJS.AES_encrypt(lstCats[i].CourseId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString()))));
                    }
                }
            }
            #endregion
            
        }
        protected void showTable(Panel pnlName, string CourseTitle, string Category, string Language, string Duration, string Attendence, string Passing, string DateCreated, int CourseId)
        {
            string strSPContractorID = objcryptoJS.AES_encrypt(CourseId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a href='Inst_Candidate.aspx?dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "' >");
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
            strContent.Append("<a class='btn btn-xs btn-primary' href='Inst_Candidate.aspx?dash=active&cgi="+ System.Web.HttpUtility.UrlEncode(strSPContractorID) + "'>View</a>");
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
               
                #region "variables"
                string vTrainingCourseId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(dropCourses.SelectedItem.Value), AppConstants.secretKey, AppConstants.initVec).ToString();
                string vTPId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(dropTPs.SelectedItem.Value), AppConstants.secretKey, AppConstants.initVec).ToString(); ;
                string vInstID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(dropInst.SelectedItem.Value), AppConstants.secretKey, AppConstants.initVec).ToString(); ; ;
                string vLocationId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(dropLocation.SelectedItem.Value), AppConstants.secretKey, AppConstants.initVec).ToString(); ; ;
                string vCName = objSecurity.KillChars(txtCTitle.Text);
                string vCDesc = objSecurity.KillChars(txtCDesc.Text);
                string vStartDate = objSecurity.KillChars(txtStartDate.Text.ToString());
                string vEndDate = objSecurity.KillChars(txtEndDate.Text.ToString());
                string vRegistrationLimit = objSecurity.KillChars(txtRegisterLimit.Text);
                string vExpectedEnrollment = objSecurity.KillChars(txtMinEnroll.Text);
                string vCLanguage = dropLanguage.SelectedItem.Value;
                string vLocation = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(dropLocation.SelectedItem.Value), AppConstants.secretKey, AppConstants.initVec).ToString();
                string vDesc = objSecurity.KillChars(txtCDesc.Text.ToString());
                string vCost = objSecurity.KillChars(txtCost.Text);
                #endregion

                #region Object for Training Provider.
                clsCourseSchedule objCourseS = new clsCourseSchedule();
                objCourseS.CourseId = Convert.ToInt32(vTrainingCourseId);
                objCourseS.TPId = Convert.ToInt32(vTPId);
                objCourseS.InstructorId = Convert.ToInt32(vInstID);
                objCourseS.TPLocationId = Convert.ToInt32(vLocationId);
                objCourseS.ClassTitle = vCName;
                objCourseS.StartDate = Convert.ToDateTime(vStartDate);
                objCourseS.EndDate = Convert.ToDateTime(vEndDate);
                objCourseS.InstructionLanguage = vCLanguage;
                objCourseS.RegistrationLimit = Convert.ToInt32(vRegistrationLimit);
                objCourseS.ExpectedEnrollment = vExpectedEnrollment;
                objCourseS.CourseCancelled = "";
                objCourseS.CancellationReason = "";
                objCourseS.CourseCost = vCost;
                objCourseS.CreateDate = DateTime.Now;
                objCourseS.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
                objCourseS.UpdatedDate = Convert.ToDateTime("1/1/1900");
                objCourseS.UpdatedBy = "";
                objCourseS.Notes = vDesc;
                objCourseS.IsActive = 1;
                if (!CourseScheduleDAL.InsertCourseSchedule(objCourseS))
                { }
                #endregion

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('You have successfully schedule a class!', '', 'success', 'Inst_ScheduleClass.aspx?desh=active&cgi="+ Request["cgi"] +"');", true);

            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }


        }
    }
}