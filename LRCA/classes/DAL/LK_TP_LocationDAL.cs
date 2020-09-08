
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
    public class LK_TP_LocationDAL
    {
	
		 public static clsLK_TP_Location SelectLK_TP_LocationById(int?  TPLocationId)
        {
            clsLK_TP_Location objLK_TP_Location = new clsLK_TP_Location();
            bool isnull = true;
            string SpName = "usp_SelectLK_TP_Location";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(TPLocationId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@TPLocationId", TPLocationId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objLK_TP_Location = db.Query<clsLK_TP_Location>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objLK_TP_Location;
        }
		
		public static List<clsLK_TP_Location> SelectDynamicLK_TP_Location(string WhereCondition, string OrderByExpression)
        {
            List<clsLK_TP_Location> lstLK_TP_Location = new List<clsLK_TP_Location>();
            bool isnull = true;
            string SpName = "usp_SelectLK_TP_LocationDynamic";
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
                        lstLK_TP_Location = db.Query<clsLK_TP_Location>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstLK_TP_Location;
        }
		
		public static List<clsLK_TP_Location> SelectAllLK_TP_Location()
        {
            List<clsLK_TP_Location> lstLK_TP_Location = new List<clsLK_TP_Location>();
            bool isnull = true;
            string SpName = "usp_SelectLK_TP_LocationAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstLK_TP_Location = db.Query<clsLK_TP_Location>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstLK_TP_Location;
        }
		
		public static Boolean InsertLK_TP_Location(clsLK_TP_Location objLK_TP_Location)
        {
            bool isAdded = false;
            string SpName = "usp_InsertLK_TP_Location";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_TP_Location, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateLK_TP_Location(clsLK_TP_Location objLK_TP_Location)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateLK_TP_Location";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objLK_TP_Location, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteLK_TP_Location(int?  TPLocationId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_TP_Location";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(TPLocationId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@TPLocationId", TPLocationId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateLK_TP_Location(clsLK_TP_Location objLK_TP_Location)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateLK_TP_Location";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objLK_TP_Location, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicLK_TP_Location(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteLK_TP_LocationDynamic";
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
		
		
