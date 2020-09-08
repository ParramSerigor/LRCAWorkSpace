
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
    public class Supervisor_ExperiencesDAL
    {
	
		 public static clsSupervisor_Experiences SelectSupervisor_ExperiencesById(int?  SupervisorExperienceId)
        {
            clsSupervisor_Experiences objSupervisor_Experiences = new clsSupervisor_Experiences();
            bool isnull = true;
            string SpName = "usp_SelectSupervisor_Experiences";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(SupervisorExperienceId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@SupervisorExperienceId", SupervisorExperienceId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objSupervisor_Experiences = db.Query<clsSupervisor_Experiences>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objSupervisor_Experiences;
        }
		
		public static List<clsSupervisor_Experiences> SelectDynamicSupervisor_Experiences(string WhereCondition, string OrderByExpression)
        {
            List<clsSupervisor_Experiences> lstSupervisor_Experiences = new List<clsSupervisor_Experiences>();
            bool isnull = true;
            string SpName = "usp_SelectSupervisor_ExperiencesDynamic";
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
                        lstSupervisor_Experiences = db.Query<clsSupervisor_Experiences>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstSupervisor_Experiences;
        }
		
		public static List<clsSupervisor_Experiences> SelectAllSupervisor_Experiences()
        {
            List<clsSupervisor_Experiences> lstSupervisor_Experiences = new List<clsSupervisor_Experiences>();
            bool isnull = true;
            string SpName = "usp_SelectSupervisor_ExperiencesAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstSupervisor_Experiences = db.Query<clsSupervisor_Experiences>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstSupervisor_Experiences;
        }
		
		public static Boolean InsertSupervisor_Experiences(clsSupervisor_Experiences objSupervisor_Experiences)
        {
            bool isAdded = false;
            string SpName = "usp_InsertSupervisor_Experiences";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objSupervisor_Experiences, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateSupervisor_Experiences(clsSupervisor_Experiences objSupervisor_Experiences)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateSupervisor_Experiences";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objSupervisor_Experiences, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteSupervisor_Experiences(int?  SupervisorExperienceId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteSupervisor_Experiences";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(SupervisorExperienceId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@SupervisorExperienceId", SupervisorExperienceId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateSupervisor_Experiences(clsSupervisor_Experiences objSupervisor_Experiences)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateSupervisor_Experiences";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objSupervisor_Experiences, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicSupervisor_Experiences(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteSupervisor_ExperiencesDynamic";
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
		
		
