using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using LRCA.classes.Models;
using LRCA.classes.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
    public partial class MDE_TrainAppView : PageBase
    {
        private readonly ITCRepository _tcRepository;
        CryptoJS objcryptoJS = new CryptoJS();
        public MDE_TrainAppView()
        {
            _tcRepository = new TCRepository(_context);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strtcId = string.Empty;
                phWriteComment.Visible = false;

                strtcId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                if (GlobalMethods.ValueIsNull(strtcId).Length > 0)
                {
                    strtcId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                }

                #region Checking if this is AssignedToMe Action
                bool IsAssignedToMe = false;

                var pendingApps = _tcRepository.PendingApps();

                if (pendingApps.Select(x => x.Id).Contains(Convert.ToInt32(strtcId)))
                {
                    // Means this needs Assigned To Me button.
                    IsAssignedToMe = true;
                    phWriteComment.Visible = false;
                }

                #endregion

                var obj = _tcRepository.Get(int.Parse(strtcId));
                if (obj != null)
                {
                    //txtLName.Text = obj.InspectorLastName;
                    //txtSuffix.Text = obj.Suffix;
                    //txtFName.Text = obj.InspectorFirstName;
                    //txtMName.Text = obj.InspectorMiddleName;
                    //lblContractorApp.Text = obj.InspectorFirstName + " " + obj.InspectorLastName; ;

                    //txtAddress_1.Text = obj.InspectorContractor_Address_Line_1;
                    //txtCity_1.Text = obj.InspectorContractor_City;
                    //txtState_1.Text = obj.InspectorContractor_State;
                    //txtZipCode_1.Text = obj.InspectorContractor_ZipCode;
                    //txtAddress_2.Text = obj.InspectorContractor_Address_Line_2;
                    //txtCity_2.Text = obj.InspectorContractor_City_2;
                    //txtState_2.Text = obj.InspectorContractor_State_2;
                    //txtZipcode_2.Text = obj.InspectorContractor_ZipCode_2;
                    //txtPhone.Text = obj.InspectorPhone;
                    //txtEmailAddress.Text = obj.InspectorEmail;
                    //txtDOB.Text = obj.InspectorDOB.FromByteArray();
                    //txtSSNO.Text = obj.InspectorSSN.FromByteArray();
                    //txtACCID.Text = obj.AccreditationID;
                    //txtAccreditationExpirationDate.Text = obj.AccreditationExpirationDate.HasValue ? obj.AccreditationExpirationDate.Value.ToShortDateString() : "";
                    //txtThirdPartyInspTechExamDate.Text = obj.ThirdPartyExamDate.HasValue ? obj.ThirdPartyExamDate.Value.ToShortDateString() : "";
                    //txtThirdPartyRiskAssExamDate.Text = obj.ThirdPartyExamDate.HasValue ? obj.ThirdPartyExamDate.Value.ToShortDateString() : "";
                    //txtMinEx_Start.Text = obj.OneYearMinExperience_Start.HasValue ? obj.OneYearMinExperience_Start.Value.ToShortDateString() : "";
                    //txtMinEx_End.Text = obj.OneYearMinExperience_End.HasValue ? obj.OneYearMinExperience_End.Value.ToShortDateString() : ""; ;
                    //txtInTechAccred.Text = obj.InspectorTechAccreditationId;
                    //chkWaiver.Checked = obj.Waiver == 1;
                    //txtTrainingCardNum.Text = obj.CourseTrainingCardNum;
                    //txtTrainCExpire.Text = obj.CourseExpirationDate;
                    //txtTrainingProviderName.Text = obj.CourseTPName;
                    //txtCourseName.Text = obj.CourseName;
                    //txtCourseStartDate.Text = obj.CourseStartDate.HasValue ? obj.CourseStartDate.Value.ToShortDateString() : "";
                    //txtCourseEndDate.Text = obj.CourseEndDate.HasValue ? obj.CourseEndDate.Value.ToShortDateString() : "";
                    //txtContractorName.Text = obj.InspectorContractorName;
                    //txtContractorAccdNum.Text = obj.InspectorContractorAcctNum;
                    //txtIC_Address_Line_1.Text = obj.InspectorContractor_Address_Line_1;
                    //txtIC_City.Text = obj.InspectorContractor_City;
                    //txtIC_State.Text = obj.InspectorContractor_State;
                    //txtIC_Zipcode.Text = obj.InspectorContractor_ZipCode;
                    //txtICContactFName.Text = obj.InspectorContactFirstName;
                    //txtICContactLName.Text = obj.InspectorContactLastName;
                    //lblContactInfo.Text = obj.InspectorContactFirstName + " " + obj.InspectorContactLastName + " / " + obj.InspectorPhone;
                    //lblDateSigned.Text = obj.CreatedDate.ToLongDateString();
                    //var url = obj.RiskAssessorExperi_URL.Split('\\');
                    //if (url[0].Length > 0)
                    //{
                    //    lkupload.Text = url[1];
                    //    lkupload.NavigateUrl = objcryptoJS.AES_encrypt(Path.GetFileNameWithoutExtension(url[1]), AppConstants.secretKey, AppConstants.initVec) + Path.GetExtension(obj.RiskAssessorExperi_URL);
                    //}
                    //chkIAgree.Checked = obj.Agreed == 1;
                    //dropIsRenewal.SelectedValue = obj.IsRenewal.HasValue ? obj.IsRenewal.Value.ToString() : "-1";

                    //if ((dropIsRenewal.SelectedValue == "0") || (dropIsRenewal.SelectedValue == "-1"))
                    //{
                    //    divIsRenewal.Visible = false;
                    //}

                    //dropCategory.SelectedValue = obj.ACRDCatID.ToString();
                    //if (obj.ACRDCatID == Category.VisualInspector)
                    //{
                    //    divCatInspection.Visible = true;
                    //}
                    //if (obj.ACRDCatID == Category.InspectorTechnician)
                    //{
                    //    divCatResidential.Visible = true;
                    //}
                    //if (obj.ACRDCatID == Category.RiskAccesor)
                    //{
                    //    divCatSteel.Visible = true;
                    //}
                }

                string strEnContractId = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(obj.Id.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                if (IsAssignedToMe)
                {
                    pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a class='btn btn-primary2 open-AssignedToMe' href='#' data-id='" + strEnContractId + "' data-toggle='modal' >Assigned to Me</a>" + GlobalMethods.ContractorAppStatus(obj.IsActive.HasValue ? obj.IsActive.Value : 0, "bar", "") + "</div>"));
                }
                else
                {
                    pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a class='btn btn-success open-Approve' title='Approve Application' href='#' data-id='" + strEnContractId + "' data-toggle='modal' >Approve</a>&nbsp;<a class='btn btn-danger open-Disapprove' href='#' title='Reject Application' data-id='" + strEnContractId + "' data-toggle='modal' >Reject</a>&nbsp;<a class='btn btn-danger2 open-Hold' href='#' title='Put Application On Hold' data-id='" + strEnContractId + "' data-toggle='modal' >On Hold</a>&nbsp;<a class='btn btn-warning open-Deficient' href='#' title='Application status is Deficient' data-id='" + strEnContractId + "' data-toggle='modal' >Deficient</a>" + GlobalMethods.ContractorAppStatus(obj.IsActive.HasValue ? obj.IsActive.Value : 0, "bar", "") + "</div>"));
                }

                #region Disabling all controls.
                GlobalMethods.DisableControls(this.Page);
                #endregion
            }
        }
        protected void AddComm_Click(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod(EnableSession = false)]
        public static string AssignedToMe(string cgi)
        {
            try
            {
                CryptoJS objcryptoJS = new CryptoJS();
                string ContractorAppId = string.Empty;
                ContractorAppId = cgi.ToString() == null ? string.Empty : cgi.ToString();
                if (GlobalMethods.ValueIsNull(ContractorAppId).Length > 0)
                {
                    ContractorAppId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(cgi), AppConstants.secretKey, AppConstants.initVec).ToString();
                }

                clsRiskAssessor_Approval objRiskApp = new clsRiskAssessor_Approval();
                objRiskApp.InspectorRiskAssId = Convert.ToInt32(ContractorAppId);
                objRiskApp.MDE_Owner_AuthorisedUserId = Convert.ToInt32(HttpContext.Current.Session["UserAuthId"]);
                //objRiskApp.CreateDate = DateTime.Now;
                //objRiskApp.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
                //objRiskApp.UpdatedDate = Convert.ToDateTime("1/1/1900");
                //objRiskApp.UpdatedBy = "";
                objRiskApp.Notes = "";
                objRiskApp.IsActive = 1;
                if (!RiskAssessor_ApprovalDAL.InsertRiskAssessor_Approval(objRiskApp))
                {

                }
            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }

            return "MDE_RiskApps.aspx?riskapps=active";
        }

        [System.Web.Services.WebMethod(EnableSession = false)]
        public static string Approve(string cgi)
        {
            CryptoJS objcryptoJS = new CryptoJS();
            string strURL = string.Empty;
            string ContractorAppId = string.Empty;
            try
            {
                ContractorAppId = cgi.ToString() == null ? string.Empty : cgi.ToString();
                if (GlobalMethods.ValueIsNull(ContractorAppId).Length > 0)
                {
                    ContractorAppId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(cgi), AppConstants.secretKey, AppConstants.initVec).ToString();
                }

                List<clsInspector_RiskAssessor> objSPCont = new List<clsInspector_RiskAssessor>();
                objSPCont = Inspector_RiskAssessorDAL.SelectDynamicInspector_RiskAssessor("InspectorRiskAssId = " + ContractorAppId + "", "InspectorRiskAssId");
                if (objSPCont != null)
                {
                    objSPCont[0].IsActive = 1;
                    if (Inspector_RiskAssessorDAL.UpdateInspector_RiskAssessor(objSPCont[0]))
                    {
                        List<clsUserRole> lstURole = new List<clsUserRole>();
                        lstURole = UserRoleDAL.SelectDynamicUserRole("RoleId = 15 and AuthorizedUserId = " + objSPCont[0].CreatedBy + "", "UserRoleId");
                        if (lstURole != null)
                        {
                            if (lstURole.Count > 0)
                            {
                                //ROLE HAS BEEN ASSIGNED. THEREFORE, DONT ADD ANOTHER ROLE.
                            }
                            else
                            {
                                clsUserRole objURole = new clsUserRole();
                                objURole.RoleId = 15;
                                objURole.AuthorizedUserId = Convert.ToInt32(objSPCont[0].CreatedBy);
                                objURole.IsActive = 1;
                                objURole.CreatedDate = DateTime.Now;
                                objURole.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
                                objURole.UpdatedDate = Convert.ToDateTime("1/1/1900");
                                objURole.UpdatedBy = "";
                                objURole.Notes = "";
                                if (!UserRoleDAL.InsertUserRole(objURole))
                                {

                                }
                            }
                        }
                        else
                        {
                            clsUserRole objURole = new clsUserRole();
                            objURole.RoleId = 15;
                            objURole.AuthorizedUserId = Convert.ToInt32(objSPCont[0].CreatedBy);
                            objURole.IsActive = 1;
                            objURole.CreatedDate = DateTime.Now;
                            objURole.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
                            objURole.UpdatedDate = Convert.ToDateTime("1/1/1900");
                            objURole.UpdatedBy = "";
                            objURole.Notes = "";
                            if (!UserRoleDAL.InsertUserRole(objURole))
                            {

                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }
            return "MDE_TrainAppView.aspx?TrainApps=active&cgi=" + cgi + "";
        }

        [System.Web.Services.WebMethod(EnableSession = false)]
        public static string Disapprove(string cgi)
        {
            CryptoJS objcryptoJS = new CryptoJS();
            string strURL = string.Empty;
            string ContractorAppId = string.Empty;
            try
            {
                ContractorAppId = cgi.ToString() == null ? string.Empty : cgi.ToString();
                if (GlobalMethods.ValueIsNull(ContractorAppId).Length > 0)
                {
                    ContractorAppId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(cgi), AppConstants.secretKey, AppConstants.initVec).ToString();
                }

                List<clsInspector_RiskAssessor> objSPCont = new List<clsInspector_RiskAssessor>();
                objSPCont = Inspector_RiskAssessorDAL.SelectDynamicInspector_RiskAssessor("InspectorRiskAssId = " + ContractorAppId + "", "InspectorRiskAssId");
                if (objSPCont != null)
                {
                    objSPCont[0].IsActive = 0;
                    if (Inspector_RiskAssessorDAL.UpdateInspector_RiskAssessor(objSPCont[0]))
                    {
                        List<clsUserRole> lstURole = new List<clsUserRole>();
                        lstURole = UserRoleDAL.SelectDynamicUserRole("RoleId = 15 and AuthorizedUserId = " + objSPCont[0].CreatedBy + "", "UserRoleId");
                        if (lstURole != null)
                        {
                            if (lstURole.Count > 0)
                            {
                                // It should get only one record per ROle.
                                if (!UserRoleDAL.DeleteUserRole(lstURole[0].UserRoleId))
                                { }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }
            return "MDE_TrainAppView.aspx?TrainApps=active&cgi=" + cgi + "";
        }

        [System.Web.Services.WebMethod(EnableSession = false)]
        public static string Hold(string cgi)
        {
            CryptoJS objcryptoJS = new CryptoJS();
            string strURL = string.Empty;
            string ContractorAppId = string.Empty;
            try
            {
                ContractorAppId = cgi.ToString() == null ? string.Empty : cgi.ToString();
                if (GlobalMethods.ValueIsNull(ContractorAppId).Length > 0)
                {
                    ContractorAppId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(cgi), AppConstants.secretKey, AppConstants.initVec).ToString();
                }

                List<clsInspector_RiskAssessor> objSPCont = new List<clsInspector_RiskAssessor>();
                objSPCont = Inspector_RiskAssessorDAL.SelectDynamicInspector_RiskAssessor("InspectorRiskAssId = " + ContractorAppId + "", "InspectorRiskAssId");
                if (objSPCont != null)
                {
                    objSPCont[0].IsActive = 2;
                    if (!Inspector_RiskAssessorDAL.UpdateInspector_RiskAssessor(objSPCont[0]))
                    {

                    }
                }
            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }
            return "MDE_TrainAppView.aspx?TrainApps=active&cgi=" + cgi + "";
        }

        [System.Web.Services.WebMethod(EnableSession = false)]
        public static string Deficient(string cgi)
        {
            CryptoJS objcryptoJS = new CryptoJS();
            string strURL = string.Empty;
            string ContractorAppId = string.Empty;
            try
            {
                ContractorAppId = cgi.ToString() == null ? string.Empty : cgi.ToString();
                if (GlobalMethods.ValueIsNull(ContractorAppId).Length > 0)
                {
                    ContractorAppId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(cgi), AppConstants.secretKey, AppConstants.initVec).ToString();
                }

                List<clsInspector_RiskAssessor> objSPCont = new List<clsInspector_RiskAssessor>();
                objSPCont = Inspector_RiskAssessorDAL.SelectDynamicInspector_RiskAssessor("InspectorRiskAssId = " + ContractorAppId + "", "InspectorRiskAssId");
                if (objSPCont != null)
                {
                    objSPCont[0].IsActive = 3;
                    if (!Inspector_RiskAssessorDAL.UpdateInspector_RiskAssessor(objSPCont[0]))
                    {

                    }
                }
            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }
            return "MDE_TrainAppView.aspx?TrainApps=active&cgi=" + cgi + "";
        }
    }
}