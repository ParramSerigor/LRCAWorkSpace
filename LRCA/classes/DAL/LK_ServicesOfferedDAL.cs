
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
    public class LK_ServicesOfferedDAL
    {
	
		 public static clsLK_ServicesOffered SelectLK_ServicesOfferedById(int?  ServiceOfferId)
        {
            clsLK_ServicesOffered objLK_ServicesOffered = new clsLK_ServicesOffered();
            bool isnull = true;
            string SpName = "usp_SelectLK_ServicesOffered";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ServiceOfferId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@ServiceOfferId", ServiceOfferId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objLK_ServicesOffered = db.Query<clsLK_ServicesOffered>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objLK_ServicesOffered;
        }
		
		public static List<clsLK_ServicesOffered> SelectDynamicLK_ServicesOffered(string WhereCondition, string OrderByExpression)
        {
            List<clsLK_ServicesOffered> lstLK_ServicesOffered = new List<clsLK_ServicesOffered>();
            bool isnull = true;
            string SpName = "usp_SelectLK_ServicesOfferedDynamic";
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
                        lstLK_ServicesOffered = db.Query<clsLK_ServicesOffered>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstLK_ServicesOffered;
        }
		
		public static List<clsLK_ServicesOffered> SelectAllLK_ServicesOffered()
        {
            List<clsLK_ServicesOffered> lstLK_ServicesOffered = new List<clsLK_ServicesOffered>();
            bool isnull = true;
            string SpName = "usp_SelectLK_ServicesOfferedAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstLK_ServicesOffered = db.Query<clsLK_ServicesOffered>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstLK_ServicesOffered;
        }
		
		public static Boolean InsertLK_ServicesOffered(clsLK_ServicesOffered objLK_ServicesOffered)
        {
            bool isAdded = false;
            string SpName = "usp_InsertLK_ServicesOffered";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_ServicesOffered, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateLK_ServicesOffered(clsLK_ServicesOffered objLK_ServicesOffered)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateLK_ServicesOffered";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objLK_ServicesOffered, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteLK_ServicesOffered(int?  ServiceOfferId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_ServicesOffered";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ServiceOfferId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@ServiceOfferId", ServiceOfferId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateLK_ServicesOffered(clsLK_ServicesOffered objLK_ServicesOffered)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateLK_ServicesOffered";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_ServicesOffered, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicLK_ServicesOffered(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_ServicesOfferedDynamic";
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
		
		
