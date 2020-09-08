using Dapper;
using LRCA.classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Net.Mail;
using System.Web;

namespace LRCA.classes
{
    public static class ErrorHandler
    {
        private static string FileLoc = string.Empty;
        public static void ErrorLogging(Exception ex, Boolean SendEmail)
        {
            string messageIn = string.Empty;
            string strackTrace = string.Empty;

            messageIn = GlobalMethods.SafeSqlLiteral(ex.Message);
            strackTrace = GlobalMethods.SafeSqlLiteral(ex.StackTrace);

            string SpName = @"INSERT INTO tbl_ErrorLog (ErrorStart, ErrorMessge, ErrorStack) VALUES ('" + DateTime.Now + "','"+ messageIn + "','"+ strackTrace + "')";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, null, commandType: CommandType.Text);
                }

            }
            catch (Exception)
            {
               
            }
            
            if (SendEmail)
            {
                ErrorEmail(ex);
            }
        }
        public static void ReadError()
        {
           // HttpContext.Current.Response.Redirect(AppConstants.ConstAppURL + "404.aspx");
        }
        public static void ErrorPage()
        {
            HttpContext.Current.Response.Redirect(AppConstants.ConstAppURL + "404.aspx");
        }
        public static void ErrorEmail(Exception ex)
        {
            string EmailText = string.Empty;

            #region Email Text
            EmailText = EmailText + "===========Start============= " + DateTime.Now + System.Environment.NewLine;
            EmailText = EmailText + "Error Message: " + ex.Message + System.Environment.NewLine;
            EmailText = EmailText + "Stack Trace: " + ex.StackTrace + System.Environment.NewLine;
            EmailText = EmailText + "===========End============= " + DateTime.Now + System.Environment.NewLine;
            EmailText = EmailText + System.Environment.NewLine + System.Environment.NewLine;
            #endregion

            #region Sending Email
            if (AppConstants.ConstErrorEmail.ToString().Length > 0)
            {
                MailMessage objEmail = new MailMessage();
                objEmail.To.Add(AppConstants.ConstErrorEmail.ToString());
                objEmail.From = new MailAddress("DO NOT REPLY <" + AppConstants.ConstEmail + ">");
                objEmail.Body = EmailText;
                objEmail.Subject = "" + AppConstants.ErrorEmailSubject + "";
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
            }
            #endregion

        }
        public static string NoticeBar(string strNoticeMSG, string typeOfNotice)
        {
            string strError = "<div class='row'><div class='col-lg-12 alert alert-" + typeOfNotice + "'><i class='fa fa-exclamation-triangle text-" + typeOfNotice + "'></i> " + strNoticeMSG + "</div></div>";
            return strError;
        }
        /// <summary>
        /// Takes a httpResponse and return 
        /// 1: Error Status
        /// 2: Error Message
        /// </summary>
        /// <param name="response"></param>
        /// <returns>1: Error Status, 2: Error Message</returns>
        public static List<string> HttpHeaderError(HttpResponseMessage response)
        {
             List<string> lstValues = new List<string>();
            var errorStatus = response.StatusCode;
            var errorMessage = response.Content.ReadAsStringAsync().Result;
             var errors = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content.ReadAsStringAsync().Result);
            var message = errors["Message"];
            lstValues.Add(errorStatus.ToString());
            lstValues.Add(message.ToString());

            return lstValues;
           
        }

    }

}