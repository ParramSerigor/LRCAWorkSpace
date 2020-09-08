using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
    public partial class AppCA : System.Web.UI.Page
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
                try
                {
                    string ClassResultId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                    if (GlobalMethods.ValueIsNull(ClassResultId).Length > 0)
                    {
                        ClassResultId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"]), AppConstants.secretKey, AppConstants.initVec).ToString();
                    }

                    #region Getting all the Contractors list 
                    List<clsSP_Contractor> lstSPCont = new List<clsSP_Contractor>();
                    lstSPCont = SP_ContractorDAL.SelectDynamicSP_Contractor("IsActive = 1 and ACRDCatID = 13", "SPContractorID");
                    if (lstSPCont != null)
                    {
                        if (lstSPCont.Count > 0)
                        {
                            dropContractors.Items.Add(new ListItem(
                                           String.Format("{0}", "Select Contractor"), String.Format("{0}", "0")));
                            for (int i = 0; i < lstSPCont.Count; i++)
                            {

                                dropContractors.Items.Add(new ListItem(
                                            String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstSPCont[i].SPName.ToString())), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(objcryptoJS.AES_encrypt(lstSPCont[i].SPContractorID.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString()))));

                            }
                        }
                    }
                    #endregion

                    clsCourse_Result objCR = new clsCourse_Result();
                    objCR = Course_ResultDAL.SelectCourse_ResultById(Convert.ToInt32(ClassResultId));
                    if (objCR != null)
                    {
                        if ((objCR.Acct_Term > 0))
                        {
                            btnAddCourse.Enabled = false;
                            btnAddCourse.Text = "Applied for C&A Certification";
                        }
                    }
                }
                catch(Exception)
                {

                }

            }
        }
        protected void AddTManual_Click(object sender, EventArgs e)
        {
            Security objSecurity = new Security();
            CryptoJS objcryptoJS = new CryptoJS();
            string ClassResultId = string.Empty;

            #region "variables"
            //// string vSPName = objSecurity.KillChars(txtTPName.Text);
            // string vContractor = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(dropContractors.SelectedItem.Value), AppConstants.secretKey, AppConstants.initVec).ToString();
            // //string vTPPhone = objSecurity.KillChars(txtTPPhone.Text);
            // //string vTPMobile = objSecurity.KillChars(txtTPMobile.Text);
            // //string vTPWebsite = objSecurity.KillChars(txtTPWebsite.Text);
            // //string vTPEmail = objSecurity.KillChars(txtTPEmail.Text);
            // int intNewTPID = 0;
            // int intNewInstructorId = 0;
            #endregion

            #region Instructor Info
            //string vCategory = objcryptoJS.AES_decrypt(dropCategory.SelectedItem.Value, AppConstants.secretKey, AppConstants.initVec).ToString();
            //string vInstructorFName = objSecurity.KillChars(txtInstructorFName.Text);
            //string vInstructorLName = objSecurity.KillChars(txtInstructorLName.Text);
            //string vInsAccId = objSecurity.KillChars(txtInsAccId.Text);
            //string vInsAccExpire = objSecurity.KillChars(txtAccdExpireDate.Text);
            //string vInstEmail = objSecurity.KillChars(txtInstEmail.Text);
            #endregion

            #region Address 1
            //string vAddress_1 = objSecurity.KillChars(txtAddress_1.Text);
            //string vAddress_2 = objSecurity.KillChars(txtAddress_2.Text);
            //string vCity = objSecurity.KillChars(txtCity.Text);
            //string vCounty = objSecurity.KillChars(txtCounty.Text);
            //string vState = objSecurity.KillChars(txtState.Text);
            //string vZipCode = objSecurity.KillChars(txtZipCode.Text);
            //string vEmail = objSecurity.KillChars(txtTPEmail.Text);
            //string vLocationTitle = objSecurity.KillChars(txtLocTitle.Text);
            #endregion

            try
            {
                ClassResultId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                if (GlobalMethods.ValueIsNull(ClassResultId).Length > 0)
                {
                    ClassResultId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"]), AppConstants.secretKey, AppConstants.initVec).ToString();
                }

                clsCourse_Result objCR = new clsCourse_Result();
                objCR = Course_ResultDAL.SelectCourse_ResultById(Convert.ToInt32(ClassResultId));
                if(objCR != null)
                {
                    objCR.PaymentAmount = "120.00";
                    objCR.Acct_Term = Convert.ToInt32(dropYears.SelectedItem.Value);
                    objCR.Notes = "User Entered Contractor Id: " + dropContractors.SelectedItem.Value;
                    if(!Course_ResultDAL.UpdateCourse_Result(objCR))
                    { }

                }
            }
            catch(Exception)
            {
                ErrorHandler.ErrorPage();
            }
            string strResultId = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode("10"), AppConstants.secretKey, AppConstants.initVec).ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been submitted successfully!', '', 'success', 'RoleDesc.aspx?Dash=active&cgi="+ strResultId + "');", true);

        }
    }
}