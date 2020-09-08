using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using Dapper;
using LRCA.classes;
using LRCA.classes.BAL;

namespace LRCA
{
    public partial class CDetails : System.Web.UI.Page
    {
        CryptoJS objcryptoJS = new CryptoJS();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string strCourseId = string.Empty;
                try
                {
                    strCourseId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                    strCourseId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(strCourseId.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                    List<dynamic> lstValues;
                    string strSQL = @"SELECT DISTINCT 
                         tbl_Course.CourseTitle, tbl_Course.ACRDCatID, tbl_Course.TrainingCourseId, tbl_CourseSchedule.InstructorId, tbl_CourseSchedule.TPLocationId, tbl_CourseSchedule.ClassTitle, tbl_CourseSchedule.StartDate, 
                         tbl_CourseSchedule.EndDate, tbl_CourseSchedule.InstructionLanguage, tbl_Instructor.Instructor_FName, tbl_Instructor.Instructor_LName, tbl_TrainingProvider.TP_Name, tbl_Course.IsActive, 
                         tbl_CourseSchedule.TrainingCourseScheduleId, tbl_Category.CatTitle, tbl_Course.Notes
FROM            tbl_Course INNER JOIN
                         tbl_TrainingProvider ON tbl_Course.TPId = tbl_TrainingProvider.TPId INNER JOIN
                         tbl_CourseSchedule ON tbl_Course.TrainingCourseId = tbl_CourseSchedule.TrainingCourseId INNER JOIN
                         tbl_Instructor ON tbl_CourseSchedule.InstructorId = tbl_Instructor.InstructorId INNER JOIN
                         tbl_TP_Location ON tbl_CourseSchedule.TPLocationId = tbl_TP_Location.TPLocationId INNER JOIN
                         tbl_Category ON tbl_Course.ACRDCatID = tbl_Category.ACRDCatID
                        WHERE (tbl_CourseSchedule.TrainingCourseScheduleId = @CurrID)";
                    var objPar = new DynamicParameters();
                    objPar.Add("@CurrID", strCourseId, DbType.Int32);

                    try
                    {
                        using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                        {
                            lstValues = db.Query<dynamic>(strSQL, objPar, commandType: CommandType.Text).ToList();
                            if (lstValues != null)
                            {
                                if (lstValues.Count > 0)
                                {
                                    lblTitle.Text = GlobalMethods.ValueIsNull(lstValues[0].CourseTitle);
                                    lblDesc.Text = GlobalMethods.ValueIsNull(lstValues[0].Notes);
                                    lblTP.Text = GlobalMethods.ValueIsNull(lstValues[0].TP_Name);
                                    lblLanguage.Text = GlobalMethods.ValueIsNull(lstValues[0].InstructionLanguage);
                                    lblLocation.Text = "";
                                    lblStartDate.Text = Convert.ToDateTime(GlobalMethods.ValueIsNull(lstValues[0].StartDate)).ToShortDateString();
                                    lblEndDate.Text = Convert.ToDateTime(GlobalMethods.ValueIsNull(lstValues[0].EndDate)).ToShortDateString();

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler.ErrorLogging(ex, false);
                        ErrorHandler.ReadError();
                    }
                }
                catch(Exception)
                {
                    ErrorHandler.ErrorPage();
                }
            }
        }
    }
}