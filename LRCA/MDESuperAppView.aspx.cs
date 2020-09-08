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
	public partial class MDESuperAppView : PageBase
	{
		private readonly ISupervisorRepository _SupervisorRepository;
		CryptoJS objcryptoJS = new CryptoJS();
		public MDESuperAppView()
		{
			_SupervisorRepository = new SupervisorRepository(_context);
		}
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string strSupervisorId = string.Empty;
				phWriteComment.Visible = false;

				strSupervisorId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
				if (GlobalMethods.ValueIsNull(strSupervisorId).Length > 0)
				{
					strSupervisorId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
				}

                #region Getting all the Comments by Application Id.
                StringBuilder strMessenger = new StringBuilder("");
                List<clsSupervisor_Comment> lstComments = new List<clsSupervisor_Comment>();
                lstComments = Supervisor_CommentDAL.SelectDynamicSupervisor_Comment("SupervisorId = " + strSupervisorId + "", "SupervisorCommentId");
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

				var pendingApps = _SupervisorRepository.PendingApps();

				if (pendingApps.Select(x => x.Id).Contains(Convert.ToInt32(strSupervisorId)))
				{
					// Means this needs Assigned To Me button.
					IsAssignedToMe = true;
					phWriteComment.Visible = false;
				}

				#endregion

				var obj = _SupervisorRepository.Get(int.Parse(strSupervisorId));
				if (obj != null)
				{
                    lblContractorApp.Text = obj.SupervisorFirstName + " " + obj.SupervisorLastName;
                    lblSignedBy.Text = obj.SupervisorFirstName + " " + obj.SupervisorLastName;
                    txtLName.Text = obj.SupervisorLastName;
					txtSuffix.Text = obj.SupervisorSuffix;
					txtFName.Text = obj.SupervisorFirstName;
					txtMName.Text = obj.SupervisorMiddleName;
					txtAddress_1.Text = obj.Supervisor_Address_Line_1;
					txtCity_1.Text = obj.Supervisor_City;
					txtState_1.Text = obj.Supervisor_State;
					txtZipCode_1.Text = obj.Supervisor_ZipCode;
					txtAddress_2.Text = obj.Supervisor_Address_Line_2;
					txtCity_2.Text = obj.Supervisor_City_2;
					txtState_2.Text = obj.Supervisor_State_2;
					txtZipcode_2.Text = obj.Supervisor_ZipCode_2;
					txtPhone.Text = obj.SupervisorPhone;
					txtEmailAddress.Text = obj.SupervisorEmail;
					txtDOB.Text = obj.SupervisorDOB.FromByteArray();
					txtSSNO.Text = obj.SupervisorSSN.FromByteArray();
					txtACCID.Text = obj.AccreditationID;

                    divCatInspection.Visible = obj.ACRDCatID == Category.StructuralSteelSupervisor; 
                    divCatResidential.Visible = obj.ACRDCatID == Category.RemovalAndDemolition;
                    divCatSteel.Visible = obj.ACRDCatID == Category.MaintananceAndRepainting;

                    if ((divCatResidential.Visible))
                    {
                        var i = 0;
                        var strContent = new StringBuilder();

                        txtThirdPartyRemovalDate.Text = obj.ThirdPartyExamDate.HasValue ? obj.ThirdPartyExamDate.Value.ToShortDateString() : "";
                        txtConstTradeRemovalStartDate.Text = obj.TwoYearMinExperience_Start.HasValue ? obj.TwoYearMinExperience_Start.Value.ToShortDateString() : "";
                        txtConstTradeRemovalEndDate.Text = obj.TwoYearMinExperience_End.HasValue ? obj.TwoYearMinExperience_End.Value.ToShortDateString() : "";
                        txtRemovalSuperWorkedFor.Text = obj.EmployerNames;
                        foreach (var each in obj.SupervisorExperiences)
                        {
                            if (i % 4 == 0)
                            {
                                strContent.Append("<div class='row'>");
                                GenerateCheckBox(pnlRemovalExperiences, each.Experience.ExperienceTitle.ToString());
                                if (i == 4)
                                {
                                    strContent.Append("</div>");
                                }
                            }
                            else
                            {
                                GenerateCheckBox(pnlRemovalExperiences, each.Experience.ExperienceTitle.ToString());
                            }
                            i++;
                        }
                    }

                    if (divCatInspection.Visible)
                    {
                        var i = 0;
                        var strContent = new StringBuilder();
                        txtConstTradeSteelStartDate.Text = obj.TwoYearMinExperience_Start.HasValue ? obj.TwoYearMinExperience_Start.Value.ToShortDateString() : "";
                        txtConstTradeSteelEndDate.Text = obj.TwoYearMinExperience_End.HasValue ? obj.TwoYearMinExperience_End.Value.ToShortDateString() : "";
                        txtSteelSuperWorkedFor.Text = obj.EmployerNames;
                        foreach (var each in obj.SupervisorExperiences)
                        {
                            if (i % 4 == 0)
                            {
                                strContent.Append("<div class='row'>");
                                GenerateCheckBox(pnlSteelExperiences, each.Experience.ExperienceTitle.ToString());
                                if (i == 4)
                                {
                                    strContent.Append("</div>");
                                }
                            }
                            else
                            {
                                GenerateCheckBox(pnlSteelExperiences, each.Experience.ExperienceTitle.ToString());
                            }
                            i++;
                        }
                    }

                    if (divCatSteel.Visible)
                    {
                        var i = 0;
                        var strContent = new StringBuilder();
                        txtThirdPartyRemovalDate.Text = obj.ThirdPartyExamDate.HasValue ? obj.ThirdPartyExamDate.Value.ToShortDateString() : "";
                        txtConstTradeRemovalStartDate.Text = obj.TwoYearMinExperience_Start.HasValue ? obj.TwoYearMinExperience_Start.Value.ToShortDateString() : "";
                        txtConstTradeRemovalEndDate.Text = obj.TwoYearMinExperience_End.HasValue ? obj.TwoYearMinExperience_End.Value.ToShortDateString() : "";
                        txtRemovalSuperWorkedFor.Text = obj.EmployerNames;
                        foreach (var each in obj.SupervisorExperiences)
                        {
                            if (i % 4 == 0)
                            {
                                strContent.Append("<div class='row'>");
                                GenerateCheckBox(pnlRepaintExperiences, each.Experience.ExperienceTitle.ToString());
                                if (i == 4)
                                {
                                    strContent.Append("</div>");
                                }
                            }
                            else
                            {
                                GenerateCheckBox(pnlRepaintExperiences, each.Experience.ExperienceTitle.ToString());
                            }
                            i++;
                        }
                    }

                    txtAccreditationExpirationDate.Text = obj.AccreditationExpirationDate.HasValue ? Convert.ToDateTime(obj.AccreditationExpirationDate.ToString()).ToShortDateString() : "";
					txtConstTradeSteelStartDate.Text = obj.TwoYearMinExperience_Start.HasValue ? Convert.ToDateTime(obj.TwoYearMinExperience_Start.ToString()).ToShortDateString() : "";
					txtConstTradeSteelEndDate.Text = obj.TwoYearMinExperience_End.HasValue ? Convert.ToDateTime(obj.TwoYearMinExperience_End.ToString()).ToShortDateString() : "";
					txtSteelSuperWorkedFor.Text = obj.EmployerNames;
					//txtThirdPartyRemovalDate.Text = obj.ThirdPartyExamDate.HasValue ? obj.ThirdPartyExamDate.ToString() : "";
					//txtConstTradeRemovalStartDate.Text = obj.SixMonthsMinExperience_Start.HasValue ? obj.SixMonthsMinExperience_Start.ToString() : "";
					//txtConstTradeRemovalEndDate.Text = obj.SixMonthsMinExperience_End.HasValue ? obj.SixMonthsMinExperience_End.ToString() : "";
					//txtRemovalSuperWorkedFor.Text = obj.EmployerNames;
					txtConstTradeRepaintStartDate.Text = obj.TwoYearMinExperience_Start.HasValue ? Convert.ToDateTime(obj.TwoYearMinExperience_Start.ToString()).ToShortDateString() : "";
					txtConstTradeRepaintEndDate.Text = obj.TwoYearMinExperience_End.HasValue ? Convert.ToDateTime(obj.TwoYearMinExperience_End.ToString()).ToShortDateString() : "";
					txtRepaintSuperWorkedFor.Text = obj.EmployerNames;
					chkWaiver.Checked = obj.Waiver == 1;
					txtTrainingCardNum.Text = obj.CourseTrainingCardNum;
					txtTrainCExpire.Text = obj.CourseExpirationDate;
					txtTrainingProviderName.Text = obj.CourseTPName;
					txtCourseName.Text = obj.CourseCatName;
					txtCourseStartDate.Text = obj.CourseStartDate.HasValue ? Convert.ToDateTime(obj.CourseStartDate.ToString()).ToShortDateString() : "";
					txtCourseEndDate.Text = obj.CourseEndDate.HasValue ? Convert.ToDateTime(obj.CourseEndDate.ToString()).ToShortDateString() : "";
					txtContractorName.Text = obj.SupervisorContractorName;
					txtContractorAccdNum.Text = obj.SupervisorContractorAcctNum;
					txtIC_Address_Line_1.Text = obj.SupervisorContractor_Address_Line_1;
					txtIC_City.Text = obj.SupervisorContractor_City;
					txtIC_State.Text = obj.SupervisorContractor_State;
					txtIC_Zipcode.Text = obj.SupervisorContractor_ZipCode;
					txtICContactFName.Text = obj.SupervisorContactFirstName;
					txtICContactLName.Text = obj.SupervisorContactLastName;
					txtICContactPhone.Text = obj.SupervisorContractor_Phone;
                    lblContactInfo.Text = obj.SupervisorContactFirstName + " " + obj.SupervisorContactLastName +" / "+ obj.SupervisorContractor_Phone;

                    chkIAgree.Checked = obj.Agreed == 1;
                    lblDateSigned.Text = obj.CreatedDate.ToLongDateString();
                    dropIsRenewal.SelectedValue = obj.IsRenewal.HasValue ? obj.IsRenewal.Value.ToString() : "0";
                    divIsRenewal.Visible = obj.IsRenewal.Value == 1;
                    dropCategory.SelectedValue = obj.ACRDCatID.HasValue ? obj.ACRDCatID.ToString() : "0";

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
            string strSupervisorId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
            if (GlobalMethods.ValueIsNull(strSupervisorId).Length > 0)
            {
                strSupervisorId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
            }
            else
            {
                ErrorHandler.ErrorPage();
            }

            clsSupervisor_Comment objComm = new clsSupervisor_Comment();
            objComm.SupervisorId = Convert.ToInt32(strSupervisorId);
            objComm.Comment = GlobalMethods.KillChars(txtComment.Text);
            objComm.CreatedDate = DateTime.Now;
            objComm.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
            objComm.IsActive = 1;
            if (!Supervisor_CommentDAL.InsertSupervisor_Comment(objComm))
            { }

            #region Getting all the Comments by Application Id.
            StringBuilder strMessenger = new StringBuilder("");
            List<clsSupervisor_Comment> lstComments = new List<clsSupervisor_Comment>();
            lstComments = Supervisor_CommentDAL.SelectDynamicSupervisor_Comment("SupervisorId = " + strSupervisorId + "", "SupervisorCommentId");
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
        protected void GenerateCheckBox(Panel pnlName, string Title)
        {
            var strContent = new StringBuilder("");
            strContent.Append("<div class='col-lg-3'><div class='checkbox-primary  m-b' >");
            strContent.Append("<input disabled='disabled' id='chk_" + Title + "' type='checkbox' name='chk_" + Title + "' checked>");
            strContent.Append("<label for='chk_" + Title + "' style='font-size:12px; padding-left:5px;padding-bottom:5px'>" + Title + "</label></div></div>");
            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

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
                    _SupervisorRepository.AddFile(Supervisor_File.Create(GetId(), path));
                    _uow.Commit();
                }
                catch { }
            }
            var strSPContractorID = GetId();
            if (strSPContractorID > 0)
            {
                StringBuilder strMessenger = new StringBuilder("");
                var subject = _SupervisorRepository.Get(strSPContractorID);
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

				clsSupervisor_Approval objRiskApp = new clsSupervisor_Approval();
				objRiskApp.SupervisorId = Convert.ToInt32(ContractorAppId);
				objRiskApp.MDE_Owner_AuthorisedUserId = Convert.ToInt32(HttpContext.Current.Session["UserAuthId"]);
                objRiskApp.CreatedDate = DateTime.Now;
                objRiskApp.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
                objRiskApp.UpdatedDate = Convert.ToDateTime("1/1/1900");
                objRiskApp.UpdatedBy = "";
                objRiskApp.Notes = "";
				objRiskApp.IsActive = 1;
				if (!Supervisor_ApprovalDAL.InsertSupervisor_Approval(objRiskApp))
				{

				}
			}
			catch (Exception)
			{
				ErrorHandler.ErrorPage();
			}

			return "MDE_SuperApps.aspx?SuperApps=active";
		}

        protected void AddTManual_Click(object sender, EventArgs e)
        {
            Update();
        }
		private void Update()
		{
			Security objSecurity = new Security();
			var vtxtLName = txtLName.Text;
			var vtxtSuffix = txtSuffix.Text;
			var vtxtFName = txtFName.Text;
			var vtxtMName = txtMName.Text;
			var vtxtAddress_1 = txtAddress_1.Text;
			var vtxtCity_1 = txtCity_1.Text;
			var vtxtState_1 = txtState_1.Text;
			var vtxtZipCode_1 = txtZipCode_1.Text;
			var vtxtAddress_2 = txtAddress_2.Text;
			var vtxtCity_2 = txtCity_2.Text;
			var vtxtState_2 = txtState_2.Text;
			var vtxtZipcode_2 = txtZipcode_2.Text;
			var vtxtPhone = txtPhone.Text;
			var vtxtEmailAddress = txtEmailAddress.Text;
			var vtxtDOB = txtDOB.Text;
			var vtxtSSNO = txtSSNO.Text;
			var vtxtACCID = txtACCID.Text;
			var vtxtAccreditationExpirationDate = !string.IsNullOrWhiteSpace(txtAccreditationExpirationDate.Text) ? DateTime.Parse(txtAccreditationExpirationDate.Text) : default(DateTime);
			var vtxtConstTradeSteelStartDate = !string.IsNullOrWhiteSpace(txtConstTradeSteelStartDate.Text) ? DateTime.Parse(txtConstTradeSteelStartDate.Text) : default(DateTime);
			var vtxtConstTradeSteelEndDate = !string.IsNullOrWhiteSpace(txtConstTradeSteelEndDate.Text) ? DateTime.Parse(txtConstTradeSteelEndDate.Text) : default(DateTime);
			var vtxtSteelSuperWorkedFor = txtSteelSuperWorkedFor.Text;
			var vtxtThirdPartyRemovalDate = !string.IsNullOrWhiteSpace(txtThirdPartyRemovalDate.Text) ? DateTime.Parse(txtThirdPartyRemovalDate.Text) : default(DateTime);
			var vtxtConstTradeRemovalStartDate = !string.IsNullOrWhiteSpace(txtConstTradeRemovalStartDate.Text) ? DateTime.Parse(txtConstTradeRemovalStartDate.Text) : default(DateTime);
			var vtxtConstTradeRemovalEndDate = !string.IsNullOrWhiteSpace(txtConstTradeRemovalEndDate.Text) ? DateTime.Parse(txtConstTradeRemovalEndDate.Text) : default(DateTime);
			var vtxtRemovalSuperWorkedFor = txtRemovalSuperWorkedFor.Text;
			var vtxtConstTradeRepaintStartDate = !string.IsNullOrWhiteSpace(txtConstTradeRepaintStartDate.Text) ? DateTime.Parse(txtConstTradeRepaintStartDate.Text) : default(DateTime);
			var vtxtConstTradeRepaintEndDate = !string.IsNullOrWhiteSpace(txtConstTradeRepaintEndDate.Text) ? DateTime.Parse(txtConstTradeRepaintEndDate.Text) : default(DateTime);
			var vtxtRepaintSuperWorkedFor = txtRepaintSuperWorkedFor.Text;
			var vchkWaiver = chkWaiver.Checked;
			var vtxtTrainingCardNum = txtTrainingCardNum.Text;
			var vtxtTrainCExpire = txtTrainCExpire.Text;
			var vtxtTrainingProviderName = txtTrainingProviderName.Text;
			var vtxtCourseName = txtCourseName.Text;
			var vtxtCourseStartDate = !string.IsNullOrWhiteSpace(txtCourseStartDate.Text) ? DateTime.Parse(txtCourseStartDate.Text) : default(DateTime);
			var vtxtCourseEndDate = !string.IsNullOrWhiteSpace(txtCourseEndDate.Text) ? DateTime.Parse(txtCourseEndDate.Text) : default(DateTime);
			var vtxtContractorName = txtContractorName.Text;
			var vtxtContractorAccdNum = txtContractorAccdNum.Text;
			var vtxtIC_Address_Line_1 = txtIC_Address_Line_1.Text;
			var vtxtIC_City = txtIC_City.Text;
			var vtxtIC_State = txtIC_State.Text;
			var vtxtIC_Zipcode = txtIC_Zipcode.Text;
			var vtxtICContactFName = txtICContactFName.Text;
			var vtxtICContactLName = txtICContactLName.Text;
			var vtxtICContactPhone = txtICContactPhone.Text;
			var vchkIAgree = chkIAgree.Checked;
			var vdropIsRenewal = int.Parse(dropIsRenewal.SelectedItem.Value);
			var vdropCategory = int.Parse(dropCategory.SelectedItem.Value);

			#region Saving obj

			var id = GetId();
			if (id > 0)
			{
				var subject = _SupervisorRepository.Get(id);
				subject.Update(vtxtLName, vtxtSuffix, vtxtFName, vtxtMName, vtxtAddress_1, vtxtCity_1, vtxtState_1, vtxtZipCode_1, vtxtAddress_2, vtxtCity_2,
				vtxtState_2, vtxtZipcode_2, vtxtPhone, vtxtEmailAddress, vtxtDOB, vtxtSSNO, vdropIsRenewal, vtxtACCID,
				vtxtAccreditationExpirationDate, vdropCategory, vtxtConstTradeSteelStartDate, vtxtConstTradeSteelEndDate,
				vtxtSteelSuperWorkedFor, vtxtThirdPartyRemovalDate, vtxtConstTradeRemovalStartDate, vtxtConstTradeRemovalEndDate,
				vtxtRemovalSuperWorkedFor, vtxtConstTradeRepaintStartDate, vtxtConstTradeRepaintEndDate, vtxtRepaintSuperWorkedFor,
				vchkWaiver, vtxtTrainingCardNum, vtxtTrainCExpire, vtxtTrainingProviderName, vtxtCourseName, vtxtCourseStartDate,
				vtxtCourseEndDate, vtxtContractorName, vtxtContractorAccdNum, vtxtIC_Address_Line_1, vtxtIC_City, vtxtIC_State,
				vtxtIC_Zipcode, vtxtICContactFName, vtxtICContactLName, vtxtICContactPhone, vchkIAgree);
				_SupervisorRepository.Update(subject);
				_uow.Commit();
				#endregion

				string strBackToForms = objcryptoJS.AES_encrypt("10", AppConstants.secretKey, AppConstants.initVec).ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been updated successfully!', '', 'success', 'MDESuperAppView.aspx?Superapps=active&cgi=" + Request["cgi"] + "');", true);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been updated successfully!', '', 'success', 'RoleDesc.aspx?Dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strBackToForms) + "');", true);
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

				List<clsSupervisor> objSPCont = new List<clsSupervisor>();
				objSPCont = SupervisorDAL.SelectDynamicSupervisor("SupervisorId = " + ContractorAppId + "", "SupervisorId");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 1;
					if (SupervisorDAL.UpdateSupervisor(objSPCont[0]))
					{
						List<clsUserRole> lstURole = new List<clsUserRole>();
						lstURole = UserRoleDAL.SelectDynamicUserRole("RoleId = 5 and AuthorizedUserId = " + objSPCont[0].CreatedBy + "", "UserRoleId");
						if (lstURole != null)
						{
							if (lstURole.Count > 0)
							{
								//ROLE HAS BEEN ASSIGNED. THEREFORE, DONT ADD ANOTHER ROLE.
							}
							else
							{
								clsUserRole objURole = new clsUserRole();
								objURole.RoleId = 5;
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
							objURole.RoleId = 5;
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
			return "MDESuperAppView.aspx?superapps=active&cgi=" + cgi + "";
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

				List<clsSupervisor> objSPCont = new List<clsSupervisor>();
				objSPCont = SupervisorDAL.SelectDynamicSupervisor("SupervisorId = " + ContractorAppId + "", "SupervisorId");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 0;
					if (SupervisorDAL.UpdateSupervisor(objSPCont[0]))
					{
						List<clsUserRole> lstURole = new List<clsUserRole>();
						lstURole = UserRoleDAL.SelectDynamicUserRole("RoleId = 5 and AuthorizedUserId = " + objSPCont[0].CreatedBy + "", "UserRoleId");
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
			return "MDESuperAppView.aspx?superapps=active&cgi=" + cgi + "";
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

				List<clsSupervisor> objSPCont = new List<clsSupervisor>();
				objSPCont = SupervisorDAL.SelectDynamicSupervisor("SupervisorId = " + ContractorAppId + "", "SupervisorId");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 2;
					if (!SupervisorDAL.UpdateSupervisor(objSPCont[0]))
					{

					}
				}
			}
			catch (Exception)
			{
				ErrorHandler.ErrorPage();
			}
			return "MDESuperAppView.aspx?superapps=active&cgi=" + cgi + "";
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

				List<clsSupervisor> objSPCont = new List<clsSupervisor>();
				objSPCont = SupervisorDAL.SelectDynamicSupervisor("SupervisorId = " + ContractorAppId + "", "SupervisorId");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 3;
					if (!SupervisorDAL.UpdateSupervisor(objSPCont[0]))
					{

					}
				}
			}
			catch (Exception)
			{
				ErrorHandler.ErrorPage();
			}
			return "MDESuperAppView.aspx?superapps=active&cgi=" + cgi + "";
		}
	}
}