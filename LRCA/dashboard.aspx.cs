using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;

namespace LRCA
{
    public partial class dashboard : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                bool IsMDE = false;
                #region User and Company Info
                clsUser objEmp = new clsUser();
                objEmp = UserDAL.SelectUserById(Convert.ToInt32(Session["UserAuthId"].ToString()));
               
                #endregion

                #region Getting User Info
                // for side menu. if 3 hide. else show.
                if (objEmp != null)
                {
                    #region Getting UserRole Id to check if the user is Admin
                    List<clsUserRole> lstUserRoleIs = new List<clsUserRole>();
                    lstUserRoleIs = UserRoleDAL.SelectDynamicUserRole("AuthorizedUserId = "+ objEmp.AuthorisedUserId +"", "UserRoleId");
                    if(lstUserRoleIs != null)
                    {
                        if(lstUserRoleIs.Count > 0)
                        {
                            for(int i =0; i < lstUserRoleIs.Count; i++)
                            {
                                if(lstUserRoleIs[i].RoleId == 1)
                                {
                                    IsMDE = true;
                                }
                            }
                        }
                    }
                    #endregion

                    #region getting all the roles boxes.
                    int counter = 1;
                    StringBuilder strAccess = new StringBuilder("");
                    List<clsRole> lstRole = new List<clsRole>();
                    if(IsMDE)
                    {
                        lstRole = RoleDAL.SelectDynamicRole("IsActive = 1", "DisplayOrder");
                    }
                    else
                    {
                        lstRole = RoleDAL.SelectDynamicRole("(IsActive = 1) and (RoleId NOT IN (1))", "DisplayOrder");
                    }
                    
                    if (lstRole != null)
                    {
                        if (lstRole.Count > 0)
                        {
                            StringBuilder strAllRole = new StringBuilder("");

                            for (int i = 0; i < lstRole.Count; i++)
                            {
                                if (counter < 5)
                                {
                                    if (counter == 1)
                                    {
                                        strAllRole.Append("<div class='Row'>");
                                    }
                                    strAllRole.Append("<div class='col-lg-3'>");
                                    strAllRole.Append("<div class='hpanel stats'>");
                                    strAllRole.Append("<div class='panel-body h-200'>");
                                    strAllRole.Append("<div class='stats-title pull-left'><div class='stats-icon pull-left'>");
                                    strAllRole.Append("<i class='" + lstRole[i].RoleIcon + " fa-3x'></i>");
                                    strAllRole.Append("</div><div class='clearfix'></div><h4 class='text-danger' style='font-size:17px'>");
                                    strAllRole.Append(lstRole[i].RoleDispName);
                                    strAllRole.Append("</h4></div><div class='clearfix'></div>");
                                    strAllRole.Append("<div class='flot-chart'>");
                                    if (GlobalMethods.ValueIsNull(lstRole[i].Notes) == "")
                                    {
                                        strAllRole.Append("<small>" + GlobalMethods.ValueIsNull(lstRole[i].Notes) + "</small>");
                                    }
                                    else
                                    {
                                        strAllRole.Append("<small>" + GlobalMethods.ValueIsNull(lstRole[i].Notes).Substring(0, 120) + " ..." + "</small>");
                                    }
                                    strAllRole.Append("</div></div><div class='panel-footer'>");
                                    strAllRole.Append(GettingRoleURL(lstRole[i].RoleId.ToString(), objEmp.AuthorisedUserId.HasValue ? objEmp.AuthorisedUserId.Value : 0 , lstRole[i].RoleName, strAccess));
                                    strAllRole.Append("</div></div></div>");
                                    if (counter == 4)
                                    {
                                        strAllRole.Append("</div>");
                                    }
                                    counter++;
                                }
                                else
                                {
                                    counter = 1;
                                    if (counter == 1)
                                    {
                                        strAllRole.Append("<div class='Row'>");
                                    }
                                    strAllRole.Append("<div class='col-lg-3'>");
                                    strAllRole.Append("<div class='hpanel stats'>");
                                    strAllRole.Append("<div class='panel-body h-200'>");
                                    strAllRole.Append("<div class='stats-title pull-left'><div class='stats-icon pull-left'>");
                                    strAllRole.Append("<i class='" + lstRole[i].RoleIcon + " fa-3x'></i>");
                                    strAllRole.Append("</div><div class='clearfix'></div><h4 class='text-danger' style='font-size:17px'>");
                                    strAllRole.Append(lstRole[i].RoleDispName);
                                    strAllRole.Append("</h4></div><div class='clearfix'></div>");
                                    strAllRole.Append("<div class='flot-chart'>");
                                    if (GlobalMethods.ValueIsNull(lstRole[i].Notes) == "")
                                    {
                                        strAllRole.Append("<small>" + GlobalMethods.ValueIsNull(lstRole[i].Notes) + "</small>");
                                    }
                                    else
                                    {
                                        strAllRole.Append("<small>" + GlobalMethods.ValueIsNull(lstRole[i].Notes).Substring(0, 120) + " ..." + "</small>");
                                    }
                                    strAllRole.Append("</div></div><div class='panel-footer'>");
                                    strAllRole.Append(GettingRoleURL(lstRole[i].RoleId.ToString(), objEmp.AuthorisedUserId.HasValue ? objEmp.AuthorisedUserId.Value : 0, lstRole[i].RoleName, strAccess));
                                    strAllRole.Append("</div></div></div>");
                                    counter++;
                                }
                            }

                            if (lstRole.Count % 2 != 0)
                            {
                                strAllRole.Append("</div>");
                            }


                            pnlAllRole.Controls.Add(new LiteralControl(strAllRole.ToString()));
                        }

                    }
                    #endregion
                }
                #endregion

            }
        }
        protected string GettingRoleURL(string RoleId, int AuthUserId, string RoleDesc, StringBuilder strAccess)
        {
            strAccess.Clear();
            strAccess.Append("<a href='RoleDesc.aspx?Dash=active&cgi=" + objcryptoJS.AES_encrypt(RoleId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString() + "' class='btn btn-xs btn-info' Title='Click to learn more on "+ RoleDesc + "'>Learn More</a>");
        
            List<clsUserRole> lstURole = new List<clsUserRole>();
            lstURole = UserRoleDAL.SelectDynamicUserRole("RoleId = "+ RoleId + " and AuthorizedUserId = " + AuthUserId + "", "UserRoleId");
            if (lstURole != null)
            {
                if (lstURole.Count > 0)
                {
                        // This is MDE Role
                        if (lstURole[0].RoleId == 1)
                        {
                            #region This is MDE Role access allowed.
                            strAccess.Clear();
                            strAccess.Append("<a href='dashboardMDE.aspx?Dash=active' class='btn btn-xs btn-success' alt='Click here to access MDE Module'>Access MDE Module</a>");
                            #endregion
                        }
                        if (lstURole[0].RoleId == 2)
                        {
                            #region This is Training Provider access allowed.
                            strAccess.Clear();
                        strAccess.Append("<a href='RoleDesc.aspx?Dash=active&cgi=" + objcryptoJS.AES_encrypt(lstURole[0].RoleId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString() + "' class='btn btn-xs btn-success' alt='Click here to view Approved Training Provider Applications'>View Training Providers</a>");
                        #endregion
                    }
                        if (lstURole[0].RoleId == 3)
                        {
                            #region This is Instructor access allowed.
                            strAccess.Clear();
                            strAccess.Append("<a href='RoleDesc.aspx?Dash=active&cgi=" + objcryptoJS.AES_encrypt(lstURole[0].RoleId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString() + "' class='btn btn-xs btn-success' alt='Click here to view Approved Instructors.'>View Instructors</a>");
                            #endregion
                        }
                        if (lstURole[0].RoleId == 4)
                        {
                            #region This is Property Owner access allowed.
                            strAccess.Clear();
                            strAccess.Append("<a href='dashboardMDE.aspx?Dash=active' class='btn btn-xs btn-success' alt='Click here to Property Owner'>Property Owner Program</a>");
                            #endregion
                        }
                        if (lstURole[0].RoleId == 5)
                        {
                            #region This is Inspector access allowed.
                            strAccess.Clear();
                            strAccess.Append("<a href='dashboardMDE.aspx?Dash=active' class='btn btn-xs btn-success' alt='Click here to Inspector'>Inspector Program</a>");
                            #endregion
                        }
                        if (lstURole[0].RoleId == 6)
                        {
                            #region This is Trainee access allowed.
                            strAccess.Clear();
                            strAccess.Append("<a href='dashboardMDE.aspx?Dash=active' class='btn btn-xs btn-success' alt='Click here to Trainee'>Trainee Program</a>");
                            #endregion
                        }
                        if (lstURole[0].RoleId == 7)
                        {
                            #region This is Contractor access allowed.
                            strAccess.Clear();
                            strAccess.Append("<a href='RoleDesc.aspx?Dash=active&cgi="+ objcryptoJS.AES_encrypt(lstURole[0].RoleId.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString() + "' class='btn btn-xs btn-success' alt='Click here to view Approved Contractor Applications'>View Contractor</a>");
                            #endregion
                        }
                        if (lstURole[0].RoleId == 8)
                        {
                            #region This is OVERSIGHT PROGRAM access allowed.
                            strAccess.Clear();
                            strAccess.Append("<a href='dashboardMDE.aspx?Dash=active' class='btn btn-xs btn-success' alt='Click here to access OVERSIGHT PROGRAM'>OVERSIGHT PROGRAM Program</a>");
                            #endregion
                        }
                        if (lstURole[0].RoleId == 9)
                        {
                            #region This is CERTIFICATION PROGRAM access allowed.
                            strAccess.Clear();
                            strAccess.Append("<a href='dashboardMDE.aspx?Dash=active' class='btn btn-xs btn-success' alt='Click here to access CERTIFICATION PROGRAM'>CERTIFICATION PROGRAM Program</a>");
                            #endregion
                        }
                    
                }
            }
            return strAccess.ToString();
        }

    }
}