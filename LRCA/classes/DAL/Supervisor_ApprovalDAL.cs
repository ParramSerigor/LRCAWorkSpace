
using System;
using System.Collections.Generic;
using System.Linq;
using LRCA.classes;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using LRCA.classes.Entity;

namespace LRCA.classes.DAL
{
    public class Supervisor_ApprovalDAL
    {
	
		 public static clsSupervisor_Approval SelectSupervisor_ApprovalById(int?  MDESuperApprId)
        {
            clsSupervisor_Approval objSupervisor_Approval = new clsSupervisor_Approval();
            bool isnull = true;
            string SpName = "usp_SelectSupervisor_Approval";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(MDESuperApprId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@MDESuperApprId", MDESuperApprId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objSupervisor_Approval = db.Query<clsSupervisor_Approval>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
                        isnull = false;
                    }
                }
                catch(Exception ex)
                {
                    ErrorHandler.ErrorLogging(ex,false);
                    ErrorHandler.ReadError();
                }
            }
          
            if (isnull) return null;
            else return objSupervisor_Approval;
        }
		
		public static List<clsSupervisor_Approval> SelectDynamicSupervisor_Approval(string WhereCondition, string OrderByExpression)
        {
            List<clsSupervisor_Approval> lstSupervisor_Approval = new List<clsSupervisor_Approval>();
            bool isnull = true;
            string SpName = "usp_SelectSupervisor_ApprovalDynamic";
            var objPar = new DynamicParameters();
           
            if (String.IsNullOrEmpty(WhereCondition))
            {
                throw new ArgumentException("WhereCondition cannot be blank!");
            }
            else
            {
                try
                {
                    objPar.Add("@WhereCondition", WhereCondition, dbType: DbType.String);
                    objPar.Add("@OrderByExpression", OrderByExpression, dbType: DbType.String);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        lstSupervisor_Approval = db.Query<clsSupervisor_Approval>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
                    }
                    isnull = false;
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorLogging(ex, false);
                    ErrorHandler.ReadError();
                }
            }
               
            if (isnull) return null;
            else return lstSupervisor_Approval;
        }
		
		public static List<clsSupervisor_Approval> SelectAllSupervisor_Approval()
        {
            List<clsSupervisor_Approval> lstSupervisor_Approval = new List<clsSupervisor_Approval>();
            bool isnull = true;
            string SpName = "usp_SelectSupervisor_ApprovalAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstSupervisor_Approval = db.Query<clsSupervisor_Approval>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstSupervisor_Approval;
        }
		
		public static Boolean InsertSupervisor_Approval(clsSupervisor_Approval objSupervisor_Approval)
        {
            bool isAdded = false;
            string SpName = "usp_InsertSupervisor_Approval";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objSupervisor_Approval, commandType: CommandType.StoredProcedure);
                }
                isAdded = true;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            return isAdded;
        }
		
		public static Boolean UpdateSupervisor_Approval(clsSupervisor_Approval objSupervisor_Approval)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateSupervisor_Approval";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objSupervisor_Approval, commandType: CommandType.StoredProcedure);
                    }
                    isUpdated = true;
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorLogging(ex, false);
                    ErrorHandler.ReadError();
                }
             return isUpdated;
        }
		
		public static Boolean DeleteSupervisor_Approval(int?  MDESuperApprId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteSupervisor_Approval";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(MDESuperApprId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@MDESuperApprId", MDESuperApprId, dbType: DbType.Int32);

                            using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                            {
                                db.Execute(SpName, objPar, commandType: CommandType.StoredProcedure);
                            }
                        isDeleted = true;
                        #endregion
                    
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorLogging(ex, false);
                    ErrorHandler.ReadError();
                }
            }

            return isDeleted;
        }
		
		public static Boolean InsertUpdateSupervisor_Approval(clsSupervisor_Approval objSupervisor_Approval)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateSupervisor_Approval";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objSupervisor_Approval, commandType: CommandType.StoredProcedure);
                }
                isAdded = true;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            return isAdded;
        }
		
		public static Boolean DeleteDynamicSupervisor_Approval(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteSupervisor_ApprovalDynamic";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(WhereCondition.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
							objPar.Add("@WhereCondition", WhereCondition, dbType: DbType.String);
                            using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                            {
                                db.Execute(SpName, objPar, commandType: CommandType.StoredProcedure);
                            }
                        isDeleted = true;
                        #endregion
                    
                }
                catch (Exception ex)
                {
                    ErrorHandler.ErrorLogging(ex, false);
                    ErrorHandler.ReadError();
                }
            }

            return isDeleted;                    
        }
	}
}
		
		
