
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
    public class LK_RiskAssessor_ExperienceDAL
    {
	
		 public static clsLK_RiskAssessor_Experience SelectLK_RiskAssessor_ExperienceById(int?  RiskAssessorExperienceId)
        {
            clsLK_RiskAssessor_Experience objLK_RiskAssessor_Experience = new clsLK_RiskAssessor_Experience();
            bool isnull = true;
            string SpName = "usp_SelectLK_RiskAssessor_Experience";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(RiskAssessorExperienceId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@RiskAssessorExperienceId", RiskAssessorExperienceId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objLK_RiskAssessor_Experience = db.Query<clsLK_RiskAssessor_Experience>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objLK_RiskAssessor_Experience;
        }
		
		public static List<clsLK_RiskAssessor_Experience> SelectDynamicLK_RiskAssessor_Experience(string WhereCondition, string OrderByExpression)
        {
            List<clsLK_RiskAssessor_Experience> lstLK_RiskAssessor_Experience = new List<clsLK_RiskAssessor_Experience>();
            bool isnull = true;
            string SpName = "usp_SelectLK_RiskAssessor_ExperienceDynamic";
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
                        lstLK_RiskAssessor_Experience = db.Query<clsLK_RiskAssessor_Experience>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstLK_RiskAssessor_Experience;
        }
		
		public static List<clsLK_RiskAssessor_Experience> SelectAllLK_RiskAssessor_Experience()
        {
            List<clsLK_RiskAssessor_Experience> lstLK_RiskAssessor_Experience = new List<clsLK_RiskAssessor_Experience>();
            bool isnull = true;
            string SpName = "usp_SelectLK_RiskAssessor_ExperienceAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstLK_RiskAssessor_Experience = db.Query<clsLK_RiskAssessor_Experience>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstLK_RiskAssessor_Experience;
        }
		
		public static Boolean InsertLK_RiskAssessor_Experience(clsLK_RiskAssessor_Experience objLK_RiskAssessor_Experience)
        {
            bool isAdded = false;
            string SpName = "usp_InsertLK_RiskAssessor_Experience";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_RiskAssessor_Experience, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateLK_RiskAssessor_Experience(clsLK_RiskAssessor_Experience objLK_RiskAssessor_Experience)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateLK_RiskAssessor_Experience";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objLK_RiskAssessor_Experience, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteLK_RiskAssessor_Experience(int?  RiskAssessorExperienceId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_RiskAssessor_Experience";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(RiskAssessorExperienceId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@RiskAssessorExperienceId", RiskAssessorExperienceId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateLK_RiskAssessor_Experience(clsLK_RiskAssessor_Experience objLK_RiskAssessor_Experience)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateLK_RiskAssessor_Experience";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_RiskAssessor_Experience, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicLK_RiskAssessor_Experience(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_RiskAssessor_ExperienceDynamic";
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
		
		
