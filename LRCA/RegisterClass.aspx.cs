using LRCA.classes;
using LRCA.classes.BAL;
using System;
using System.Web.UI;

namespace LRCA
{
    public partial class RegisterClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void OnClick_Back(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx?home=active#login");
        }
        protected void btnReset(object sender, EventArgs e)
        {
            string FName = GlobalMethods.KillChars(txt_FName.Text);
            string LName = GlobalMethods.KillChars(txt_LName.Text);
            string EmailIn = GlobalMethods.KillChars(txt_email.Text);

            if (EmailIn.Length > 0)
            {
                if (LoginBAL.CheckEmailExsists(EmailIn))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('This email address has been used by some other user. Please use another valid email!', '', 'danger', 'RegisterClass.aspx');", true);
                }
                else
                {
                    if (LoginBAL.Registration(FName, LName, EmailIn))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Your Account has been created!', '', 'success', 'RegisterClass.aspx');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Cannot Reset Password!', '', 'danger', 'RegisterClass.aspx');", true);
                    }
                }


            }
        }
    }
}