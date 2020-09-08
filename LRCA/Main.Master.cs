using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
    public partial class Main : System.Web.UI.MasterPage
    {
        CryptoJS objcryptoJS = new CryptoJS();
        public int IdIn = 1;
        public string IsTraineeRoleId = string.Empty;

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
            if (!Page.IsPostBack)
            {
                string CompId = string.Empty;
                string BranchId = string.Empty;
                string BranchName = string.Empty;
                string LstBranchdropdown = string.Empty;
                string SelectBranchdrpdown = string.Empty;
                StringBuilder strAccessRole = new StringBuilder("");
                IsTraineeRoleId = objcryptoJS.AES_encrypt(HttpUtility.UrlEncode("6"), AppConstants.secretKey, AppConstants.initVec).ToString();

                phLogoTop.Controls.Add(new LiteralControl("<a href='dashboard.aspx?Dash=active'><img src='CSSBackEnd/img/logo.png'  width='115%' class='img-responsive' alt='LRCA: LEAD Rental Certification and Accreditation'></a>"));

                clsUser objUser = new clsUser();
                objUser = UserDAL.SelectUserById(Convert.ToInt32(Session["UserAuthId"].ToString()));
                if (objUser != null)
                {
                    if (GlobalMethods.ValueIsNull(objUser.ImageURL).Length > 0)
                    {
                        phProfileImg.Controls.Add(new LiteralControl("<img src='" + objUser.ImageURL.ToString() + "' class='img-circle m-b, img-responsive, center-block' width='70%' alt='" + GlobalMethods.stringToMixedCase(objUser.FName + " " + objUser.LName) + "'>"));
                        lblUserName.Text = "<span>" + GlobalMethods.stringToMixedCase(objUser.FName + " " + objUser.LName) + "</span>";
                    }
                    else
                    {
                        phProfileImg.Controls.Add(new LiteralControl("<img src='CSSBackEnd/img/avatars/profile.jpg' class='img-circle m-b, img-responsive, center-block'  width='70%' alt='" + GlobalMethods.stringToMixedCase(objUser.FName + " " + objUser.LName) + "'>"));
                        lblUserName.Text = "<span>" + GlobalMethods.stringToMixedCase(objUser.FName + " " + objUser.LName) + "</span>";
                    }
                    if(objUser.IsAdmin == 1)
                    {
                        phAdmin.Visible = true;
                        strAccessRole.Append("Administrator");
                    }
                    else
                    {
                        phAdmin.Visible = false;
                    }

                    #region Now getting all the UserRole and making sure buttons are displayed accordingly.
                    List<clsUserRole> lstURole = new List<clsUserRole>();
                    lstURole = UserRoleDAL.SelectDynamicUserRole("AuthorizedUserId = " + objUser.AuthorisedUserId + "", "UserRoleId");
                    if (lstURole != null)
                    {
                        if (lstURole.Count > 0)
                        {
                            for (int i = 0; i < lstURole.Count; i++)
                            {
                                // This is MDE Role
                                if (lstURole[i].RoleId == 1)
                                {
                                    #region This is MDE Role access allowed.
                                    strAccessRole.Append("<br />MDE");
                                    #endregion
                                }
                               
                            }
                        }
                    }
                    #endregion

                    pnRole.Controls.Add(new LiteralControl(strAccessRole.ToString()));
                }
            }
        }
    }
}