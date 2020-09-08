
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
    public class Instructor_ApprovalDAL
    {
	
		 public static clsInstructor_Approval SelectInstructor_ApprovalById(int?  MDEInsApprId)
        {
            clsInstructor_Approval objInstructor_Approval = new clsInstructor_Approval();
            bool isnull = true;
            string SpName = "usp_SelectInstructor_Approval";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(MDEInsApprId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@MDEInsApprId", MDEInsApprId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objInstructor_Approval = db.Query<clsInstructor_Approval>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objInstructor_Approval;
        }
		
		public static List<clsInstructor_Approval> SelectDynamicInstructor_Approval(string WhereCondition, string OrderByExpression)
        {
            List<clsInstructor_Approval> lstInstructor_Approval = new List<clsInstructor_Approval>();
            bool isnull = true;
            string SpName = "usp_SelectInstructor_ApprovalDynamic";
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
                        lstInstructor_Approval = db.Query<clsInstructor_Approval>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstInstructor_Approval;
        }
		
		public static List<clsInstructor_Approval> SelectAllInstructor_Approval()
        {
            List<clsInstructor_Approval> lstInstructor_Approval = new List<clsInstructor_Approval>();
            bool isnull = true;
            string SpName = "usp_SelectInstructor_ApprovalAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstInstructor_Approval = db.Query<clsInstructor_Approval>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstInstructor_Approval;
        }
		
		public static Boolean InsertInstructor_Approval(clsInstructor_Approval objInstructor_Approval)
        {
            bool isAdded = false;
            string SpName = "usp_InsertInstructor_Approval";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objInstructor_Approval, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateInstructor_Approval(clsInstructor_Approval objInstructor_Approval)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateInstructor_Approval";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objInstructor_Approval, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteInstructor_Approval(int?  MDEInsApprId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteInstructor_Approval";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(MDEInsApprId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@MDEInsApprId", MDEInsApprId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateInstructor_Approval(clsInstructor_Approval objInstructor_Approval)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateInstructor_Approval";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objInstructor_Approval, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicInstructor_Approval(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteInstructor_ApprovalDynamic";
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
		
		
