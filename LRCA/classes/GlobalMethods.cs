using System;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using LRCA.classes;
using LRCA.classes.DAL;
using LRCA.classes.Entity;
using LRCA.classes.Models;
using LRCA.classes.Repositories;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

namespace LRCA.classes
{
    public class GlobalMethods
    {
        public static bool IsValidPassword(string passwords)
        {
            bool IsValid = false;

            String[] arrPassword = { passwords };
            foreach (string s in arrPassword)
            {

                Match password = Regex.Match(s, @"^(?=.*[a-z])(?=.*?[@'#.$;%^&+=!()*,-/:<>?])(?=.*[0-9]).{6,15}$", RegexOptions.IgnorePatternWhitespace);

                if (password.Success)
                {
                    IsValid = true;
                }
            }
            return IsValid;
        }
        public static string CheckByRegex(string inputStr, string TypeOfFunction)
        {
            try
            {
                if (TypeOfFunction == "Name")
                {
                    RegexStringValidator regName = new RegexStringValidator(@"^[a-zA-Z''-'\s]{1,40}$");
                    regName.Validate(inputStr);

                }
                else if (TypeOfFunction == "SSN")
                {
                    RegexStringValidator regSSN = new RegexStringValidator(@"^\d{3}-\d{2}-\d{4}$");
                    regSSN.Validate(inputStr);
                }
                else if (TypeOfFunction == "Phone")
                {
                    RegexStringValidator regPhone = new RegexStringValidator(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$");
                    regPhone.Validate(inputStr);
                }
                else if (TypeOfFunction == "Email")
                {
                    RegexStringValidator regEmail = new RegexStringValidator(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
                    regEmail.Validate(inputStr);

                }
                else if (TypeOfFunction == "URL")
                {
                    RegexStringValidator regURL = new RegexStringValidator(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$");
                    regURL.Validate(inputStr);
                }
                else if (TypeOfFunction == "Password")
                {
                    RegexStringValidator regPassword = new RegexStringValidator(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$");
                    regPassword.Validate(inputStr);
                }
                else if (TypeOfFunction == "integer") // Non negative Integers
                {
                    RegexStringValidator regPInteger = new RegexStringValidator(@"^\d+$");
                    regPInteger.Validate(inputStr);
                }
                else if (TypeOfFunction == "Currency") // Non negative Currency
                {
                    RegexStringValidator regCurrency = new RegexStringValidator(@"^\d+(\.\d\d)?$");
                    regCurrency.Validate(inputStr);
                }
                else if (TypeOfFunction == "CurrencyPN") // Both positive and negative Currency
                {
                    RegexStringValidator regCurrencyPN = new RegexStringValidator(@"^(-)?\d+(\.\d\d)?$");
                    regCurrencyPN.Validate(inputStr);
                }
                return inputStr;
            }
            catch (ArgumentException)
            {
                //return e.Message.ToString();
                return "false";
            }
        }
        public static string SafeSqlLiteral(string inputSQL)
        {
            if (!String.IsNullOrEmpty(inputSQL))
            {
                if (inputSQL.Contains("'"))
                {
                    return inputSQL.Replace("'", "''");
                }
                else if (inputSQL.Contains("&"))
                {
                    return inputSQL.Replace("&", "&&");
                }
                else
                {
                    return inputSQL;
                }
            }
            else
            {
                return inputSQL;
            }

        }
        public static string NumberGenerator(int HowManyChars)
        {
            string strReturnVal = "";

            Random rng = new Random();
            for (int i = 0; i < HowManyChars; i++)
            {
                strReturnVal = rng.Next(1, 10) + strReturnVal;
            }
            return strReturnVal;
        }
        public static string KillChars(string StrWords)
        {
            string NewChars = "";
            string ValSelect = "select";
            string ValDrop = "drop";
            string ValInsert = "insert";
            string ValDelete = "delete";
            string ValXp = "xp_";
            string ValDashes = "--";
            string ValSemi = ";";

            string[] arrBadChars = { "select", "drop", ";", "--", "insert", "delete", "xp_" };

            if (!String.IsNullOrEmpty(StrWords))
            {
                if (StrWords.Contains(ValDrop))
                {
                    NewChars = StrWords.Replace(ValDrop, "");
                }
                else if (StrWords.Contains(ValSelect))
                {
                    NewChars = StrWords.Replace(ValSelect, "");
                }
                else if (StrWords.Contains(ValInsert))
                {
                    NewChars = StrWords.Replace(ValInsert, "");
                }
                else if (StrWords.Contains(ValDelete))
                {
                    NewChars = StrWords.Replace(ValDelete, "");
                }
                else if (StrWords.Contains(ValXp))
                {
                    NewChars = StrWords.Replace(ValXp, "");
                }
                else if (StrWords.Contains(ValDashes))
                {
                    NewChars = StrWords.Replace(ValDashes, "");
                }
                else if (StrWords.Contains(ValSemi))
                {
                    NewChars = StrWords.Replace(ValSemi, "");
                }
                else
                {
                    NewChars = StrWords;
                }
                return NewChars;
            }
            else
            {
                return StrWords;
            }
        }
        public static bool IsDate(String strToCheck)
        {
            DateTime showDate;
            bool isValid = DateTime.TryParse(strToCheck, out showDate);
            return isValid;
        }
        public static bool IsEmail(string Email)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Email))
                return (true);
            else
                return (false);
        }
        public static bool IsUrl(string Url)
        {
            string strRegex = "^(https?://)"
            + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@
            + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
            + "|" // allows either IP or domain
            + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
            + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // second level domain
            + "[a-z]{2,6})" // first level domain- .com or .museum
            + "(:[0-9]{1,4})?" // port number- :80
            + "((/?)|" // a slash isn't required if there is no file name
            + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(Url))
                return (true);
            else
                return (false);
        }
        public static void SendEmail(string SendTo, string EmailFrom, StringBuilder EmailBody, string EmailSubject)
        {
            string EmailText = string.Empty;
            
            #region Sending Email
           
                MailMessage objEmail = new MailMessage();
                objEmail.To.Add(SendTo);
                if (EmailFrom.Length == 0)
                {
                    objEmail.From = new MailAddress("DO NOT REPLY <" + AppConstants.ConstEmail + ">");
                }
                else
                {
                    objEmail.From = new MailAddress("DO NOT REPLY <" + EmailFrom + ">");
                }
                
                objEmail.Body = EmailBody.ToString();
                objEmail.Subject = EmailSubject ;
                try
                {
                    SmtpClient smtClient = new SmtpClient(AppConstants.ConstSMTP_PRIMARY);
                    smtClient.Send(objEmail);
                }
                catch (Exception)
                {
                    try
                    {
                        SmtpClient smtClient = new SmtpClient(AppConstants.ConstSMTP_SECONDARY);
                        smtClient.Send(objEmail);
                    }
                    catch (Exception exx)
                    {
                        Console.WriteLine(exx.Message);
                    }
                }
           
            #endregion

        }
        public static void logout()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Redirect("default.aspx#login");
        }
        public static string AcctStatus(int StatusIn)
        {
            string strStatusIs = string.Empty;

            if (StatusIn == 1)
            {
                strStatusIs = "Active";
            }
            else if (StatusIn == -1)
            {
                strStatusIs = "Deactivate";
            }
            else if (StatusIn == 0)
            {
                strStatusIs = "Reset";
            }
            else if (StatusIn == -2)
            {
                strStatusIs = "New Account";
            }

                return strStatusIs;
        }
        public static string EmpStatus(int StatusIn)
        {
            string strStatusIs = string.Empty;

            if (StatusIn == 1)
            {
                strStatusIs = "Active";
            }
            else if (StatusIn == -1)
            {
                strStatusIs = "Deactivated";
            }
            else if (StatusIn == 0)
            {
                strStatusIs = "Password Reset";
            }
            else if (StatusIn == -2)
            {
                strStatusIs = "Never Logged-In";
            }

            return strStatusIs;
        }
        public static string LoginErrorMsg(string Title, string Msg)
        {
            StringBuilder myString = new StringBuilder("");
            myString.Append("");
            myString.Append("");
            myString.Append("<h5>");
            myString.Append("<i class='fa fa-exclamation-triangle text-danger'></i>&nbsp;");
            myString.Append(Title);
            myString.Append("</h5>");
            myString.Append("");
            myString.Append("<p style='font - size:12px'><small>");
            myString.Append(Msg);
            myString.Append("</small>");
            myString.Append("</p>");
            myString.Append("");

            return myString.ToString();
        }
        public static string stringToMixedCase(string strInput)
        {
            int intStrLen = 0;
            string strOutput = "";
            string strChar = "";

            try
            {
                intStrLen = strInput.Length;

                if (intStrLen > 0)
                {
                    for (int i = 0; i < intStrLen; i++)
                    {
                        strChar = strInput.Substring(i, 1);
                        if (i == 0)
                        {
                            strChar = strChar.ToUpper();
                        }
                        else
                        {
                            strChar = strChar.ToLower();

                            if (i >= 3)
                            {
                                if (strInput.Substring(i - 3, 3) == " O'")
                                {
                                    strChar = strChar.ToUpper();
                                }
                            }
                            if (i >= 2)
                            {
                                if (strInput.Substring(i - 2, 2) == "MC")
                                {
                                    strChar = strChar.ToUpper();
                                }
                            }
                            if ((strInput.Substring(i - 1, 1) == " ") || (strInput.Substring(i - 1, 1) == "-"))
                            {
                                //checks if previous character was a space
                                strChar = strChar.ToUpper();
                            }
                        }

                        strOutput += strChar;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error has occured when attempting to convert the text to mixed case.  Error: " + ex.Message);
            }
            return strOutput;
        }
        public static string ReturnHours(string Hours)
        {
            string returnHrs = "";
            TimeSpan TotalOut;
            TimeSpan singleHr;
            TimeSpan mins;
            TimeSpan EightHrs = new TimeSpan(08, 00, 00);
            string minsall = "";
            if (Hours.IndexOf(".") > 0)
            {
                TotalOut = TimeSpan.FromHours(Convert.ToDouble(Hours.Substring(0, Hours.IndexOf("."))));
                minsall = Hours.Substring(Hours.IndexOf("."));
                minsall = minsall.Replace(".", "");
                if (minsall.Length == 1)
                {
                    minsall = minsall + "0";
                }
                if (minsall.Length == 0)
                {
                    minsall = "00";
                }
                mins = TimeSpan.FromMinutes(Convert.ToDouble(minsall));
                singleHr = (TotalOut.Add(mins));
                returnHrs = string.Format("{0}.{1}", (int)singleHr.TotalHours, singleHr.Minutes);
            }

            return returnHrs;
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public static string javaCall(string Msg, string MsgType, string MsgTime)
        {
            string strMsgT = "";

            if (MsgType == "success")
            {
                strMsgT = "alert alert-success fade in";
            }
            else if (MsgType == "error")
            {
                strMsgT = "alert alert-danger fade in";
            }
            else if (MsgType == "warning")
            {
                strMsgT = "alert alert-warning fade in";
            }
            else if (MsgType == "info")
            {
                strMsgT = "alert alert-info fade in";
            }

            return "<div  class='" + strMsgT + "' style='font-size:10px;'>" + Msg + "</div>";
        }
        public static string GetUserIP()
        {
            string ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        public static string strBusinessType(string IsType)
        {
            string strBusType = string.Empty;

            if (IsType == "1")
            {
                strBusType = "Restaurant";
            }
            else
            {
                strBusType = "Summer Camp";
            }
            return strBusType;
        }
        public static string IsActive(string IsAcitveId)
        {
            string strBusType = string.Empty;

            if (IsAcitveId == "1")
            {
                strBusType = "Active";
            }
            else
            {
                strBusType = "In-Active";
            }
            return strBusType;
        }
        public static Boolean IsInteger(int IntIn)
        {
            Boolean IsInt = false;
            
            if (IntIn.GetType() == typeof(int))
            {
                IsInt = true;
            }
            return IsInt;
        }
        public static string ValueIsNull(dynamic ValueIn)
        {
            string Valueout = string.Empty;

            try
            {
                Valueout = ValueIn == null ? "" : ValueIn.ToString();
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }

            return Valueout;
        }
        /// <summary>
        /// Send SQL where you are getting total Number of duplicate values.
        /// </summary>
        /// <param name="strSQL">e.g. SELECT AuthorisedUserId FROM Users WHERE(EmailId = 'someEmail') </param>
        /// <returns></returns>
        public static bool IsDuplicate(string strSQL)
        {
            bool IsDup = false;
            dynamic lstValues;
           
            var objPar = new DynamicParameters();
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    lstValues = db.Query<dynamic>(strSQL, objPar, commandType: CommandType.Text).ToList();
                    if (lstValues != null)
                    {
                        if (lstValues.Count > 0)
                        {
                            IsDup = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }

            return IsDup;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StatusVal"></param>
        /// <param name="TypeDisplay">badge for small badge, bar for div bar</param>
        /// <returns></returns>
        public static string ContractorAppStatus(int StatusVal,string TypeDisplay, string URLIn)
        {
            string strStatusIs = string.Empty;

            if(TypeDisplay == "badge")
            {
                switch (StatusVal)
                {
                    case 4:
                        strStatusIs = "<span class='badge badge-info'>In Progress</span>";
                        break;
                    case 1:
                        strStatusIs = "<span class='badge badge-success'>Approved</span>";
                        break;
                    case 2:
                        strStatusIs = "<span class='badge badge-warning'>On Hold</span>";
                        break;
                    case 3:
                        strStatusIs = "<span class='badge badge-warning'>Deficient</span>";
                        break;
                    case 0:
                        strStatusIs = "<span class='badge badge-danger'>Rejected</span>";
                        break;
                }
            }
            else if(TypeDisplay == "bar")
            {
                switch (StatusVal)
                {
                    case 4:
                        if(URLIn.Length > 0)
                        {
                            strStatusIs = "<a href='"+ URLIn +"'  class='btn btn-primary'>Back</a></div><div class='alert alert-info' style='padding:8px !important;'><b>Application In Progress</b></div>";
                        }
                        else
                        {
                            strStatusIs = "<a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a></div><div class='alert alert-info' style='padding:8px !important;'><b>Application In Progress</b></div>";
                        }
                        break;
                    case 1:
                        if (URLIn.Length > 0)
                        {
                            strStatusIs = "<a href='"+ URLIn +"'  class='btn btn-primary'>Back</a></div><div class='alert alert-success' style='padding:8px !important;'><b>Application Approved</b></div>";
                        }
                        else
                        {
                            strStatusIs = "<a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a></div><div class='alert alert-success' style='padding:8px !important;'><b>Application Approved</b></div>";
                        }
                        break;
                    case 2:
                        if (URLIn.Length > 0)
                        {
                            strStatusIs = "<a href='"+ URLIn +"' class='btn btn-primary'>Back</a></div><div class='alert alert-warning' style='padding:8px !important;'><b>Application On Hold</b></div>";
                        }
                        else
                        {
                            strStatusIs = "<a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a></div><div class='alert alert-warning' style='padding:8px !important;'><b>Application On Hold</b></div>";
                        }
                        break;
                    case 3:
                        if (URLIn.Length > 0)
                        {
                            strStatusIs = "<a href='" + URLIn + "' class='btn btn-primary'>Back</a></div><div class='alert alert-warning' style='padding:8px !important;'><b>Application Deficient</b></div>";
                        }
                        else
                        {
                            strStatusIs = "<a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a></div><div class='alert alert-warning' style='padding:8px !important;'><b>Application Deficient</b></div>";
                        }
                        break;
                    case 0:
                        if (URLIn.Length > 0)
                        {
                            strStatusIs = "<a href='"+ URLIn + "' class='btn btn-primary'>Back</a></div><div class='alert alert-danger' style='padding:8px !important;'><b>Application Rejected</b></div>";
                        }
                        else
                        {
                            strStatusIs = "<a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a></div><div class='alert alert-danger' style='padding:8px !important;'><b>Application Rejected</b></div>";
                        }                            
                        break;
                    case 9:
                        if (URLIn.Length > 0)
                        {
                            strStatusIs = "<a href='" + URLIn + "' class='btn btn-primary'>Back</a></div><div class='alert alert-success' style='padding:8px !important;'><b>&nbsp;</b></div>";
                        }
                        else
                        {
                            strStatusIs = "<a href='#' onclick='return history.back();' class='btn btn-primary'>Back</a></div><div class='alert alert-success' style='padding:8px !important;'><b>&nbsp;</b></div>";
                        }
                        break;
                }
            }

            return strStatusIs;
        }

        public static void DisableControls(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                DisableControls(c);
                if (c is DropDownList)
                {
                    ((DropDownList)(c)).Enabled = false;
                }
                if (c is TextBox)
                {
                    ((TextBox)(c)).CssClass = "form-control";
                    ((TextBox)(c)).Enabled = false;
                }
                if (c is CheckBox)
                {
                    ((CheckBox)(c)).Enabled = false;
                }

            }
        }
        public static void EnableControls(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                DisableControls(c);
                if (c is DropDownList)
                {
                    ((DropDownList)(c)).Enabled = true;
                }
                if (c is TextBox)
                {
                    ((TextBox)(c)).CssClass = "form-control";
                    ((TextBox)(c)).Enabled = true;
                }
                if (c is CheckBox)
                {
                    ((CheckBox)(c)).Enabled = true;
                }

            }
        }
        public static void EnableControl_TextBoxByID(TextBox txtId)
        {
            ((TextBox)(txtId)).CssClass = "form-control";
            ((TextBox)(txtId)).Enabled = true;
        }
        public static void DisableControl_TextBoxByID(TextBox txtId)
        {
            ((TextBox)(txtId)).Enabled = false;
        }
        public static void DisableControl_CheckBoxByID(CheckBox chkId)
        {
            ((CheckBox)(chkId)).Enabled = false;
        }
        public static void DisableControl_DropDownByID(DropDownList dropId)
        {
            ((DropDownList)(dropId)).Enabled = false;
        }
        public static string AppStatus(int StatusVal)
        {
            string strStatusIs = string.Empty;

                switch (StatusVal)
                {
                    case 4:
                        strStatusIs = "<span class='badge badge-info'>In Progress</span>";
                        break;
                    case 1:
                        strStatusIs = "<span class='badge badge-success'>Approved</span>";
                        break;
                    case 2:
                        strStatusIs = "<span class='badge badge-warning'>On Hold</span>";
                        break;
                    case 3:
                        strStatusIs = "<span class='badge badge-warning'>Deficient</span>";
                        break;
                    case 0:
                        strStatusIs = "<span class='badge badge-danger'>Rejected</span>";
                        break;
                }

            return strStatusIs;
        }
        public static string Messenger(string Name, string DateTimeIn, string Message)
        {
            StringBuilder strMessenger = new StringBuilder("<div class='chat-message'>");
            strMessenger.Append("<div class='message'>");
            strMessenger.Append("<a class='message-author' href='#'>"+ Name + " </a>");
            strMessenger.Append("<span class='message-date'>  "+ DateTimeIn +" </span>");
            strMessenger.Append("<span class='message-content'>");
            strMessenger.Append(Message);
            strMessenger.Append("</span>");
            strMessenger.Append("</div></div>");
            
            return strMessenger.ToString();
        }
        public static string UploadedFiles(string Name, string DateTimeIn, string Message)
        {
            StringBuilder strMessenger = new StringBuilder("<div class='chat-message'>");
            strMessenger.Append("<div class='message'>");
            strMessenger.Append("<a class='message-author' href='#'>" + Name + " </a>");
            strMessenger.Append("<span class='message-date'>  " + DateTimeIn + " </span>");
            strMessenger.Append("<span class='message-content'>");
            strMessenger.Append("<a href=\""+ Message + "\" target='_blank'>View Attachment</a>");
            strMessenger.Append("</span>");
            strMessenger.Append("</div></div>");
            
            return strMessenger.ToString();
        }

        public static void SDATVerify(TextBox txtBoxId, string SDATNumber)
        {
            List<clsLK_SDAT> lstSDAT = new List<clsLK_SDAT>();
            lstSDAT = LK_SDATDAL.SelectDynamicLK_SDAT("SDATNumber = '" + SDATNumber + "'", "SDATInfoId");
            if (lstSDAT != null)
            {
                if (lstSDAT.Count > 0)
                {
                    ((TextBox)(txtBoxId)).Style.Add("border-color", "#74d348 !important");
                    //  ((TextBox)(txtBoxId)).Enabled = false;
                }
                else
                {
                    ((TextBox)(txtBoxId)).Style.Add("border-color", "#ea6557 !important");
                    //((TextBox)(txtBoxId)).Enabled = true;
                }
            }

        }
        public static void TAXIDVerify(TextBox txtBoxId, string TaxId)
        {
            List<clsLK_SDAT> lstSDAT = new List<clsLK_SDAT>();
            lstSDAT = LK_SDATDAL.SelectDynamicLK_SDAT("TaxId = '" + TaxId + "'", "SDATInfoId");
            if (lstSDAT != null)
            {
                if (lstSDAT.Count > 0)
                {
                    ((TextBox)(txtBoxId)).Style.Add("border-color", "#74d348 !important");
                    //  ((TextBox)(txtBoxId)).Enabled = false;
                }
                else
                {
                    ((TextBox)(txtBoxId)).Style.Add("border-color", "#ea6557 !important");
                    //((TextBox)(txtBoxId)).Enabled = true;
                }
            }

        }
        public static void AccreditationNumVerify(TextBox txtBoxId, string AcctNumber)
        {
            List<clsAccreditations> lstAccd = new List<clsAccreditations>();
            lstAccd = AccreditationsDAL.SelectDynamicAccreditations("AccreditationId = '" + AcctNumber + "'", "AccreditationId");
            if (lstAccd != null)
            {
                if (lstAccd.Count > 0)
                {
                    ((TextBox)(txtBoxId)).Style.Add("border-color", "#74d348 !important");
                    //  ((TextBox)(txtBoxId)).Enabled = false;
                }
                else
                {
                    ((TextBox)(txtBoxId)).Style.Add("border-color", "#ea6557 !important");
                    //((TextBox)(txtBoxId)).Enabled = true;
                }
            }
        }
        public static void AccreditationExpireDateVerify(TextBox txtBoxId, string AcctNumber, DateTime DateIn)
        {
            List<clsAccreditations> lstAccd = new List<clsAccreditations>();
            lstAccd = AccreditationsDAL.SelectDynamicAccreditations("AccreditationId = '" + AcctNumber + "'", "AccreditationId");
            if (lstAccd != null)
            {
                if (lstAccd.Count > 0)
                {
                    if(lstAccd[0].ExpirationDate == DateIn)
                    {
                        ((TextBox)(txtBoxId)).Style.Add("border-color", "#74d348 !important");
                        //  ((TextBox)(txtBoxId)).Enabled = false;
                    }
                    else
                    {
                        ((TextBox)(txtBoxId)).Style.Add("border-color", "#ea6557 !important");
                        //((TextBox)(txtBoxId)).Enabled = true;
                    }
                }
                else
                {
                    ((TextBox)(txtBoxId)).Style.Add("border-color", "#ea6557 !important");
                    //((TextBox)(txtBoxId)).Enabled = true;
                }
            }
        }

    }
}