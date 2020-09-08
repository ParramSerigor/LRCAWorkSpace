using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using LRCA.classes.Models;
using LRCA.classes.Repositories;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web.UI.HtmlControls;
using System.IO;

namespace LRCA
{
	public partial class MDEContAppView : PageBase
	{
		private readonly IContractorRepository _contractorRepository;
		CryptoJS objcryptoJS = new CryptoJS();
		private IReadOnlyCollection<LK_Regions> _regions;
		private IReadOnlyCollection<LK_ServicesOffered> _servicesOffered;

		public MDEContAppView()
		{
			_contractorRepository = new ContractorRepository(_context);
			_regions = _contractorRepository.AllRegionByStatus();
			_servicesOffered = _contractorRepository.AllServicesOfferedByStatus();
		}
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
			
        }
        protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string strSPContractorID = string.Empty;

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

                phWriteComment.Visible = false;

				strSPContractorID = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
				if (GlobalMethods.ValueIsNull(strSPContractorID).Length > 0)
				{
					strSPContractorID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
				}

                #region Getting all the Comments by Application Id.
                StringBuilder strMessenger = new StringBuilder("");
                List<clsContractor_Comment> lstComments = new List<clsContractor_Comment>();
                lstComments = Contractor_CommentDAL.SelectDynamicContractor_Comment("SPContractorID = "+ strSPContractorID +"", "ContractorCommentId");
                if(lstComments != null)
                {
                    if(lstComments.Count > 0)
                    {
                        
                        for (int i = 0; i < lstComments.Count; i++)
                        {
                            strMessenger.Append(GlobalMethods.Messenger(lstComments[i].CreatedBy.ToString(),Convert.ToDateTime(lstComments[i].CreatedDate).ToLongDateString(),lstComments[i].Comment.ToString()).ToString());
                        }
                    }
                }
                pnlComments.Controls.Add(new LiteralControl(strMessenger.ToString()));
                #endregion

                #region Checking if this is AssignedToMe Action
                bool IsAssignedToMe = false;
				List<clsContractor_Approval> lstContAppr = new List<clsContractor_Approval>();
				lstContAppr = Contractor_ApprovalDAL.SelectDynamicContractor_Approval("SPContractorID = " + strSPContractorID + "", "MDEContApprId");
				if (lstContAppr != null)
				{
					if (lstContAppr.Count > 0)
					{
						IsAssignedToMe = true;
						phWriteComment.Visible = true;
					}
				}
                #endregion

               

