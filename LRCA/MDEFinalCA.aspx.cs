using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using System;
using System.Web;
using System.Web.UI;

namespace LRCA
{
    public partial class MDEFinalCA : System.Web.UI.Page
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
                string strTCSID = string.Empty;
                string strTCid = string.Empty;
                try
                {
                    strTCSID = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                    if (GlobalMethods.ValueIsNull(strTCSID).Length > 0)
                    {
                        strTCSID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                    }

                    #region Getting Class Details
                    clsCourse_Result objCS = new clsCourse_Result();
                    objCS = Course_ResultDAL.SelectCourse_ResultById(Convert.ToInt32(strTCSID));
                    if (objCS != null)
                    {
                        #region Getting Employer info
                        clsSP_Contractor objCont = new clsSP_Contractor();
                        objCont = SP_ContractorDAL.SelectSP_ContractorById(objCS.SPContractorID);
                        if(objCont != null)
                        {
                            lblEmployerName.Text = objCont.SPName;
                            lblEmployerEmail.Text = objCont.SPEmail;
                            lblEmployerPhone.Text = objCont.SPPhone + " / " + objCont.SPMobile;
                        }
                        #endregion

                        lblYearFor.Text = objCS.Acct_Term.ToString();

                        clsUser objUser = new clsUser();
                        objUser = UserDAL.SelectUserById(objCS.AuthorisedUserId);
                        if (objUser != null)
                        {
                            lblCrouseName.Text = objUser.FName + " " + objUser.LName;
                            
                        }

                        if (objCS.IsActive == 1)
                        {
                            // this records already exsistes
                            btnAddTManual.Enabled = false;
                            dropEmpVerify.Enabled = false;
                            dropPayment.Enabled = false;
                            dropFinalStatus.Enabled = false;
                            dropBackGround.Enabled = false;
                            txtNotes.Enabled = false;

                            //strTCid = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(strTCid.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                            pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a class='btn btn-success download' title='Download as PDF' href='/" + objcryptoJS.AES_encrypt("Acct_Certificate", AppConstants.secretKey, AppConstants.initVec) + ".cert' target='_blank' >Generate Accreditation Certificate</a>" + GlobalMethods.ContractorAppStatus(1, "bar", "MDE_ApprCertApps.aspx?approvecertapp=active") + "</div>"));
                        }
                        else
                        {
                            btnAddTManual.Enabled = true;
                            dropEmpVerify.Enabled = true;
                            dropPayment.Enabled = true;
                            dropFinalStatus.Enabled = true;
                            dropBackGround.Enabled = true;
                            txtNotes.Enabled = true;
                            //strTCid = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(strTCid.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                            pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'>" + GlobalMethods.ContractorAppStatus(9, "bar", "MDE_ApprCertApps.aspx?approvecertapp=active") + "</div>"));
                        }
                    }
                    #endregion

                   
                    

                }
                catch (Exception)
                {
                    ErrorHandler.ErrorPage();
                }
            }
        }
        protected void AddTManual_Click(object sender, EventArgs e)
        {
            Security objSecurity = new Security();

            #region "variables"
            string vPayment = dropPayment.SelectedItem.Value;
            string vBackGround = dropBackGround.SelectedItem.Value;
            string vVerify = dropEmpVerify.SelectedItem.Value;
            string vComments = string.Empty;
            string vFinalStatus = dropFinalStatus.SelectedItem.Value;


            #endregion

            string strTCSID = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
            if (GlobalMethods.ValueIsNull(strTCSID).Length > 0)
            {
                strTCSID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
            }

            clsCourse_Result objCR = new clsCourse_Result();
            objCR = Course_ResultDAL.SelectCourse_ResultById(Convert.ToInt32(strTCSID));
            if(objCR != null)
            {
                objCR.MDE_AuthorisedUserId = Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString());
                objCR.MDE_EmployerVeri = Convert.ToInt32(vVerify);
                objCR.MDE_BackGround = Convert.ToInt32(vBackGround);
                objCR.MDE_PaymentVeri = Convert.ToInt32(vPayment);
                objCR.MDE_F_Decision = Convert.ToInt32(vFinalStatus);
                objCR.MDE_F_Notes = vComments;
                objCR.Notes = objCR.Notes + "  "+ DateTime.Now.ToShortDateString();
                objCR.IsActive = Convert.ToInt32(vFinalStatus);

                if (Course_ResultDAL.UpdateCourse_Result(objCR))
                {
                    //strTCSID = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(strTCSID.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Saved successfully!', '', 'success', 'MDE_ApprCertApps.aspx?approvecertapp=active');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Error: Cannot Save Records!', '', 'danger', '#');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Error: Cannot Save Records!', '', 'danger', '#');", true);
            }

        }
    }
}