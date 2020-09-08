using LRCA.classes;
using LRCA.classes.BAL;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
    public partial class AppView_Cont : System.Web.UI.Page
    {
        CryptoJS objcryptoJS = new CryptoJS();
        protected void Page_init(object sender, EventArgs e)
        {
            string EmpId = HttpContext.Current.Session["UserAuthId"] == null ? string.Empty : HttpContext.Current.Session["UserAuthId"].ToString();
            if (EmpId.Length == 0)
            {
                GlobalMethods.logout();
            }

            if(!AccessRightsBAL.IsContractor(Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString())))
            {
                GlobalMethods.logout();
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strSPContractorID = string.Empty;
                try
                {
                    #region Dropdown Categories
                    List<clsCategory> lstCategory = new List<clsCategory>();
                    lstCategory = CategoryDAL.SelectDynamicCategory("(ACRDCategory = 'Contractor Accreditations') AND (IsActive = 1)", "ACRDCatID");
                    if (lstCategory != null)
                    {
                        if (lstCategory.Count > 0)
                        {
                            dropCategory.Items.Clear();
                            for (int i = 0; i < lstCategory.Count; i++)
                            {

                                dropCategory.Items.Add(new ListItem(
                                            String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstCategory[i].CatTitle.ToString())), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstCategory[i].ACRDCatID.ToString()))));

                            }
                        }
                    }
                    #endregion

                    strSPContractorID = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                    if (GlobalMethods.ValueIsNull(strSPContractorID).Length > 0)
                    {
                        strSPContractorID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                    }

                    clsSP_Contractor objSPCont = new clsSP_Contractor();
                    objSPCont = SP_ContractorDAL.SelectSP_ContractorById(Convert.ToInt32(strSPContractorID));
                    if(objSPCont != null)
                    {
                        lblContractorApp.Text = objSPCont.SPName;
                        lblName.Text = objSPCont.SPName;
                        lblSDATNum.Text = objSPCont.SDATDepartmentId;
                        lblEIN.Text = objSPCont.SPTaxId;
                        lblMHICNumber.Text = objSPCont.SPMHICNumber;
                        dropCategory.SelectedValue = objSPCont.ACRDCatID.ToString();
                        lblCourseName.Text = "<b>"+ dropCategory.SelectedItem.Text + "</b>"; // for heading
                        lblACCID.Text = objSPCont.AccreditationID;
                        lblAccreditationExpirationDate.Text = objSPCont.AccreditationExpirationDate.HasValue ? objSPCont.AccreditationExpirationDate.Value.ToShortDateString() : "";
                        //lblAddress_1.Text = objSPCont.SPAddress_Line_1;
                        //lblAddress_2.Text = objSPCont.SPAddress_Line_2;
                        //lblCity.Text = objSPCont.SPCity;
                        //lblCounty.Text = objSPCont.SPCounty;
                        //lblState.Text = objSPCont.SPState;
                        //lblZipCode.Text = objSPCont.SPZipCode;
                        lblPhone.Text = objSPCont.SPPhone;
                        lblMobile.Text = objSPCont.SPMobile;
                        lblWebSite.Text = objSPCont.SPWebSite;
                        lblEmailAddress.Text = objSPCont.SPEmail;
                        if(objSPCont.SPFeeStatus == "1")
                        {
                            chkFeeStatus.Checked = true;
                        }

                        if(objSPCont.PublishOnMDEWebsite == 1)
                        {
                            chkPublishOnMDEWebsite.Checked = true;
                        }

                        pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'>" + GlobalMethods.ContractorAppStatus(objSPCont.IsActive.HasValue ? objSPCont.IsActive.Value : -1 , "bar","") + "</div>"));
                    }


                   
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorPage();
                }
                
            }
        }
    }
}