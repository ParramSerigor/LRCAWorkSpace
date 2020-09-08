using LRCA.classes.DAL;
using LRCA.classes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LRCA.classes.BAL
{
    public class LoginBAL
    {
        CryptoJS objcryptoJS = new CryptoJS();
        public static string _Error = string.Empty;

        public static bool ResetPassword(string strEmail)
        {
            bool isReset = false;
            string strTempPass = string.Empty;
            string HashPassword = string.Empty;
            string HashSalt = string.Empty;
            string strReturn = string.Empty;

            strTempPass = DateTime.Now.Millisecond.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString();
            HashPassword = SecurityObj.SecurityObj.ComputeHash(strTempPass, "SHA1", null);
            HashSalt = SecurityObj.SecurityObj.GetSalt("SHA1", HashPassword);

            List<clsUser> objEmp = new List<clsUser>();
            objEmp = UserDAL.SelectDynamicUser("EmailId = '" + strEmail + "'", "AuthorisedUserId");
            if (objEmp != null)
            {
                if (objEmp.Count > 0)
                {
                    clsUser objEmpSelect = new clsUser();
                    objEmpSelect = UserDAL.SelectUserById(Convert.ToInt32(objEmp[0].AuthorisedUserId));
                    if (objEmpSelect != null)
                    {
                        objEmpSelect.Password = HashPassword;
                        objEmpSelect.TempPassword = strTempPass;
                        objEmpSelect.salt = HashSalt;
                        objEmpSelect.IsActive = 0;
                        if (UserDAL.UpdateUser(objEmpSelect))
                        {
                            isReset = true;
                        }

                        #region Calling API to rest the Password.
                        try
                        {
                            //#region Generating email message with the TEMP Password for the new ADMIN.
                            //StringBuilder strbEmailMSG = new StringBuilder();
                            //strbEmailMSG.Append(objEmpSelect.FName + " " + objEmpSelect.LName + "," + System.Environment.NewLine + System.Environment.NewLine);
                            //strbEmailMSG.Append("LRCA Application created a TEMPORARY PASSWORD for your new account." + System.Environment.NewLine + " Please, use " + objEmpSelect.EmailId + " as your USERNAME and " + objEmpSelect.TempPassword + " as a TEMPORARY PASSWORD to login on the LRCA System." + System.Environment.NewLine);
                            //strbEmailMSG.Append("To access LRCA System please visit " + AppConstants.ConstAppURL + "." + System.Environment.NewLine);
                            //strbEmailMSG.Append(System.Environment.NewLine + System.Environment.NewLine);
                            //strbEmailMSG.Append("If you require any further information, feel free to contact " + AppConstants.ConstHelpPhone + System.Environment.NewLine + " or Email us @" + AppConstants.ConstHelpEmail + System.Environment.NewLine + System.Environment.NewLine);
                            //#endregion

                            //GlobalMethods.SendEmail(objEmpSelect.EmailId, "", strbEmailMSG, "LRCA System Account Reset!");
                            Mailing.SendResetPasswordMail(objEmpSelect.AuthorisedUserId.ToString(), objEmpSelect.EmailId, strTempPass);

                        }
                        catch (Exception ex)
                        {
                            ErrorHandler.ErrorLogging(ex, false);
                            ErrorHandler.ReadError();
                        }
                        #endregion
                    }

                }
            }

            // var objEmpResetPass = JsonConvert.SerializeObject(objEmp);



            return isReset;
        }
        public static bool DisableUsersAccount(clsUser objEmp)
        {
            bool isCreated = false;
            if (UserDAL.UpdateUser(objEmp))
            {
                isCreated = true;
            }

            return isCreated;
        }
        public static bool TempPassReset(string NewPassword)
        {
            bool isReset = false;
            string strTempPass = string.Empty;
            string HashPassword = string.Empty;
            string HashSalt = string.Empty;

            clsUser objUser = new clsUser();
            objUser = UserDAL.SelectUserById(Convert.ToInt32(HttpContext.Current.Session["UserAuthId"].ToString()));
            if (objUser != null)
            {
                HashPassword = SecurityObj.SecurityObj.ComputeHash(NewPassword, "SHA1", null);
                HashSalt = SecurityObj.SecurityObj.GetSalt("SHA1", HashPassword);

                objUser.Password = HashPassword;
                objUser.TempPassword = "NONE";
                objUser.salt = HashSalt;
                objUser.IsActive = 1;
                if (UserDAL.UpdateUser(objUser))
                {
                    //List<clsBranchUser> objB = new List<clsBranchUser>();
                    //objB = BranchUserDAL.SelectDynamicBranchUser("UserId =" + HttpContext.Current.Session["UserId"].ToString() + "", "BranchId");
                    //if (objB != null)
                    //{
                    //    System.Web.HttpContext.Current.Session["BranchId"] = objB[0].BranchId.ToString();
                    //}

                    //System.Web.HttpContext.Current.Session["CompanyType"] = CompanyBAL.GetCompanyType(Convert.ToInt32(objUser.CompanyId));
                    isReset = true;
                }
            }
            return isReset;
        }

        public static string Login(string strEmail, string strPass)
        {
            CryptoJS objcryptoJS = new CryptoJS();
            bool PassCheck = false;
            string _Error = string.Empty;

            clsUser objEmp = new clsUser();

            strEmail = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(strEmail), AppConstants.secretKey, AppConstants.initVec).ToString();
            strPass = objcryptoJS.AES_decrypt(HttpUtility.UrlEncode(strPass), AppConstants.secretKey, AppConstants.initVec).ToString();

            if (GlobalMethods.IsEmail(strEmail))
            {
                List<clsUser> lstUser = new List<clsUser>();
                lstUser = UserDAL.SelectDynamicUser("EmailId like '" + strEmail + "'", "AuthorisedUserId");
                if (lstUser != null)
                {
                    if (lstUser.Count > 0)
                    {
                        PassCheck = SecurityObj.SecurityObj.VerifyHash(strPass, "SHA1", lstUser[0].Password, lstUser[0].salt);
                        if (!PassCheck)
                        {
                            #region The Username or Password is bad!
                            _Error = "Username or Password is not valid!";
                            #endregion
                        }
                        else
                        {
                            #region Creating all the User related sessions.
                                HttpContext.Current.Session["UserAuthId"] = lstUser[0].AuthorisedUserId;
                            if(GlobalMethods.ValueIsNull(lstUser[0].IsAdmin) != null)
                            {
                                if(lstUser[0].IsAdmin == 1)
                                {
                                    HttpContext.Current.Session["IsAdmin"] = "1";
                                }
                            }
                            #endregion


                            #region This is a valid account now transfer to a valid location.
                            if (lstUser[0].IsActive == 1)
                            {
                                if (lstUser[0].EmailId == "admin@lrca.com")
                                {
                                    #region This is when AdminAdmin account is accessed for the first time.
                                  //  HttpContext.Current.Response.Redirect(AppConstants.ConstAppURL + "AdminReset.aspx");
                                    #endregion
                                }
                                else
                                {

                                    clsSignOnLog objSOL = new clsSignOnLog();
                                    objSOL.AuthorisedUserId = lstUser[0].AuthorisedUserId;
                                    objSOL.SignedOn = DateTime.Now;
                                    if (!SignOnLogDAL.InsertSignOnLog(objSOL)) { }

                                    #region This is when everything works as normal. Let the user log's in to the System.
                                    //HttpContext.Current.Response.Redirect(AppConstants.ConstAppURL + "dashboard.aspx?Dash=active");
                                    _Error = AppConstants.ConstAppURL + "dashboard.aspx?Dash=active";
                                    #endregion
                                }
                            }
                            else if (lstUser[0].IsActive == -1)
                            {
                                #region This is when the account is disabled.
                                _Error = "Currently, your account has been disabled. Please, email " + AppConstants.ConstHelpEmail + " or call " + AppConstants.ConstHelpPhone + ".";
                                #endregion
                            }
                            else if (lstUser[0].IsActive == -2)
                            {
                                #region This is where we let the new user create a new password for a first time user.
                                // HttpContext.Current.Response.Redirect(AppConstants.ConstAppURL + "ResetPassword.aspx");
                                _Error = AppConstants.ConstAppURL + "ResetPassword.aspx#login";
                                #endregion
                            }
                            else if (lstUser[0].IsActive == 0)
                            {
                                #region This is when the account is reset if the forgot password.
                                //HttpContext.Current.Response.Redirect(AppConstants.ConstAppURL + "ResetPassword.aspx");
                                _Error = AppConstants.ConstAppURL + "ResetPassword.aspx#login";
                                #endregion
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        #region  The Username or Password is bad!
                        _Error = "Username or Password is not valid!";
                        #endregion
                    }
                }
                else
                {
                    #region  The Username or Password is bad!
                    _Error = "Username or Password is not valid!";
                    #endregion
                }
            }
            else
            {
                #region  The Username or Password is bad!
                _Error = "Username or Password is not valid!";
                #endregion
            }

            return _Error;
        }
        public static bool Registration(string strFName, string strLName, string strEmail)
        {
            bool IsRegistered = false;
            string strTempPass = string.Empty;
            string HashPassword = string.Empty;
            string HashSalt = string.Empty;
            string strReturn = string.Empty;

            try
            {
                strTempPass = DateTime.Now.Millisecond.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString();
                HashPassword = SecurityObj.SecurityObj.ComputeHash(strTempPass, "SHA1", null);
                HashSalt = SecurityObj.SecurityObj.GetSalt("SHA1", HashPassword);

                clsUser objUser = new clsUser();
                objUser.FName = GlobalMethods.stringToMixedCase(strFName);
                objUser.LName = GlobalMethods.stringToMixedCase(strLName);
                objUser.Password = HashPassword;
                objUser.TempPassword = strTempPass;
                objUser.salt = HashSalt;
                objUser.EmailId = strEmail;
                objUser.IsCurrent = 1;
                objUser.IndividualUserID = 0;
                objUser.CreatedDate = DateTime.Now;
                objUser.CreatedBy = GlobalMethods.stringToMixedCase(strFName) + " " + GlobalMethods.stringToMixedCase(strLName);
                objUser.UpdatedDate = Convert.ToDateTime("1/1/1900");
                objUser.UpdatedBy = "";
                objUser.Notes = "";
                objUser.ImageURL = "";
                objUser.IsAdmin = 0;
                objUser.IsActive = -2;
                if (UserDAL.InsertUser(objUser))
                {
                    IsRegistered = true;

                    #region Now sending email with the Temp Password.

                    //System.Text.StringBuilder strbEmailMSG = new StringBuilder();
                    //strbEmailMSG.Append(objUser.FName + " " + objUser.LName + "," + System.Environment.NewLine + System.Environment.NewLine);
                    //strbEmailMSG.Append("LRCA System generated a TEMPORARY PASSWORD For your account." + System.Environment.NewLine + " To access your account enter the following information:" + System.Environment.NewLine + "Username : " + objUser.EmailId + System.Environment.NewLine + "Temporary Password : " + objUser.TempPassword + System.Environment.NewLine);
                    //strbEmailMSG.Append("To access LRCA application please visit " + AppConstants.ConstAppURL + "." + System.Environment.NewLine);
                    //strbEmailMSG.Append(System.Environment.NewLine + System.Environment.NewLine);
                    //strbEmailMSG.Append("If you require any further information, feel free to contact " + AppConstants.ConstHelpPhone + System.Environment.NewLine + " or Email us @" + AppConstants.ConstHelpEmail + System.Environment.NewLine + System.Environment.NewLine);

                    //GlobalMethods.SendEmail(objUser.EmailId, "", strbEmailMSG, "LRCA - New Account Registration");
                    Mailing.SendWelcomeMail(objUser, objUser.EmailId, strTempPass);
                    #endregion
                }
            }
            catch(Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }

            return IsRegistered;
        }
        public static bool RegistrationByRole(string strFName, string strLName, string strEmail, int RoleIdIs, int CreatedById)
        {
            bool IsRegistered = false;
            string strTempPass = string.Empty;
            string HashPassword = string.Empty;
            string HashSalt = string.Empty;
            string strReturn = string.Empty;
            string strRoleIs = string.Empty;
            try
            {
                strTempPass = DateTime.Now.Millisecond.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString();
                HashPassword = SecurityObj.SecurityObj.ComputeHash(strTempPass, "SHA1", null);
                HashSalt = SecurityObj.SecurityObj.GetSalt("SHA1", HashPassword);

                clsUser objUser = new clsUser();
                objUser.FName = GlobalMethods.stringToMixedCase(strFName);
                objUser.LName = GlobalMethods.stringToMixedCase(strLName);
                objUser.Password = HashPassword;
                objUser.TempPassword = strTempPass;
                objUser.salt = HashSalt;
                objUser.EmailId = strEmail;
                objUser.IsCurrent = 1;
                objUser.IndividualUserID = 0;
                objUser.CreatedDate = DateTime.Now;
                objUser.CreatedBy = GlobalMethods.stringToMixedCase(strFName) + " " + GlobalMethods.stringToMixedCase(strLName);
                objUser.UpdatedDate = Convert.ToDateTime("1/1/1900");
                objUser.UpdatedBy = "";
                objUser.Notes = "";
                objUser.ImageURL = "";
                objUser.IsAdmin = 0;
                objUser.IsActive = -2;
                if (UserDAL.InsertUser(objUser))
                {

                    #region First getting the Title of the ROLE the user has been assigned.
                    clsRole objRole = new clsRole();
                    objRole = RoleDAL.SelectRoleById(RoleIdIs);
                    if(objRole != null)
                    {
                        strRoleIs = objRole.RoleDispName;
                    }
                    #endregion

                    #region Now we have a new User lets save the ROLE in USERROLE Table
                    List<clsUser> lstUser = new List<clsUser>();
                    lstUser = UserDAL.SelectDynamicUser("FName = '"+ GlobalMethods.stringToMixedCase(strFName) + "' and LName = '"+ GlobalMethods.stringToMixedCase(strLName) + "' and EmailId = '" + strEmail +"'", "AuthorisedUserId");
                    if(lstUser != null)
                    {
                        if(lstUser.Count > 0)
                        {
                            clsUserRole objURole = new clsUserRole();
                            objURole.RoleId = RoleIdIs;
                            objURole.AuthorizedUserId = lstUser[0].AuthorisedUserId;
                            objURole.IsActive = 1;
                            objURole.CreatedDate = DateTime.Now;
                            objURole.CreatedBy = CreatedById.ToString();
                            objURole.UpdatedBy = "";
                            objURole.UpdatedDate = Convert.ToDateTime("1/1/1900");
                            objURole.Notes = "";
                            if(UserRoleDAL.InsertUserRole(objURole))
                            {
                                IsRegistered = true;

                                #region Now sending email with the Temp Password.

                                System.Text.StringBuilder strbEmailMSG = new StringBuilder();
                                strbEmailMSG.Append(objUser.FName + " " + objUser.LName + "," + System.Environment.NewLine + System.Environment.NewLine);
                                strbEmailMSG.Append("LRCA System created a/an " + strRoleIs + " account with a TEMPORARY PASSWORD." + System.Environment.NewLine + " To access your account enter the following information:" + System.Environment.NewLine + "Username : " + objUser.EmailId + System.Environment.NewLine + "Temporary Password : " + objUser.TempPassword + System.Environment.NewLine);
                                strbEmailMSG.Append("To access LRCA application please visit " + AppConstants.ConstAppURL + "." + System.Environment.NewLine);
                                strbEmailMSG.Append(System.Environment.NewLine + System.Environment.NewLine);
                                strbEmailMSG.Append("If you require any further information, feel free to contact " + AppConstants.ConstHelpPhone + System.Environment.NewLine + " or Email us @" + AppConstants.ConstHelpEmail + System.Environment.NewLine + System.Environment.NewLine);

                                GlobalMethods.SendEmail(objUser.EmailId, "", strbEmailMSG, "LRCA - New Account Registration");
                                #endregion
                            }
                        }
                    }
                    #endregion

                    
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }

            return IsRegistered;
        }
        public static bool CheckEmailExsists(string EmailIn)
        {
            bool IsActive = false;
            List<clsUser> lstUser = new List<clsUser>();
            lstUser = UserDAL.SelectDynamicUser("EmailId = '" + EmailIn +"'", "AuthorisedUserId");
            if(lstUser != null)
            {
                if(lstUser.Count > 0)
                {
                    IsActive = true;
                }
            }
            return IsActive;
        }
    }
}