using LRCA.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LRCA
{
    public partial class OnlineHelp : System.Web.UI.Page
    {
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
        protected void btnSave(object sender, EventArgs e)
        {
            int TotalIs = 0;

            string Company, Branch, email, name;
            string HashPassword = string.Empty;
            string HashSalt = string.Empty;
            string strdropPType = string.Empty;
            string strDesc = string.Empty;

            string UserIP = string.Empty; // GetUserIP();


            if (txtDesc.Text.Trim().Length > 0)
            {
               
                //strdropPType = dropPType.SelectedValue;
                //strDesc = objSecurity.KillChars(txtDesc.Text.Trim());

                try
                {
                    //Mailing.SendContactMailITHelp(Company, Branch, strdropPType, name, email, strDesc, UserIP);
                }
                catch (Exception ex)
                {

                }

                //Response.Redirect("Onlinehelp.aspx?help=active&call=");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Request send successfully!', '', 'success', 'Onlinehelp.aspx?help=active');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CallNotify('Error sending email', '', 'danger', 'Onlinehelp.aspx?help=active');", true);
            }

        }
        public string GetUserIP()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return Request.ServerVariables["REMOTE_ADDR"];
        }

    }
}