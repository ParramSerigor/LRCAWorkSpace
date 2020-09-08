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
	public partial class MDE_TPAppView : PageBase
	{
		private readonly ITPRepository _tpRepository;
		CryptoJS objcryptoJS = new CryptoJS();
		public MDE_TPAppView()
		{
			_tpRepository = new TPRepository(_context);
		}
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string strtpId = string.Empty;
				phWriteComment.Visible = false;

				strtpId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
				if (GlobalMethods.ValueIsNull(strtpId).Length > 0)
				{
					strtpId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
				}

				#region Getting all the Comments by Application Id.
				StringBuilder strMessenger = new StringBuilder("");
				List<clsTP_Comment> lstComments = new List<clsTP_Comment>();
				lstComments = TP_CommentDAL.SelectDynamicTP_Comment("TPId = " + strtpId + "", "TPCommentId");
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

				var pendingApps = _tpRepository.PendingApps();

				if (pendingApps.Select(x => x.Id).Contains(Convert.ToInt32(strtpId)))
				{
					// Means this needs Assigned To Me button.
					IsAssignedToMe = true;
					phWriteComment.Visible = false;
				}

				#endregion

				var obj = _tpRepository.Get(int.Parse(strtpId));
				if (obj != null)
				{
					txtName.Text = obj.TP_Name;
					txtSDATNum.Text = obj.TP_SDAT;
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
					txtEIN.Text = obj.TP_TaxID.FromByteArray();
					txtACCID.Text = obj.AccreditationID;
					txtAccreditationExpirationDate.Text = obj.AccreditationExpirationDate.HasValue ? obj.AccreditationExpirationDate.Value.ToShortDateString() : "";
					chkChargeFee.Checked = obj.TP_Fee == 1;
					if (!string.IsNullOrWhiteSpace(obj.TP_TaxExempt))
					{
						chkTaxExempt.Checked = true;
					}
					else
					{
						chkTaxExempt.Checked = false;
					}

					txtTaxExempt.Text = obj.TP_TaxExempt;
                    if(obj.TPWebsiteURL.Length > 0)
                    {
                        chkTPwebsiteYES.Checked = true;
                        chkTPwebsiteNO.Checked = false;
                    }
                    else
                    {
                        chkTPwebsiteYES.Checked = false;
                        chkTPwebsiteNO.Checked = true;
                    }
					
					txtTPwebsiteURL.Text = obj.TPWebsiteURL;
					chkCORiskAssessor.Checked = obj.RiskAssessor == 1;
					chkCOProjectDesigner.Checked = obj.ProjectDesign == 1;
					chkCOInspectorTech.Checked = obj.InspectorTech == 1;
					chkCOAbatWorkEnglish.Checked = obj.AbatWorkerEnglish == 1;
					chkCOVisualInspector.Checked = obj.VisualInspector == 1;
					chkCOAbatWorkSpanish.Checked = obj.AbatWorkerSpanish == 1;
					chkCOMainRepaintSup.Checked = obj.MainRepaint == 1;
					chkCOStructSteelSup.Checked = obj.StructSteelSupervisor == 1;
					chkCORemovalSup.Checked = obj.RemovalDemo == 1;
					chkStructSteelWork.Checked = obj.StructSteelWorker == 1;
                    txtAuthRepContFName.Text = obj.TPContactFirstName;
					txtAuthRepContLName.Text = obj.TPContactLastName;
					txtAuthRepContTitle.Text = obj.TPContactTitle;
					lblContractorApp.Text = obj.TP_Name;
					lblSignedBy.Text = obj.TPContactFirstName + " " + obj.TPContactLastName;
					chkIAgree.Checked = obj.Agreed == 1;
					dropIsRenewal.SelectedValue = obj.IsRenewal.HasValue ? obj.IsRenewal.Value.ToString() : "-1";

					if ((dropIsRenewal.SelectedValue == "0") || (dropIsRenewal.SelectedValue == "-1"))
					{
						divIsRenewal.Visible = false;
					}
					// dropPublicList.Text = obj;
					lblDateSigned.Text = obj.CreatedDate.ToLongDateString();
					for (int i = 0; i < obj.Locations.Count; i++)
					{
						var element = obj.Locations.ElementAt(i);
						if (element != null)
						{
							var cIndex = i + 1; 
							 var address1 = (TextBox)Page.FindControl("ctl00$CPMain$txtLocation_Address_" + cIndex);
							var city = (TextBox)Page.FindControl("ctl00$CPMain$txtLocation_City_" + cIndex);
							var state = (TextBox)Page.FindControl("ctl00$CPMain$txtLocation_State_" + cIndex);
							var zipcode = (TextBox)Page.FindControl("ctl00$CPMain$txtLocation_ZipCode_" + cIndex);
							if (address1 != null)
							{
								address1.Text = element.TP_Address_Line_1;
								city.Text = element.TP_City;
								state.Text = element.TP_State;
								zipcode.Text = element.TP_ZipCode;
							}
						}
					}
					for (int i = 0; i < obj.Instructors.Count; i++)
					{
						var element = obj.Instructors.ElementAt(i);
						if (element != null)
						{
							var cIndex = i + 1; 
							 var fn = (TextBox)Page.FindControl("ctl00$CPMain$txtInstructorFN_" + cIndex);
							var ln = (TextBox)Page.FindControl("ctl00$CPMain$txtInstructorLN_" + cIndex);
							
							if (fn != null)
							{
								fn.Text = element.TP_InstructorFN;
								ln.Text = element.TP_InstructorLN;	
							}
						}
					}

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
				GlobalMethods.DisableControl_DropDownByID(dropPublicList);
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
                    _tpRepository.AddFile(TP_File.Create(GetId(), path));
                    _uow.Commit();
                }
                catch { }
            }
            var strSPContractorID = GetId();
            if (strSPContractorID > 0)
            {
                StringBuilder strMessenger = new StringBuilder("");
                var subject = _tpRepository.Get(strSPContractorID);
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
        protected void CommentEnter(object sender, EventArgs e)
		{
			string strtpId = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
			if (GlobalMethods.ValueIsNull(strtpId).Length > 0)
			{
				strtpId = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
			}
			else
			{
				ErrorHandler.ErrorPage();
			}

			clsTP_Comment objComm = new clsTP_Comment();
			objComm.TPId = Convert.ToInt32(strtpId);
			objComm.Comment = GlobalMethods.KillChars(txtComment.Text);
			objComm.CreatedDate = DateTime.Now;
			objComm.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
			objComm.IsActive = 1;
			if (!TP_CommentDAL.InsertTP_Comment(objComm))
			{ }

			#region Getting all the Comments by Application Id.
			StringBuilder strMessenger = new StringBuilder("");
			List<clsTP_Comment> lstComments = new List<clsTP_Comment>();
			lstComments = TP_CommentDAL.SelectDynamicTP_Comment("TPId = " + strtpId + "", "TPCommentId");
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
			var vtxtName = txtName.Text;
			var vtxtSDATNum = txtSDATNum.Text;
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
			var vtxtEIN = txtEIN.Text;
			var vtxtACCID = txtACCID.Text;
			DateTime vAccreditationExpirationDate = default(DateTime);
			if (!string.IsNullOrWhiteSpace(txtAccreditationExpirationDate.Text))
			{
				DateTime.TryParse(txtAccreditationExpirationDate.Text, out vAccreditationExpirationDate);
			}
			var vchkChargeFee = chkChargeFee.Checked ? 1 : 0;
			var vchkTaxExempt = chkTaxExempt.Checked ? 1 : 0;
			var vtxtTaxExempt = txtTaxExempt.Text;
            var vchkTPwebsiteNO = 0;
            var vchkTPwebsiteYES = 0;
            var vtxtTPwebsiteURL = "";

            if (chkTPwebsiteYES.Checked)
            {
                vchkTPwebsiteYES = 1;
                vtxtTPwebsiteURL = txtTPwebsiteURL.Text;
                vchkTPwebsiteNO = 0;
            }
            else
            {
                vchkTPwebsiteYES = 0;
                vtxtTPwebsiteURL = "";
                vchkTPwebsiteNO = 1;
            }
			
			
			var vtxtLocation_Address_1 = txtLocation_Address_1.Text;
			var vtxtLocation_City_1 = txtLocation_City_1.Text;
			var vtxtLocation_State_1 = txtLocation_State_1.Text;
			var vtxtLocation_ZipCode_1 = txtLocation_ZipCode_1.Text;
			var vtxtLocation_Address_2 = txtLocation_Address_2.Text;
			var vtxtLocation_City_2 = txtLocation_City_2.Text;
			var vtxtLocation_State_2 = txtLocation_State_2.Text;
			var vtxtLocation_ZipCode_2 = txtLocation_ZipCode_2.Text;
			var vtxtLocation_Address_3 = txtLocation_Address_3.Text;
			var vtxtLocation_City_3 = txtLocation_City_3.Text;
			var vtxtLocation_State_3 = txtLocation_State_3.Text;
			var vtxtLocation_ZipCode_3 = txtLocation_ZipCode_3.Text;
			var vtxtLocation_Address_4 = txtLocation_Address_4.Text;
			var vtxtLocation_City_4 = txtLocation_City_4.Text;
			var vtxtLocation_State_4 = txtLocation_State_4.Text;
			var vtxtLocation_ZipCode_4 = txtLocation_ZipCode_4.Text;
			var vtxtLocation_Address_5 = txtLocation_Address_5.Text;
			var vtxtLocation_City_5 = txtLocation_City_5.Text;
			var vtxtLocation_State_5 = txtLocation_State_5.Text;
			var vtxtLocation_ZipCode_5 = txtLocation_ZipCode_5.Text;
			var vtxtLocation_Address_6 = txtLocation_Address_6.Text;
			var vtxtLocation_City_6 = txtLocation_City_6.Text;
			var vtxtLocation_State_6 = txtLocation_State_6.Text;
			var vtxtLocation_ZipCode_6 = txtLocation_ZipCode_6.Text;
			var vchkCORiskAssessor = chkCORiskAssessor.Checked ? 1 : 0;
			var vchkCOProjectDesigner = chkCOProjectDesigner.Checked ? 1 : 0;
			var vchkCOInspectorTech = chkCOInspectorTech.Checked ? 1 : 0;
			var vchkCOAbatWorkEnglish = chkCOAbatWorkEnglish.Checked ? 1 : 0;
			var vchkCOVisualInspector = chkCOVisualInspector.Checked ? 1 : 0;
			var vchkCOAbatWorkSpanish = chkCOAbatWorkSpanish.Checked ? 1 : 0;
			var vchkCOMainRepaintSup = chkCOMainRepaintSup.Checked ? 1 : 0;
			var vchkCOStructSteelSup = chkCOStructSteelSup.Checked ? 1 : 0;
			var vchkCORemovalSup = chkCORemovalSup.Checked ? 1 : 0;
			var vchkStructSteelWork = chkStructSteelWork.Checked ? 1 : 0;
			var vtxtInstructorFN_1 = txtInstructorFN_1.Text;
			var vtxtInstructorLN_1 = txtInstructorLN_1.Text;
			var vtxtInstructorFN_2 = txtInstructorFN_2.Text;
			var vtxtInstructorLN_2 = txtInstructorLN_2.Text;
			var vtxtInstructorFN_3 = txtInstructorFN_3.Text;
			var vtxtInstructorLN_3 = txtInstructorLN_3.Text;
			var vtxtInstructorFN_4 = txtInstructorFN_4.Text;
			var vtxtInstructorLN_4 = txtInstructorLN_4.Text;
			var vtxtInstructorFN_5 = txtInstructorFN_5.Text;
			var vtxtInstructorLN_5 = txtInstructorLN_5.Text;
			var vtxtInstructorFN_6 = txtInstructorFN_6.Text;
			var vtxtInstructorLN_6 = txtInstructorLN_6.Text;
			var vtxtInstructorFN_7 = txtInstructorFN_7.Text;
			var vtxtInstructorLN_7 = txtInstructorLN_7.Text;
			var vtxtInstructorFN_8 = txtInstructorFN_8.Text;
			var vtxtInstructorLN_8 = txtInstructorLN_8.Text;
			var vtxtAuthRepContFName = txtAuthRepContFName.Text;
			var vtxtAuthRepContLName = txtAuthRepContLName.Text;
			var vtxtAuthRepContTitle = txtAuthRepContTitle.Text;
			var vchkIAgree = chkIAgree.Checked ? 1 : 0;
			var vdropPublicList = int.Parse(dropPublicList.SelectedItem.Value);
			var vdropIsRenewal = int.Parse(dropIsRenewal.SelectedItem.Value);

			#region Saving obj

			var id = GetId();
			if (id > 0)
			{
				var subject = _tpRepository.Get(id);
				subject.Update(vtxtName, vtxtSDATNum, vtxtAddress_1, vtxtCity_1, vtxtState_1, vtxtZipCode_1, vtxtAddress_2, vtxtCity_2, vtxtState_2, vtxtZipcode_2,
				vdropPublicList, vtxtPhone, vtxtFax, vtxtEmailAddress, vtxtEIN, vdropIsRenewal, vtxtACCID, vAccreditationExpirationDate, vchkChargeFee, vchkTaxExempt,
				vtxtTaxExempt, vchkTPwebsiteYES, vtxtTPwebsiteURL, vchkTPwebsiteNO, vchkCORiskAssessor,
				vchkCOProjectDesigner, vchkCOInspectorTech, vchkCOAbatWorkEnglish, vchkCOVisualInspector, vchkCOAbatWorkSpanish, vchkCOMainRepaintSup, vchkCOStructSteelSup,
				vchkCORemovalSup, vchkStructSteelWork, vtxtAuthRepContFName, vtxtAuthRepContLName, vtxtAuthRepContTitle, vchkIAgree);
				_tpRepository.Update(subject);
				_uow.Commit();
				#endregion

				string strBackToForms = objcryptoJS.AES_encrypt("10", AppConstants.secretKey, AppConstants.initVec).ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been updated successfully!', '', 'success', 'MDE_TPAppView.aspx?tpApps=active&cgi=" + Request["cgi"] + "');", true);
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

				clsTP_Approval objRiskApp = new clsTP_Approval();
				objRiskApp.TPId = Convert.ToInt32(ContractorAppId);
				objRiskApp.MDE_Owner_AuthorisedUserId = Convert.ToInt32(HttpContext.Current.Session["UserAuthId"]);
				objRiskApp.CreatedDate = DateTime.Now;
				objRiskApp.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
				objRiskApp.UpdatedDate = Convert.ToDateTime("1/1/1900");
				objRiskApp.UpdatedBy = "";
				objRiskApp.Notes = "";
				objRiskApp.IsActive = 1;
				if (!TP_ApprovalDAL.InsertTP_Approval(objRiskApp))
				{

				}
			}
			catch (Exception)
			{
				ErrorHandler.ErrorPage();
			}

			return "MDE_TPApps.aspx?tpapps=active";
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

				List<clsTrainingProvider> objSPCont = new List<clsTrainingProvider>();
				objSPCont = TrainingProviderDAL.SelectDynamicTrainingProvider("TPId = " + ContractorAppId + "", "TPId");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 1;
					if (TrainingProviderDAL.UpdateTrainingProvider(objSPCont[0]))
					{
						List<clsUserRole> lstURole = new List<clsUserRole>();
						lstURole = UserRoleDAL.SelectDynamicUserRole("RoleId = 2 and AuthorizedUserId = " + objSPCont[0].CreatedBy + "", "UserRoleId");
						if (lstURole != null)
						{
							if (lstURole.Count > 0)
							{
								//ROLE HAS BEEN ASSIGNED. THEREFORE, DONT ADD ANOTHER ROLE.
							}
							else
							{
								clsUserRole objURole = new clsUserRole();
								objURole.RoleId = 2;
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
							objURole.RoleId = 2;
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
			return "MDE_TPAppView.aspx?tpapps=active&cgi=" + cgi + "";
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

				List<clsTrainingProvider> objSPCont = new List<clsTrainingProvider>();
				objSPCont = TrainingProviderDAL.SelectDynamicTrainingProvider("TPId = " + ContractorAppId + "", "TPId");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 0;
					if (TrainingProviderDAL.UpdateTrainingProvider(objSPCont[0]))
					{
						List<clsUserRole> lstURole = new List<clsUserRole>();
						lstURole = UserRoleDAL.SelectDynamicUserRole("RoleId = 2 and AuthorizedUserId = " + objSPCont[0].CreatedBy + "", "UserRoleId");
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
			return "MDE_TPAppView.aspx?tpapps=active&cgi=" + cgi + "";
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

				List<clsTrainingProvider> objSPCont = new List<clsTrainingProvider>();
				objSPCont = TrainingProviderDAL.SelectDynamicTrainingProvider("TPId = " + ContractorAppId + "", "TPId");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 2;
					if (!TrainingProviderDAL.UpdateTrainingProvider(objSPCont[0]))
					{

					}
				}
			}
			catch (Exception)
			{
				ErrorHandler.ErrorPage();
			}
			return "MDE_TPAppView.aspx?tpapps=active&cgi=" + cgi + "";
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

				List<clsTrainingProvider> objSPCont = new List<clsTrainingProvider>();
				objSPCont = TrainingProviderDAL.SelectDynamicTrainingProvider("TPId = " + ContractorAppId + "", "TPId");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 3;
					if (!TrainingProviderDAL.UpdateTrainingProvider(objSPCont[0]))
					{

					}
				}
			}
			catch (Exception)
			{
				ErrorHandler.ErrorPage();
			}
			return "MDE_TPAppView.aspx?tpapps=active&cgi=" + cgi + "";
		}
	}
}