
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
    public class Form_Experience_MapDAL
    {
	
		 public static clsForm_Experience_Map SelectForm_Experience_MapById(int?  ExperienceFormMappingId)
        {
            clsForm_Experience_Map objForm_Experience_Map = new clsForm_Experience_Map();
            bool isnull = true;
            string SpName = "usp_SelectForm_Experience_Map";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ExperienceFormMappingId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@ExperienceFormMappingId", ExperienceFormMappingId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objForm_Experience_Map = db.Query<clsForm_Experience_Map>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objForm_Experience_Map;
        }
		
		public static List<clsForm_Experience_Map> SelectDynamicForm_Experience_Map(string WhereCondition, string OrderByExpression)
        {
            List<clsForm_Experience_Map> lstForm_Experience_Map = new List<clsForm_Experience_Map>();
            bool isnull = true;
            string SpName = "usp_SelectForm_Experience_MapDynamic";
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
                        lstForm_Experience_Map = db.Query<clsForm_Experience_Map>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstForm_Experience_Map;
        }
		
		public static List<clsForm_Experience_Map> SelectAllForm_Experience_Map()
        {
            List<clsForm_Experience_Map> lstForm_Experience_Map = new List<clsForm_Experience_Map>();
            bool isnull = true;
            string SpName = "usp_SelectForm_Experience_MapAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstForm_Experience_Map = db.Query<clsForm_Experience_Map>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstForm_Experience_Map;
        }
		
		public static Boolean InsertForm_Experience_Map(clsForm_Experience_Map objForm_Experience_Map)
        {
            bool isAdded = false;
            string SpName = "usp_InsertForm_Experience_Map";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objForm_Experience_Map, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateForm_Experience_Map(clsForm_Experience_Map objForm_Experience_Map)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateForm_Experience_Map";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objForm_Experience_Map, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteForm_Experience_Map(int?  ExperienceFormMappingId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteForm_Experience_Map";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ExperienceFormMappingId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@ExperienceFormMappingId", ExperienceFormMappingId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateForm_Experience_Map(clsForm_Experience_Map objForm_Experience_Map)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateForm_Experience_Map";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objForm_Experience_Map, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicForm_Experience_Map(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteForm_Experience_MapDynamic";
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
		
		
