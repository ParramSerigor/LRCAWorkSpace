using LRCA.classes;
using LRCA.classes.Models;
using LRCA.classes.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
    public partial class AppSupervisor : PageBase
    {
        CryptoJS objcryptoJS = new CryptoJS();
        private readonly ISupervisorRepository _supervisorRepository;
        public AppSupervisor()
        {
            _supervisorRepository = new SupervisorRepository(_context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblDateSigned.Text = DateTime.Now.ToLongDateString();

                #region For Steel Checkboxes.
                var _experience_map_Steel = _supervisorRepository.Form_Experience_Maps(4);
                int i = 0;
                var strContent = new StringBuilder();

                foreach (var each in _experience_map_Steel)
                {
                    if (i % 4 == 0)
                    {
                       var _Experience = _supervisorRepository.Get_Experience(each.ExperienceId.HasValue ? each.ExperienceId.Value : 0);
                        strContent.Append("<div class='row'>");
                        GenerateCheckBox(pnlSteelExperiences, _Experience.ExperienceTitle, _Experience.ExperienceId.HasValue ? _Experience.ExperienceId.Value : 0, each.ExperienceId.HasValue ? each.ExperienceId.Value : 0);
                        if (i == 4)
                        {
                            strContent.Append("</div>");
                        }
                    }
                    else
                    {
                       var _Experience = _supervisorRepository.Get_Experience(each.ExperienceId.HasValue ? each.ExperienceId.Value : 0);
                        GenerateCheckBox(pnlSteelExperiences, _Experience.ExperienceTitle, _Experience.ExperienceId.HasValue ? _Experience.ExperienceId.Value : 0, each.ExperienceId.HasValue ? each.ExperienceId.Value : 0);
                    }
                    i++;
                }
                if (_experience_map_Steel.Count > 0)
                {
                    strContent.Append("</div>");
                    pnlSteelExperiences.Controls.Add(new LiteralControl(strContent.ToString()));
                }
                #endregion

                #region For Removal Checkboxes.
                var _experience_map_Removal = _supervisorRepository.Form_Experience_Maps(6);
                int j = 0;
                var strContentRemoval = new StringBuilder();

                foreach (var each in _experience_map_Removal)
                {
                    if (j % 4 == 0)
                    {
                       var _Experience = _supervisorRepository.Get_Experience(each.ExperienceId.HasValue ? each.ExperienceId.Value : 0);
                        strContentRemoval.Append("<div class='row'>");
                        GenerateCheckBox(pnlRemovalExperiences, _Experience.ExperienceTitle, _Experience.ExperienceId.HasValue ? _Experience.ExperienceId.Value : 0, each.ExperienceId.HasValue ? each.ExperienceId.Value : 0);
                        if (i == 4)
                        {
                            strContentRemoval.Append("</div>");
                        }
                    }
                    else
                    {
                       var _Experience = _supervisorRepository.Get_Experience(each.ExperienceId.HasValue ? each.ExperienceId.Value : 0);
                        GenerateCheckBox(pnlRemovalExperiences, _Experience.ExperienceTitle, _Experience.ExperienceId.HasValue ? _Experience.ExperienceId.Value : 0, each.ExperienceId.HasValue ? each.ExperienceId.Value : 0);
                    }
                    j++;
                }
                if (_experience_map_Removal.Count > 0)
                {
                    strContentRemoval.Append("</div>");
                    pnlRemovalExperiences.Controls.Add(new LiteralControl(strContent.ToString()));
                }
                #endregion

                #region For Repaint Checkboxes.
                var _experience_map_Repaint = _supervisorRepository.Form_Experience_Maps(5);
                int l = 0;
                var strContentRepaint = new StringBuilder();

                foreach (var each in _experience_map_Repaint)
                {
                    if (l % 4 == 0)
                    {
                       var _Experience = _supervisorRepository.Get_Experience(each.ExperienceId.HasValue ? each.ExperienceId.Value : 0);
                        strContentRepaint.Append("<div class='row'>");
                        GenerateCheckBox(pnlRepaintExperiences, _Experience.ExperienceTitle, _Experience.ExperienceId.HasValue ? _Experience.ExperienceId.Value : 0, each.ExperienceId.HasValue ? each.ExperienceId.Value : 0);
                        if (i == 4)
                        {
                            strContentRepaint.Append("</div>");
                        }
                    }
                    else
                    {
                       var _Experience = _supervisorRepository.Get_Experience(each.ExperienceId.HasValue ? each.ExperienceId.Value : 0);
                        GenerateCheckBox(pnlRepaintExperiences, _Experience.ExperienceTitle, _Experience.ExperienceId.HasValue ? _Experience.ExperienceId.Value : 0, each.ExperienceId.HasValue ? each.ExperienceId.Value : 0);
                    }
                    l++;
                }
                if (_experience_map_Repaint.Count > 0)
                {
                    strContentRepaint.Append("</div>");
                    pnlRepaintExperiences.Controls.Add(new LiteralControl(strContent.ToString()));
                }
                #endregion
            }
        }
        protected void AddTManual_Click(object sender, EventArgs e)
        {
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

			var supervisor = Supervisor.Create(vtxtLName, vtxtSuffix, vtxtFName, vtxtMName, vtxtAddress_1, vtxtCity_1, vtxtState_1, vtxtZipCode_1, vtxtAddress_2, vtxtCity_2,
				vtxtState_2, vtxtZipcode_2, vtxtPhone, vtxtEmailAddress, vtxtDOB, vtxtSSNO, vdropIsRenewal, vtxtACCID, 
				vtxtAccreditationExpirationDate, vdropCategory, vtxtConstTradeSteelStartDate, vtxtConstTradeSteelEndDate, 
				vtxtSteelSuperWorkedFor, vtxtThirdPartyRemovalDate, vtxtConstTradeRemovalStartDate, vtxtConstTradeRemovalEndDate, 
				vtxtRemovalSuperWorkedFor, vtxtConstTradeRepaintStartDate, vtxtConstTradeRepaintEndDate, vtxtRepaintSuperWorkedFor, 
				vchkWaiver, vtxtTrainingCardNum, vtxtTrainCExpire, vtxtTrainingProviderName, vtxtCourseName, vtxtCourseStartDate, 
				vtxtCourseEndDate, vtxtContractorName, vtxtContractorAccdNum, vtxtIC_Address_Line_1, vtxtIC_City, vtxtIC_State,
				vtxtIC_Zipcode, vtxtICContactFName, vtxtICContactLName, vtxtICContactPhone, vchkIAgree);
			_supervisorRepository.Add(supervisor);
			_uow.Commit();
			if (vdropCategory == Category.StructuralSteelSupervisor)
			{
				foreach (var each in _supervisorRepository.Form_Experience_Maps(Category.StructuralSteelSupervisor))
				{
					var label = Request.Form["lbl_" + each.Experience.ExperienceTitle];
					var chkRegion = Request.Form["chk_" + each.Experience.ExperienceTitle.Replace(" ","")] == "on";
					if (chkRegion)
					{
						var exp = Supervisor_Experiences.Create(supervisor.Id, each.ExperienceId, label == "Other" ? label : string.Empty);
						_supervisorRepository.AddExperience(exp);
					}
				}
			}
			else if (vdropCategory == Category.RemovalAndDemolition)
			{
				foreach (var each in _supervisorRepository.Form_Experience_Maps(Category.RemovalAndDemolition))
				{
					var label = Request.Form["lbl_" + each.Experience.ExperienceTitle];
					var chkRegion = Request.Form["chk_" + each.Experience.ExperienceTitle.Replace(" ", "")] == "on";
					if (chkRegion)
					{
						var exp = Supervisor_Experiences.Create(supervisor.Id, each.ExperienceId, label == "Other" ? label : string.Empty);
						_supervisorRepository.AddExperience(exp);
					}
				}
			}
			else if (vdropCategory == Category.MaintananceAndRepainting)
			{
				foreach (var each in _supervisorRepository.Form_Experience_Maps(Category.MaintananceAndRepainting))
				{
					var label = Request.Form["lbl_" + each.Experience.ExperienceTitle];
					var chkRegion = Request.Form["chk_" + each.Experience.ExperienceTitle.Replace(" ", "")] == "on";
					if (chkRegion)
					{
						var exp = Supervisor_Experiences.Create(supervisor.Id, each.ExperienceId, label == "Other" ? label : string.Empty);
						_supervisorRepository.AddExperience(exp);
					}
				}
			}
			_uow.Commit();

            string strBackToForms = objcryptoJS.AES_encrypt("10", AppConstants.secretKey, AppConstants.initVec).ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been submitted successfully!', '', 'success', 'RoleDesc.aspx?Dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strBackToForms) + "');", true);
        }
        protected void GenerateCheckBox(Panel pnlName, string Title, int Counter, int RegionId)
        {
            string IsRegionId = objcryptoJS.AES_encrypt(RegionId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();

            StringBuilder strContent = new StringBuilder("");
            strContent.Append("<div class='col-lg-3'><div class='checkbox-primary  m-b' >");
            strContent.Append("<input id='chk_" + Counter + IsRegionId + "' type='checkbox' name='chk_" + Title.Replace(" ","") + "'>");
            strContent.Append("<label for='chk_" + Counter + IsRegionId + "' name='lbl_" + Title + "' style='font-size:12px; padding-left:5px;padding-bottom:5px'>" + Title + "</label></div></div>");
            pnlName.Controls.Add(new LiteralControl(strContent.ToString()));

        }

        [System.Web.Services.WebMethod(EnableSession = false)]
        public void CallCheckBox(int Id)
        {
           
        }
    }
}