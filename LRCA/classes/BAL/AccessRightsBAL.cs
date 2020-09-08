using LRCA.classes.DAL;
using LRCA.classes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LRCA.classes.BAL
{
    public class AccessRightsBAL
    {
        CryptoJS objcryptoJS = new CryptoJS();
        public static string _Error = string.Empty;

        public static bool IsMDE(int UserAuthId)
        {
            bool isValid = false;
            List<clsUserRole> lstURole = new List<clsUserRole>();
            lstURole = UserRoleDAL.SelectDynamicUserRole("(AuthorizedUserId = "+ UserAuthId + ") and (RoleId = 1)", "UserRoleId");
            if(lstURole != null)
            {
                if(lstURole.Count > 0)
                {
                    isValid = true;
                }
            }
            return isValid;
        }
        public static bool IsTP(int UserAuthId)
        {
            bool isValid = false;
            List<clsUserRole> lstURole = new List<clsUserRole>();
            lstURole = UserRoleDAL.SelectDynamicUserRole("(AuthorizedUserId = " + UserAuthId + ") and (RoleId = 2)", "UserRoleId");
            if (lstURole != null)
            {
                if (lstURole.Count > 0)
                {
                    isValid = true;
                }
            }
            return isValid;
        }
        public static bool IsContractor(int UserAuthId)
        {
            bool isValid = false;
            List<clsUserRole> lstURole = new List<clsUserRole>();
            lstURole = UserRoleDAL.SelectDynamicUserRole("(AuthorizedUserId = " + UserAuthId + ") and (RoleId = 7)", "UserRoleId");
            if (lstURole != null)
            {
                if (lstURole.Count > 0)
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        public static bool IsInstructor(int UserAuthId)
        {
            bool isValid = false;
            List<clsUserRole> lstURole = new List<clsUserRole>();
            lstURole = UserRoleDAL.SelectDynamicUserRole("(AuthorizedUserId = " + UserAuthId + ") and (RoleId = 3)", "UserRoleId");
            if (lstURole != null)
            {
                if (lstURole.Count > 0)
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}