
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
    public class TP_InstructorsDAL
    {
	
		 public static clsTP_Instructors SelectTP_InstructorsById(int?  TP_InstructorListId)
        {
            clsTP_Instructors objTP_Instructors = new clsTP_Instructors();
            bool isnull = true;
            string SpName = "usp_SelectTP_Instructors";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(TP_InstructorListId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@TP_InstructorListId", TP_InstructorListId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objTP_Instructors = db.Query<clsTP_Instructors>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objTP_Instructors;
        }
		
		public static List<clsTP_Instructors> SelectDynamicTP_Instructors(string WhereCondition, string OrderByExpression)
        {
            List<clsTP_Instructors> lstTP_Instructors = new List<clsTP_Instructors>();
            bool isnull = true;
            string SpName = "usp_SelectTP_InstructorsDynamic";
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
                        lstTP_Instructors = db.Query<clsTP_Instructors>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstTP_Instructors;
        }
		
		public static List<clsTP_Instructors> SelectAllTP_Instructors()
        {
            List<clsTP_Instructors> lstTP_Instructors = new List<clsTP_Instructors>();
            bool isnull = true;
            string SpName = "usp_SelectTP_InstructorsAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstTP_Instructors = db.Query<clsTP_Instructors>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstTP_Instructors;
        }
		
		public static Boolean InsertTP_Instructors(clsTP_Instructors objTP_Instructors)
        {
            bool isAdded = false;
            string SpName = "usp_InsertTP_Instructors";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objTP_Instructors, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateTP_Instructors(clsTP_Instructors objTP_Instructors)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateTP_Instructors";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objTP_Instructors, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteTP_Instructors(int?  TP_InstructorListId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteTP_Instructors";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(TP_InstructorListId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@TP_InstructorListId", TP_InstructorListId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateTP_Instructors(clsTP_Instructors objTP_Instructors)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateTP_Instructors";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objTP_Instructors, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicTP_Instructors(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteTP_InstructorsDynamic";
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
		
		
