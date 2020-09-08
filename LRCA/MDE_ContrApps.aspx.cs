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
    public partial class MDE_ContrApps : System.Web.UI.Page
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
                string strContactFName = string.Empty;
                string strContactLName = string.Empty;

                #region Calling first table with all the pending 
                List<dynamic> lstValues;
                string strSQL = @"SELECT        tbl_SP_Contractor.SPContractorID, tbl_SP_Contractor.ACRDCatID, tbl_SP_Contractor.SPName, tbl_SP_Contractor.IsActive, tbl_Category.CatTitle, tbl_SP_Contractor.CreatedDate, tbl_SP_Contractor.ContactLastName, 
                         tbl_SP_Contractor.ContactFirstName, tbl_SP_Contractor.RepLastName, tbl_SP_Contractor.RepFirstName, tbl_SP_Contractor.SPPhone
                                FROM             tbl_SP_Contractor INNER JOIN
                                tbl_Category ON  tbl_SP_Contractor.ACRDCatID = tbl_Category.ACRDCatID
                                WHERE        ( tbl_SP_Contractor.SPContractorID NOT IN
                                (SELECT        SPContractorID
                                FROM            tbl_Contractor_Approval))";
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
                                    if((GlobalMethods.ValueIsNull(lstValues[i].ContactFirstName).Length == 0) && (GlobalMethods.ValueIsNull(lstValues[i].ContactLastName).Length == 0))
                                    {
                                        strContactFName = GlobalMethods.ValueIsNull(lstValues[i].RepFirstName);
                                        strContactLName = GlobalMethods.ValueIsNull(lstValues[i].RepLastName);
                                    }
                                    else
                                    {
                                        strContactFName = GlobalMethods.ValueIsNull(lstValues[i].ContactFirstName);
                                        strContactLName = GlobalMethods.ValueIsNull(lstValues[i].ContactLastName);
                                    }
                                    showTable(pnlVideos, GlobalMethods.ValueIsNull(lstValues[i].SPName), strContactFName +" "+ strContactLName, GlobalMethods.ValueIsNull(lstValues[i].SPPhone), GlobalMethods.ValueIsNull(lstValues[i].CatTitle), GlobalMethods.ValueIsNull(lstValues[i].IsActive), GlobalMethods.ValueIsNull(lstValues[i].CreatedDate), Convert.ToInt32(GlobalMethods.ValueIsNull(lstValues[i].SPContractorID)));
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

                #region Calling Assigned To Me
                List<dynamic> lstAssigned;
                string strSQL1 = @"SELECT    tbl_SP_Contractor.SPContractorID, tbl_SP_Contractor.ACRDCatID, tbl_SP_Contractor.SPName, tbl_SP_Contractor.AccreditationID, tbl_SP_Contractor.AccreditationExpirationDate, tbl_SP_Contractor.IsActive, tbl_Category.CatTitle, 
                         tbl_SP_Contractor.CreatedDate, tbl_Contractor_Approval.MDE_Owner_AuthorisedUserId, tbl_SP_Contractor.ContactLastName, tbl_SP_Contractor.ContactFirstName, tbl_SP_Contractor.RepTitle, tbl_SP_Contractor.RepLastName, 
                         tbl_SP_Contractor.RepFirstName, tbl_SP_Contractor.IsActive
                                  FROM    tbl_SP_Contractor INNER JOIN
                                  tbl_Category ON  tbl_SP_Contractor.ACRDCatID = tbl_Category.ACRDCatID INNER JOIN
                                  tbl_Contractor_Approval ON  tbl_SP_Contractor.SPContractorID = tbl_Contractor_Approval.SPContractorID
                                  WHERE  (tbl_Contractor_Approval.MDE_Owner_AuthorisedUserId = " + HttpContext.Current.Session["UserAuthId"].ToString() + ") AND ( tbl_SP_Contractor.IsActive IN(4,2,3))";
                var objPar1 = new DynamicParameters();

                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        lstAssigned = db.Query<dynamic>(strSQL1, objPar1, commandType: CommandType.Text).ToList();
                        if (lstAssigned != null)
                        {
                            if (lstAssigned.Count > 0)
                            {
                                for (int i = 0; i < lstAssigned.Count; i++)
                                {
                                    if ((GlobalMethods.ValueIsNull(lstAssigned[i].ContactFirstName).Length == 0) && (GlobalMethods.ValueIsNull(lstAssigned[i].ContactLastName).Length == 0))
                                    {
                                        strContactFName = GlobalMethods.ValueIsNull(lstAssigned[i].RepFirstName);
                                        strContactLName = GlobalMethods.ValueIsNull(lstAssigned[i].RepLastName);
                                    }
                                    else
                                    {
                                        strContactFName = GlobalMethods.ValueIsNull(lstAssigned[i].ContactFirstName);
                                        strContactLName = GlobalMethods.ValueIsNull(lstAssigned[i].ContactLastName);
                                    }
                                    showTable(pnlMyContApps, GlobalMethods.ValueIsNull(lstAssigned[i].SPName), strContactFName + " " + strContactLName, GlobalMethods.ValueIsNull(lstAssigned[i].SPPhone), GlobalMethods.ValueIsNull(lstAssigned[i].CatTitle), GlobalMethods.ValueIsNull(lstAssigned[i].IsActive), GlobalMethods.ValueIsNull(lstAssigned[i].CreatedDate), Convert.ToInt32(GlobalMethods.ValueIsNull(lstAssigned[i].SPContractorID)));
                                    //showTable(pnlMyContApps, GlobalMethods.ValueIsNull(lstAssigned[i].SPName), GlobalMethods.ValueIsNull(lstAssigned[i].CatTitle), GlobalMethods.ValueIsNull(lstAssigned[i].AccreditationID), GlobalMethods.ValueIsNull(lstAssigned[i].AccreditationExpirationDate), GlobalMethods.ValueIsNull(lstAssigned[i].CreatedDate), Convert.ToInt32(GlobalMethods.ValueIsNull(lstAssigned[i].SPContractorID)));
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
        protected void showTable(Panel pnlName, string CompName, string Name, string Phone, string Category, string IsActive, string DateCreated, int SPContractorID)
        {
            string strSPContractorID = objcryptoJS.AES_encrypt(SPContractorID.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap><a title='View full application' style='text-decoration: underline;' href='MDEContAppView.aspx?contapps=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "' >");
            strContent.Append(CompName);
            strContent.Append("</a></td>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(Category);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Name);
            strContent.Append("</td>");
            strContent.Append("<td width='10%' nowrap>");
            strContent.Append(Phone);
            strContent.Append("</td>");
            if(pnlName.ID.ToString() == "pnlMyContApps")
            {
                strContent.Append("<td width='10%' nowrap>");
                strContent.Append(GlobalMethods.AppStatus(Convert.ToInt32(IsActive)));
                strContent.Append("</td>");
            }
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(Convert.ToDateTime(DateCreated).ToShortDateString());
            strContent.Append("</td>");
            //***************************************
            strContent.Append("<td width='5%' nowrap>");
            strContent.Append("<a class='btn btn-xs btn-success' title='View full application' href='MDEContAppView.aspx?contapps=active&cgi=" + System.Web.HttpUtility.UrlEncode(strSPContractorID) + "'>View</a>");
            strContent.Append("</td>");

            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
    }
}