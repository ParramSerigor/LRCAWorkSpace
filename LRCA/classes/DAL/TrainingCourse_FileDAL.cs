
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
    public class TrainingCourse_FileDAL
    {
	
		 public static clsTrainingCourse_File SelectTrainingCourse_FileById(int?  TrainingCourseFileId)
        {
            clsTrainingCourse_File objTrainingCourse_File = new clsTrainingCourse_File();
            bool isnull = true;
            string SpName = "usp_SelectTrainingCourse_File";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(TrainingCourseFileId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@TrainingCourseFileId", TrainingCourseFileId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objTrainingCourse_File = db.Query<clsTrainingCourse_File>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objTrainingCourse_File;
        }
		
		public static List<clsTrainingCourse_File> SelectDynamicTrainingCourse_File(string WhereCondition, string OrderByExpression)
        {
            List<clsTrainingCourse_File> lstTrainingCourse_File = new List<clsTrainingCourse_File>();
            bool isnull = true;
            string SpName = "usp_SelectTrainingCourse_FileDynamic";
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
                        lstTrainingCourse_File = db.Query<clsTrainingCourse_File>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstTrainingCourse_File;
        }
		
		public static List<clsTrainingCourse_File> SelectAllTrainingCourse_File()
        {
            List<clsTrainingCourse_File> lstTrainingCourse_File = new List<clsTrainingCourse_File>();
            bool isnull = true;
            string SpName = "usp_SelectTrainingCourse_FileAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstTrainingCourse_File = db.Query<clsTrainingCourse_File>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstTrainingCourse_File;
        }
		
		public static Boolean InsertTrainingCourse_File(clsTrainingCourse_File objTrainingCourse_File)
        {
            bool isAdded = false;
            string SpName = "usp_InsertTrainingCourse_File";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objTrainingCourse_File, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateTrainingCourse_File(clsTrainingCourse_File objTrainingCourse_File)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateTrainingCourse_File";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objTrainingCourse_File, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteTrainingCourse_File(int?  TrainingCourseFileId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteTrainingCourse_File";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(TrainingCourseFileId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@TrainingCourseFileId", TrainingCourseFileId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateTrainingCourse_File(clsTrainingCourse_File objTrainingCourse_File)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateTrainingCourse_File";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objTrainingCourse_File, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicTrainingCourse_File(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteTrainingCourse_FileDynamic";
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
		
		
