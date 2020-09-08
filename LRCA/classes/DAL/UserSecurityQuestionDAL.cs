
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
    public class UserSecurityQuestionDAL
    {
	
		 public static clsUserSecurityQuestion SelectUserSecurityQuestionById(int?  UserSecurityQuestionId)
        {
            clsUserSecurityQuestion objUserSecurityQuestion = new clsUserSecurityQuestion();
            bool isnull = true;
            string SpName = "usp_SelectUserSecurityQuestion";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(UserSecurityQuestionId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@UserSecurityQuestionId", UserSecurityQuestionId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objUserSecurityQuestion = db.Query<clsUserSecurityQuestion>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objUserSecurityQuestion;
        }
		
		public static List<clsUserSecurityQuestion> SelectDynamicUserSecurityQuestion(string WhereCondition, string OrderByExpression)
        {
            List<clsUserSecurityQuestion> lstUserSecurityQuestion = new List<clsUserSecurityQuestion>();
            bool isnull = true;
            string SpName = "usp_SelectUserSecurityQuestionDynamic";
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
                        lstUserSecurityQuestion = db.Query<clsUserSecurityQuestion>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstUserSecurityQuestion;
        }
		
		public static List<clsUserSecurityQuestion> SelectAllUserSecurityQuestion()
        {
            List<clsUserSecurityQuestion> lstUserSecurityQuestion = new List<clsUserSecurityQuestion>();
            bool isnull = true;
            string SpName = "usp_SelectUserSecurityQuestionAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstUserSecurityQuestion = db.Query<clsUserSecurityQuestion>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstUserSecurityQuestion;
        }
		
		public static Boolean InsertUserSecurityQuestion(clsUserSecurityQuestion objUserSecurityQuestion)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUserSecurityQuestion";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objUserSecurityQuestion, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateUserSecurityQuestion(clsUserSecurityQuestion objUserSecurityQuestion)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateUserSecurityQuestion";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objUserSecurityQuestion, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteUserSecurityQuestion(int?  UserSecurityQuestionId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteUserSecurityQuestion";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(UserSecurityQuestionId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@UserSecurityQuestionId", UserSecurityQuestionId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateUserSecurityQuestion(clsUserSecurityQuestion objUserSecurityQuestion)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateUserSecurityQuestion";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objUserSecurityQuestion, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicUserSecurityQuestion(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteUserSecurityQuestionDynamic";
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
		
		
