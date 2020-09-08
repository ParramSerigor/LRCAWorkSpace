
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
    public class Contractor_ServiceOfferedDAL
    {
	
		 public static clsContractor_ServiceOffered SelectContractor_ServiceOfferedById(int?  ContractorServiceOfferId)
        {
            clsContractor_ServiceOffered objContractor_ServiceOffered = new clsContractor_ServiceOffered();
            bool isnull = true;
            string SpName = "usp_SelectContractor_ServiceOffered";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ContractorServiceOfferId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@ContractorServiceOfferId", ContractorServiceOfferId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objContractor_ServiceOffered = db.Query<clsContractor_ServiceOffered>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objContractor_ServiceOffered;
        }
		
		public static List<clsContractor_ServiceOffered> SelectDynamicContractor_ServiceOffered(string WhereCondition, string OrderByExpression)
        {
            List<clsContractor_ServiceOffered> lstContractor_ServiceOffered = new List<clsContractor_ServiceOffered>();
            bool isnull = true;
            string SpName = "usp_SelectContractor_ServiceOfferedDynamic";
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
                        lstContractor_ServiceOffered = db.Query<clsContractor_ServiceOffered>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstContractor_ServiceOffered;
        }
		
		public static List<clsContractor_ServiceOffered> SelectAllContractor_ServiceOffered()
        {
            List<clsContractor_ServiceOffered> lstContractor_ServiceOffered = new List<clsContractor_ServiceOffered>();
            bool isnull = true;
            string SpName = "usp_SelectContractor_ServiceOfferedAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstContractor_ServiceOffered = db.Query<clsContractor_ServiceOffered>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstContractor_ServiceOffered;
        }
		
		public static Boolean InsertContractor_ServiceOffered(clsContractor_ServiceOffered objContractor_ServiceOffered)
        {
            bool isAdded = false;
            string SpName = "usp_InsertContractor_ServiceOffered";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objContractor_ServiceOffered, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateContractor_ServiceOffered(clsContractor_ServiceOffered objContractor_ServiceOffered)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateContractor_ServiceOffered";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objContractor_ServiceOffered, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteContractor_ServiceOffered(int?  ContractorServiceOfferId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteContractor_ServiceOffered";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ContractorServiceOfferId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@ContractorServiceOfferId", ContractorServiceOfferId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateContractor_ServiceOffered(clsContractor_ServiceOffered objContractor_ServiceOffered)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateContractor_ServiceOffered";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objContractor_ServiceOffered, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicContractor_ServiceOffered(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteContractor_ServiceOfferedDynamic";
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
		
		
