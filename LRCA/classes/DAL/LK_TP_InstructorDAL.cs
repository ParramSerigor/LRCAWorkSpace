
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
    public class LK_TP_InstructorDAL
    {
	
		 public static clsLK_TP_Instructor SelectLK_TP_InstructorById(int?  TP_InstructorsId)
        {
            clsLK_TP_Instructor objLK_TP_Instructor = new clsLK_TP_Instructor();
            bool isnull = true;
            string SpName = "usp_SelectLK_TP_Instructor";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(TP_InstructorsId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@TP_InstructorsId", TP_InstructorsId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objLK_TP_Instructor = db.Query<clsLK_TP_Instructor>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objLK_TP_Instructor;
        }
		
		public static List<clsLK_TP_Instructor> SelectDynamicLK_TP_Instructor(string WhereCondition, string OrderByExpression)
        {
            List<clsLK_TP_Instructor> lstLK_TP_Instructor = new List<clsLK_TP_Instructor>();
            bool isnull = true;
            string SpName = "usp_SelectLK_TP_InstructorDynamic";
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
                        lstLK_TP_Instructor = db.Query<clsLK_TP_Instructor>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstLK_TP_Instructor;
        }
		
		public static List<clsLK_TP_Instructor> SelectAllLK_TP_Instructor()
        {
            List<clsLK_TP_Instructor> lstLK_TP_Instructor = new List<clsLK_TP_Instructor>();
            bool isnull = true;
            string SpName = "usp_SelectLK_TP_InstructorAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstLK_TP_Instructor = db.Query<clsLK_TP_Instructor>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstLK_TP_Instructor;
        }
		
		public static Boolean InsertLK_TP_Instructor(clsLK_TP_Instructor objLK_TP_Instructor)
        {
            bool isAdded = false;
            string SpName = "usp_InsertLK_TP_Instructor";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_TP_Instructor, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateLK_TP_Instructor(clsLK_TP_Instructor objLK_TP_Instructor)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateLK_TP_Instructor";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objLK_TP_Instructor, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteLK_TP_Instructor(int?  TP_InstructorsId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_TP_Instructor";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(TP_InstructorsId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@TP_InstructorsId", TP_InstructorsId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateLK_TP_Instructor(clsLK_TP_Instructor objLK_TP_Instructor)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateLK_TP_Instructor";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_TP_Instructor, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicLK_TP_Instructor(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_TP_InstructorDynamic";
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
		
		
