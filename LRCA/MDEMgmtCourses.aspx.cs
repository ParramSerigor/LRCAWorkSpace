using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;


namespace LRCA
{
    public partial class MDEMgmtCourses : System.Web.UI.Page
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
                #region Call Tables
                List<dynamic> lstValues;
                string strSQL = @"SELECT        ACRDCatID, CatTitle, CatDescription, ACRDCategory, ValidFor, CreateDate, CreatedBy, UpdatedDate, UpdatedBy, Notes, IsActive
                                  FROM            tbl_Category
                                  WHERE        (IsActive = 1)";
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
                                for (int i = 0; i < lstValues.Count; i++)
                                {
                                    showTable(GlobalMethods.ValueIsNull(lstValues[i].CatTitle), GlobalMethods.ValueIsNull(lstValues[i].ACRDCategory), GlobalMethods.ValueIsNull(lstValues[i].ValidFor),"1", Convert.ToInt32("1"), GlobalMethods.ValueIsNull("70%"), GlobalMethods.ValueIsNull(lstValues[i].ACRDCatID));
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

                #region Dropdown Categories
                List<string> lstCategory;
                string strSQL1 = @"SELECT DISTINCT ACRDCategory
                                    FROM            tbl_Category
                                ORDER BY ACRDCategory";
                var objPar1 = new DynamicParameters();

                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        lstCategory = db.Query<string>(strSQL1, objPar1, commandType: CommandType.Text).ToList();
                        if (lstCategory != null)
                        {
                            if (lstCategory.Count > 0)
                            {
                                dropCategory.Items.Clear();
                                for (int i = 0; i < lstCategory.Count; i++)
                                {

                                    dropCategory.Items.Add(new ListItem(
                                                String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstCategory[i].ToString())), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstCategory[i].ToString()))));

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
      
        protected void showTable(string CatTitle, string ACRDCategory, string ValidFor, string ThirdPartyExam, int PassScore_Required, string PassScore, string MDEMasterId)
        {
            MDEMasterId = objcryptoJS.AES_encrypt(MDEMasterId, AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(CatTitle);
            strContent.Append("</td>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(ACRDCategory);
            strContent.Append("</td>");
          
            strContent.Append("<td width='10%' nowrap>");
            if(Convert.ToInt32(ValidFor) > 0)
            {
                strContent.Append(ValidFor + " Year/s");
            }
            else
            {
                strContent.Append("-");
            }
            
            strContent.Append("</td>");
            strContent.Append("<td width='5%' nowrap>");
            if(ThirdPartyExam == "1")
            {
                strContent.Append("YES");
            }
            else
            {
                strContent.Append("NO");
            }
            strContent.Append("</td>");
            strContent.Append("<td width='5%'nowrap>");
            if (PassScore_Required.ToString() == "1")
            {
                strContent.Append("YES");
            }
            else
            {
                strContent.Append("NO");
            }
            strContent.Append("</td>");
            strContent.Append("<td width='5%'nowrap>");
            strContent.Append(PassScore);
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='10%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-warning open-ActivateAcctOn' href='#' data-id='");
            strContent.Append(System.Web.HttpUtility.UrlEncode(MDEMasterId));
            strContent.Append("' data-toggle='modal'> Edit </a>"); 
            strContent.Append("</td>");

            pnlVideos.Controls.Add(new LiteralControl(strContent.ToString()));

        }
        protected void AddCourse_OnClick(object sender, EventArgs e)
        {
            Security objSecurity = new Security();

            #region "variables"
            string vCategoryId = dropCategory.SelectedItem.Value;
            string vCourseTitle = objSecurity.KillChars(txtTitle.Text);
            string vCourseDesc = objSecurity.KillChars(txtDesc.Text);
            int v3PartyExam = 0;
            int vPassScoreReq = 0;
            int vAttendReq = 0;
            if (chkThirdPartExam.Checked)
            {
                v3PartyExam = 1;
            }

            if (chkPassScoreReq.Checked)
            {
                vPassScoreReq = 1;
            }
            if(chkAttendReq.Checked)
            {
                vAttendReq = 1;
            }
            string vPassScore = objSecurity.KillChars(txtPassScore.Text);

            #endregion
            clsCategory objCourse = new clsCategory();
            objCourse.ACRDCatID = Convert.ToInt32(vCategoryId);
            objCourse.CatTitle = vCourseTitle;
            objCourse.CatDescription = vCourseDesc;
            objCourse.ThirdPartyExam = v3PartyExam;
            objCourse.PassScoreReq = vPassScoreReq;
            objCourse.PassScore = vPassScore;
            objCourse.AttendanceReq = vAttendReq;
            objCourse.CreateDate = DateTime.Now;
            objCourse.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
            objCourse.UpdatedDate = Convert.ToDateTime("1/1/1900");
            objCourse.UpdatedBy = "";
            objCourse.Notes = "";
            objCourse.IsActive = 1;
            if(CategoryDAL.InsertCategory(objCourse))
            {
                Response.Redirect("MDEMgmtCourses.aspx?mdecourse=active");
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Course Added successfully!', '', 'success', 'MDEMgmtCourses.aspx?mdecourse=active');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Error: Cannot add a Course!', '', 'danger', 'MDEMgmtCourses.aspx?mdecourse=active');", true);
            }

        }

        [System.Web.Services.WebMethod(EnableSession = false)]
        public static string CallMgmtAcct(string cgi)
        {
            CryptoJS objcryptoJS = new CryptoJS();
            string AuthUserId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(cgi), AppConstants.secretKey, AppConstants.initVec).ToString();

            List<clsUserRole> lstURole = new List<clsUserRole>();
            lstURole = UserRoleDAL.SelectDynamicUserRole("UserRoleId = " + AuthUserId + "", "UserRoleId");
            if (lstURole != null)
            {
                if (lstURole.Count > 0)
                {
                    if (lstURole[0].IsActive == 0)
                    {
                        lstURole[0].IsActive = 1;
                    }
                    else
                    {
                        lstURole[0].IsActive = 0;
                    }


                    if (!UserRoleDAL.UpdateUserRole(lstURole[0]))
                    {

                    }
                }
            }

            return "MDEMgmtCourses.aspx?mdecourse=active";
        }
    }
}