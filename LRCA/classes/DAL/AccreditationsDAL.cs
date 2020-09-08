
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
    public class AccreditationsDAL
    {
	
		 public static clsAccreditations SelectAccreditationsById(int?  AccreditationId)
        {
            clsAccreditations objAccreditations = new clsAccreditations();
            bool isnull = true;
            string SpName = "usp_SelectAccreditation";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(AccreditationId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@AccreditationId", AccreditationId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objAccreditations = db.Query<clsAccreditations>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objAccreditations;
        }
		
		public static List<clsAccreditations> SelectDynamicAccreditations(string WhereCondition, string OrderByExpression)
        {
            List<clsAccreditations> lstAccreditations = new List<clsAccreditations>();
            bool isnull = true;
            string SpName = "usp_SelectAccreditationDynamic";
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
                        lstAccreditations = db.Query<clsAccreditations>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstAccreditations;
        }
		
		public static List<clsAccreditations> SelectAllAccreditations()
        {
            List<clsAccreditations> lstAccreditations = new List<clsAccreditations>();
            bool isnull = true;
            string SpName = "usp_SelectAccreditationAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstAccreditations = db.Query<clsAccreditations>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstAccreditations;
        }
		
		public static Boolean InsertAccreditations(clsAccreditations objAccreditations)
        {
            bool isAdded = false;
            string SpName = "usp_InsertAccreditation";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objAccreditations, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateAccreditations(clsAccreditations objAccreditations)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateAccreditation";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objAccreditations, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteAccreditations(int?  AccreditationId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteAccreditation";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(AccreditationId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@AccreditationId", AccreditationId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateAccreditations(clsAccreditations objAccreditations)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateAccreditation";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objAccreditations, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicAccreditations(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteAccreditationDynamic";
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
		
		
