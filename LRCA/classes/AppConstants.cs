using System;
using System.Collections.Generic;
using System.Configuration;

namespace LRCA.classes
{
    public static class AppConstants
    {
        public static string Environment = string.Format(ConfigurationManager.AppSettings["Environment"]);
        public static bool isLive = false;
        public static string ConstLoginMsg = "";
        public static string ConstAppName = "LRCA";
        public static string ConstLoginURL = "https://mightystartups.com/default.aspx?home=active#login";
        public static string ConstAppURL = Environment.Equals("development") ? "http://localhost:50223/" : "https://mightystartups.com/";
       
        public static string ConstSMTP_PRIMARY = "smtp.1and1.com";
        public static string ConstSMTP_SECONDARY = "smtp.1and1.com";
        public static string ConstEmail = "site.support@mightystartups.com";
        public static string ConstErrorEmail = "faujiman@hotmail.com";
        public static string ErrorEmailSubject = "Error Generated!";
        public static string ConstHelpPhone = "301-333-3333";
        public static string ConstHelpEmail = "site.support@mightystartups.com";
        public static string secretKey = "2e35f242a46d67eeb74aabc37d5e5d05";
        public static string initVec = "2314345645678765";

        public static Int32 ConstAccActive = 1;
        public static Int32 ConstAccInactive = 0;
        public static Int32 ConstAccDisabled = -1;
        public static Int32 ConstAccNew = -2;
        
    }
}