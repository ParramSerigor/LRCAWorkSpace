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
    public partial class dashboardMDE : System.Web.UI.Page
    {
        CryptoJS objcryptoJS = new CryptoJS();
        public string TotalMDECourses = "0";
        public string TotalContractorPendingApps = "0";
        public string TotalTP_Apps ="0";
        public string TotalInstructor_Apps = "0";
        public string TotalMDECertifications = "0";
        public string TotalRisk_Apps = "0";
        public string TotalSuper_Apps = "0";
        public string TotalTrainingCourses = "0";


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

                #region User and Company Info
                clsUser objEmp = new clsUser();
                objEmp = UserDAL.SelectUserById(Convert.ToInt32(Session["UserAuthId"].ToString()));

                #endregion

                #region Getting User Info
                // for side menu. if 3 hide. else show.
                if (objEmp != null)
                {
                    if (GlobalMethods.ValueIsNull(objEmp.ImageURL).Length > 0)
                    {
                        // phProfileImg.Controls.Add(new LiteralControl("<img src='" + objEmp.ImageURL.ToEncryptUrl() + "' width='35%' class='img-circle m-b m-t-md, img-responsive' alt='" + GlobalMethods.stringToMixedCase(objEmp.FName + " " + objEmp.LName) + "'>"));
                        //lblUserName.Text = "<span>" + GlobalMethods.stringToMixedCase(objEmp.FName + " " + objEmp.LName).ToUpper() + "</span>";
                        // lblUserIs.Text = "<span>" + GlobalMethods.stringToMixedCase(objEmp.FName + " " + objEmp.LName) + "</span>";
                        //lblDateJoin.Text = Convert.ToDateTime(objEmp.CreatedDate).ToLongDateString();
                    }
                    else
                    {
                        //  phProfileImg.Controls.Add(new LiteralControl("<img src='CSSBackEnd/img/imagemissing.png' width='35%' class='img-circle m-b m-t-md, img-responsive' alt='" + GlobalMethods.stringToMixedCase(objEmp.FName + " " + objEmp.LName) + "'>"));
                        //  lblUserName.Text = "<span>" + GlobalMethods.stringToMixedCase(objEmp.FName + " " + objEmp.LName).ToUpper() + "</span>";
                        //  lblUserIs.Text = "<span>" + GlobalMethods.stringToMixedCase(objEmp.FName + " " + objEmp.LName) + "</span>";
                        //  lblDateJoin.Text = Convert.ToDateTime(objEmp.CreatedDate).ToLongDateString();
                    }
                    //pnlMDEAccess
                    #region Now getting all the UserRole and making sure buttons are displayed accordingly.
                    List<clsUserRole> lstURole = new List<clsUserRole>();
                    lstURole = UserRoleDAL.SelectDynamicUserRole("AuthorizedUserId = " + objEmp.AuthorisedUserId + "", "UserRoleId");
                    if (lstURole != null)
                    {
                        if (lstURole.Count > 0)
                        {
                            for (int i = 0; i < lstURole.Count; i++)
                            {
                                // This is MDE Role
                               
                            }
                        }
                    }
                    #endregion

                    #region Getting all the totals for dashboard
                    List<clsCategory> lstMDECourse = new List<clsCategory>();
                    lstMDECourse = CategoryDAL.SelectAllCategory();
                    if(lstMDECourse != null)
                    {
                        if(lstMDECourse.Count > 0)
                        {
                            TotalMDECourses = lstMDECourse.Count.ToString();
                        }
                    }
                    #endregion

                    #region Getting all the Pending Contractor Acc Applications
                    TotalContractorPendingApps = "0";

                    List<dynamic> lstValues;
                    string strSQL = @"SELECT        tbl_SP_Contractor.SPContractorID, tbl_SP_Contractor.ACRDCatID, tbl_SP_Contractor.SPName, tbl_SP_Contractor.AccreditationID, tbl_SP_Contractor.AccreditationExpirationDate, 
                                tbl_SP_Contractor.IsActive, tbl_Category.CatTitle, tbl_SP_Contractor.CreatedDate
                                FROM            tbl_SP_Contractor INNER JOIN
                                tbl_Category ON tbl_SP_Contractor.ACRDCatID = tbl_Category.ACRDCatID
                                WHERE        (tbl_SP_Contractor.SPContractorID NOT IN
                                (SELECT        SPContractorID
                                FROM            tbl_Contractor_Approval))";
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
                                    TotalContractorPendingApps = lstValues.Count.ToString();
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

                    #region Getting all New Training Provider Application
                    TotalTP_Apps = "0";
                    List<dynamic> lstTPTotal;
                    string strSQL3 = @"SELECT        tbl_TrainingProvider.TP_Name, tbl_TrainingProvider.TPId, tbl_TrainingProvider.CreatedDate, tbl_Instructor.AccreditationID, tbl_Instructor.AccreditationExpirationDate, tbl_Instructor.Instructor_FName, 
                         tbl_Instructor.Instructor_LName
FROM            tbl_TrainingProvider INNER JOIN
                         tbl_TP_Instructors ON tbl_TrainingProvider.TPId = tbl_TP_Instructors.TPId INNER JOIN
                         tbl_Instructor ON tbl_TP_Instructors.TP_InstructorListId = tbl_Instructor.InstructorId
WHERE        (tbl_TrainingProvider.TPId NOT IN
                             (SELECT        TPId
                               FROM            tbl_TP_Approval))";
                    var objPar3 = new DynamicParameters();

                    try
                    {
                        //objPar.Add("@CompanyId", CompanyId, dbType: DbType.Int32);
                        using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                        {
                            lstTPTotal = db.Query<dynamic>(strSQL3, objPar3, commandType: CommandType.Text).ToList();
                            if (lstTPTotal != null)
                            {
                                if (lstTPTotal.Count > 0)
                                {
                                    TotalTP_Apps = lstTPTotal.Count.ToString();
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

                    #region Getting all the New Instructor Applications
                    List<dynamic> lstInstructorApps;
                    string strSQL4 = @"SELECT        Instructor_FName, Instructor_LName, InstructorId, AccreditationID, AccreditationExpirationDate
FROM            tbl_Instructor
WHERE        (InstructorId NOT IN
                             (SELECT        InstructorId
                               FROM            tbl_Instructor_Approval))";
                    var objPar4 = new DynamicParameters();

                    try
                    {
                        using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                        {
                            lstInstructorApps = db.Query<dynamic>(strSQL4, objPar4, commandType: CommandType.Text).ToList();
                            if (lstInstructorApps != null)
                            {
                                if (lstInstructorApps.Count > 0)
                                {
                                    TotalInstructor_Apps = lstInstructorApps.Count.ToString();
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

                    #region Getting all the New Certifications.
                    List<clsCourse_Result> lstCR = new List<clsCourse_Result>();
                    lstCR = Course_ResultDAL.SelectDynamicCourse_Result("(IsActive = -1) and (Cast(Acct_Term as int) > 0)", "ClassResultId");
                    if(lstCR != null)
                    {
                        if(lstCR.Count > 0)
                        {
                            TotalMDECertifications = lstCR.Count.ToString();
                        }
                    }
                    #endregion

                    #region Getting New Inspector and Risk Assessor
                    TotalRisk_Apps = "0";
                    List<dynamic> lstRiskAssesorApps;
                    string strSQL6 = @"SELECT InspectorRiskAssId
                                       FROM  tbl_Inspector_RiskAssessor
                                      WHERE (InspectorRiskAssId NOT IN
                             (SELECT        InspectorRiskAssId
                               FROM    tbl_RiskAssessor_Approval))";
                    var objPar6 = new DynamicParameters();

                    try
                    {
                        using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                        {
                            lstRiskAssesorApps = db.Query<dynamic>(strSQL6, objPar6, commandType: CommandType.Text).ToList();
                            if (lstRiskAssesorApps != null)
                            {
                                if (lstRiskAssesorApps.Count > 0)
                                {
                                    TotalRisk_Apps = lstRiskAssesorApps.Count.ToString();
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

                    #region Getting New Supervisor
                    TotalSuper_Apps = "0";
                    List<dynamic> lstSuper_Apps;
                    string strSQL7 = @"SELECT SupervisorId
                                       FROM  tbl_Supervisor
                                      WHERE (SupervisorId NOT IN
                             (SELECT        SupervisorId
                               FROM     tbl_Supervisor_Approval))";
                    var objPar7 = new DynamicParameters();

                    try
                    {
                        using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                        {
                            lstSuper_Apps = db.Query<dynamic>(strSQL7, objPar7, commandType: CommandType.Text).ToList();
                            if (lstSuper_Apps != null)
                            {
                                if (lstSuper_Apps.Count > 0)
                                {
                                    TotalSuper_Apps = lstSuper_Apps.Count.ToString();
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

                    #region Getting New Training Courses
                    TotalTrainingCourses = "0";
                    List<dynamic> lstTCourses;
                    string strSQL8 = @"SELECT TrainingCourseAppId
                                       FROM  tbl_TrainingCourse
                                      WHERE (TrainingCourseAppId NOT IN
                             (SELECT        TrainingCourseAppId
                               FROM     tbl_TrainingCourse_Approval))";
                    var objPar8 = new DynamicParameters();

                    try
                    {
                        using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                        {
                            lstTCourses = db.Query<dynamic>(strSQL8, objPar8, commandType: CommandType.Text).ToList();
                            if (lstTCourses != null)
                            {
                                if (lstTCourses.Count > 0)
                                {
                                    TotalTrainingCourses = lstTCourses.Count.ToString();
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
                #endregion

            }
        }
    }
}