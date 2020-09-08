
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
    public class RiskAssessor_FileDAL
    {
	
		 public static clsRiskAssessor_File SelectRiskAssessor_FileById(int?  RiskAssessorFileId)
        {
            clsRiskAssessor_File objRiskAssessor_File = new clsRiskAssessor_File();
            bool isnull = true;
            string SpName = "usp_SelectRiskAssessor_File";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(RiskAssessorFileId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@RiskAssessorFileId", RiskAssessorFileId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objRiskAssessor_File = db.Query<clsRiskAssessor_File>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objRiskAssessor_File;
        }
		
		public static List<clsRiskAssessor_File> SelectDynamicRiskAssessor_File(string WhereCondition, string OrderByExpression)
        {
            List<clsRiskAssessor_File> lstRiskAssessor_File = new List<clsRiskAssessor_File>();
            bool isnull = true;
            string SpName = "usp_SelectRiskAssessor_FileDynamic";
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
                        lstRiskAssessor_File = db.Query<clsRiskAssessor_File>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstRiskAssessor_File;
        }
		
		public static List<clsRiskAssessor_File> SelectAllRiskAssessor_File()
        {
            List<clsRiskAssessor_File> lstRiskAssessor_File = new List<clsRiskAssessor_File>();
            bool isnull = true;
            string SpName = "usp_SelectRiskAssessor_FileAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstRiskAssessor_File = db.Query<clsRiskAssessor_File>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstRiskAssessor_File;
        }
		
		public static Boolean InsertRiskAssessor_File(clsRiskAssessor_File objRiskAssessor_File)
        {
            bool isAdded = false;
            string SpName = "usp_InsertRiskAssessor_File";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objRiskAssessor_File, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateRiskAssessor_File(clsRiskAssessor_File objRiskAssessor_File)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateRiskAssessor_File";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objRiskAssessor_File, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteRiskAssessor_File(int?  RiskAssessorFileId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteRiskAssessor_File";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(RiskAssessorFileId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@RiskAssessorFileId", RiskAssessorFileId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateRiskAssessor_File(clsRiskAssessor_File objRiskAssessor_File)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateRiskAssessor_File";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objRiskAssessor_File, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicRiskAssessor_File(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteRiskAssessor_FileDynamic";
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
		
		
