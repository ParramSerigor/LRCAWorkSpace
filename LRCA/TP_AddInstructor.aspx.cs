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
    public partial class TP_AddInstructor : System.Web.UI.Page
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
                string strTPId = string.Empty;

              

                #region Getting TPId using AuthUserId
                List<dynamic> lstTPValues;
                string strSQLTP = @"SELECT        tbl_User.AuthorisedUserId, tbl_User.FName, tbl_User.LName, tbl_User.Password, tbl_User.TempPassword, tbl_User.salt, tbl_User.EmailId, tbl_User.IsCurrent, tbl_User.IndividualUserID, tbl_User.CreatedDate, 
                         tbl_User.CreatedBy, tbl_User.UpdatedDate, tbl_User.UpdatedBy, tbl_User.Notes, tbl_User.ImageURL, tbl_User.IsAdmin, tbl_User.IsActive, tbl_UserRole.RoleId, tbl_TrainingProvider.TP_Name, tbl_TrainingProvider.TPId
                         FROM            tbl_User INNER JOIN
                         tbl_UserRole ON tbl_User.AuthorisedUserId = tbl_UserRole.AuthorizedUserId INNER JOIN
                         tbl_TrainingProvider ON tbl_User.AuthorisedUserId = tbl_TrainingProvider.CreatedBy
                         WHERE        (tbl_User.AuthorisedUserId = @UserId) AND (tbl_UserRole.RoleId = 2)";
                var objParTP = new DynamicParameters();
                objParTP.Add("@UserId", Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString()), DbType.Int32);
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        lstTPValues = db.Query<dynamic>(strSQLTP, objParTP, commandType: CommandType.Text).ToList();
                        if (lstTPValues != null)
                        {
                            if (lstTPValues.Count > 0)
                            {
                                strTPId = GlobalMethods.ValueIsNull(lstTPValues[0].TPId);
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

                #region Showing all the Courses added to the list. 
                List<dynamic> lstValues;
                string strSQL = @"SELECT        tbl_Instructor.Instructor_LName, tbl_Instructor.Instructor_Email, tbl_Instructor.Instructor_Image, tbl_Instructor.IsActive, tbl_Instructor.InstructorId, tbl_Instructor.Instructor_FName, tbl_Instructor.Instructor_Phone, 
                         tbl_Category.CatTitle, tbl_TrainingProvider.TP_Name, tbl_LK_TP_Instructor.TPId
FROM            tbl_Instructor INNER JOIN
                         tbl_Category ON tbl_Instructor.ACRDCatID = tbl_Category.ACRDCatID INNER JOIN
                         tbl_LK_TP_Instructor ON tbl_Instructor.InstructorId = tbl_LK_TP_Instructor.InstructorId INNER JOIN
                         tbl_TrainingProvider ON tbl_LK_TP_Instructor.TPId = tbl_TrainingProvider.TPId
WHERE        (tbl_TrainingProvider.TPId = @TPId)";
                var objPar = new DynamicParameters();
                objPar.Add("@TPId", Convert.ToInt32(strTPId), DbType.Int32);
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
                                    showTable(pnlVideos, GlobalMethods.ValueIsNull(lstValues[i].Instructor_FName) + " " + GlobalMethods.ValueIsNull(lstValues[i].Instructor_LName), GlobalMethods.ValueIsNull(lstValues[i].Instructor_Email), GlobalMethods.ValueIsNull(lstValues[i].CatTitle), GlobalMethods.ValueIsNull(lstValues[i].Instructor_AcctId), GlobalMethods.ValueIsNull(lstValues[i].CourseCost), GlobalMethods.ValueIsNull(lstValues[i].Instructor_AcctExpire), GlobalMethods.ValueIsNull(lstValues[i].TP_Name), GlobalMethods.ValueIsNull(lstValues[i].IsActive), Convert.ToInt32(GlobalMethods.ValueIsNull(lstValues[i].InstructorId)));
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

            }
        }
        protected void ShowInstructors(object sender, EventArgs e)
        {

           // string strTPId = objcryptoJS.AES_decrypt(dropTPSearch.SelectedItem.Value.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

          
        }
        protected void AddTManual_Click(object sender, EventArgs e)
        {
            Security objSecurity = new Security();
            string vAcctNum = objSecurity.KillChars(txtAcctNumber.Text);

            List<clsInstructor> lstInstructors = new List<clsInstructor>();
            lstInstructors = InstructorDAL.SelectDynamicInstructor("IsActive = 1", "InstructorId");
            if(lstInstructors != null)
            {
                if(lstInstructors.Count > 0)
                {
                    for(int i =0; i < lstInstructors.Count; i++)
                    {
                        showInstructors(pnlInstructors,lstInstructors[i].Instructor_FName +" "+ lstInstructors[i].Instructor_LName, lstInstructors[i].Instructor_Email, lstInstructors[i].AccreditationID.ToString(), Convert.ToDateTime(lstInstructors[i].AccreditationExpirationDate).ToShortDateString(), lstInstructors[i].InstructorId.HasValue ? lstInstructors[i].InstructorId.Value : 0);
                    }
                }
            }

            #region Instructor Info
            //string vTPID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(dropTPs.SelectedItem.Value), AppConstants.secretKey, AppConstants.initVec).ToString();
            //string vCategory = objcryptoJS.AES_decrypt(dropCategory.SelectedItem.Value, AppConstants.secretKey, AppConstants.initVec).ToString();
            //string vInstructorFName = objSecurity.KillChars(txtInstructorFName.Text);
            //string vInstructorLName = objSecurity.KillChars(txtInstructorLName.Text);
            //string vInsAccId = objSecurity.KillChars(txtInsAccId.Text);
            //string vInsAccExpire = objSecurity.KillChars(txtAccdExpireDate.Text);
            //string vEmail = objSecurity.KillChars(txtInstEmail.Text);
            #endregion

            // intNewTPID = Convert.ToInt32(vTPID);

            // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Instructor Added successfully!', '', 'success', 'TP_AddInstructor.aspx?desh=active');", true);

        }
        protected void showTable(Panel pnlName, string CourseTitle, string Category, string Language, string Duration, string Attendence, string Passing, string TPName, string DateCreated, int CourseId)
        {
            string strSPContractorID = objcryptoJS.AES_encrypt(CourseId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a href='#' >");
            strContent.Append(CourseTitle);
            strContent.Append("</a></td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Category);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(TPName);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Language);
            strContent.Append("</td>");
            //strContent.Append("<td width='10%'nowrap>");
            //strContent.Append(Duration);
            //strContent.Append("</td>");
          
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Passing);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(GlobalMethods.ContractorAppStatus(Convert.ToInt32(DateCreated), "badge",""));
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-primary' href='#'>View Details</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
        protected void showInstructors(Panel pnlName, string FullName, string Email, string AcctNum, string DateExpire, int InstructorId)
        {
            string strInstructorId = objcryptoJS.AES_encrypt(InstructorId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(FullName);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Email);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(AcctNum);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(DateExpire);
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-primary' href='#'>Add Instructor</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
    }
}