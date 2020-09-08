
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
    public class ExamUserSignupMapDAL
    {
	
		 public static clsExamUserSignupMap SelectExamUserSignupMapById(int ExamUserMapId)
        {
            clsExamUserSignupMap objExamUserSignupMap = new clsExamUserSignupMap();
            bool isnull = true;
            string SpName = "usp_SelectExamUserSignupMap";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ExamUserMapId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@ExamUserMapId", ExamUserMapId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objExamUserSignupMap = db.Query<clsExamUserSignupMap>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objExamUserSignupMap;
        }
		
		public static List<clsExamUserSignupMap> SelectDynamicExamUserSignupMap(string WhereCondition, string OrderByExpression)
        {
            List<clsExamUserSignupMap> lstExamUserSignupMap = new List<clsExamUserSignupMap>();
            bool isnull = true;
            string SpName = "usp_SelectExamUserSignupMapDynamic";
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
                        lstExamUserSignupMap = db.Query<clsExamUserSignupMap>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstExamUserSignupMap;
        }
		
		public static List<clsExamUserSignupMap> SelectAllExamUserSignupMap()
        {
            List<clsExamUserSignupMap> lstExamUserSignupMap = new List<clsExamUserSignupMap>();
            bool isnull = true;
            string SpName = "usp_SelectExamUserSignupMapAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstExamUserSignupMap = db.Query<clsExamUserSignupMap>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstExamUserSignupMap;
        }
		
		public static Boolean InsertExamUserSignupMap(clsExamUserSignupMap objExamUserSignupMap)
        {
            bool isAdded = false;
            string SpName = "usp_InsertExamUserSignupMap";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objExamUserSignupMap, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateExamUserSignupMap(clsExamUserSignupMap objExamUserSignupMap)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateExamUserSignupMap";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objExamUserSignupMap, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteExamUserSignupMap(int ExamUserMapId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteExamUserSignupMap";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ExamUserMapId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@ExamUserMapId", ExamUserMapId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateExamUserSignupMap(clsExamUserSignupMap objExamUserSignupMap)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateExamUserSignupMap";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objExamUserSignupMap, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicExamUserSignupMap(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteExamUserSignupMapDynamic";
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
		
		
