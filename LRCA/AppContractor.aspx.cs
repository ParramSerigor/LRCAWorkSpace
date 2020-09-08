using LRCA.classes;
using LRCA.classes.Models;
using LRCA.classes.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
	public partial class AppContractor : PageBase
	{
		private readonly IContractorRepository _contractorRepository;
		private IReadOnlyCollection<LK_Regions> _regions;
		CryptoJS objcryptoJS = new CryptoJS();
		private IReadOnlyCollection<LK_ServicesOffered> _servicesOffered;

		public AppContractor()
		{
			_contractorRepository = new ContractorRepository(_context);
			_regions = _contractorRepository.AllRegionByStatus();
			_servicesOffered = _contractorRepository.AllServicesOfferedByStatus();
		}
		
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				#region Regions
				var i = 0;

				foreach (var each in _contractorRepository.AllRegionByStatus())
				{
					GenerateRadio(pnlRegions, each.RegionName, i, each.RegionId.HasValue ? each.RegionId.Value : 0);
					i++;
				}
				#endregion

				#region Getting Services Offered.
				i = 0;
				var strContent = new StringBuilder();

				foreach (var each in _servicesOffered)
				{
					if (i % 4 == 0)
					{
						strContent.Append("<div class='row'>");
						GenerateCheckBox(pnlServiceOffered, each.ServiceOffered, i, each.ServiceOfferId.HasValue ? each.ServiceOfferId.Value : 0);
						if (i == 4)
						{
							strContent.Append("</div>");
						}
					}
					else
					{
						GenerateCheckBox(pnlServiceOffered, each.ServiceOffered, i, each.ServiceOfferId.HasValue ? each.ServiceOfferId.Value : 0);
					}
					i++;
				}
				if (_servicesOffered.Count > 0)
				{
					strContent.Append("</div>");
					pnlServiceOffered.Controls.Add(new LiteralControl(strContent.ToString()));
				}
				#endregion

				lblDateSigned.Text = DateTime.Now.ToLongDateString();
			}
		}
		protected void AddTManual_Click(object sender, EventArgs e)
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
            DateTime vAccreditationExpirationDate= default(DateTime);
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

			#region Saving obj
			var contractor = SP_Contractor.Create(vSPName, vSDATDepartmentId,
				vSPTaxId, vSPFeeStatus,
				vSPMHICNumber, vPublishOnMDEWebsite,
				vSPPhone, "", vSPWebSite, vSPEmail, vAccreditationID, Convert.ToInt32(vCourseCatID),
				vAccreditationExpirationDate
				, int.Parse(vDropIsRenewal), vDropWaiverType, vDropPublicListing
				, vContactFirstName, vContactLastName, vAuthFName, vAuthLName, vAuthTitle, vAgreed);
			_contractorRepository.Add(contractor);
			_uow.Commit();

			#region Add Addresses
			var addressStreet = Contractor_Address.Create(1, vSPAddress_Line_1, vSPCity, vSPState, vSPZipCode, contractor.Id, vDropPublicList == 1 ? vDropPublicList : null);
            _contractorRepository.AddAddress(addressStreet);

            if (vSPAddress_Line_2.Length > 0)
            {
                var addressMailing = Contractor_Address.Create(2, vSPAddress_Line_2, vSPCity2, vSPState2, vSPZipCode2, contractor.Id, vDropPublicList == 2 ? vDropPublicList : null);
                _contractorRepository.AddAddress(addressMailing);
            }
			#endregion

			#region Add Regions
			var regions = new List<string>();
			foreach (var each in _regions)
			{
				var chkRegion = Request.Form["chk_" + each.RegionName] == "on";
				if (chkRegion)
				{
					var region = Contractor_Region.Create(contractor.Id, each.RegionId.Value);
					_contractorRepository.AddRegion(region);
				}
			}
			#endregion

			#region Add Services
			var services = new List<string>();
			foreach (var each in _servicesOffered)
			{
				var chkService = Request.Form["chk_" + each.ServiceOffered] == "on";
				if (chkService)
				{
					var service = Contractor_ServiceOffered.Create(contractor.Id, each.ServiceOfferId.Value);
					_contractorRepository.AddServiceOffered(service);
				}
			}
			#endregion


            if(dropCategory.SelectedItem.Value == "10")
            {
                #region Add Emp for Inspector
                var employees = new Dictionary<int, Instructor>();
                for (int i = 1; i <= 10; i++)
                {
                    if (Request.Form["ctl00$CPMain$InspectorEmpFN_" + i] != null)
                    {
                        int isActive;
                        int.TryParse(Request.Form["ctl00$CPMain$dropIsApplyInspector_" + i], out isActive);
                        var emp = Contractor_EmpList.Create(Request.Form["ctl00$CPMain$InspectorEmpFN_" + i],
                            Request.Form["ctl00$CPMain$InspectorEmpLN_" + i],
                            Request.Form["ctl00$CPMain$InspectorAcctId_" + i],
                            "",
                            contractor.Id,
                            isActive,
                            contractor.ACRDCatID.Value);
                        _contractorRepository.AddEmpList(emp);
                    }

                }
                #endregion
            }
            else if(dropCategory.SelectedItem.Value == "11")
            {
                #region Add Emp Residential
                var employees = new Dictionary<int, Instructor>();
                for (int i = 1; i <= 10; i++)
                {
                    if (Request.Form["ctl00$CPMain$ResidentialEmpFN_" + i] != null)
                    {
                        int isActive;
                        int.TryParse(Request.Form["ctl00$CPMain$dropIsApplyResidential_" + i], out isActive);
                        var emp = Contractor_EmpList.Create(Request.Form["ctl00$CPMain$ResidentialEmpFN_" + i],
                            Request.Form["ctl00$CPMain$ResidentialEmpLN_" + i],
                            Request.Form["ctl00$CPMain$ResidentialAcctId_" + i],
                            "",
                            contractor.Id,
                            isActive,
                            contractor.ACRDCatID.Value);
                        _contractorRepository.AddEmpList(emp);
                    }

                }
                #endregion
            }
            else if(dropCategory.SelectedItem.Value == "12")
            {
                #region Add Emp Steel
                var employees = new Dictionary<int, Instructor>();
                for (int i = 1; i <= 10; i++)
                {
                    if (Request.Form["ctl00$CPMain$SteelEmpFN_" + i] != null)
                    {
                        int isActive;
                        int.TryParse(Request.Form["ctl00$CPMain$dropIsApplySteel_" + i], out isActive);
                        var emp = Contractor_EmpList.Create(Request.Form["ctl00$CPMain$SteelEmpFN_" + i],
                            Request.Form["ctl00$CPMain$SteelEmpLN_" + i],
                            Request.Form["ctl00$CPMain$SteelAcctId_" + i],
                            "",
                            contractor.Id,
                            isActive,
                            contractor.ACRDCatID.Value);
                        _contractorRepository.AddEmpList(emp);
                    }

                }
                #endregion
            }



            var objConUser = LK_Contractor_User.Create(contractor.Id);
			_contractorRepository.AddUser(objConUser);
			_uow.Commit();

            string strBackToForms = objcryptoJS.AES_encrypt("10", AppConstants.secretKey, AppConstants.initVec).ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been submitted successfully!', '', 'success', 'RoleDesc.aspx?Dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strBackToForms) + "');", true);

            #endregion

        }

		protected void GenerateRadio(Panel pnlName, string Title, int Counter, int RegionId)
		{
			string IsRegionId = objcryptoJS.AES_encrypt(RegionId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

			StringBuilder strContent = new StringBuilder("");
			strContent.Append("<div class='col-lg-2'><div class='checkbox-primary form-control m-b' >");
			strContent.Append("<input id='chk_" + Title + "' type='checkbox' name='chk_" + Title + "'>");
			strContent.Append("<label for='chk_" + Title + "' style='font-size:12px; padding-left:5px;padding-bottom:5px'>" + Title + "</label></div></div>");
			pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

		}

		protected void GenerateCheckBox(Panel pnlName, string Title, int Counter, int RegionId)
		{
			string IsRegionId = objcryptoJS.AES_encrypt(RegionId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

			StringBuilder strContent = new StringBuilder("");
			strContent.Append("<div class='col-lg-3'><div class='checkbox-primary form-control m-b' >");
			strContent.Append("<input id='chk_" + Title + "' type='checkbox' name='chk_" + Title + "'>");
			strContent.Append("<label for='chk_" + Title + "' style='font-size:12px; padding-left:5px;padding-bottom:5px'>" + Title + "</label></div></div>");
			pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

		}
	}
}