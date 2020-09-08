
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
    public class LK_InstructorMatchDAL
    {
	
		 public static clsLK_InstructorMatch SelectLK_InstructorMatchById(int?  Instructor_match_Id)
        {
            clsLK_InstructorMatch objLK_InstructorMatch = new clsLK_InstructorMatch();
            bool isnull = true;
            string SpName = "usp_SelectLK_InstructorMatch";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(Instructor_match_Id.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@Instructor_match_Id", Instructor_match_Id, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objLK_InstructorMatch = db.Query<clsLK_InstructorMatch>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objLK_InstructorMatch;
        }
		
		public static List<clsLK_InstructorMatch> SelectDynamicLK_InstructorMatch(string WhereCondition, string OrderByExpression)
        {
            List<clsLK_InstructorMatch> lstLK_InstructorMatch = new List<clsLK_InstructorMatch>();
            bool isnull = true;
            string SpName = "usp_SelectLK_InstructorMatchDynamic";
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
                        lstLK_InstructorMatch = db.Query<clsLK_InstructorMatch>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstLK_InstructorMatch;
        }
		
		public static List<clsLK_InstructorMatch> SelectAllLK_InstructorMatch()
        {
            List<clsLK_InstructorMatch> lstLK_InstructorMatch = new List<clsLK_InstructorMatch>();
            bool isnull = true;
            string SpName = "usp_SelectLK_InstructorMatchAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstLK_InstructorMatch = db.Query<clsLK_InstructorMatch>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstLK_InstructorMatch;
        }
		
		public static Boolean InsertLK_InstructorMatch(clsLK_InstructorMatch objLK_InstructorMatch)
        {
            bool isAdded = false;
            string SpName = "usp_InsertLK_InstructorMatch";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_InstructorMatch, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateLK_InstructorMatch(clsLK_InstructorMatch objLK_InstructorMatch)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateLK_InstructorMatch";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objLK_InstructorMatch, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteLK_InstructorMatch(int?  Instructor_match_Id)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_InstructorMatch";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(Instructor_match_Id.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@Instructor_match_Id", Instructor_match_Id, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateLK_InstructorMatch(clsLK_InstructorMatch objLK_InstructorMatch)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateLK_InstructorMatch";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_InstructorMatch, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicLK_InstructorMatch(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_InstructorMatchDynamic";
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
		
		
