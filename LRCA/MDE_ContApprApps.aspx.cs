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
    public partial class MDE_ContApprApps : System.Web.UI.Page
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
                #region Calling first table with all the pending 
                List<dynamic> lstValues;
                string strSQL = @"SELECT         tbl_SP_Contractor.SPContractorID,  tbl_SP_Contractor.ACRDCatID,  tbl_SP_Contractor.SPName,  tbl_SP_Contractor.AccreditationID,  tbl_SP_Contractor.AccreditationExpirationDate, 
                                 tbl_SP_Contractor.IsActive, tbl_Category.CatTitle,  tbl_SP_Contractor.CreatedDate
                                FROM             tbl_SP_Contractor INNER JOIN
                                tbl_Category ON  tbl_SP_Contractor.ACRDCatID = tbl_Category.ACRDCatID
                                WHERE   tbl_SP_Contractor.IsActive = 1";
                var objPar = new DynamicParameters();

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
                                    showTable(pnlVideos, GlobalMethods.ValueIsNull(lstValues[i].SPName), GlobalMethods.ValueIsNull(lstValues[i].CatTitle), GlobalMethods.ValueIsNull(lstValues[i].AccreditationID), GlobalMethods.ValueIsNull(lstValues[i].AccreditationExpirationDate), GlobalMethods.ValueIsNull(lstValues[i].CreatedDate), Convert.ToInt32(GlobalMethods.ValueIsNull(lstValues[i].SPContractorID)));
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

                #region Calling Disaproved applications.
                List<dynamic> lstDisapproved;
                string strSQL1 = @"SELECT         tbl_SP_Contractor.SPContractorID,  tbl_SP_Contractor.ACRDCatID,  tbl_SP_Contractor.SPName,  tbl_SP_Contractor.AccreditationID,  tbl_SP_Contractor.AccreditationExpirationDate, 
                                 tbl_SP_Contractor.IsActive, tbl_Category.CatTitle,  tbl_SP_Contractor.CreatedDate
                                FROM             tbl_SP_Contractor INNER JOIN
                                tbl_Category ON  tbl_SP_Contractor.ACRDCatID = tbl_Category.ACRDCatID
                                WHERE   tbl_SP_Contractor.IsActive = 0";
                var objPar1 = new DynamicParameters();

                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        lstDisapproved = db.Query<dynamic>(strSQL1, objPar1, commandType: CommandType.Text).ToList();
                        if (lstDisapproved != null)
                        {
                            if (lstDisapproved.Count > 0)
                            {
                                for (int i = 0; i < lstDisapproved.Count; i++)
                                {
                                    showTable(pnlDisapproved, GlobalMethods.ValueIsNull(lstDisapproved[i].SPName), GlobalMethods.ValueIsNull(lstDisapproved[i].CatTitle), GlobalMethods.ValueIsNull(lstDisapproved[i].AccreditationID), GlobalMethods.ValueIsNull(lstDisapproved[i].AccreditationExpirationDate), GlobalMethods.ValueIsNull(lstDisapproved[i].CreatedDate), Convert.ToInt32(GlobalMethods.ValueIsNull(lstDisapproved[i].SPContractorID)));
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
        protected void showTable(Panel pnlName, string CompName, string Category, string ACRDID, string ACRDDateExpire, string DateCreated, int SPContractorID)
        {
            string strSPContractorID = objcryptoJS.AES_encrypt(SPContractorID.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a href='MDEContAppView.aspx?contapps=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "' >");
            strContent.Append(CompName);
            strContent.Append("</a></td>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(Category);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(ACRDID);
            strContent.Append("</td>");
            strContent.Append("<td width='10%' nowrap>");
            strContent.Append(Convert.ToDateTime(ACRDDateExpire).ToShortDateString());
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Convert.ToDateTime(DateCreated).ToShortDateString());
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-success' href='MDEContAppView.aspx?contapps=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "'>View</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
    }
}