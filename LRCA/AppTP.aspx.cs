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

namespace LRCA
{
    public partial class AppTP : PageBase
    {
		private readonly ITPRepository _tPRepository;
        CryptoJS objcryptoJS = new CryptoJS();
		public AppTP()
		{
			_tPRepository = new TPRepository(_context);
		}
        protected void Page_init(object sender, EventArgs e)
        {
            string EmpId = HttpContext.Current.Session["UserAuthId"] == null ? string.Empty : HttpContext.Current.Session["UserAuthId"].ToString();
            if (EmpId.Length == 0)
            {
                GlobalMethods.logout();
            }

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
			var vchkTPwebsiteYES = chkTPwebsiteYES.Checked ? 1 : 0;
			var vtxtTPwebsiteURL = txtTPwebsiteURL.Text;
			var vchkTPwebsiteNO = chkTPwebsiteNO.Checked ? 1 : 0;
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

			var tp = TrainingProvider.Create(vtxtName, vtxtSDATNum, vtxtAddress_1, vtxtCity_1, vtxtState_1, vtxtZipCode_1, vtxtAddress_2, vtxtCity_2, vtxtState_2, vtxtZipcode_2,
				vdropPublicList, vtxtPhone, vtxtFax, vtxtEmailAddress, vtxtEIN, vdropIsRenewal, vtxtACCID, vAccreditationExpirationDate, vchkChargeFee, vchkTaxExempt,
				vtxtTaxExempt, vchkTPwebsiteYES, vtxtTPwebsiteURL, vchkTPwebsiteNO, vchkCORiskAssessor,
				vchkCOProjectDesigner, vchkCOInspectorTech, vchkCOAbatWorkEnglish, vchkCOVisualInspector, vchkCOAbatWorkSpanish, vchkCOMainRepaintSup, vchkCOStructSteelSup,
				vchkCORemovalSup, vchkStructSteelWork, vtxtAuthRepContFName, vtxtAuthRepContLName, vtxtAuthRepContTitle, vchkIAgree);
			_tPRepository.Add(tp);
			_uow.Commit();
			_tPRepository.AddLocation(TP_Location.Create(tp.Id,vtxtLocation_Address_1, vtxtLocation_City_1, vtxtLocation_State_1, vtxtLocation_ZipCode_1));
			_tPRepository.AddLocation(TP_Location.Create(tp.Id, vtxtLocation_Address_2, vtxtLocation_City_2, vtxtLocation_State_2, vtxtLocation_ZipCode_2));
			_tPRepository.AddLocation(TP_Location.Create(tp.Id, vtxtLocation_Address_3, vtxtLocation_City_3, vtxtLocation_State_3, vtxtLocation_ZipCode_3));
			_tPRepository.AddLocation(TP_Location.Create(tp.Id, vtxtLocation_Address_4, vtxtLocation_City_4, vtxtLocation_State_4, vtxtLocation_ZipCode_4));
			_tPRepository.AddLocation(TP_Location.Create(tp.Id, vtxtLocation_Address_5, vtxtLocation_City_5, vtxtLocation_State_5, vtxtLocation_ZipCode_5));
			_tPRepository.AddLocation(TP_Location.Create(tp.Id, vtxtLocation_Address_6, vtxtLocation_City_6, vtxtLocation_State_6, vtxtLocation_ZipCode_6));

			_tPRepository.AddInstrutor(TP_Instructors.Create(tp.Id, vtxtInstructorFN_1, vtxtInstructorLN_1));
			_tPRepository.AddInstrutor(TP_Instructors.Create(tp.Id, vtxtInstructorFN_2, vtxtInstructorLN_2));
			_tPRepository.AddInstrutor(TP_Instructors.Create(tp.Id, vtxtInstructorFN_3, vtxtInstructorLN_3));
			_tPRepository.AddInstrutor(TP_Instructors.Create(tp.Id, vtxtInstructorFN_4, vtxtInstructorLN_4));
			_tPRepository.AddInstrutor(TP_Instructors.Create(tp.Id, vtxtInstructorFN_5, vtxtInstructorLN_5));
			_tPRepository.AddInstrutor(TP_Instructors.Create(tp.Id, vtxtInstructorFN_6, vtxtInstructorLN_6));
			_tPRepository.AddInstrutor(TP_Instructors.Create(tp.Id, vtxtInstructorFN_7, vtxtInstructorLN_7));
			_tPRepository.AddInstrutor(TP_Instructors.Create(tp.Id, vtxtInstructorFN_8, vtxtInstructorLN_8));
			_uow.Commit();

            string strBackToForms = objcryptoJS.AES_encrypt("10", AppConstants.secretKey, AppConstants.initVec).ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been submitted successfully!', '', 'success', 'RoleDesc.aspx?Dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strBackToForms) + "');", true);

        }
    }
}