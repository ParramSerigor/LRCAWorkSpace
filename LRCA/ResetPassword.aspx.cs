using System;
using System.Web;
using System.Web.UI;
using LRCA.classes;
using LRCA.classes.BAL;

namespace LRCA
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        CryptoJS objcryptoJS = new CryptoJS();
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

        }

        protected void btn_signin_Click(object sender, EventArgs e)
        {
            string TempPass = string.Empty;
            string pass_1 = string.Empty;
            string pass_2 = string.Empty;
            string HashPassword = string.Empty;
            string HashSalt = string.Empty;

            TempPass = GlobalMethods.KillChars(txt_TempPass.Text.Trim());
            pass_1 = GlobalMethods.KillChars(txt_Pass_1.Text.Trim());
            pass_2 = GlobalMethods.KillChars(txt_Pass_2.Text.Trim());

            if (pass_1.CompareTo(pass_2) == 0)
            {
                if (LoginBAL.TempPassReset(pass_1))
                {
                    System.Web.HttpContext.Current.Response.Redirect("dashboard.aspx?dash=active");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Cannot Reset Password!', '', 'danger', 'Registration.aspx');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Please re-enter new password again!', '', 'danger', 'Registration.aspx');", true);
            }
        }
    }
}