using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using LRCA.classes.Models;
using LRCA.classes.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
	public partial class AppInspector_RiskAssessor : PageBase
	{
		private readonly IRiskAssessorRepository _riskAssessorRepository;
		CryptoJS objcryptoJS = new CryptoJS();
		public AppInspector_RiskAssessor()
		{
			_riskAssessorRepository = new RiskAssessorRepository(_context);
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				lblDateSigned.Text = DateTime.Now.ToLongDateString();
			}
		}
		protected void AddTManual_Click(object sender, EventArgs e)
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
			var path = Path.Combine("uf", upload.FileName);
			try
			{
				upload.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path));
			}
			catch { }
			var riskAccessor = Inspector_RiskAssessor.Create(vtxtLName, vtxtSuffix, vtxtFName, vtxtMName, vtxtAddress_1, 
				vtxtCity_1, vtxtState_1, vtxtZipCode_1, vtxtAddress_2, vtxtCity_2, vtxtState_2, vtxtZipcode_2, vtxtPhone, 
				vtxtEmailAddress, vtxtDOB.ToByteArray(), vtxtSSNO.ToByteArray(), vtxtACCID, vtxtAccreditationExpirationDate, 
				vtxtThirdPartyInspTechExamDate, vtxtThirdPartyRiskAssExamDate, vtxtMinEx_Start, vtxtMinEx_End, 
				vtxtInTechAccred, vchkWaiver, vtxtTrainingCardNum, vtxtTrainCExpire, vtxtTrainingProviderName, 
				vtxtCourseName, vtxtCourseStartDate, vtxtCourseEndDate, vtxtContractorName, vtxtContractorAccdNum, 
				vtxtIC_Address_Line_1, vtxtIC_City, vtxtIC_State, vtxtIC_Zipcode, vtxtICContactFName, vtxtICContactLName, 
				vtxtICContactPhone, vchkIAgree, vdropIsRenewal, vdropCategory, path);
			_riskAssessorRepository.Add(riskAccessor);
			_uow.Commit();
            #endregion

            string strBackToForms = objcryptoJS.AES_encrypt("10", AppConstants.secretKey, AppConstants.initVec).ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been submitted successfully!', '', 'success', 'RoleDesc.aspx?Dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strBackToForms) + "');", true);
        }

	}
}