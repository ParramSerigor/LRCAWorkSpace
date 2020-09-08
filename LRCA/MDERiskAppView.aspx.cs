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
	public partial class MDERiskAppView : PageBase
	{
		private readonly IRiskAssessorRepository _riskAssessorRepository;
		CryptoJS objcryptoJS = new CryptoJS();
		public MDERiskAppView()
		{
			_riskAssessorRepository = new RiskAssessorRepository(_context);
		}
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string strInspectorRiskAssId = string.Empty;
				phWriteComment.Visible = false;

				strInspectorRiskAssId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
				if (GlobalMethods.ValueIsNull(strInspectorRiskAssId).Length > 0)
				{
					strInspectorRiskAssId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
				}
                #region Getting all the Comments by Application Id.
                StringBuilder strMessenger = new StringBuilder("");
                List<clsRiskAssessor_Comment> lstComments = new List<clsRiskAssessor_Comment>();
                lstComments = RiskAssessor_CommentDAL.SelectDynamicRiskAssessor_Comment("InspectorRiskAssId = " + strInspectorRiskAssId + "", "InspectorRiskAssId");
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

                var pendingApps = _riskAssessorRepository.PendingApps();

                if (pendingApps.Select(x => x.Id).Contains(Convert.ToInt32(strInspectorRiskAssId)))
                {
                    // Means this needs Assigned To Me button.
                    IsAssignedToMe = true;
                    phWriteComment.Visible = false;
                }
               
				#endregion

				var obj = _riskAssessorRepository.Get(int.Parse(strInspectorRiskAssId));
				if (obj != null)
				{
					txtLName.Text = obj.InspectorLastName;
					txtSuffix.Text = obj.Suffix;
					txtFName.Text = obj.InspectorFirstName;
					txtMName.Text = obj.InspectorMiddleName;
                    lblContractorApp.Text = obj.InspectorFirstName +" "+ obj.InspectorLastName;
                    lblSignedBy.Text = obj.InspectorFirstName + " " + obj.InspectorLastName;
                    txtAddress_1.Text = obj.InspectorContractor_Address_Line_1;
					txtCity_1.Text = obj.InspectorContractor_City;
					txtState_1.Text = obj.InspectorContractor_State;
					txtZipCode_1.Text = obj.InspectorContractor_ZipCode;
					txtAddress_2.Text = obj.InspectorContractor_Address_Line_2;
					txtCity_2.Text = obj.InspectorContractor_City_2;
					txtState_2.Text = obj.InspectorContractor_State_2;
					txtZipcode_2.Text = obj.InspectorContractor_ZipCode_2;
					txtPhone.Text = obj.InspectorPhone;
					txtEmailAddress.Text = obj.InspectorEmail;
					txtDOB.Text = obj.InspectorDOB.FromByteArray();
					txtSSNO.Text = obj.InspectorSSN.FromByteArray();
					txtACCID.Text = obj.AccreditationID;
					txtAccreditationExpirationDate.Text = obj.AccreditationExpirationDate.HasValue ? obj.AccreditationExpirationDate.Value.ToShortDateString() : "";
					txtThirdPartyInspTechExamDate.Text = obj.ThirdPartyExamDate.HasValue ? obj.ThirdPartyExamDate.Value.ToShortDateString() : "";
					txtThirdPartyRiskAssExamDate.Text = obj.ThirdPartyExamDate.HasValue ? obj.ThirdPartyExamDate.Value.ToShortDateString() : "";
                    txtMinEx_Start.Text = obj.OneYearMinExperience_Start.HasValue ? obj.OneYearMinExperience_Start.Value.ToShortDateString() : "";
					txtMinEx_End.Text = obj.OneYearMinExperience_End.HasValue ? obj.OneYearMinExperience_End.Value.ToShortDateString() : ""; ;
					txtInTechAccred.Text = obj.InspectorTechAccreditationId;
					chkWaiver.Checked = obj.Waiver == 1;
					txtTrainingCardNum.Text = obj.CourseTrainingCardNum;
					txtTrainCExpire.Text = obj.CourseExpirationDate;
					txtTrainingProviderName.Text = obj.CourseTPName;
					txtCourseName.Text = obj.CourseName;
					txtCourseStartDate.Text = obj.CourseStartDate.HasValue ? obj.CourseStartDate.Value.ToShortDateString() : "";
					txtCourseEndDate.Text = obj.CourseEndDate.HasValue ? obj.CourseEndDate.Value.ToShortDateString() : "";
					txtContractorName.Text = obj.InspectorContractorName;
					txtContractorAccdNum.Text = obj.InspectorContractorAcctNum;
					txtIC_Address_Line_1.Text = obj.InspectorContractor_Address_Line_1;
					txtIC_City.Text = obj.InspectorContractor_City;
					txtIC_State.Text = obj.InspectorContractor_State;
					txtIC_Zipcode.Text = obj.InspectorContractor_ZipCode;
					txtICContactFName.Text = obj.InspectorContactFirstName;
					txtICContactLName.Text = obj.InspectorContactLastName;
                    lblContactInfo.Text = obj.InspectorContactFirstName +" "+ obj.InspectorContactLastName +" / " + obj.InspectorPhone;
                    lblDateSigned.Text = obj.CreatedDate.ToLongDateString();
                    var url = obj.RiskAssessorExperi_URL.Split('\\');
					if (url[0].Length > 0)
					{
						lkupload.Text = "View Attachment";
						lkupload.NavigateUrl = obj.RiskAssessorExperi_URL;
					}
					chkIAgree.Checked = obj.Agreed == 1;
					dropIsRenewal.SelectedValue = obj.IsRenewal.HasValue ? obj.IsRenewal.Value.ToString() : "-1";

                    if ((dropIsRenewal.SelectedValue == "0") || (dropIsRenewal.SelectedValue == "-1"))
                    {
                        divIsRenewal.Visible = false;
                    }

					dropCategory.SelectedValue = obj.ACRDCatID.ToString();
					if (obj.ACRDCatID == Category.VisualInspector)
					{
						divCatInspection.Visible = true;
					}
					if (obj.ACRDCatID == Category.InspectorTechnician)
					{
						divCatResidential.Visible = true;
					}
					if (obj.ACRDCatID == Category.RiskAccesor)
					{
						divCatSteel.Visible = true;
					}
					txtICContactPhone.Text = obj.InspectorContractor_Phone;

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
                GlobalMethods.DisableControl_DropDownByID(dropCategory);
                GlobalMethods.DisableControl_DropDownByID(dropIsRenewal);
                #endregion	 
            }
        }
        protected void CommentEnter(object sender, EventArgs e)
        {
            string strInspectorRiskAssId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
            if (GlobalMethods.ValueIsNull(strInspectorRiskAssId).Length > 0)
            {
                strInspectorRiskAssId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
            }
            else
            {
                ErrorHandler.ErrorPage();
            }

            clsRiskAssessor_Comment objComm = new clsRiskAssessor_Comment();
            objComm.InspectorRiskAssId = Convert.ToInt32(strInspectorRiskAssId);
            objComm.Comment = GlobalMethods.KillChars(txtComment.Text);
            objComm.CreatedDate = DateTime.Now;
            objComm.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
            objComm.IsActive = 1;
            if (!RiskAssessor_CommentDAL.InsertRiskAssessor_Comment(objComm))
            { }

            #region Getting all the Comments by Application Id.
            StringBuilder strMessenger = new StringBuilder("");
            List<clsRiskAssessor_Comment> lstComments = new List<clsRiskAssessor_Comment>();
            lstComments = RiskAssessor_CommentDAL.SelectDynamicRiskAssessor_Comment("InspectorRiskAssId = " + strInspectorRiskAssId + "", "InspectorRiskAssId");
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
        protected void AddTManual_Click(object sender, EventArgs e)
        {
            Update();
        }
		private void Update()
		{
			Security objSecurity = new Security();
			#region "variables"
			var vtxtLName = objSecurity.KillChars(txtLName.Text);
			var vtxtSuffix = objSecurity.KillChars(txtSuffix.Text);
			var vtxtFName = objSecurity.KillChars(txtFName.Text);
			var vtxtMName = objSecurity.KillChars(txtMName.Text);
			var vtxtAddress_1 = objSecurity.KillChars(txtAddress_1.Text);
			var vtxtCity_1 = objSecurity.KillChars(txtCity_1.Text);
			var vtxtState_1 = objSecurity.KillChars(txtState_1.Text);
			var vtxtZipCode_1 = objSecurity.KillChars(txtZipCode_1.Text);
			var vtxtAddress_2 = objSecurity.KillChars(txtAddress_2.Text);
			var vtxtCity_2 = objSecurity.KillChars(txtCity_2.Text);
			var vtxtState_2 = objSecurity.KillChars(txtState_2.Text);
			var vtxtZipcode_2 = objSecurity.KillChars(txtZipcode_2.Text);
			var vtxtPhone = objSecurity.KillChars(txtPhone.Text);
			var vtxtEmailAddress = objSecurity.KillChars(txtEmailAddress.Text);
			var vtxtDOB = objSecurity.KillChars(txtDOB.Text);
			var vtxtSSNO = objSecurity.KillChars(txtSSNO.Text);
			var vtxtACCID = objSecurity.KillChars(txtACCID.Text);
			var vtxtAccreditationExpirationDate = objSecurity.KillChars(txtAccreditationExpirationDate.Text);
			var vtxtThirdPartyInspTechExamDate = objSecurity.KillChars(txtThirdPartyInspTechExamDate.Text);
			var vtxtThirdPartyRiskAssExamDate = objSecurity.KillChars(txtThirdPartyRiskAssExamDate.Text);
			var vtxtMinEx_Start = objSecurity.KillChars(txtMinEx_Start.Text);
			var vtxtMinEx_End = objSecurity.KillChars(txtMinEx_End.Text);
			var vtxtInTechAccred = objSecurity.KillChars(txtInTechAccred.Text);
			var vchkWaiver = chkWaiver.Checked;
			var vtxtTrainingCardNum = objSecurity.KillChars(txtTrainingCardNum.Text);
			var vtxtTrainCExpire = objSecurity.KillChars(txtTrainCExpire.Text);
			var vtxtTrainingProviderName = objSecurity.KillChars(txtTrainingProviderName.Text);
			var vtxtCourseName = objSecurity.KillChars(txtCourseName.Text);
			var vtxtCourseStartDate = objSecurity.KillChars(txtCourseStartDate.Text);
			var vtxtCourseEndDate = objSecurity.KillChars(txtCourseEndDate.Text);
			var vtxtContractorName = objSecurity.KillChars(txtContractorName.Text);
			var vtxtContractorAccdNum = objSecurity.KillChars(txtContractorAccdNum.Text);
			var vtxtIC_Address_Line_1 = objSecurity.KillChars(txtIC_Address_Line_1.Text);
			var vtxtIC_City = objSecurity.KillChars(txtIC_City.Text);
			var vtxtIC_State = objSecurity.KillChars(txtIC_State.Text);
			var vtxtIC_Zipcode = objSecurity.KillChars(txtIC_Zipcode.Text);
			var vtxtICContactFName = objSecurity.KillChars(txtICContactFName.Text);
			var vtxtICContactLName = objSecurity.KillChars(txtICContactLName.Text);
			var vtxtICContactPhone = objSecurity.KillChars(txtICContactPhone.Text);
			var vchkIAgree = chkIAgree.Checked;
			var vdropIsRenewal = int.Parse(dropIsRenewal.SelectedItem.Value);
			var vdropCategory = dropCategory.SelectedItem.Value;
			#endregion

			#region Saving obj
			
			var id = GetId();
			if (id > 0)
			{
				var subject = _riskAssessorRepository.Get(id);
				subject.Update(vtxtLName, vtxtSuffix, vtxtFName, vtxtMName, vtxtAddress_1,
				vtxtCity_1, vtxtState_1, vtxtZipCode_1, vtxtAddress_2, vtxtCity_2, vtxtState_2, vtxtZipcode_2, vtxtPhone,
				vtxtEmailAddress, vtxtDOB.ToByteArray(), vtxtSSNO.ToByteArray(), vtxtACCID, vtxtAccreditationExpirationDate,
				vtxtThirdPartyInspTechExamDate, vtxtThirdPartyRiskAssExamDate, vtxtMinEx_Start, vtxtMinEx_End,
				vtxtInTechAccred, vchkWaiver, vtxtTrainingCardNum, vtxtTrainCExpire, vtxtTrainingProviderName,
				vtxtCourseName, vtxtCourseStartDate, vtxtCourseEndDate, vtxtContractorName, vtxtContractorAccdNum,
				vtxtIC_Address_Line_1, vtxtIC_City, vtxtIC_State, vtxtIC_Zipcode, vtxtICContactFName, vtxtICContactLName,
				vtxtICContactPhone, vchkIAgree, vdropIsRenewal, vdropCategory);
				_riskAssessorRepository.Update(subject);
				_uow.Commit();
                #endregion


                #region Getting all the Case files.
                StringBuilder strMessengerUpload = new StringBuilder("");

                foreach (var each in subject.Files.OrderByDescending(x => x.Id))
                {
                    strMessengerUpload.Append(GlobalMethods.UploadedFiles(each.CreatedBy.ToString(), Convert.ToDateTime(each.CreatedDate).ToLongDateString(), each.FileLocation.ToString()).ToString());
                }
                pnlUploads.Controls.Add(new LiteralControl(strMessengerUpload.ToString()));
                #endregion

                string strBackToForms = objcryptoJS.AES_encrypt("10", AppConstants.secretKey, AppConstants.initVec).ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been updated successfully!', '', 'success', 'MDERiskAppView.aspx?riskapps=active&cgi=" + Request["cgi"] + "');", true);
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
                    _riskAssessorRepository.AddFile(RiskAssessor_File.Create(GetId(), path));
                    _uow.Commit();
                }
                catch { }
            }
            var strSPContractorID = GetId();
            if (strSPContractorID > 0)
            {
                StringBuilder strMessenger = new StringBuilder("");
                var subject = _riskAssessorRepository.Get(strSPContractorID);
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
			return "MDERiskAppView.aspx?riskapps=active&cgi=" + cgi + "";
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
			return "MDERiskAppView.aspx?riskapps=active&cgi=" + cgi + "";
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
			return "MDERiskAppView.aspx?riskapps=active&cgi=" + cgi + "";
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
            return "MDERiskAppView.aspx?riskapps=active&cgi=" + cgi + "";
        }
    }
}