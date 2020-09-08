using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using LRCA.classes.Models;
using LRCA.classes.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
	public partial class AppInstructor : PageBase
	{
		private readonly IInstructorRepository _instructorRepository;
		CryptoJS objcryptoJS = new CryptoJS();
		public AppInstructor()
		{
			_instructorRepository = new InstructorRepository(_context);
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
											  String.Format("{0}", SQLHelper.TrimAndReplaceEOF(lstCategory[i].CatTitle.ToString())), String.Format("{0}", SQLHelper.TrimAndReplaceEOF(objcryptoJS.AES_encrypt(lstCategory[i].ACRDCatID.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString()))));

						}
					}
				}
			}
		}
		protected void AddTManual_Click(object sender, EventArgs e)
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
			var vupload_1 = string.Empty;
			var vupload_2 = string.Empty;

			try
			{
				vupload_1 = Path.Combine("uf", uploadNewInstructors.FileName);
				uploadNewInstructors.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_1));
				vupload_2 = Path.Combine("uf", uploadNewInspectorTech.FileName);
				uploadNewInspectorTech.PostedFile.SaveAs(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vupload_2));
				
			}
			catch { }
			var vtxtNewRenewAcctNum = txtNewRenewAcctNum.Text;
			var vtxtNewRenewAcctExpireDate = txtNewRenewAcctExpireDate.Text;
			var vchkIAgree = chkIAgree.Checked ? 1 : 0;
			var vdropIsRenewal = int.Parse(dropIsRenewal.SelectedItem.Value);
            //var vdropInstructCategory = int.Parse(objcryptoJS.AES_decrypt(dropInstructCategory.SelectedItem.Value, AppConstants.secretKey, AppConstants.initVec).ToString());
            var vdropInstructCategory = int.Parse("2");

            var instructor = Instructor.Create(vtxtLName, vtxtSuffix, vtxtFName, vtxtMName, vtxtAddress_1, vtxtCity_1, vtxtState_1, vtxtZipCode_1, vtxtAddress_2, 
				vtxtCity_2, vtxtState_2, vtxtZipcode_2, vtxtPhone, vtxtEmailAddress, vtxtDOB, vtxtSSNO, vtxtInstructTP, vtxtInstructAcctNum, vtxtInstructContFN, 
				vtxtInstructContLN, vtxtInstructContPhone, vtxtInstructContAddress, vtxtInstructContCity, vtxtInstructContState, vtxtInstructContZipcode, vdropIsRenewal, 
				vtxtACCID, vAccreditationExpirationDate, vdropInstructCategory, vtxtNewInitTrainingCard, vtxtNewInitStartDate, vtxtNewInitEndDate, vtxtRenewalTrainingCard, 
				vtxtRenewalStartDate, vtxtRenewalEndDate, vupload_1, vtxtNewRenewAcctNum, vtxtNewRenewAcctExpireDate, vupload_2, vchkIAgree);
			_instructorRepository.Add(instructor);
			_uow.Commit();

            string strBackToForms = objcryptoJS.AES_encrypt("10", AppConstants.secretKey, AppConstants.initVec).ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Application has been submitted successfully!', '', 'success', 'RoleDesc.aspx?Dash=active&cgi=" + System.Web.HttpUtility.UrlEncode(strBackToForms) + "');", true);
        }
	}
}