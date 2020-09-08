
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
    public class Inspector_RiskAssessorDAL
    {
	
		 public static clsInspector_RiskAssessor SelectInspector_RiskAssessorById(int?  InspectorRiskAssId)
        {
            clsInspector_RiskAssessor objInspector_RiskAssessor = new clsInspector_RiskAssessor();
            bool isnull = true;
            string SpName = "usp_SelectInspector_RiskAssessor";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(InspectorRiskAssId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@InspectorRiskAssId", InspectorRiskAssId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objInspector_RiskAssessor = db.Query<clsInspector_RiskAssessor>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objInspector_RiskAssessor;
        }
		
		public static List<clsInspector_RiskAssessor> SelectDynamicInspector_RiskAssessor(string WhereCondition, string OrderByExpression)
        {
            List<clsInspector_RiskAssessor> lstInspector_RiskAssessor = new List<clsInspector_RiskAssessor>();
            bool isnull = true;
            string SpName = "usp_SelectInspector_RiskAssessorDynamic";
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
                        lstInspector_RiskAssessor = db.Query<clsInspector_RiskAssessor>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstInspector_RiskAssessor;
        }
		
		public static List<clsInspector_RiskAssessor> SelectAllInspector_RiskAssessor()
        {
            List<clsInspector_RiskAssessor> lstInspector_RiskAssessor = new List<clsInspector_RiskAssessor>();
            bool isnull = true;
            string SpName = "usp_SelectInspector_RiskAssessorAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstInspector_RiskAssessor = db.Query<clsInspector_RiskAssessor>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstInspector_RiskAssessor;
        }
		
		public static Boolean InsertInspector_RiskAssessor(clsInspector_RiskAssessor objInspector_RiskAssessor)
        {
            bool isAdded = false;
            string SpName = "usp_InsertInspector_RiskAssessor";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objInspector_RiskAssessor, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateInspector_RiskAssessor(clsInspector_RiskAssessor objInspector_RiskAssessor)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateInspector_RiskAssessor";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objInspector_RiskAssessor, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteInspector_RiskAssessor(int?  InspectorRiskAssId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteInspector_RiskAssessor";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(InspectorRiskAssId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@InspectorRiskAssId", InspectorRiskAssId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateInspector_RiskAssessor(clsInspector_RiskAssessor objInspector_RiskAssessor)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateInspector_RiskAssessor";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objInspector_RiskAssessor, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicInspector_RiskAssessor(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteInspector_RiskAssessorDynamic";
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
		
		