                var subject = _contractorRepository.Get(int.Parse(strSPContractorID));
				if (subject != null)
				{
					var addresses = subject.ContractorAddresses;
					var emplist = subject.ContractorEmpList;
					txtName.Text = subject.SPName;
                    lblContractorApp.Text = subject.SPName;
                    
                    if((subject.ContactFirstName == null) && (subject.ContactLastName == null))
                    {
                        lblSignedBy.Text = subject.RepFirstName + " " + subject.RepLastName;
                    }
                    else
                    {
                        lblSignedBy.Text = subject.ContactFirstName + " " + subject.ContactLastName;
                    }
                    dropIsRenewal.SelectedValue = subject.IsRenewal.HasValue ? subject.IsRenewal.Value.ToString() : "0";
                    divIsRenewal.Visible = subject.IsRenewal.Value == 1;
                    txtSDATNum.Text = subject.SDATDepartmentId;
                    GlobalMethods.SDATVerify(txtSDATNum, subject.SDATDepartmentId);

                    txtEIN.Text = subject.SPTaxId;
                    GlobalMethods.TAXIDVerify(txtEIN, subject.SPTaxId);

                    txtMHICNumber.Text = subject.SPMHICNumber;
					if (addresses.Count > 0)
					{
						var add1 = addresses.FirstOrDefault(x => x.AddressType == 1);
						if (add1 != null)
						{
							txtAddress_1.Text = add1.Address_Line_1;
							txtCity_1.Text = add1.City;
							txtState_1.Text = add1.State;
							txtZipCode_1.Text = add1.ZipCode;
							if (add1.PublicListing.HasValue && add1.PublicListing.Value > 0)
							{
								dropPublicList.SelectedValue = add1.PublicListing.Value.ToString();
							}
						}

						var add2 = addresses.FirstOrDefault(x => x.AddressType == 2);
						if (add2 != null)
						{
							txtAddress_2.Text = add2.Address_Line_1;
							txtCity_2.Text = add2.City;
							txtState_2.Text = add2.State;
							txtZipcode_2.Text = add2.ZipCode;
							if (add2.PublicListing.HasValue && add2.PublicListing.Value > 0)
							{
								dropPublicList.SelectedValue = add2.PublicListing.Value.ToString();
							}
						}
					}
					divCatInspection.Visible = subject.ACRDCatID == Category.Inspection;
					divCatResidential.Visible = subject.ACRDCatID == Category.Residential;
					divCatSteel.Visible = subject.ACRDCatID == Category.Steel;
					foreach (var each in emplist)
					{
						if (each.ACRDCatID == Category.Inspection)
						{
							showTable(pnlInspection, each);
						}
						if (each.ACRDCatID == Category.Residential)
						{
							showTable(pnlResidential, each);
						}
						if (each.ACRDCatID == Category.Steel)
						{
							showTable(pnlSteel, each);
						}
					}
					txtPhone.Text = subject.SPPhone;
					//txtFax.Text = objSPCont.;
					txtEmailAddress.Text = subject.SPEmail;
					txtACCID.Text = subject.AccreditationID;
                    GlobalMethods.AccreditationNumVerify(txtACCID, subject.AccreditationID);

                    dropCategory.SelectedValue = subject.ACRDCatID.HasValue ? subject.ACRDCatID.Value.ToString() : "";
                    lblCourseName.Text = dropCategory.SelectedItem.Text;
                    txtAccreditationExpirationDate.Text = subject.AccreditationExpirationDate.HasValue ? Convert.ToDateTime(subject.AccreditationExpirationDate.Value.ToString()).ToShortDateString() : "";
                    GlobalMethods.AccreditationExpireDateVerify(txtAccreditationExpirationDate, subject.AccreditationID, subject.AccreditationExpirationDate.HasValue ? Convert.ToDateTime(subject.AccreditationExpirationDate.Value.ToString()) : Convert.ToDateTime("1/1/1900"));

                    dropWaiverType.SelectedValue = subject.Waiver.HasValue ? subject.Waiver.ToString() : "";
					dropPublicListing.SelectedValue = subject.PublishOnMDEWebsite.HasValue ? subject.PublishOnMDEWebsite.ToString() : "";

					txtContactFName.Text = subject.ContactFirstName;
					txtContactLName.Text = subject.ContactLastName;
					txtAuthRepContFName.Text = subject.RepFirstName;
					txtAuthRepContLName.Text = subject.RepLastName;
                    lblContactInfo.Text = subject.RepFirstName + " " + subject.RepLastName +" - "+ subject.SPPhone +" - "+ subject.SPEmail;
                    lblDateSigned.Text = Convert.ToDateTime(subject.CreatedDate).ToShortDateString();

                    txtAuthRepContTitle.Text = subject.RepTitle;
					chkIAgree.Checked = subject.Agreed.HasValue ? subject.Agreed.Value == 1 : false;

					string strEnContractId = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode(subject.Id.ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
					if (!IsAssignedToMe)
					{
                        GlobalMethods.DisableControls(this.Page);
                        btnAddCourse.Visible = false;
                        pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a class='btn btn-primary2 open-AssignedToMe' href='#' data-id='" + strEnContractId + "' data-toggle='modal' >Assigned to Me</a>" + GlobalMethods.ContractorAppStatus(subject.IsActive.HasValue ? subject.IsActive.Value : 0, "bar", "") + "</div>"));
					}
					else
					{
                       
                        pnlAppStatus.Controls.Add(new LiteralControl("<div class='input-group'><div class='input-group-btn'><a class='btn btn-success open-Approve' title='Approve Application' href='#' data-id='" + strEnContractId + "' data-toggle='modal' >Approve</a>&nbsp;<a class='btn btn-danger open-Disapprove' href='#' title='Reject Application' data-id='" + strEnContractId + "' data-toggle='modal' >Reject</a>&nbsp;<a class='btn btn-primary open-Hold' href='#' title='Put Application On Hold' data-id='" + strEnContractId + "' data-toggle='modal' >On Hold</a>&nbsp;<a class='btn btn-primary open-Deficient' href='#' title='Application status is Deficient' data-id='" + strEnContractId + "' data-toggle='modal' >Deficient</a>" + GlobalMethods.ContractorAppStatus(subject.IsActive.HasValue ? subject.IsActive.Value : 0, "bar", "") + "</div>"));   
                        phWriteComment.Visible = true;
                    }
					foreach (var each in subject.ContractorRegions)
					{
						GenerateRadio(pnlRegions, each.Region.RegionName);
					}

					var i = 0;
					var strContent = new StringBuilder();

					foreach (var each in subject.ContractorServices)
					{
						if (i % 4 == 0)
						{
							strContent.Append("<div class='row'>");
							GenerateCheckBox(pnlServiceOffered, each.ServiceOffer.ServiceOffered);
							if (i == 4)
							{
								strContent.Append("</div>");
							}
						}
						else
						{
							GenerateCheckBox(pnlServiceOffered, each.ServiceOffer.ServiceOffered);
						}
						i++;
					}
					if (subject.ContractorServices.Count > 0)
					{
						strContent.Append("</div>");
						pnlServiceOffered.Controls.Add(new LiteralControl(strContent.ToString()));
					}

                    #region Getting all the Case files.
                    StringBuilder strMessengerUpload = new StringBuilder("");

                    foreach (var each in subject.ContractorFiles.OrderByDescending(x => x.Id))
                    {
                        strMessengerUpload.Append(GlobalMethods.UploadedFiles(each.CreatedBy.ToString(), Convert.ToDateTime(each.CreatedDate).ToLongDateString(), each.FileLocation.ToString()).ToString());
                    }
                    pnlUploads.Controls.Add(new LiteralControl(strMessengerUpload.ToString()));
                    #endregion

                }

                #region Making all the fields disabled.
                //GlobalMethods.EnableControl_TextBoxByID(txtComment);
                GlobalMethods.DisableControl_CheckBoxByID(chkIAgree);
                GlobalMethods.DisableControl_DropDownByID(dropCategory);
                GlobalMethods.DisableControl_DropDownByID(dropIsRenewal);
                GlobalMethods.DisableControl_DropDownByID(dropPublicList);
                GlobalMethods.DisableControl_DropDownByID(dropPublicListing);
                GlobalMethods.DisableControl_DropDownByID(dropWaiverType);
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
                    _contractorRepository.AddFile(Contractor_File.Create(GetId(), path));
                    _uow.Commit();
                }
                catch { }
            }
            var strSPContractorID = GetId();
            if(strSPContractorID > 0)
            {
                StringBuilder strMessenger = new StringBuilder("");
                var subject = _contractorRepository.Get(strSPContractorID);
                if (subject != null)
                {
                    foreach (var each in subject.ContractorFiles.OrderByDescending(x => x.Id))
                    {
                        strMessenger.Append(GlobalMethods.UploadedFiles(each.CreatedBy.ToString(), Convert.ToDateTime(each.CreatedDate).ToLongDateString(), each.FileLocation.ToString()).ToString());
                    }
                    pnlUploads.Controls.Add(new LiteralControl(strMessenger.ToString()));
                }
            }
            
        }
       protected void CommentEnter(object sender, EventArgs e)
       {
            string  strSPContractorID = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
            if (GlobalMethods.ValueIsNull(strSPContractorID).Length > 0)
            {
                strSPContractorID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
            }
            else
            {
                ErrorHandler.ErrorPage();
            }

            clsContractor_Comment objComm = new clsContractor_Comment();
            objComm.SPContractorID = Convert.ToInt32(strSPContractorID);
            objComm.Comment = GlobalMethods.KillChars(txtComment.Text);
            objComm.CreatedDate = DateTime.Now;
            objComm.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
            objComm.IsActive = 1;
            if(!Contractor_CommentDAL.InsertContractor_Comment(objComm))
            { }

            #region Getting all the Comments by Application Id.
            StringBuilder strMessenger = new StringBuilder("");
            List<clsContractor_Comment> lstComments = new List<clsContractor_Comment>();
            lstComments = Contractor_CommentDAL.SelectDynamicContractor_Comment("SPContractorID = " + strSPContractorID + "", "ContractorCommentId");
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
		protected void AddTManual_Click(object sender, EventArgs e)
		{
			Update();
		}
		private void Update()
		{
			Security objSecurity = new Security();

			#region "variables"
			string vSPName = objSecurity.KillChars(txtName.Text);
			string vSDATDepartmentId = objSecurity.KillChars(txtSDATNum.Text);
			string vSPTaxId = objSecurity.KillChars(txtEIN.Text);
			bool vSPFeeStatus = false;//chkFeeStatus.Checked;
			string vSPMHICNumber = objSecurity.KillChars(txtMHICNumber.Text);
			bool vPublishOnMDEWebsite = false;//chkPublishOnMDEWebsite.Checked;
			string vSPAddress_Line_1 = objSecurity.KillChars(txtAddress_1.Text);
			string vSPAddress_Line_2 = objSecurity.KillChars(txtAddress_2.Text);
			string vSPCity = objSecurity.KillChars(txtCity_1.Text);
			string vSPState = objSecurity.KillChars(txtState_1.Text);
			//string vSPCounty = "";// objSecurity.KillChars(txtCounty.Text);
			string vSPZipCode = objSecurity.KillChars(txtZipCode_1.Text);
			string vSPCity2 = objSecurity.KillChars(txtCity_2.Text);
			string vSPState2 = objSecurity.KillChars(txtState_2.Text);
			//string vSPCounty2 = "";// objSecurity.KillChars(txtCounty.Text);
			string vSPZipCode2 = objSecurity.KillChars(txtZipcode_2.Text);
			string vSPPhone = objSecurity.KillChars(txtPhone.Text);
			string vSPFax = objSecurity.KillChars(txtFax.Text);
			string vSPWebSite = "";//objSecurity.KillChars(txtWebSite.Text);
			string vSPEmail = objSecurity.KillChars(txtEmailAddress.Text);
			string vAccreditationID = objSecurity.KillChars(txtACCID.Text);
			string vCourseCatID = dropCategory.SelectedItem.Value;
			DateTime vAccreditationExpirationDate = default(DateTime);
			//if ((txtAccreditationExpirationDate.Text.Length == 0) || (txtAccreditationExpirationDate.Text == null))
			//{
			//    vAccreditationExpirationDate = Convert.ToDateTime("1/1/1900").ToShortDateString();
			//}
			if (!string.IsNullOrWhiteSpace(txtAccreditationExpirationDate.Text))
			{
				DateTime.TryParse(txtAccreditationExpirationDate.Text, out vAccreditationExpirationDate);
				//vAccreditationExpirationDate = Convert.ToDateTime(objSecurity.KillChars(txtAccreditationExpirationDate.Text));
			}

			int? vDropPublicList = null;
			int pDropPublicList;
			if (int.TryParse(dropPublicList.SelectedItem.Value, out pDropPublicList) && pDropPublicList > -1)
			{
				vDropPublicList = pDropPublicList;
			}
			string vDropIsRenewal = dropIsRenewal.SelectedItem.Value;
			int? vDropWaiverType = null;
			int pDropWaiverType;
			if (int.TryParse(dropWaiverType.SelectedItem.Value, out pDropWaiverType) && pDropWaiverType > -1)
			{
				vDropWaiverType = pDropWaiverType;
			}
			int? vDropPublicListing = null;
			int pDropPublicListing;
			if (int.TryParse(dropPublicListing.SelectedItem.Value, out pDropPublicListing) && pDropPublicListing > -1)
			{
				vDropPublicListing = pDropPublicListing;
			}
			string vContactFirstName = objSecurity.KillChars(txtContactFName.Text);
			string vContactLastName = objSecurity.KillChars(txtContactLName.Text);
			string vAuthFName = objSecurity.KillChars(txtAuthRepContFName.Text);
			string vAuthLName = objSecurity.KillChars(txtAuthRepContLName.Text);
			string vAuthTitle = objSecurity.KillChars(txtAuthRepContTitle.Text);
			bool vAgreed = chkIAgree.Checked;
			#endregion

			#region Updating obj
			var strSPContractorID = GetId();
			if (strSPContractorID > 0)
			{
				var subject = _contractorRepository.Get(strSPContractorID);
				subject.Update(vSPName, vSDATDepartmentId,
					vSPTaxId, vSPFeeStatus,
					vSPMHICNumber, vPublishOnMDEWebsite,
					vSPPhone, "", vSPWebSite, vSPEmail, vAccreditationID, Convert.ToInt32(vCourseCatID),
					vAccreditationExpirationDate
					, int.Parse(vDropIsRenewal), vDropWaiverType, vDropPublicListing
					, vContactFirstName, vContactLastName, vAuthFName, vAuthLName, vAuthTitle, vAgreed);
				_contractorRepository.Update(subject);
				_uow.Commit();

				string strBackToForms = objcryptoJS.AES_encrypt("10", AppConstants.secretKey, AppConstants.initVec).ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been updated successfully!', '', 'success', 'MDEContAppView.aspx?contapps=active&cgi="+ Request["cgi"] +"');", true);
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been updated successfully!', '', 'success', '#');", true);
            }
			#endregion
		}

		private int GetId()
		{
			string strSPContractorID = Request["cgi"].ToString() == null ? string.Empty : Request["cgi"].ToString();
			if (GlobalMethods.ValueIsNull(strSPContractorID).Length > 0)
			{
				strSPContractorID = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(Request["cgi"].ToString()), AppConstants.secretKey, AppConstants.initVec).ToString();
			}
			else
			{
				ErrorHandler.ErrorPage();
			}

			return int.Parse(strSPContractorID);
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

				clsContractor_Approval objContApp = new clsContractor_Approval();
				objContApp.SPContractorID = Convert.ToInt32(ContractorAppId);
				objContApp.MDE_Owner_AuthorisedUserId = Convert.ToInt32(HttpContext.Current.Session["UserAuthId"]);
				objContApp.CreateDate = DateTime.Now;
				objContApp.CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
				objContApp.UpdatedDate = Convert.ToDateTime("1/1/1900");
				objContApp.UpdatedBy = "";
				objContApp.Notes = "";
				objContApp.IsActive = 1;
				if (!Contractor_ApprovalDAL.InsertContractor_Approval(objContApp))
				{

				}
			}
			catch (Exception)
			{
				ErrorHandler.ErrorPage();
			}

			return "MDE_ContrApps.aspx?contapps=active";
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

				List<clsSP_Contractor> objSPCont = new List<clsSP_Contractor>();
				objSPCont = SP_ContractorDAL.SelectDynamicSP_Contractor("SPContractorID = " + ContractorAppId + "", "SPContractorID");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 1;
					if (SP_ContractorDAL.UpdateSP_Contractor(objSPCont[0]))
					{
						List<clsUserRole> lstURole = new List<clsUserRole>();
						lstURole = UserRoleDAL.SelectDynamicUserRole("RoleId = 7 and AuthorizedUserId = " + objSPCont[0].CreatedBy + "", "UserRoleId");
						if (lstURole != null)
						{
							if (lstURole.Count > 0)
							{
								//ROLE HAS BEEN ASSIGNED. THEREFORE, DONT ADD ANOTHER ROLE.
							}
							else
							{
								clsUserRole objURole = new clsUserRole();
								objURole.RoleId = 7;
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
							objURole.RoleId = 7;
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
			return "MDEContAppView.aspx?contapps=active&cgi=" + cgi + "";
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

				List<clsSP_Contractor> objSPCont = new List<clsSP_Contractor>();
				objSPCont = SP_ContractorDAL.SelectDynamicSP_Contractor("SPContractorID = " + ContractorAppId + "", "SPContractorID");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 0;
					if (SP_ContractorDAL.UpdateSP_Contractor(objSPCont[0]))
					{
						List<clsUserRole> lstURole = new List<clsUserRole>();
						lstURole = UserRoleDAL.SelectDynamicUserRole("RoleId = 7 and AuthorizedUserId = " + objSPCont[0].CreatedBy + "", "UserRoleId");
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
			return "MDEContAppView.aspx?contapps=active&cgi=" + cgi + "";
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

				List<clsSP_Contractor> objSPCont = new List<clsSP_Contractor>();
				objSPCont = SP_ContractorDAL.SelectDynamicSP_Contractor("SPContractorID = " + ContractorAppId + "", "SPContractorID");
				if (objSPCont != null)
				{
					objSPCont[0].IsActive = 2;
					if (!SP_ContractorDAL.UpdateSP_Contractor(objSPCont[0]))
					{

					}
				}
			}
			catch (Exception)
			{
				ErrorHandler.ErrorPage();
			}
			return "MDEContAppView.aspx?contapps=active&cgi=" + cgi + "";
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

                List<clsSP_Contractor> objSPCont = new List<clsSP_Contractor>();
                objSPCont = SP_ContractorDAL.SelectDynamicSP_Contractor("SPContractorID = " + ContractorAppId + "", "SPContractorID");
                if (objSPCont != null)
                {
                    objSPCont[0].IsActive = 3;
                    if (!SP_ContractorDAL.UpdateSP_Contractor(objSPCont[0]))
                    {

                    }
                }
            }
            catch (Exception)
            {
                ErrorHandler.ErrorPage();
            }
            return "MDEContAppView.aspx?contapps=active&cgi=" + cgi + "";
        }

        protected void GenerateRadio(Panel pnlName, string Title)
		{
            //disabled='disabled'
            var strContent = new StringBuilder("");
			strContent.Append("<div class='col-lg-2'><div class='checkbox-primary m-b' >");
			strContent.Append("<input  id='chk_" + Title + "' type='checkbox' name='chk_" + Title + "' checked>");
			strContent.Append("<label for='chk_" + Title + "' style='font-size:12px; padding-left:5px;padding-bottom:5px'>" + Title + "</label></div></div>");
			pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

		}

		protected void GenerateCheckBox(Panel pnlName, string Title)
		{
            //disabled='disabled'
            var strContent = new StringBuilder("");
			strContent.Append("<div class='col-lg-3'><div class='checkbox-primary  m-b' >");
			strContent.Append("<input  id='chk_" + Title + "' type='checkbox' name='chk_" + Title + "' checked>");
			strContent.Append("<label for='chk_" + Title + "' style='font-size:12px; padding-left:5px;padding-bottom:5px'>" + Title + "</label></div></div>");
			pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

		}

		protected void showTable(Panel pnlName, Contractor_EmpList contractor_EmpList)
		{

			StringBuilder strContent = new StringBuilder("<tr>");
			strContent.Append("<td width='15%' nowrap>");
			strContent.Append(contractor_EmpList.EmpFName);
			strContent.Append("</td>");
			strContent.Append("<td width='15%' nowrap>");
			strContent.Append(contractor_EmpList.EmpLName);
			strContent.Append("</td>");
			strContent.Append("<td width='10%'nowrap>");
			strContent.Append(contractor_EmpList.AccreditedId);
			strContent.Append("</td>");
			if (contractor_EmpList.IsApplying.HasValue)
			{
				strContent.Append("<td width='10%'nowrap>");
				strContent.Append(contractor_EmpList.IsApplying.Value == 1 ? "YES" : "NO");
				strContent.Append("</td>");
			}
			//***************************************
			strContent.Append("<td width='5%' nowrap>");
			strContent.Append("<a class='btn btn-xs btn-success' href='#'>View</a>");
			strContent.Append("</td>");

			pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

		}
	}
}