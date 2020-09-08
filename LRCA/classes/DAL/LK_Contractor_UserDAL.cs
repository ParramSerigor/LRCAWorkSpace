
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
    public class LK_Contractor_UserDAL
    {
	
		 public static clsLK_Contractor_User SelectLK_Contractor_UserById(int?  ContractorUserId)
        {
            clsLK_Contractor_User objLK_Contractor_User = new clsLK_Contractor_User();
            bool isnull = true;
            string SpName = "usp_SelectLK_Contractor_User";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ContractorUserId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@ContractorUserId", ContractorUserId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objLK_Contractor_User = db.Query<clsLK_Contractor_User>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objLK_Contractor_User;
        }
		
		public static List<clsLK_Contractor_User> SelectDynamicLK_Contractor_User(string WhereCondition, string OrderByExpression)
        {
            List<clsLK_Contractor_User> lstLK_Contractor_User = new List<clsLK_Contractor_User>();
            bool isnull = true;
            string SpName = "usp_SelectLK_Contractor_UserDynamic";
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
                        lstLK_Contractor_User = db.Query<clsLK_Contractor_User>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstLK_Contractor_User;
        }
		
		public static List<clsLK_Contractor_User> SelectAllLK_Contractor_User()
        {
            List<clsLK_Contractor_User> lstLK_Contractor_User = new List<clsLK_Contractor_User>();
            bool isnull = true;
            string SpName = "usp_SelectLK_Contractor_UserAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstLK_Contractor_User = db.Query<clsLK_Contractor_User>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstLK_Contractor_User;
        }
		
		public static Boolean InsertLK_Contractor_User(clsLK_Contractor_User objLK_Contractor_User)
        {
            bool isAdded = false;
            string SpName = "usp_InsertLK_Contractor_User";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_Contractor_User, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateLK_Contractor_User(clsLK_Contractor_User objLK_Contractor_User)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateLK_Contractor_User";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objLK_Contractor_User, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteLK_Contractor_User(int?  ContractorUserId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_Contractor_User";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ContractorUserId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@ContractorUserId", ContractorUserId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateLK_Contractor_User(clsLK_Contractor_User objLK_Contractor_User)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateLK_Contractor_User";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_Contractor_User, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicLK_Contractor_User(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_Contractor_UserDynamic";
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
		
		
