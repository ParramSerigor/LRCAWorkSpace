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
    public partial class TP_AddLocations : System.Web.UI.Page
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
            string strTPId = string.Empty;

            if (!IsPostBack)
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

                #region Getting list of locations
                List<clsTP_Location> lstLocations = new List<clsTP_Location>();
                lstLocations = TP_LocationDAL.SelectDynamicTP_Location("TPId = "+ strTPId + "", "TPId");
                if(lstLocations != null)
                {
                    if(lstLocations.Count > 0)
                    {
                        for (int i = 0; i < lstLocations.Count; i++)
                        {
                            showTable(pnlVideos,  GlobalMethods.ValueIsNull(lstLocations[i].TP_Address_Line_1), GlobalMethods.ValueIsNull(lstLocations[i].TP_City), GlobalMethods.ValueIsNull(lstLocations[i].TP_State), GlobalMethods.ValueIsNull(lstLocations[i].TP_ZipCode));
                        }
                    }
                }
                #endregion
            }
        }
        protected void AddTManual_Click(object sender, EventArgs e)
        {
            Security objSecurity = new Security();

            #region Address 1
            string vTPID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(dropTPs.SelectedItem.Value), AppConstants.secretKey, AppConstants.initVec).ToString(); 
            string vAddress_1 = objSecurity.KillChars(txtAddress_1.Text);
           // string vAddress_2 = objSecurity.KillChars(txtAddress_2.Text);
            string vCity = objSecurity.KillChars(txtCity.Text);
           // string vCounty = objSecurity.KillChars(txtCounty.Text);
            string vState = objSecurity.KillChars(txtState.Text);
            string vZipCode = objSecurity.KillChars(txtZipCode.Text);
            #endregion
   
                #region Now saving Location
                clsTP_Location objTPLoc = new clsTP_Location();
                objTPLoc.TPId = Convert.ToInt32(vTPID);
                objTPLoc.TP_Address_Line_1 = vAddress_1;
                //objTPLoc.TP_Address_Line_2 = vAddress_2;
                objTPLoc.TP_City = vCity;
                objTPLoc.TP_State = vState;
                //objTPLoc.TP_County = vCounty;
                objTPLoc.TP_ZipCode = vZipCode;
                //objTPLoc.Location_Email = "";
                if (!TP_LocationDAL.InsertTP_Location(objTPLoc))
                {

                }
            #endregion

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Location Added successfully!', '', 'success', 'TP_AddLocations.aspx?desh=active');", true);

        }
        protected void showTable(Panel pnlName, string Address, string City, string State, string ZipCode)
        {  
            StringBuilder strContent = new StringBuilder("<tr>");
            strContent.Append("<td width='15%' nowrap>");
            strContent.Append(Address);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(City);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(State);
            strContent.Append("</td>");
            strContent.Append("<td width='10%'nowrap>");
            strContent.Append(ZipCode);
            strContent.Append("</td>");
            
            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }
    }
}