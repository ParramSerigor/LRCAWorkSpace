
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
    public class Contractor_EmpListDAL
    {
	
		 public static clsContractor_EmpList SelectContractor_EmpListById(int?  ContractorUserListId)
        {
            clsContractor_EmpList objContractor_EmpList = new clsContractor_EmpList();
            bool isnull = true;
            string SpName = "usp_SelectContractor_EmpList";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ContractorUserListId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@ContractorUserListId", ContractorUserListId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objContractor_EmpList = db.Query<clsContractor_EmpList>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objContractor_EmpList;
        }
		
		public static List<clsContractor_EmpList> SelectDynamicContractor_EmpList(string WhereCondition, string OrderByExpression)
        {
            List<clsContractor_EmpList> lstContractor_EmpList = new List<clsContractor_EmpList>();
            bool isnull = true;
            string SpName = "usp_SelectContractor_EmpListDynamic";
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
                        lstContractor_EmpList = db.Query<clsContractor_EmpList>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstContractor_EmpList;
        }
		
		public static List<clsContractor_EmpList> SelectAllContractor_EmpList()
        {
            List<clsContractor_EmpList> lstContractor_EmpList = new List<clsContractor_EmpList>();
            bool isnull = true;
            string SpName = "usp_SelectContractor_EmpListAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstContractor_EmpList = db.Query<clsContractor_EmpList>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstContractor_EmpList;
        }
		
		public static Boolean InsertContractor_EmpList(clsContractor_EmpList objContractor_EmpList)
        {
            bool isAdded = false;
            string SpName = "usp_InsertContractor_EmpList";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objContractor_EmpList, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateContractor_EmpList(clsContractor_EmpList objContractor_EmpList)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateContractor_EmpList";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objContractor_EmpList, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteContractor_EmpList(int?  ContractorUserListId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteContractor_EmpList";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ContractorUserListId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@ContractorUserListId", ContractorUserListId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateContractor_EmpList(clsContractor_EmpList objContractor_EmpList)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateContractor_EmpList";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objContractor_EmpList, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicContractor_EmpList(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteContractor_EmpListDynamic";
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
		
		
