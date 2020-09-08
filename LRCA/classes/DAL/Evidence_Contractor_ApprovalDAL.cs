
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
    public class Evidence_Contractor_ApprovalDAL
    {
	
		 public static clsEvidence_Contractor_Approval SelectEvidence_Contractor_ApprovalById(int?  ContractorEvidenceId)
        {
            clsEvidence_Contractor_Approval objEvidence_Contractor_Approval = new clsEvidence_Contractor_Approval();
            bool isnull = true;
            string SpName = "usp_SelectEvidence_Contractor_Approval";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ContractorEvidenceId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {     
                    objPar.Add("@ContractorEvidenceId", ContractorEvidenceId, dbType: DbType.Int32);

                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        objEvidence_Contractor_Approval = db.Query<clsEvidence_Contractor_Approval>(SpName, objPar, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
            else return objEvidence_Contractor_Approval;
        }
		
		public static List<clsEvidence_Contractor_Approval> SelectDynamicEvidence_Contractor_Approval(string WhereCondition, string OrderByExpression)
        {
            List<clsEvidence_Contractor_Approval> lstEvidence_Contractor_Approval = new List<clsEvidence_Contractor_Approval>();
            bool isnull = true;
            string SpName = "usp_SelectEvidence_Contractor_ApprovalDynamic";
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
                        lstEvidence_Contractor_Approval = db.Query<clsEvidence_Contractor_Approval>(SpName, objPar, commandType: CommandType.StoredProcedure).ToList();
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
            else return lstEvidence_Contractor_Approval;
        }
		
		public static List<clsEvidence_Contractor_Approval> SelectAllEvidence_Contractor_Approval()
        {
            List<clsEvidence_Contractor_Approval> lstEvidence_Contractor_Approval = new List<clsEvidence_Contractor_Approval>();
            bool isnull = true;
            string SpName = "usp_SelectEvidence_Contractor_ApprovalAll";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                   lstEvidence_Contractor_Approval = db.Query<clsEvidence_Contractor_Approval>(SpName, commandType: CommandType.StoredProcedure).ToList();
                }
                isnull = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorLogging(ex, false);
                ErrorHandler.ReadError();
            }
            if (isnull) return null;
            else return lstEvidence_Contractor_Approval;
        }
		
		public static Boolean InsertEvidence_Contractor_Approval(clsEvidence_Contractor_Approval objEvidence_Contractor_Approval)
        {
            bool isAdded = false;
            string SpName = "usp_InsertEvidence_Contractor_Approval";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objEvidence_Contractor_Approval, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean UpdateEvidence_Contractor_Approval(clsEvidence_Contractor_Approval objEvidence_Contractor_Approval)
        {
            bool isUpdated = false;
            string SpName = "usp_UpdateEvidence_Contractor_Approval";
                try
                {
                    using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                    {
                        db.Execute(SpName, objEvidence_Contractor_Approval, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteEvidence_Contractor_Approval(int?  ContractorEvidenceId)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteEvidence_Contractor_Approval";
            var objPar = new DynamicParameters();

            if (String.IsNullOrEmpty(ContractorEvidenceId.ToString()))
            {
                throw new ArgumentException("Function parameters cannot be blank!");
            }
            else
            {
                try
                {
                        #region This is when you want to delete the record from the database.
                            objPar.Add("@ContractorEvidenceId", ContractorEvidenceId, dbType: DbType.Int32);

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
		
		public static Boolean InsertUpdateEvidence_Contractor_Approval(clsEvidence_Contractor_Approval objEvidence_Contractor_Approval)
        {
            bool isAdded = false;
            string SpName = "usp_InsertUpdateEvidence_Contractor_Approval";
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, objEvidence_Contractor_Approval, commandType: CommandType.StoredProcedure);
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
		
		public static Boolean DeleteDynamicEvidence_Contractor_Approval(string WhereCondition)
        {
            bool isDeleted = false;
            string SpName = "usp_DeleteEvidence_Contractor_ApprovalDynamic";
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
		
		
