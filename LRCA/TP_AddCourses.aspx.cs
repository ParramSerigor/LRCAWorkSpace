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
    public partial class TP_AddCourses : System.Web.UI.Page
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
                string strTPID = string.Empty;
                string strTPStatus = string.Empty;
                string strTPIDs = string.Empty;
                try
                {
                    

                    #region Getting approved Training Provider list
                    List<clsTrainingProvider> lstTPs = new List<clsTrainingProvider>();
                    lstTPs = TrainingProviderDAL.SelectDynamicTrainingProvider("(IsActive = 1) and (CreatedBy = '" + HttpContext.Current.Session["UserAuthId"].ToString() + "')", "TPId");
                    if (lstTPs != null)
                    {
                        if (lstTPs.Count > 0)
                        {
                            for(int i =0; i < lstTPs.Count; i++)
                            {
                                strTPIDs = strTPIDs + lstTPs[i].TPId.ToString() +",";
                                dropTPs.Items.Add(new ListItem(
                                            String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstTPs[i].TP_Name.ToString())), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(objcryptoJS.AES_encrypt(lstTPs[i].TPId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString()))));
                            }
                        }
                    }
                    #endregion
                    strTPIDs = strTPIDs.Substring(0,strTPIDs.Length - 1);
                    #region Getting all the Contractors list 
                    List<clsCategory> lstSPCont = new List<clsCategory>();
                    lstSPCont = CategoryDAL.SelectDynamicCategory("(IsActive = 1) AND (ACRDCategory NOT IN ('Contractor Accreditations', 'Instructor accreditations'))", "ACRDCatID");
                    if (lstSPCont != null)
                    {
                        if (lstSPCont.Count > 0)
                        {
                            dropCourseCat.Items.Add(new ListItem(
                                           String.Format("{0}", "Select Category"), String.Format("{0}", objcryptoJS.AES_encrypt("0", AppConstants.secretKey, AppConstants.initVec).ToString())));

                            for (int i = 0; i < lstSPCont.Count; i++)
                            {
                                dropCourseCat.Items.Add(new ListItem(
                                            String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstSPCont[i].CatTitle.ToString())), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(objcryptoJS.AES_encrypt(lstSPCont[i].ACRDCatID.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString()))));
                            }
                        }
                    }
                    #endregion

                    #region Showing all the Courses added to the list. 
                    List<dynamic> lstValues;
                    string strSQL = @"SELECT tbl_Course.TrainingCourseId, tbl_Course.TPId, tbl_Course.CourseTitle, tbl_Course.ACRDCatID, tbl_Course.InstructionLanguage, tbl_Course.CourseDuration, tbl_Course.MeasurementUnit, tbl_Course.InitialOrRenewal, 
                                     tbl_Course.AttendanceRequirement, tbl_Course.PassScore, tbl_Course.CreateDate, tbl_Course.IsActive, tbl_Category.CatTitle
                                     FROM tbl_Course INNER JOIN
                                     tbl_Category ON tbl_Course.ACRDCatID = tbl_Category.ACRDCatID
                                     WHERE        (tbl_Course.TPId IN("+ Convert.ToInt32(strTPIDs) +"))";
                    var objPar = new DynamicParameters();
                    //objPar.Add("@TPID", strTPID, DbType.Int32);
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
                                        showTable(pnlVideos, GlobalMethods.ValueIsNull(lstValues[i].CourseTitle), GlobalMethods.ValueIsNull(lstValues[i].CatTitle), GlobalMethods.ValueIsNull(lstValues[i].InstructionLanguage), GlobalMethods.ValueIsNull(lstValues[i].CourseDuration), GlobalMethods.ValueIsNull(lstValues[i].AttendanceRequirement), GlobalMethods.ValueIsNull(lstValues[i].PassScore)+ "%", GlobalMethods.ValueIsNull(lstValues[i].CreateDate), Convert.ToInt32(GlobalMethods.ValueIsNull(lstValues[i].TrainingCourseId)));
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
                    pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'>" + GlobalMethods.ContractorAppStatus(9, "bar", "RoleDesc.aspx?Dash=active&cgi="+ IsRole + "") + "</div>"));
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
            if(Convert.ToInt32(Duration) > 1)
            { strContent.Append(Duration+ " Days"); }
            else
            { strContent.Append(Duration + " Day"); }
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            if(Attendence == "1")
            { strContent.Append("YES"); }
            else
            { strContent.Append("NO"); }
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Passing);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Convert.ToDateTime(DateCreated).ToShortDateString());
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-warning' href='#'>Edit</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
        protected void AddTManual_Click(object sender, EventArgs e)
        {
            Security objSecurity = new Security();
            string strTPID = string.Empty;
            try
            {
                //strTPID = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                //if (GlobalMethods.ValueIsNull(strTPID).Length > 0)
                //{
                //    strTPID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                //}

                #region "variables"
                string vTPId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(dropTPs.SelectedItem.Value), AppConstants.secretKey, AppConstants.initVec).ToString(); 
                string vCName = objSecurity.KillChars(txtCTitle.Text);
                string vCategory = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(dropCourseCat.SelectedItem.Value), AppConstants.secretKey, AppConstants.initVec).ToString();
                string vCDesc = objSecurity.KillChars(txtCDesc.Text);
                string vCLanguage = dropLanguage.SelectedItem.Value;
                string vDuration = dropDuration.SelectedItem.Value;
                string vAttendence = dropAttendanceReq.SelectedItem.Value;
                string vPassPercent = dropPassPercent.SelectedItem.Value;
                string vInitRenew = dropInitRenew.SelectedItem.Value;
                #endregion

                #region Object for Training Provider.
                clsCourse objCourse = new clsCourse();
                objCourse.TPId = Convert.ToInt32(vTPId);
                objCourse.CourseTitle = vCName;
                objCourse.Notes = vCDesc;
                objCourse.ACRDCatID = Convert.ToInt32(vCategory);
                objCourse.InstructionLanguage = vCLanguage;
                objCourse.CourseDuration = vDuration;
                objCourse.MeasurementUnit = "percentage";
                objCourse.InitialOrRenewal = vInitRenew;
                objCourse.AttendanceRequirement = vAttendence;
                objCourse.PassScore = vPassPercent;
                objCourse.CreateDate = DateTime.Now;
                objCourse.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
                objCourse.UpdatedDate = Convert.ToDateTime("1/1/1900");
                objCourse.UpdatedBy = "";
                objCourse.IsActive = 1;
                if (!CourseDAL.InsertCourse(objCourse))
                { }
                #endregion

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Course has been submitted successfully!', '', 'success', 'TP_AddCourses.aspx?desh=active&cgi="+ Request["cgi"] +"');", true);

            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }

          
        }
    }
}