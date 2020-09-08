
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
    public class LK_Inst_CourseScheduleDAL
    {
	
		 public static clsLK_Inst_CourseSchedule SelectLK_Inst_CourseScheduleById(int?  Inst_CourseSchId)
        {
            clsLK_Inst_CourseSchedule objLK_Inst_CourseSchedule = new clsLK_Inst_CourseSchedule();
            bool isnull = true;
            string SpName = "usp_SelectLK_Inst_CourseSchedule";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(Inst_CourseSchId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@Inst_CourseSchId", Inst_CourseSchId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objLK_Inst_CourseSchedule = db.Query<clsLK_Inst_CourseSchedule>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objLK_Inst_CourseSchedule;
        }
		
		public static List<clsLK_Inst_CourseSchedule> SelectDynamicLK_Inst_CourseSchedule(string WhereCondition, string OrderByExpression)
        {
            List<clsLK_Inst_CourseSchedule> lstLK_Inst_CourseSchedule = new List<clsLK_Inst_CourseSchedule>();
            bool isnull = true;
            string SpName = "usp_SelectLK_Inst_CourseScheduleDynamic";
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
                        lstLK_Inst_CourseSchedule = db.Query<clsLK_Inst_CourseSchedule>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstLK_Inst_CourseSchedule;
        }
		
		public static List<clsLK_Inst_CourseSchedule> SelectAllLK_Inst_CourseSchedule()
        {
            List<clsLK_Inst_CourseSchedule> lstLK_Inst_CourseSchedule = new List<clsLK_Inst_CourseSchedule>();
            bool isnull = true;
            string SpName = "usp_SelectLK_Inst_CourseScheduleAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstLK_Inst_CourseSchedule = db.Query<clsLK_Inst_CourseSchedule>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstLK_Inst_CourseSchedule;
        }
		
		public static Boolean InsertLK_Inst_CourseSchedule(clsLK_Inst_CourseSchedule objLK_Inst_CourseSchedule)
        {
            bool isAdded = false;
            string SpName = "usp_InsertLK_Inst_CourseSchedule";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_Inst_CourseSchedule, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateLK_Inst_CourseSchedule(clsLK_Inst_CourseSchedule objLK_Inst_CourseSchedule)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateLK_Inst_CourseSchedule";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objLK_Inst_CourseSchedule, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteLK_Inst_CourseSchedule(int?  Inst_CourseSchId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_Inst_CourseSchedule";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(Inst_CourseSchId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@Inst_CourseSchId", Inst_CourseSchId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateLK_Inst_CourseSchedule(clsLK_Inst_CourseSchedule objLK_Inst_CourseSchedule)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateLK_Inst_CourseSchedule";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_Inst_CourseSchedule, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicLK_Inst_CourseSchedule(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_Inst_CourseScheduleDynamic";
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
		
		
