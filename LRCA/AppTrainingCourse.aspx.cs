using LRCA.classes;
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
    public partial class AppTrainingCourse : PageBase
    {
        CryptoJS objcryptoJS = new CryptoJS();
        private readonly ITCRepository  _iTCRepository;
		public AppTrainingCourse()
		{
			_iTCRepository = new TCRepository(_context);
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
			var vupload_1 = string.Empty;
			var vupload_2 = string.Empty;
			var vupload_3 = string.Empty;
			var vupload_4 = string.Empty;
			var vupload_5 = string.Empty;
			
			try
			{
				vupload_1 = Path.Combine("uf", upload_1.FileName);
				upload_1.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_1));
				vupload_2 = Path.Combine("uf", upload_2.FileName);
				upload_2.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_2));
				vupload_3 = Path.Combine("uf", upload_3.FileName);
				upload_3.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_3));
				vupload_4 = Path.Combine("uf", upload_4.FileName);
				upload_4.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_4));
				vupload_5 = Path.Combine("uf", upload_5.FileName);
				upload_5.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_5));
			}
			catch { }
			
			var vtxtAuthRepContFName = txtAuthRepContFName.Text;
			var vtxtAuthRepContLName = txtAuthRepContLName.Text;
			var vtxtAuthRepContTitle = txtAuthRepContTitle.Text;
			var vchkIAgree = chkIAgree.Checked ? 1 : 0;
			var vdropIsRenewal = dropIsRenewal.SelectedItem.Value;

			var tc = TrainingCourse.Create(vtxtTPName, vtxtAddress_1, vtxtCity_1, vtxtState_1, vtxtZipCode_1, vtxtAddress_2, vtxtCity_2, vtxtState_2, vtxtZipcode_2, vtxtPhone, 
				vtxtFax, vtxtEmailAddress, vtxtSSN, vdropIsRenewal, vtxtACCID, vtxtAccreditationExpirationDate, vchkRiskAssessor, vchkInspectorTech, vchkVisualInspector, 
				vchkMainRepaint, vchkRemoval, vchkProjectDesign, vchkAbatmentEnglish, vchkAbatmentSpanish, vchkStructSteelSuper, vchkStructSteelWorker, vupload_1, 
				vupload_2, vupload_3, vupload_4, vupload_5, vtxtAuthRepContFName, vtxtAuthRepContLName, vtxtAuthRepContTitle, vchkIAgree);
			_iTCRepository.Add(tc);

			_uow.Commit();

            string strBackToForms = objcryptoJS.AES_encrypt("10", AppConstants.secretKey, AppConstants.initVec).ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been submitted successfully!', '', 'success', 'RoleDesc.aspx?Dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strBackToForms) + "');", true);
        }
	}
}