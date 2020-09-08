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
	public partial class MDE_InstructorAppView : PageBase
	{
		private readonly IInstructorRepository _instructorRepository;
		CryptoJS objcryptoJS = new CryptoJS();
		public MDE_InstructorAppView()
		{
			_instructorRepository = new InstructorRepository(_context);
		}
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string strInstructorId = string.Empty;
				phWriteComment.Visible = false;

				strInstructorId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
				if (GlobalMethods.ValueIsNull(strInstructorId).Length > 0)
				{
					strInstructorId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
				}

                #region Category Dropdown
                List<clsCategory> lstCategory = new List<clsCategory>();
                lstCategory = CategoryDAL.SelectDynamicCategory("(ACRDCategory = 'Instructor Accreditations')", "ACRDCatID");
                if (lstCategory != null)
                {
                    if (lstCategory.Count > 0)
                    {
                        dropInstructCategory.Items.Add(new ListItem(
                                           String.Format("{0}", SQLHelper.TrimAndReplaceEOF("Select a Category")), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(objcryptoJS.AES_encrypt("0".ToString(), AppConstants.secretKey, AppConstants.initVec).ToString()))));
                        for (int i = 0; i < lstCategory.Count; i++)
                        {
                            dropInstructCategory.Items.Add(new ListItem(
                                String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstCategory[i].CatTitle.ToString())), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstCategory[i].ACRDCatID.ToString()))));
                            // String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstCategory[i].CatTitle.ToString())), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(objcryptoJS.AES_encrypt(lstCategory[i].ACRDCatID.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString()))));

                        }
                    }
                }
                #endregion


                #region Getting all the Comments by Application Id.
                StringBuilder strMessenger = new StringBuilder("");
                List<clsInstructor_Comment> lstComments = new List<clsInstructor_Comment>();
                lstComments = Instructor_CommentDAL.SelectDynamicInstructor_Comment("InstructorId = " + strInstructorId + "", "InstructorCommentId");
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

				var pendingApps = _instructorRepository.PendingApps();

				if (pendingApps.Select(x => x.Id).Contains(Convert.ToInt32(strInstructorId)))
				{
					// Means this needs Assigned To Me button.
					IsAssignedToMe = true;
					phWriteComment.Visible = false;
				}

				#endregion

				var obj = _instructorRepository.Get(int.Parse(strInstructorId));
				if (obj != null)
				{
					lblContractorApp.Text = obj.Instructor_FName + " " + obj.Instructor_LName;
					lblContactInfo.Text = obj.TP_Contact_FName + " " + obj.TP_Contact_LName + " / " + obj.Instructor_Phone;

					txtLName.Text = obj.Instructor_LName;
					txtSuffix.Text = obj.Instructor_Suffix;
					txtFName.Text = obj.Instructor_FName;
					txtMName.Text = obj.Instructor_MName;
					txtAddress_1.Text = obj.Instructor_Address_Line_1;
					txtCity_1.Text = obj.Instructor_City;
					txtState_1.Text = obj.Instructor_State;
					txtZipCode_1.Text = obj.Instructor_ZipCode;
					txtAddress_2.Text = obj.Instructor_Address_Line_2;
					txtCity_2.Text = obj.Instructor_City_2;
					txtState_2.Text = obj.Instructor_State_2;
					txtZipcode_2.Text = obj.Instructor_ZipCode_2;
					txtPhone.Text = obj.Instructor_Phone;
					txtEmailAddress.Text = obj.Instructor_Email;
					txtDOB.Text = obj.Instructor_DOB.FromByteArray();
					txtSSNO.Text = obj.Instructor_SSN.FromByteArray();
					txtInstructTP.Text = obj.TP_Name;
					txtInstructAcctNum.Text = obj.TP_AcctNumber;
					txtInstructContFN.Text = obj.TP_Contact_FName;
					txtInstructContLN.Text = obj.TP_Contact_LName;
					txtInstructContPhone.Text = obj.TP_Telephone;
					txtInstructContAddress.Text = obj.TP_Address_Line_1;
					txtInstructContCity.Text = obj.TP_City;
					txtInstructContState.Text = obj.TP_State;
					txtInstructContZipcode.Text = obj.TP_ZipCode;
					txtACCID.Text = obj.AccreditationID;
					txtAccreditationExpirationDate.Text = obj.AccreditationExpirationDate.HasValue ? obj.AccreditationExpirationDate.Value.ToShortDateString() : "";
					txtNewInitTrainingCard.Text = obj.NewInitialTCard;
					txtNewInitStartDate.Text = obj.NewIT_StartDates.HasValue ? obj.NewIT_StartDates.Value.ToShortDateString() : "";
					txtNewInitEndDate.Text = obj.NewIT_EndDates.HasValue ? obj.NewIT_EndDates.Value.ToShortDateString() : "";
					txtRenewalTrainingCard.Text = obj.RenewalTCard;
					txtRenewalStartDate.Text = obj.RenewalLT_StartDates.HasValue ? obj.RenewalLT_StartDates.Value.ToShortDateString() : "";
					txtRenewalEndDate.Text = obj.RenewalLT_EndDates.HasValue ? obj.RenewalLT_EndDates.Value.ToShortDateString() : "";
					if (obj.NewInstructors_URL != null)
					{
						var url = obj.NewInstructors_URL.Split('\\')[1];
						lkuploadNewInstructors.Text = url;
						lkuploadNewInstructors.NavigateUrl = obj.NewInstructors_URL;
					}
					txtNewRenewAcctNum.Text = obj.NewRenewal_InspecTech_AcctNumber;
					txtNewRenewAcctExpireDate.Text = obj.NewRenewal_InspecTech_AcctExpiration;
					if (obj.NewInspectorTechnInstructors_URL != null)
					{
						var url = obj.NewInspectorTechnInstructors_URL.Split('\\')[1];
						lkuploadNewInspectorTech.Text = url;
						lkuploadNewInspectorTech.NavigateUrl = obj.NewInspectorTechnInstructors_URL;
					}
					chkIAgree.Checked = obj.Agreed == 1;
                    lblSignedBy.Text = obj.Instructor_FName + " " + obj.Instructor_LName;
                    lblDateSigned.Text = Convert.ToDateTime(obj.CreatedDate).ToLongDateString();
                    dropIsRenewal.SelectedValue = obj.IsRenewal.ToString();
					dropInstructCategory.SelectedValue = obj.ACRDCatID.ToString();

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
                    pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a class='btn btn-success open-Approve' title='Approve Application' href='#' data-id='" + strEnContractId + "' data-toggle='modal' >Approve</a>&nbsp;<a class='btn btn-danger open-Disapprove' href='#' title='Reject Application' data-id='" + strEnContractId + "' data-toggle='modal' >Reject</a>&nbsp;<a class='btn btn-primary open-Hold' href='#' title='Put Application On Hold' data-id='" + strEnContractId + "' data-toggle='modal' >On Hold</a>&nbsp;<a class='btn btn-primary open-Deficient' href='#' title='Application status is Deficient' data-id='" + strEnContractId + "' data-toggle='modal' >Deficient</a>" + GlobalMethods.ContractorAppStatus(obj.IsActive.HasValue ? obj.IsActive.Value : 0, "bar", "MDE_InstructorApps.aspx?InstructApps=active") + "</div>"));
				}

                #region Making all the fields disabled.
                GlobalMethods.DisableControl_CheckBoxByID(chkIAgree);
                GlobalMethods.DisableControl_DropDownByID(dropInstructCategory);
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
                    _instructorRepository.AddFile(Instructor_File.Create(GetId(), path));
                    _uow.Commit();
                }
                catch { }
            }
            var strSPContractorID = GetId();
            if (strSPContractorID > 0)
            {
                StringBuilder strMessenger = new StringBuilder("");
                var subject = _instructorRepository.Get(strSPContractorID);
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
			var vtxtInstructTP = txtInstructTP.Text;
			var vtxtInstructAcctNum = txtInstructAcctNum.Text;
			var vtxtInstructContFN = txtInstructContFN.Text;
			var vtxtInstructContLN = txtInstructContLN.Text;
			var vtxtInstructContPhone = txtInstructContPhone.Text;
			var vtxtInstructContAddress = txtInstructContAddress.Text;
			var vtxtInstructContCity = txtInstructContCity.Text;
			var vtxtInstructContState = txtInstructContState.Text;
			var vtxtInstructContZipcode = txtInstructContZipcode.Text;
			var vtxtACCID = txtACCID.Text;
			DateTime vAccreditationExpirationDate = default(DateTime);
			if (!string.IsNullOrWhiteSpace(txtAccreditationExpirationDate.Text))
			{
				DateTime.TryParse(txtAccreditationExpirationDate.Text, out vAccreditationExpirationDate);
			}
			var vtxtNewInitTrainingCard = txtNewInitTrainingCard.Text;
			DateTime vtxtNewInitStartDate = default(DateTime);
			if (!string.IsNullOrWhiteSpace(txtNewInitStartDate.Text))
			{
				DateTime.TryParse(txtNewInitStartDate.Text, out vtxtNewInitStartDate);
			}
			DateTime vtxtNewInitEndDate = default(DateTime);
			if (!string.IsNullOrWhiteSpace(txtNewInitEndDate.Text))
			{
				DateTime.TryParse(txtNewInitEndDate.Text, out vtxtNewInitEndDate);
			}
			var vtxtRenewalTrainingCard = txtRenewalTrainingCard.Text;
			DateTime vtxtRenewalStartDate = default(DateTime);
			if (!string.IsNullOrWhiteSpace(txtRenewalStartDate.Text))
			{
				DateTime.TryParse(txtRenewalStartDate.Text, out vtxtRenewalStartDate);
			}
			DateTime vtxtRenewalEndDate = default(DateTime);
			if (!string.IsNullOrWhiteSpace(txtRenewalEndDate.Text))
			{
				DateTime.TryParse(txtRenewalEndDate.Text, out vtxtRenewalEndDate);
			}
			//var vupload_1 = string.Empty;
			//var vupload_2 = string.Empty;

			//try
			//{
			//	vupload_1 = Path.Combine("uf", uploadNewInstructors.FileName);
			//	uploadNewInstructors.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_1));
			//	vupload_2 = Path.Combine("uf", uploadNewInspectorTech.FileName);
			//	uploadNewInspectorTech.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_2));

			//}
			//catch { }
			var vtxtNewRenewAcctNum = txtNewRenewAcctNum.Text;
			var vtxtNewRenewAcctExpireDate = txtNewRenewAcctExpireDate.Text;
			var vchkIAgree = chkIAgree.Checked ? 1 : 0;
			var vdropIsRenewal = int.Parse(dropIsRenewal.SelectedItem.Value);
			//var vdropInstructCategory = int.Parse(objcryptoJS.AES_decrypt(dropInstructCategory.SelectedItem.Value, AppConstants.secretKey, AppConstants.initVec).ToString());
			var vdropInstructCategory = int.Parse("2");

			#region Saving obj

			var id = GetId();
			if (id > 0)
			{
				var subject = _instructorRepository.Get(id);
				subject.Update(vtxtLName, vtxtSuffix, vtxtFName, vtxtMName, vtxtAddress_1, vtxtCity_1, vtxtState_1, vtxtZipCode_1, vtxtAddress_2,
				vtxtCity_2, vtxtState_2, vtxtZipcode_2, vtxtPhone, vtxtEmailAddress, vtxtDOB, vtxtSSNO, vtxtInstructTP, vtxtInstructAcctNum, vtxtInstructContFN,
				vtxtInstructContLN, vtxtInstructContPhone, vtxtInstructContAddress, vtxtInstructContCity, vtxtInstructContState, vtxtInstructContZipcode, vdropIsRenewal,
				vtxtACCID, vAccreditationExpirationDate, vdropInstructCategory, vtxtNewInitTrainingCard, vtxtNewInitStartDate, vtxtNewInitEndDate, vtxtRenewalTrainingCard,
				vtxtRenewalStartDate, vtxtRenewalEndDate, vtxtNewRenewAcctNum, vtxtNewRenewAcctExpireDate, vchkIAgree);
				_instructorRepository.Update(subject);
				_uow.Commit();
				#endregion

				string strBackToForms = objcryptoJS.AES_encrypt("10", AppConstants.secretKey, AppConstants.initVec).ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been updated successfully!', '', 'success', 'MDE_InstructorAppView.aspx?InstructApps=active&cgi=" + Request["cgi"] + "');", true);
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
            string strInstructorId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
            if (GlobalMethods.ValueIsNull(strInstructorId).Length > 0)
            {
                strInstructorId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
            }
            else
            {
                ErrorHandler.ErrorPage();
            }

            clsInstructor_Comment objComm = new clsInstructor_Comment();
            objComm.InstructorId = Convert.ToInt32(strInstructorId);
            objComm.Comment = GlobalMethods.KillChars(txtComment.Text);
            objComm.CreatedDate = DateTime.Now;
            objComm.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
            objComm.IsActive = 1;
            if (!Instructor_CommentDAL.InsertInstructor_Comment(objComm))
            { }

            #region Getting all the Comments by Application Id.
            StringBuilder strMessenger = new StringBuilder("");
            List<clsInstructor_Comment> lstComments = new List<clsInstructor_Comment>();
            lstComments = Instructor_CommentDAL.SelectDynamicInstructor_Comment("InstructorId = " + strInstructorId + "", "InstructorCommentId");
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

				clsInstructor_Approval objRiskApp = new clsInstructor_Approval();
				objRiskApp.InstructorId = Convert.ToInt32(ContractorAppId);
				objRiskApp.MDE_Owner_AuthorisedUserId = Convert.ToInt32(HttpContext.Current.Session["UserAuthId"]);
                objRiskApp.CreatedDate = DateTime.Now;
                objRiskApp.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
                objRiskApp.UpdatedDate = Convert.ToDateTime("1/1/1900");
                objRiskApp.UpdatedBy = "";
                objRiskApp.Notes = "";
				objRiskApp.IsActive = 1;
				if (!Instructor_ApprovalDAL.InsertInstructor_Approval(objRiskApp))
				{

				}
			}
			catch (Exception)
			{
				ErrorHandler.ErrorPage();
			}

			return "MDE_InstructorApps.aspx?InstructApps=active";
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

				List<clsInstructor> objSPCont = new List<clsInstructor>();
				objSPCont = InstructorDAL.SelectDynamicInstructor("InstructorId = " + ContractorAppId + "", "InstructorId");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 1;
					if (InstructorDAL.UpdateInstructor(objSPCont[0]))
					{
						List<clsUserRole> lstURole = new List<clsUserRole>();
						lstURole = UserRoleDAL.SelectDynamicUserRole("RoleId = 3 and AuthorizedUserId = " + objSPCont[0].CreatedBy + "", "UserRoleId");
						if (lstURole != null)
						{
							if (lstURole.Count > 0)
							{
								//ROLE HAS BEEN ASSIGNED. THEREFORE, DONT ADD ANOTHER ROLE.
							}
							else
							{
								clsUserRole objURole = new clsUserRole();
								objURole.RoleId = 3;
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
							objURole.RoleId = 3;
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
			return "MDE_InstructorAppView.aspx?InstructApps=active&cgi=" + cgi + "";
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

				List<clsInstructor> objSPCont = new List<clsInstructor>();
				objSPCont = InstructorDAL.SelectDynamicInstructor("InstructorId = " + ContractorAppId + "", "InstructorId");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 0;
					if (InstructorDAL.UpdateInstructor(objSPCont[0]))
					{
						List<clsUserRole> lstURole = new List<clsUserRole>();
						lstURole = UserRoleDAL.SelectDynamicUserRole("RoleId = 3 and AuthorizedUserId = " + objSPCont[0].CreatedBy + "", "UserRoleId");
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
			return "MDE_InstructorAppView.aspx?InstructApps=active&cgi=" + cgi + "";
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

				List<clsInstructor> objSPCont = new List<clsInstructor>();
				objSPCont = InstructorDAL.SelectDynamicInstructor("InstructorId = " + ContractorAppId + "", "InstructorId");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 2;
					if (!InstructorDAL.UpdateInstructor(objSPCont[0]))
					{

					}
				}
			}
			catch (Exception)
			{
				ErrorHandler.ErrorPage();
			}
			return "MDE_InstructorAppView.aspx?InstructApps=active&cgi=" + cgi + "";
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

				List<clsInstructor> objSPCont = new List<clsInstructor>();
				objSPCont = InstructorDAL.SelectDynamicInstructor("InstructorId = " + ContractorAppId + "", "InstructorId");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 3;
					if (!InstructorDAL.UpdateInstructor(objSPCont[0]))
					{

					}
				}
			}
			catch (Exception)
			{
				ErrorHandler.ErrorPage();
			}
			return "MDE_InstructorAppView.aspx?InstructApps=active&cgi=" + cgi + "";
		}
	}
}