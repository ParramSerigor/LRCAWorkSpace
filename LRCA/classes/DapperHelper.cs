using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LRCA.classes
{
    public class DapperHelper
    {
        /// <summary>
        /// This function is good for Running Insert, Delete and or updates.
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static bool RunSingleQuery(string SQL)
        {
            bool isUpdated = false;
            string SpName = SQL;
            try
            {
                using (IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["databaseConnection"]))
                {
                    db.Execute(SpName, null, commandType: CommandType.Text);
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
    }
}