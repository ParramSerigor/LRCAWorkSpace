using LRCA.classes;
using LRCA.classes.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
    public partial class repassword : System.Web.UI.Page
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
            string UserId = GlobalMethods.KillChars(txt_email.Text);
            if (UserId.Length > 0)
            {
                if (LoginBAL.ResetPassword(UserId))
                {
                    txt_email.Text = "";
                    //lblerror.CssClass = "alert alert-success";
                    //lblerror.Text = "Your password has been reset!";
                    //lblerror.Text = "<div  class='alert alert-success fade in' style='font-size:14px;'><button data-dismiss='alert' class='close' type='button'>×</button>Your password has been reset!</div>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('YOUR PASSWORD HAS BEEN RESET!', '', 'success', 'repassword.aspx');", true);
                }
                else
                {
                    txt_email.Text = "";
                    //lblerror.CssClass = "alert alert-danger";
                    //lblerror.Text = "Not a registered email address!";
                    //lblerror.Text = "Not a registered email address!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('NOT A REGISTERED EMAIL!', '', 'danger', 'repassword.aspx');", true);
                }

            }
        }
    }
}