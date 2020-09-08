using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using Dapper;
using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;

namespace LRCA
{
    public partial class RoleDesc : System.Web.UI.Page
    {
        CryptoJS objcryptoJS = new CryptoJS();
        public string RoleIcon = string.Empty;
        public string RoleText = string.Empty;
        public string RoleTitle = string.Empty;
        public string RoleRegisterURL = string.Empty;

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
            if(!IsPostBack)
            {
                string strRoleId = string.Empty;
                phGeneral.Visible = true;
                phTrainee.Visible = false;
                phInstructors.Visible = false;
                phCertAccedit.Visible = false;
                try
                {
                    strRoleId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();

                    if (GlobalMethods.ValueIsNull(strRoleId).Length > 0)
                    {
                        strRoleId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                        clsRole objRole = new clsRole();
                        objRole = RoleDAL.SelectRoleById(Convert.ToInt32(strRoleId));
                        if(objRole != null)
                        {
                            RoleText = objRole.Notes;
                            RoleIcon = objRole.RoleIcon;
                            RoleTitle = objRole.RoleDispName;
                            RoleRegisterURL =GlobalMethods.ValueIsNull(objRole.RoleRegisterURL);
                        }
                    }

                    #region Now Getting Pending Applications.
                    if(strRoleId == "7") // Contractor Role
                    {
                        #region Now Getting Pending Contractor Applications.
                        List<clsSP_Contractor> lstSPContractor = new List<clsSP_Contractor>();
                        lstSPContractor = SP_ContractorDAL.SelectDynamicSP_Contractor("(CreatedBy = "+ HttpContext.Current.Session["UserAuthId"].ToString() + ")", "CreatedDate DESC");
                        if(lstSPContractor != null)
                        {
                            if(lstSPContractor.Count > 0)
                            {
                                for(int i=0; i < lstSPContractor.Count; i++)
                                {
                                   // showTable(lstSPContractor[i].SPName,lstSPContractor[i].IsActive, lstSPContractor[i].SPContractorID.ToString());
                                }
                            }
                        }
                        #endregion
                        lblLowerTableHead.Text = "Applications";
                        pnlLogicalButtons.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a><a href='" + RoleRegisterURL + "' class='btn btn-primary' title='Apply for the " + RoleTitle + "'>Apply for the " + RoleTitle + " </a></div><div class='alert alert-success' style='padding:8px !important;'>&nbsp;</div></div>"));
                    }
                    else if(strRoleId == "2")// Training Provider
                    {
                        bool IsApprTP = false;
                        string strTPId = string.Empty;
                        #region Checking if User have any TP approved.
                        List<clsTrainingProvider> lstTP = new List<clsTrainingProvider>();
                        lstTP = TrainingProviderDAL.SelectDynamicTrainingProvider("CreatedBy = " + HttpContext.Current.Session["UserAuthId"].ToString() + " and IsActive = 1 ", "TPId");
                        if(lstTP != null)
                        {
                            if(lstTP.Count > 0)
                            {
                                IsApprTP = true;
                                strTPId = lstTP[0].TPId.ToString();
                            }
                        }
                        #endregion

                        #region Now Getting All Training Provider Applications.
                        List<clsTrainingProvider> lstSPContractor = new List<clsTrainingProvider>();
                        lstSPContractor = TrainingProviderDAL.SelectDynamicTrainingProvider("(CreatedBy = " + HttpContext.Current.Session["UserAuthId"].ToString() + ")", "CreatedDate DESC");
                        if (lstSPContractor != null)
                        {
                            if (lstSPContractor.Count > 0)
                            {
                                for (int i = 0; i < lstSPContractor.Count; i++)
                                {
                                    //showTable(lstSPContractor[i].TP_Name, lstSPContractor[i].IsActive, lstSPContractor[i].TPId.ToString());
                                }
                            }
                        }
                        #endregion

                        strTPId = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(strTPId.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                        if (IsApprTP)
                        {
                            //<a class='btn btn-primary' href='TP_AddCourses.aspx?dash=active&cgi=" + Request["cgi"] + "'  >Add Courses</a>
                            pnlLogicalButtons.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a><a class='btn btn-primary' href='Inst_ScheduleClass.aspx?dash=active&cgi=" + Request["cgi"] + "'  >Schedule Courses</a><a class='btn btn-primary' href='TP_AddLocations.aspx?dash=active'  >Add Locations</a><a class='btn btn-primary' href='TP_AddInstructor.aspx?dash=active'  >Add Instructors</a>&nbsp;<a class='btn btn-primary' href='TP_MgmtTraineeCards.aspx?dash=active&cgi="+ strTPId + "'  >Manage Trainee Cards</a></div><div class='alert alert-success' style='padding:8px !important;'>&nbsp;</div></div>"));
                        }
                        else
                        {
                            pnlLogicalButtons.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a><a href='" + RoleRegisterURL + "' class='btn btn-primary' title='Apply for the " + RoleTitle + "'>Apply for the " + RoleTitle + " </a></div><div class='alert alert-success' style='padding:8px !important;'>&nbsp;</div></div>"));
                        }
                        lblLowerTableHead.Text = "Applications";
                    }
                    else if (strRoleId == "3")// Instructor
                    {
                        phGeneral.Visible = false;
                        phInstructors.Visible = true;
                        phTrainee.Visible = false;
                        phCertAccedit.Visible = false;
                        string strUserEmail = string.Empty;
                        bool blShowCourseButton = false;
                        string UserId = string.Empty;

                        #region Getting User Email
                        clsUser objUser = new clsUser();
                        objUser = UserDAL.SelectUserById(Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString()));
                        if(objUser != null)
                        {
                            strUserEmail = objUser.EmailId;
                            UserId = objUser.AuthorisedUserId.ToString();
                        }
                        #endregion

                        #region Checking if Instructor have any assigned Courses and users that applied to the Course.
                        List<dynamic> lstCourses;
                        string strSQLC = @"SELECT        tbl_Instructor.InstructorId, tbl_CourseSchedule.CourseId, tbl_CourseSchedule.TPLocationId, tbl_CourseSchedule.ClassTitle, tbl_CourseSchedule.StartDate, tbl_CourseSchedule.EndDate, 
                                            tbl_CourseSchedule.InstructionLanguage, tbl_CourseSchedule.CreateDate
                                            FROM            tbl_Instructor INNER JOIN
                                            tbl_CourseSchedule ON tbl_Instructor.InstructorId = tbl_CourseSchedule.InstructorId
                                            WHERE        (tbl_Instructor.Instructor_Email = @Email)";
                        var objParC = new DynamicParameters();
                        objParC.Add("@Email", strUserEmail,DbType.String);
                        try
                        {
                            using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                            {
                                lstCourses = db.Query<dynamic>(strSQLC, objParC, commandType: CommandType.Text).ToList();
                                if (lstCourses != null)
                                {
                                    if (lstCourses.Count > 0)
                                    {
                                        blShowCourseButton = true;
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

                        #region Now Getting All Instructor Applications.
                        List<clsInstructor> lstSPContractor = new List<clsInstructor>();
                        lstSPContractor = InstructorDAL.SelectDynamicInstructor("IsActive = 1", "CreatedDate");
                        if (lstSPContractor != null)
                        {
                            if (lstSPContractor.Count > 0)
                            {
                                for (int i = 0; i < lstSPContractor.Count; i++)
                                {
                                    showTableInst(lstSPContractor[i].Instructor_FName , lstSPContractor[i].Instructor_LName, lstSPContractor[i].Instructor_Phone , lstSPContractor[i].Instructor_Email, lstSPContractor[i].InstructorId.ToString());
                                }
                            }
                        }
                        #endregion

                        if(blShowCourseButton)
                        {//UserId
                            #region Checking if this user has been added to UserRole as Instructor
                            List<clsUserRole> lstUR = new List<clsUserRole>();
                            lstUR = UserRoleDAL.SelectDynamicUserRole("(AuthorizedUserId = "+ UserId +") and (RoleId = 3)", "UserRoleId");
                            if(lstUR != null)
                            {
                                if(lstUR.Count <= 0)
                                {
                                    // Dont have UserRole as Instructor.
                                    clsUserRole objUR = new clsUserRole();
                                    objUR.RoleId = 3;
                                    objUR.AuthorizedUserId = Convert.ToInt32(UserId);
                                    objUR.IsActive = 1;
                                    objUR.CreatedDate = DateTime.Now;
                                    objUR.CreatedBy = UserId;
                                    objUR.UpdatedDate = Convert.ToDateTime("1/1/1900");
                                    objUR.UpdatedBy = "";
                                    objUR.Notes = "";
                                    if(!UserRoleDAL.InsertUserRole(objUR))
                                    { }
                                }
                                
                            }
                            #endregion

                            pnlLogicalButtons.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a><a href='Inst_MgmtCourses.aspx?dash=active' class='btn btn-primary'>Manage Scores & Attendence Log</a></div><div class='alert alert-success' style='padding:8px !important;'>&nbsp;</div></div>"));
                        }
                        else
                        {
                            pnlLogicalButtons.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a></div><div class='alert alert-success' style='padding:8px !important;'>&nbsp;</div></div>"));
                        }

                        lblLowerTableHead.Text = "Applications";
                    }
                    else if (strRoleId == "1")
                    {
                        lblLowerTableHead.Text = "Applications";
                        pnlLogicalButtons.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a><a href='" + RoleRegisterURL + "' class='btn btn-primary' title='Apply for the " + RoleTitle + "'>Apply for the " + RoleTitle + " </a></div><div class='alert alert-success' style='padding:8px !important;'>&nbsp;</div></div>"));
                    }
                    else if (strRoleId == "4")
                    {
                        lblLowerTableHead.Text = "Applications";
                        pnlLogicalButtons.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a><a href='" + RoleRegisterURL + "' class='btn btn-primary' title='Apply for the " + RoleTitle + "'>Apply for the " + RoleTitle + " </a></div><div class='alert alert-success' style='padding:8px !important;'>&nbsp;</div></div>"));
                    }
                    else if (strRoleId == "5")
                    {   // Inspector
                        lblLowerTableHead.Text = "Applications";
                        pnlLogicalButtons.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a><a href='" + RoleRegisterURL + "' class='btn btn-primary' title='Apply for the " + RoleTitle + "'>Apply for the " + RoleTitle + " </a></div><div class='alert alert-success' style='padding:8px !important;'>&nbsp;</div></div>"));
                    }
                    else if (strRoleId == "6")
                    {   // Trainee
                        phGeneral.Visible = false;
                        phInstructors.Visible = false;
                        phCertAccedit.Visible = false;
                        phTrainee.Visible = true;
                        pnlLogicalButtons.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a></div><div class='alert alert-success' style='padding:8px !important;'>&nbsp;</div></div>"));

                        #region Getting all the current and future courses.
                        List<dynamic> lstCourseTotal;
                        string strTagValue = string.Empty;
                        
                        StringBuilder strContent = new StringBuilder("<tr>");
                        string strSQL3 = @"SELECT DISTINCT 
                         tbl_CourseSchedule.TrainingCourseScheduleId, tbl_MDE_Courses.CourseDescription, tbl_MDE_Courses.InitialOrRenewal, tbl_TrainingProvider.TP_Name, tbl_CourseSchedule.CourseCost, 
                         tbl_MDE_Courses.InstructionLanguage, tbl_MDE_Courses.CourseDuration, tbl_MDE_Courses.PassScore, tbl_Category.ACRDCategory, tbl_TP_Location.TP_Address_Line_1, tbl_TP_Location.TP_City, tbl_TP_Location.TP_State, 
                         tbl_TP_Location.TP_ZipCode, tbl_TrainingProvider.TP_Telephone, tbl_Instructor.Instructor_FName, tbl_Instructor.Instructor_LName, tbl_MDE_Courses.CourseId, tbl_CourseSchedule.ClassTitle, tbl_CourseSchedule.StartDate, 
                         tbl_CourseSchedule.EndDate, tbl_CourseSchedule.Notes
FROM            tbl_CourseSchedule INNER JOIN
                         tbl_TrainingProvider ON tbl_CourseSchedule.TPId = tbl_TrainingProvider.TPId INNER JOIN
                         tbl_MDE_Courses ON tbl_CourseSchedule.CourseId = tbl_MDE_Courses.CourseId INNER JOIN
                         tbl_Category ON tbl_MDE_Courses.ACRDCatID = tbl_Category.ACRDCatID INNER JOIN
                         tbl_TP_Location ON tbl_CourseSchedule.TPLocationId = tbl_TP_Location.TPLocationId INNER JOIN
                         tbl_Instructor ON tbl_CourseSchedule.InstructorId = tbl_Instructor.InstructorId";
                        
                        try
                        {
                            var objPar3 = new DynamicParameters();
                           // objPar3.Add("@DateIn", Convert.ToDateTime(DateTime.Now).ToShortDateString(), dbType: DbType.String);

                            using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                            {
                                lstCourseTotal = db.Query<dynamic>(strSQL3, objPar3, commandType: CommandType.Text).ToList();
                                if (lstCourseTotal != null)
                                {
                                    if (lstCourseTotal.Count > 0)
                                    {
                                        for(int i=0; i < lstCourseTotal.Count; i++)
                                        {
                                            strTagValue = GlobalMethods.ValueIsNull(lstCourseTotal[i].CourseDescription).ToString().Replace("(","").Replace(" ","").Replace(")", "");
                                            strContent.Append("<div class='element-item transition " + strTagValue + "' data-category='" + strTagValue + "'>");
                                            if(GlobalMethods.ValueIsNull(lstCourseTotal[i].Notes).Length > 110)
                                            {
                                                strContent.Append("<h3 class='name'>" + GlobalMethods.ValueIsNull(lstCourseTotal[i].Notes).Substring(0, 100) + "...</h3>");
                                            }
                                            else
                                            {
                                                strContent.Append("<h3 class='name'>" + GlobalMethods.ValueIsNull(lstCourseTotal[i].Notes) + "</h3>");
                                            }
                                            strContent.Append("<p class='symbol'><a href='CourseDetails.aspx?dash=active&cgi=" + objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(GlobalMethods.ValueIsNull(lstCourseTotal[i].TrainingCourseScheduleId)), AppConstants.secretKey, AppConstants.initVec).ToString() + "' title='" + GlobalMethods.ValueIsNull(lstCourseTotal[i].ClassTitle) + "'>" + GlobalMethods.ValueIsNull(lstCourseTotal[i].ClassTitle) + "</a></p>");
                                            strContent.Append("<p class='number'>"+ GlobalMethods.ValueIsNull(lstCourseTotal[i].InitialOrRenewal) + "</p>");
                                            strContent.Append("<p class='weight' style='align-content:center'><a href='CourseDetails.aspx?dash=active&cgi="+ objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(GlobalMethods.ValueIsNull(lstCourseTotal[i].TrainingCourseScheduleId)), AppConstants.secretKey, AppConstants.initVec).ToString() + "' class='btn btn-xs btn-primary'>View Details</a></p>");
                                            strContent.Append("</div>");
                                        }
                                    }
                                }
                                pnlListofCourses.Controls.Add(new LiteralControl(strContent.ToString()));
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorHandler.ErrorLogging(ex, false);
                            ErrorHandler.ReadError();
                        }
                        #endregion

                        lblLowerTableHead.Text = "Applications";
                    }
                    else if (strRoleId == "8")
                    {
                        lblLowerTableHead.Text = "Applications";
                        pnlLogicalButtons.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a><a href='" + RoleRegisterURL + "' class='btn btn-primary' title='Apply for the " + RoleTitle + "'>Apply for the " + RoleTitle + " </a></div><div class='alert alert-success' style='padding:8px !important;'>&nbsp;</div></div>"));
                    }
                    else if (strRoleId == "9")
                    {   //Oversight
                        lblLowerTableHead.Text = "Applications";
                        pnlLogicalButtons.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a><a href='" + RoleRegisterURL + "' class='btn btn-primary' title='Apply for the " + RoleTitle + "'>Apply for the " + RoleTitle + " </a></div><div class='alert alert-success' style='padding:8px !important;'>&nbsp;</div></div>"));
                    }
                    else if (strRoleId == "10")
                    {
                        //Certificate
                        phGeneral.Visible = false;
                        phTrainee.Visible = false;
                        phInstructors.Visible = false;
                        phCertAccedit.Visible = true;
                        lblLowerTableHead.Text = "Applications";
                        #region Now building the table with Courses Information.
                        
                        List<dynamic> lstCourses;
                        string strSQLC = @"SELECT        tbl_LK_Inst_CourseSchedule.Inst_CourseSchId, tbl_LK_Inst_CourseSchedule.CreatedDate, tbl_LK_Inst_CourseSchedule.ApprovedOn, tbl_Instructor.Instructor_FName, tbl_Instructor.Instructor_LName, 
                         tbl_TrainingProvider.TP_Name, tbl_Category.CatTitle, tbl_Course_Result.ClassResultId, tbl_Course_Result.AuthorisedUserId, tbl_Course_Result.IsActive, tbl_CourseSchedule.TPId, tbl_MDE_Courses.ACRDCatID
FROM            tbl_LK_Inst_CourseSchedule INNER JOIN
                         tbl_Instructor ON tbl_LK_Inst_CourseSchedule.InstructorId = tbl_Instructor.InstructorId INNER JOIN
                         tbl_CourseSchedule ON tbl_LK_Inst_CourseSchedule.TrainingCourseScheduleId = tbl_CourseSchedule.TrainingCourseScheduleId INNER JOIN
                         tbl_Course_Result ON tbl_LK_Inst_CourseSchedule.Inst_CourseSchId = tbl_Course_Result.Inst_CourseSchId INNER JOIN
                         tbl_TrainingProvider ON tbl_CourseSchedule.TPId = tbl_TrainingProvider.TPId INNER JOIN
                         tbl_MDE_Courses ON tbl_CourseSchedule.CourseId = tbl_MDE_Courses.CourseId INNER JOIN
                         tbl_Category ON tbl_MDE_Courses.ACRDCatID = tbl_Category.ACRDCatID
WHERE        (tbl_LK_Inst_CourseSchedule.AuthorisedUserId = @AuthorisedUserId) AND (tbl_Course_Result.AuthorisedUserId = @AuthorisedUserId) AND (tbl_Course_Result.IsActive = - 1)";
                        var objParC = new DynamicParameters();
                        objParC.Add("@AuthorisedUserId", HttpContext.Current.Session["UserAuthId"].ToString(), DbType.String);
                        try
                        {
                            using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                            {
                                lstCourses = db.Query<dynamic>(strSQLC, objParC, commandType: CommandType.Text).ToList();
                                if (lstCourses != null)
                                {
                                    if (lstCourses.Count > 0)
                                    {
                                       for(int i=0; i < lstCourses.Count; i++)
                                        {
                                            showTableCertAccredit(GlobalMethods.ValueIsNull(lstCourses[i].CourseTitle), GlobalMethods.ValueIsNull(lstCourses[i].Instructor_FName) + " " + GlobalMethods.ValueIsNull(lstCourses[i].Instructor_LName), GlobalMethods.ValueIsNull(lstCourses[i].CatTitle), GlobalMethods.ValueIsNull(lstCourses[i].TP_Name), GlobalMethods.ValueIsNull(lstCourses[i].ClassResultId));
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

                        //pnlLogicalButtons.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a></div><div class='alert alert-success' style='padding:8px !important;'>&nbsp;</div></div>"));
                        pnlLogicalButtons.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a href='dashboard.aspx?Dash=active' class='btn btn-primary'>BACK</a><a href='AppContractor.aspx?Dash=active' class='btn btn-primary' title='CONTRACTOR' >CONTRACTOR</a><a href='AppInspector_RiskAssessor.aspx?Dash=active' class='btn btn-primary' title='INSPECTOR AND RISK ASSESSOR'>INSPECTOR AND RISK ASSESSOR</a><a href='AppSupervisor.aspx?Dash=active' class='btn btn-primary' title='SUPERVISOR'>SUPERVISOR</a><a href='AppTrainingCourse.aspx?Dash=active' class='btn btn-primary' title='TRAINING COURSE'>TRAINING COURSE</a><a href='AppTP.aspx?Dash=active' class='btn btn-primary' title='TRAINING PROVIDER'>TRAINING PROVIDER</a><a href='AppInstructor.aspx?Dash=active' class='btn btn-primary' title='INSTRUCTOR'>INSTRUCTOR</a></div><div class='alert' style='background-color:#354A5F;padding:8px !important;'>&nbsp;</div></div>"));
                    }
                    #endregion


                }
                catch(Exception)
                {
                    ErrorHandler.ErrorPage();
                }
                
            }
        }
        protected void showTableCertAccredit(string Title, string Inst_Name, string Cat, string TPName, string ClassResultId)
        {
            string strSPContractorID = objcryptoJS.AES_encrypt(ClassResultId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            bool IsSubmitted = false;

            clsCourse_Result objCR = new clsCourse_Result();
            objCR = Course_ResultDAL.SelectCourse_ResultById(Convert.ToInt32(ClassResultId));
            if(objCR != null)
            {
                if((objCR.Acct_Term > 0))
                {
                    IsSubmitted = true;
                }
            }

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a href='AppCA.aspx?dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "' >");
            strContent.Append(Title);
            strContent.Append("</a></td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Inst_Name);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Cat);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(TPName);
            strContent.Append("</td>");

            //***************************************
            strContent.Append("<td width='5%' nowrap>");

            if(IsSubmitted)
            {
                strContent.Append("<a class='btn btn-xs btn-default' href='#'>Applied for C&A Certification</a>");
            }
            else
            {
                strContent.Append("<a class='btn btn-xs btn-primary' href='AppCA.aspx?dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "'>Apply for C&A</a>");
            }
            
            strContent.Append("</td>");

            pnlMyCourses.Controls.Add(new LiteralControl(strContent.ToString()));
        }
        protected void showTableInst(string Instructor_FName , string Instructor_LName, string Instructor_Phone, string Instructor_Email, string InstructorId)
        {
            string strSPContractorID = objcryptoJS.AES_encrypt(InstructorId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a href='ClassDetails.aspx?dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "' >");
            strContent.Append(Instructor_FName);
            strContent.Append("</a></td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Instructor_LName);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Instructor_Email);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Instructor_Phone);
            strContent.Append("</td>");
           
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-primary' href='#'>Detail View</a>");
            strContent.Append("</td>");

            pnlVideos.Controls.Add(new LiteralControl(strContent.ToString()));
        }
        protected void showTable(string AppTitle, int StatusIn, string AppId, int RoleId,string DateCreated)
        {
            string strRoleId = string.Empty;

            try
            {
                AppId = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(AppId), AppConstants.secretKey, AppConstants.initVec).ToString();

                strRoleId = RoleId.ToString();

                if (GlobalMethods.ValueIsNull(strRoleId).Length > 0)
                {
                    strRoleId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                }

                StringBuilder strContent = new StringBuilder("<tr>");
                if(strRoleId == "7") // For Contractor Application Detail view
                {
                    strContent.Append("<td><b><a href='AppView_Cont.aspx?dash=active&cgi="+ AppId + "'>");
                }
                else if(strRoleId == "2")
                {
                    strContent.Append("<td><b><a href='AppView_TP.aspx?dash=active&cgi=" + AppId + "'>");
                }
                else if (strRoleId == "3")
                {
                    strContent.Append("<td><b><a href='AppView_Instructor.aspx?dash=active&cgi=" + AppId + "'>");
                }
                else
                {
                    strContent.Append("<td><b><a href='#'>");
                }
                strContent.Append(AppTitle);
                strContent.Append("</a></b>");
                strContent.Append("</td>");
                strContent.Append("<td>");
                strContent.Append("Contractor Accreditation");
                strContent.Append("</td>");
                strContent.Append("<td>");
                strContent.Append("Date Created");
                strContent.Append("</td>");
                strContent.Append("<td>");
                strContent.Append(GlobalMethods.ContractorAppStatus(StatusIn,"badge",""));
                strContent.Append("</td>");
                strContent.Append("<td>");
                if (strRoleId == "7")
                {
                    strContent.Append("<a class='btn btn-xs btn-primary' href='AppView_Cont.aspx?dash=active&cgi=" + AppId + "'>View</a>");
                }
                else if(strRoleId == "2")
                {
                    strContent.Append("<a class='btn btn-xs btn-primary' href='AppView_TP.aspx?dash=active&cgi=" + AppId + "'>View</a>");
                }
                else if (strRoleId == "3")
                {
                    strContent.Append("<a class='btn btn-xs btn-primary' href='AppView_Instructor.aspx?dash=active&cgi=" + AppId + "'>View</a>");
                }
               strContent.Append("</td>");
                pnlMyCourses.Controls.Add(new LiteralControl(strContent.ToString()));

            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }
            
        }
    }
}