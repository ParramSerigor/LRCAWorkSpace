using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for SQLHelper
/// </summary>
public class SQLHelper
{
	public SQLHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /// <summary>
    /// Replace EOF (case-insensitive) with the empty string.
    /// Replace nulls and "" with the empty string.
    /// If neither of the above, trim the string,
    /// and if not empty, return its value.
    /// </summary>
    /// <param name="strString">Any string you would like to remove EOF from.</param>
    /// <returns>A string that is not EOF</returns>
    public static string TrimAndReplaceEOF(string strString)
    {
        if (strString == null || strString.Length == 0)
        {
            return String.Empty;
        }
        strString = strString.Trim();
        if (strString.Length > 3)
        {
            return strString;
        }
        if (strString.ToLower().Equals("eof"))
        {
            return String.Empty;
        }
        return strString;
    }
    /// <summary>
    /// cleanSQL will strip your SQL of bad characters and try to prevent SQL injection
    /// </summary>
    /// <param name="strSQLIn">A string containing your SQL command</param>
    /// <returns>The string you put in, but safe for SQL</returns>
    public static string cleanSQL(string strSQLIn)
    {
        string strSQLOut = strSQLIn.Replace("'", "''");
        return strSQLOut;
    }
}

