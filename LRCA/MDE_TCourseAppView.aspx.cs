using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using LRCA.classes.Models;
using LRCA.classes.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
    public partial class MDE_TCourseAppView : PageBase
    {
        private readonly ITCRepository _tcRepository;
        CryptoJS objcryptoJS = new CryptoJS();
        public MDE_TCourseAppView()
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
                string strTrainingCourseAppId = string.Empty;
                phWriteComment.Visible = false;

                strTrainingCourseAppId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
                if (GlobalMethods.ValueIsNull(strTrainingCourseAppId).Length > 0)
                {
                    strTrainingCourseAppId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                }

                #region Getting all the Comments by Application Id.
                StringBuilder strMessenger = new StringBuilder("");
                List<clsTrainingCourse_Comment> lstComments = new List<clsTrainingCourse_Comment>();
                lstComments = TrainingCourse_CommentDAL.SelectDynamicTrainingCourse_Comment("TrainingCourseAppId = " + strTrainingCourseAppId + "", "TrainingCourseCommentId");
                if (lstComments != null)
                {
                    if (lstComments.Count > 0)
                    {

                        for (int i = 0; i < lstComments.Count; i++)
                        {
                            strMessenger.Append(GlobalMethods.Messenger(lstComments[i].CreatedBy.ToString(), Convert.ToDateTime(lstComments[i].CreatedDate).ToLongDateString(), lstComments[i].Comment.ToString()).ToString());
                        }
                    }
                }
                pnlComments.Controls.Add(new LiteralControl(strMessenger.ToString()));
                #endregion

                #region Checking if this is AssignedToMe Action
                bool IsAssignedToMe = false;

                var pendingApps = _tcRepository.PendingApps();

                if (pendingApps.Select(x => x.Id).Contains(Convert.ToInt32(strTrainingCourseAppId)))
                {
                    // Means this needs Assigned To Me button.
                    IsAssignedToMe = true;
                    phWriteComment.Visible = false;
                }

                #endregion

                var obj = _tcRepository.Get(int.Parse(strTrainingCourseAppId));
                if (obj != null)
                {
                    txtTPName.Text = obj.TrainingProviderName;
                    txtAddress_1.Text = obj.TP_Address_Line_1;
                    txtCity_1.Text = obj.TP_City;
                    txtState_1.Text = obj.TP_State;
                    txtZipCode_1.Text = obj.TP_ZipCode;
                    txtAddress_2.Text = obj.TP_Address_Line_2;
                    txtCity_2.Text = obj.TP_City_2;
                    txtState_2.Text = obj.TP_State_2;
                    txtZipcode_2.Text = obj.TP_Zipcode_2;
                    txtPhone.Text = obj.TP_Telephone;
                    txtFax.Text = obj.TP_Fax;
                    txtEmailAddress.Text = obj.TP_Email;
                    txtSSN.Text = obj.TP_TaxID.FromByteArray();
                   chkIAgree.Checked = obj.Agreed == 1;
					//dropIsRenewal.SelectedValue = obj.IsRenewal.HasValue ? obj.IsRenewal.Value.ToString() : "-1";

                    if ((dropIsRenewal.SelectedValue == "0") || (dropIsRenewal.SelectedValue == "-1"))
                    {
                        divIsRenewal.Visible = false;
                    }
                    txtACCID.Text = obj.AccreditationID;
                    txtAccreditationExpirationDate.Text = obj.AccreditationExpirationDate.HasValue ? obj.AccreditationExpirationDate.Value.ToShortDateString() : "";
                    chkRiskAssessor.Checked = obj.TC_RiskAssessor == 1;
                    chkInspectorTech.Checked = obj.TC_InspectorTech == 1;
                    chkVisualInspector.Checked = obj.TC_VisualInspector == 1;
                    chkMainRepaint.Checked = obj.TC_Main_Repair == 1;
                    chkRemoval.Checked = obj.TC_Removal == 1;
                    chkProjectDesign.Checked = obj.TC_ProjectDesign == 1;
                    chkAbatmentEnglish.Checked = obj.TC_AbatementWorkerEnglish == 1;
                    chkAbatmentSpanish.Checked = obj.TC_AbatementWorkerSpanish == 1;
                    chkStructSteelSuper.Checked = obj.TC_StructSteelSuper == 1;
                    chkStructSteelWorker.Checked = obj.TC_StructSteelWorker == 1;
                    hlnkUpload_1.NavigateUrl = obj.DocURL_1;
                    hlnkUpload_2.NavigateUrl = obj.DocURL_2;
                    hlnkUpload_3.NavigateUrl = obj.DocURL_3;
                    hlnkUpload_4.NavigateUrl = obj.DocURL_4;
                    hlnkUpload_5.NavigateUrl = obj.DocURL_5;
                    txtAuthRepContFName.Text = obj.TPContactFirstName;
                    txtAuthRepContLName.Text = obj.TPContactLastName;
                    txtAuthRepContTitle.Text = obj.TPContactTitle;
                    chkIAgree.Checked = obj.Agreed == 1;
                    lblDateSigned.Text = obj.CreatedDate.ToShortDateString();
                    lblSignedBy.Text = obj.TPContactFirstName +" "+ obj.TPContactLastName;

                    #region Getting all the Case files.
                    StringBuilder strMessengerUpload = new StringBuilder("");

                    foreach (var each in obj.Files.OrderByDescending(x => x.Id))
                    {
                        strMessengerUpload.Append(GlobalMethods.UploadedFiles(each.CreatedBy.ToString(), Convert.ToDateTime(each.CreatedDate).ToLongDateString(), each.FileLocation.ToString()).ToString());
                    }
                    pnlUploads.Controls.Add(new LiteralControl(strMessengerUpload.ToString()));
                    #endregion
                }

                string strEnContractId = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(obj.Id.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
                if (IsAssignedToMe)
                {
                    GlobalMethods.DisableControls(this.Page);
                    btnAddCourse.Visible = false;
                    pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a class='btn btn-primary2 open-AssignedToMe' href='#' data-id='" + strEnContractId + "' data-toggle='modal' >Assigned to Me</a>" + GlobalMethods.ContractorAppStatus(obj.IsActive.HasValue ? obj.IsActive.Value : 0, "bar", "") + "</div>"));
                }
                else
                {
                    phWriteComment.Visible = true;
                    pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a class='btn btn-success open-Approve' title='Approve Application' href='#' data-id='" + strEnContractId + "' data-toggle='modal' >Approve</a>&nbsp;<a class='btn btn-danger open-Disapprove' href='#' title='Reject Application' data-id='" + strEnContractId + "' data-toggle='modal' >Reject</a>&nbsp;<a class='btn btn-primary open-Hold' href='#' title='Put Application On Hold' data-id='" + strEnContractId + "' data-toggle='modal' >On Hold</a>&nbsp;<a class='btn btn-primary open-Deficient' href='#' title='Application status is Deficient' data-id='" + strEnContractId + "' data-toggle='modal' >Deficient</a>" + GlobalMethods.ContractorAppStatus(obj.IsActive.HasValue ? obj.IsActive.Value : 0, "bar", "") + "</div>"));
                }

                #region Making all the fields disabled.
                GlobalMethods.DisableControl_CheckBoxByID(chkIAgree);
                GlobalMethods.DisableControl_DropDownByID(dropIsRenewal);
                #endregion	
            }
        }
        protected void UploadFiles(object sender, EventArgs e)
        {
            string strFile = upload_1.FileName;
            if (upload_1.HasFile)
            {
                var path = Path.Combine("uf", upload_1.FileName);
                try
                {
                    upload_1.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path));
                    _tcRepository.AddFile(TrainingCourse_File.Create(GetId(), path));
                    _uow.Commit();
                }
                catch { }
            }
            var strSPContractorID = GetId();
            if (strSPContractorID > 0)
            {
                StringBuilder strMessenger = new StringBuilder("");
                var subject = _tcRepository.Get(strSPContractorID);
                if (subject != null)
                {
                    foreach (var each in subject.Files.OrderByDescending(x => x.Id))
                    {
                        strMessenger.Append(GlobalMethods.UploadedFiles(each.CreatedBy.ToString(), Convert.ToDateTime(each.CreatedDate).ToLongDateString(), each.FileLocation.ToString()).ToString());
                    }
                    pnlUploads.Controls.Add(new LiteralControl(strMessenger.ToString()));
                }
            }

        }
        protected void AddTManual_Click(object sender, EventArgs e)
        {
            Update();
        }
		private void Update()
		{
			Security objSecurity = new Security();
			var vtxtTPName = txtTPName.Text;
			var vtxtAddress_1 = txtAddress_1.Text;
			var vtxtCity_1 = txtCity_1.Text;
			var vtxtState_1 = txtState_1.Text;
			var vtxtZipCode_1 = txtZipCode_1.Text;
			var vtxtAddress_2 = txtAddress_2.Text;
			var vtxtCity_2 = txtCity_2.Text;
			var vtxtState_2 = txtState_2.Text;
			var vtxtZipcode_2 = txtZipcode_2.Text;
			var vtxtPhone = txtPhone.Text;
			var vtxtFax = txtFax.Text;
			var vtxtEmailAddress = txtEmailAddress.Text;
			var vtxtSSN = txtSSN.Text;
			var vtxtACCID = txtACCID.Text;
			DateTime vAccreditationExpirationDate = default(DateTime);
			if (!string.IsNullOrWhiteSpace(txtAccreditationExpirationDate.Text))
			{
				DateTime.TryParse(txtAccreditationExpirationDate.Text, out vAccreditationExpirationDate);
			}
			var vtxtAccreditationExpirationDate = vAccreditationExpirationDate;
			var vchkRiskAssessor = chkRiskAssessor.Checked ? 1 : 0;
			var vchkInspectorTech = chkInspectorTech.Checked ? 1 : 0;
			var vchkVisualInspector = chkVisualInspector.Checked ? 1 : 0;
			var vchkMainRepaint = chkMainRepaint.Checked ? 1 : 0;
			var vchkRemoval = chkRemoval.Checked ? 1 : 0;
			var vchkProjectDesign = chkProjectDesign.Checked ? 1 : 0;
			var vchkAbatmentEnglish = chkAbatmentEnglish.Checked ? 1 : 0;
			var vchkAbatmentSpanish = chkAbatmentSpanish.Checked ? 1 : 0;
			var vchkStructSteelSuper = chkStructSteelSuper.Checked ? 1 : 0;
			var vchkStructSteelWorker = chkStructSteelWorker.Checked ? 1 : 0;
			//var vupload_1 = string.Empty;
			//var vupload_2 = string.Empty;
			//var vupload_3 = string.Empty;
			//var vupload_4 = string.Empty;
			//var vupload_5 = string.Empty;

			//try
			//{
			//	vupload_1 = Path.Combine("uf", upload_1.FileName);
			//	upload_1.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_1));
			//	vupload_2 = Path.Combine("uf", upload_2.FileName);
			//	upload_2.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_2));
			//	vupload_3 = Path.Combine("uf", upload_3.FileName);
			//	upload_3.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_3));
			//	vupload_4 = Path.Combine("uf", upload_4.FileName);
			//	upload_4.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_4));
			//	vupload_5 = Path.Combine("uf", upload_5.FileName);
			//	upload_5.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_5));
			//}
			//catch { }

			var vtxtAuthRepContFName = txtAuthRepContFName.Text;
			var vtxtAuthRepContLName = txtAuthRepContLName.Text;
			var vtxtAuthRepContTitle = txtAuthRepContTitle.Text;
			var vchkIAgree = chkIAgree.Checked ? 1 : 0;
			var vdropIsRenewal = dropIsRenewal.SelectedItem.Value;

			#region Saving obj

			var id = GetId();
			if (id > 0)
			{
				var subject = _tcRepository.Get(id);
				subject.Update(vtxtTPName, vtxtAddress_1, vtxtCity_1, vtxtState_1, vtxtZipCode_1, vtxtAddress_2, vtxtCity_2, vtxtState_2, vtxtZipcode_2, vtxtPhone,
				vtxtFax, vtxtEmailAddress, vtxtSSN, vdropIsRenewal, vtxtACCID, vtxtAccreditationExpirationDate, vchkRiskAssessor, vchkInspectorTech, vchkVisualInspector,
				vchkMainRepaint, vchkRemoval, vchkProjectDesign, vchkAbatmentEnglish, vchkAbatmentSpanish, vchkStructSteelSuper, vchkStructSteelWorker, 
				vtxtAuthRepContFName, vtxtAuthRepContLName, vtxtAuthRepContTitle, vchkIAgree);
				_tcRepository.Update(subject);
				_uow.Commit();
				#endregion

				string strBackToForms = objcryptoJS.AES_encrypt("10", AppConstants.secretKey, AppConstants.initVec).ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been updated successfully!', '', 'success', 'MDE_TCourseAppView.aspx?TCourseApps=active&cgi=" + Request["cgi"] + "');", true);
            }
		}

		private int GetId()
		{
			string result = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
			if (GlobalMethods.ValueIsNull(result).Length > 0)
			{
				result = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
			}
			else
			{
				ErrorHandler.ErrorPage();
			}

			return int.Parse(result);
		}
		protected void CommentEnter(object sender, EventArgs e)
        {
            string strTrainingCourseAppId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
            if (GlobalMethods.ValueIsNull(strTrainingCourseAppId).Length > 0)
            {
                strTrainingCourseAppId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
            }
            else
            {
                ErrorHandler.ErrorPage();
            }

            clsTrainingCourse_Comment objComm = new clsTrainingCourse_Comment();
            objComm.TrainingCourseAppId = Convert.ToInt32(strTrainingCourseAppId);
            objComm.Comment = GlobalMethods.KillChars(txtComment.Text);
            objComm.CreatedDate = DateTime.Now;
            objComm.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
            objComm.IsActive = 1;
            if (!TrainingCourse_CommentDAL.InsertTrainingCourse_Comment(objComm))
            { }

            #region Getting all the Comments by Application Id.
            StringBuilder strMessenger = new StringBuilder("");
            List<clsTrainingCourse_Comment> lstComments = new List<clsTrainingCourse_Comment>();
            lstComments = TrainingCourse_CommentDAL.SelectDynamicTrainingCourse_Comment("TrainingCourseAppId = " + strTrainingCourseAppId + "", "TrainingCourseCommentId");
            if (lstComments != null)
            {
                if (lstComments.Count > 0)
                {

                    for (int i = 0; i < lstComments.Count; i++)
                    {
                        strMessenger.Append(GlobalMethods.Messenger(lstComments[i].CreatedBy.ToString(), Convert.ToDateTime(lstComments[i].CreatedDate).ToLongDateString(), lstComments[i].Comment.ToString()).ToString());
                    }
                }
            }
            pnlComments.Controls.Add(new LiteralControl(strMessenger.ToString()));
            #endregion
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

                clsTrainingCourse_Approval objRiskApp = new clsTrainingCourse_Approval();
                objRiskApp.TrainingCourseAppId = Convert.ToInt32(ContractorAppId);
                objRiskApp.MDE_Owner_AuthorisedUserId = Convert.ToInt32(HttpContext.Current.Session["UserAuthId"]);
                objRiskApp.CreatedDate = DateTime.Now;
                objRiskApp.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
                objRiskApp.UpdatedDate = Convert.ToDateTime("1/1/1900");
                objRiskApp.UpdatedBy = "";
                objRiskApp.Notes = "";
                objRiskApp.IsActive = 1;
                if (!TrainingCourse_ApprovalDAL.InsertTrainingCourse_Approval(objRiskApp))
                {

                }
            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }

            return "MDE_TCourseApps.aspx?TCourseApps=active";
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

                List<clsTrainingCourse> objSPCont = new List<clsTrainingCourse>();
                objSPCont = TrainingCourseDAL.SelectDynamicTrainingCourse("TrainingCourseAppId = " + ContractorAppId + "", "TrainingCourseAppId");
                if (objSPCont != null)
                {
                    objSPCont[0].IsActive = 1;
                    if (TrainingCourseDAL.UpdateTrainingCourse(objSPCont[0]))
                    {
                        List<clsUserRole> lstURole = new List<clsUserRole>();
                        lstURole = UserRoleDAL.SelectDynamicUserRole("RoleId = 17 and AuthorizedUserId = " + objSPCont[0].CreatedBy + "", "UserRoleId");
                        if (lstURole != null)
                        {
                            if (lstURole.Count > 0)
                            {
                                //ROLE HAS BEEN ASSIGNED. THEREFORE, DONT ADD ANOTHER ROLE.
                            }
                            else
                            {
                                clsUserRole objURole = new clsUserRole();
                                objURole.RoleId = 17;
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
                            objURole.RoleId = 17;
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
            return "MDE_TCourseAppView.aspx?TCourseApps=active&cgi=" + cgi + "";
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

                List<clsTrainingCourse> objSPCont = new List<clsTrainingCourse>();
                objSPCont = TrainingCourseDAL.SelectDynamicTrainingCourse("TrainingCourseAppId = " + ContractorAppId + "", "TrainingCourseAppId");
                if (objSPCont != null)
                {
                    objSPCont[0].IsActive = 0;
                    if (TrainingCourseDAL.UpdateTrainingCourse(objSPCont[0]))
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
            return "MDE_TCourseAppView.aspx?TCourseApps=active&cgi=" + cgi + "";
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

                List<clsTrainingCourse> objSPCont = new List<clsTrainingCourse>();
                objSPCont = TrainingCourseDAL.SelectDynamicTrainingCourse("TrainingCourseAppId = " + ContractorAppId + "", "TrainingCourseAppId");
                if (objSPCont != null)
                {
                    objSPCont[0].IsActive = 2;
                    if (!TrainingCourseDAL.UpdateTrainingCourse(objSPCont[0]))
                    {

                    }
                }
            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }
            return "MDE_TCourseAppView.aspx?TCourseApps=active&cgi=" + cgi + "";
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

                List<clsTrainingCourse> objSPCont = new List<clsTrainingCourse>();
                objSPCont = TrainingCourseDAL.SelectDynamicTrainingCourse("TrainingCourseAppId = " + ContractorAppId + "", "TrainingCourseAppId");
                if (objSPCont != null)
                {
                    objSPCont[0].IsActive = 3;
                    if (!TrainingCourseDAL.UpdateTrainingCourse(objSPCont[0]))
                    {

                    }
                }
            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }
            return "MDE_TCourseAppView.aspx?TCourseApps=active&cgi=" + cgi + "";
        }
    }
}