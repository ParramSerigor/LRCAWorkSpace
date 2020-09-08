
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
    public class TrainingCourse_CommentDAL
    {
	
		 public static clsTrainingCourse_Comment SelectTrainingCourse_CommentById(int?  TrainingCourseCommentId)
        {
            clsTrainingCourse_Comment objTrainingCourse_Comment = new clsTrainingCourse_Comment();
            bool isnull = true;
            string SpName = "usp_SelectTrainingCourse_Comment";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(TrainingCourseCommentId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@TrainingCourseCommentId", TrainingCourseCommentId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objTrainingCourse_Comment = db.Query<clsTrainingCourse_Comment>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objTrainingCourse_Comment;
        }
		
		public static List<clsTrainingCourse_Comment> SelectDynamicTrainingCourse_Comment(string WhereCondition, string OrderByExpression)
        {
            List<clsTrainingCourse_Comment> lstTrainingCourse_Comment = new List<clsTrainingCourse_Comment>();
            bool isnull = true;
            string SpName = "usp_SelectTrainingCourse_CommentDynamic";
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
                        lstTrainingCourse_Comment = db.Query<clsTrainingCourse_Comment>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstTrainingCourse_Comment;
        }
		
		public static List<clsTrainingCourse_Comment> SelectAllTrainingCourse_Comment()
        {
            List<clsTrainingCourse_Comment> lstTrainingCourse_Comment = new List<clsTrainingCourse_Comment>();
            bool isnull = true;
            string SpName = "usp_SelectTrainingCourse_CommentAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstTrainingCourse_Comment = db.Query<clsTrainingCourse_Comment>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstTrainingCourse_Comment;
        }
		
		public static Boolean InsertTrainingCourse_Comment(clsTrainingCourse_Comment objTrainingCourse_Comment)
        {
            bool isAdded = false;
            string SpName = "usp_InsertTrainingCourse_Comment";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objTrainingCourse_Comment, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateTrainingCourse_Comment(clsTrainingCourse_Comment objTrainingCourse_Comment)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateTrainingCourse_Comment";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objTrainingCourse_Comment, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteTrainingCourse_Comment(int?  TrainingCourseCommentId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteTrainingCourse_Comment";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(TrainingCourseCommentId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@TrainingCourseCommentId", TrainingCourseCommentId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateTrainingCourse_Comment(clsTrainingCourse_Comment objTrainingCourse_Comment)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateTrainingCourse_Comment";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objTrainingCourse_Comment, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicTrainingCourse_Comment(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteTrainingCourse_CommentDynamic";
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
		
		
