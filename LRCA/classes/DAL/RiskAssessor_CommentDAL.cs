
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
    public class RiskAssessor_CommentDAL
    {
	
		 public static clsRiskAssessor_Comment SelectRiskAssessor_CommentById(int?  RiskAssessorCommentId)
        {
            clsRiskAssessor_Comment objRiskAssessor_Comment = new clsRiskAssessor_Comment();
            bool isnull = true;
            string SpName = "usp_SelectRiskAssessor_Comment";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(RiskAssessorCommentId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@RiskAssessorCommentId", RiskAssessorCommentId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objRiskAssessor_Comment = db.Query<clsRiskAssessor_Comment>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objRiskAssessor_Comment;
        }
		
		public static List<clsRiskAssessor_Comment> SelectDynamicRiskAssessor_Comment(string WhereCondition, string OrderByExpression)
        {
            List<clsRiskAssessor_Comment> lstRiskAssessor_Comment = new List<clsRiskAssessor_Comment>();
            bool isnull = true;
            string SpName = "usp_SelectRiskAssessor_CommentDynamic";
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
                        lstRiskAssessor_Comment = db.Query<clsRiskAssessor_Comment>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstRiskAssessor_Comment;
        }
		
		public static List<clsRiskAssessor_Comment> SelectAllRiskAssessor_Comment()
        {
            List<clsRiskAssessor_Comment> lstRiskAssessor_Comment = new List<clsRiskAssessor_Comment>();
            bool isnull = true;
            string SpName = "usp_SelectRiskAssessor_CommentAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstRiskAssessor_Comment = db.Query<clsRiskAssessor_Comment>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstRiskAssessor_Comment;
        }
		
		public static Boolean InsertRiskAssessor_Comment(clsRiskAssessor_Comment objRiskAssessor_Comment)
        {
            bool isAdded = false;
            string SpName = "usp_InsertRiskAssessor_Comment";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objRiskAssessor_Comment, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateRiskAssessor_Comment(clsRiskAssessor_Comment objRiskAssessor_Comment)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateRiskAssessor_Comment";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objRiskAssessor_Comment, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteRiskAssessor_Comment(int?  RiskAssessorCommentId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteRiskAssessor_Comment";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(RiskAssessorCommentId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@RiskAssessorCommentId", RiskAssessorCommentId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateRiskAssessor_Comment(clsRiskAssessor_Comment objRiskAssessor_Comment)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateRiskAssessor_Comment";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objRiskAssessor_Comment, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicRiskAssessor_Comment(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteRiskAssessor_CommentDynamic";
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
		
		
