using System;
using System.Collections.Generic;
using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;

namespace LRCA.CSSBackEnd.ajax.notify
{
    public partial class Notices : System.Web.UI.Page
    {
        CryptoJS objcryptoJS = new CryptoJS();
        protected void Page_init(object sender, EventArgs e)
        {
            if (Session["EmployeeId"] == null)
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("default.aspx?home=active#login");
            }

        }
        protected bool IsAdminOrManager()
        {
            bool returnVal = false;


            if (Session["IsAdmin"].ToString() == "1" || Session["IsManager"].ToString() == "2")
            {
                returnVal = true;
            }

            return returnVal;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CompId = string.Empty;
                string BranchId = string.Empty;
                string strStart = "<ul class='notification-body'>";
                string strBody = string.Empty;

                CompId = System.Web.HttpContext.Current.Session["CCompanyId"].ToString();
                BranchId = System.Web.HttpContext.Current.Session["BranchId"].ToString();
                //clsEmployee objEmp = new clsEmployee();
                //objEmp = EmployeeDAL.SelectEmployeeById(Convert.ToInt32(Session["EmployeeId"].ToString()));
                //if (objEmp != null)
                //{
                //    CompId = objEmp.CompanyId.ToString();
                //}
                //BranchId = System.Web.HttpContext.Current.Session["BranchId"].ToString();

                List<clsNotice> lstEMailNotices = new List<clsNotice>();
                lstEMailNotices = NoticeDAL.SelectDynamicNotice("(CompanyId = " + CompId + ") AND (BranchId = " + BranchId + ") AND (NoticeType = 'Notice')", "NoticeId Desc");

                if (lstEMailNotices != null)
                {
                    if (lstEMailNotices.Count > 0)
                    {
                        for (int i = 0; i < lstEMailNotices.Count; i++)
                        {
                            if (lstEMailNotices[i].Message.Trim().Length > 30)
                            {
                                strBody = "<li><span class='unread'><a href='DisplayNotices.aspx?dnotice=active' ><time>" + lstEMailNotices[i].NoticeDate + "</time><span class='subject'>" + lstEMailNotices[i].Title.Trim() + "</span><span class='msg-body'>" + lstEMailNotices[i].Message.Trim().Substring(1, 30) + "...</span></a></span></li>" + strBody;
                            }
                            else
                            {
                                strBody = "<li><span class='unread'><a href='DisplayNotices.aspx?dnotice=active'><time>" + lstEMailNotices[i].NoticeDate + "</time><span class='subject'>" + lstEMailNotices[i].Title.Trim() + "</span><span class='msg-body'>" + lstEMailNotices[i].Message.Trim() + "...</span></a></span></li>" + strBody;
                            }
                        }
                    }
                }
                
                if (strBody.Length == 0)
                {
                    strBody = "<li><span class='unread'><time>-</time><span class='subject'>-</span><span class='msg-body'></span></span></li>";
                }

                Response.Write(strStart + strBody + "</ul>");
            }
        }
    }
}