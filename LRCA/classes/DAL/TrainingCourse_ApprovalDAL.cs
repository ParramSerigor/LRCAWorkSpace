
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
    public class TrainingCourse_ApprovalDAL
    {
	
		 public static clsTrainingCourse_Approval SelectTrainingCourse_ApprovalById(int?  MDETCourseApprId)
        {
            clsTrainingCourse_Approval objTrainingCourse_Approval = new clsTrainingCourse_Approval();
            bool isnull = true;
            string SpName = "usp_SelectTrainingCourse_Approval";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(MDETCourseApprId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@MDETCourseApprId", MDETCourseApprId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objTrainingCourse_Approval = db.Query<clsTrainingCourse_Approval>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objTrainingCourse_Approval;
        }
		
		public static List<clsTrainingCourse_Approval> SelectDynamicTrainingCourse_Approval(string WhereCondition, string OrderByExpression)
        {
            List<clsTrainingCourse_Approval> lstTrainingCourse_Approval = new List<clsTrainingCourse_Approval>();
            bool isnull = true;
            string SpName = "usp_SelectTrainingCourse_ApprovalDynamic";
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
                        lstTrainingCourse_Approval = db.Query<clsTrainingCourse_Approval>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstTrainingCourse_Approval;
        }
		
		public static List<clsTrainingCourse_Approval> SelectAllTrainingCourse_Approval()
        {
            List<clsTrainingCourse_Approval> lstTrainingCourse_Approval = new List<clsTrainingCourse_Approval>();
            bool isnull = true;
            string SpName = "usp_SelectTrainingCourse_ApprovalAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstTrainingCourse_Approval = db.Query<clsTrainingCourse_Approval>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstTrainingCourse_Approval;
        }
		
		public static Boolean InsertTrainingCourse_Approval(clsTrainingCourse_Approval objTrainingCourse_Approval)
        {
            bool isAdded = false;
            string SpName = "usp_InsertTrainingCourse_Approval";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objTrainingCourse_Approval, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateTrainingCourse_Approval(clsTrainingCourse_Approval objTrainingCourse_Approval)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateTrainingCourse_Approval";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objTrainingCourse_Approval, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteTrainingCourse_Approval(int?  MDETCourseApprId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteTrainingCourse_Approval";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(MDETCourseApprId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@MDETCourseApprId", MDETCourseApprId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateTrainingCourse_Approval(clsTrainingCourse_Approval objTrainingCourse_Approval)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateTrainingCourse_Approval";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objTrainingCourse_Approval, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicTrainingCourse_Approval(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteTrainingCourse_ApprovalDynamic";
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
		
		
