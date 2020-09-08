
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
    public class Supervisor_CommentDAL
    {
	
		 public static clsSupervisor_Comment SelectSupervisor_CommentById(int?  SupervisorCommentId)
        {
            clsSupervisor_Comment objSupervisor_Comment = new clsSupervisor_Comment();
            bool isnull = true;
            string SpName = "usp_SelectSupervisor_Comment";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(SupervisorCommentId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@SupervisorCommentId", SupervisorCommentId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objSupervisor_Comment = db.Query<clsSupervisor_Comment>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objSupervisor_Comment;
        }
		
		public static List<clsSupervisor_Comment> SelectDynamicSupervisor_Comment(string WhereCondition, string OrderByExpression)
        {
            List<clsSupervisor_Comment> lstSupervisor_Comment = new List<clsSupervisor_Comment>();
            bool isnull = true;
            string SpName = "usp_SelectSupervisor_CommentDynamic";
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
                        lstSupervisor_Comment = db.Query<clsSupervisor_Comment>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstSupervisor_Comment;
        }
		
		public static List<clsSupervisor_Comment> SelectAllSupervisor_Comment()
        {
            List<clsSupervisor_Comment> lstSupervisor_Comment = new List<clsSupervisor_Comment>();
            bool isnull = true;
            string SpName = "usp_SelectSupervisor_CommentAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstSupervisor_Comment = db.Query<clsSupervisor_Comment>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstSupervisor_Comment;
        }
		
		public static Boolean InsertSupervisor_Comment(clsSupervisor_Comment objSupervisor_Comment)
        {
            bool isAdded = false;
            string SpName = "usp_InsertSupervisor_Comment";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objSupervisor_Comment, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateSupervisor_Comment(clsSupervisor_Comment objSupervisor_Comment)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateSupervisor_Comment";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objSupervisor_Comment, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteSupervisor_Comment(int?  SupervisorCommentId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteSupervisor_Comment";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(SupervisorCommentId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@SupervisorCommentId", SupervisorCommentId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateSupervisor_Comment(clsSupervisor_Comment objSupervisor_Comment)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateSupervisor_Comment";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objSupervisor_Comment, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicSupervisor_Comment(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteSupervisor_CommentDynamic";
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
		
		
