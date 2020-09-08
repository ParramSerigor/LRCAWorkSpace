using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Validation
/// </summary>
public class Validation
{
	public Validation()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    // Function to test for Positive Integers.
    public bool IsNaturalNumber(String strNumber)
    {
        Regex objNotNaturalPattern = new Regex("[^0-9]");
        Regex objNaturalPattern = new Regex("0*[1-9][0-9]*");
        return !objNotNaturalPattern.IsMatch(strNumber) &&
        objNaturalPattern.IsMatch(strNumber);
    }
    // Function to test for Positive Integers with zero inclusive
    public bool IsWholeNumber(String strNumber)
    {
        Regex objNotWholePattern = new Regex("[^0-9]");
        return !objNotWholePattern.IsMatch(strNumber);
    }
    // Function to Test for Integers both Positive & Negative
    public bool IsInteger(String strNumber)
    {
        Regex objNotIntPattern = new Regex("[^0-9-]");
        Regex objIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");
        return !objNotIntPattern.IsMatch(strNumber) && objIntPattern.IsMatch(strNumber);
    }
    // Function to Test for Positive Number both Integer & Real
    public bool IsPositiveNumber(String strNumber)
    {
        Regex objNotPositivePattern = new Regex("[^0-9.]");
        Regex objPositivePattern = new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
        Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
        return !objNotPositivePattern.IsMatch(strNumber) &&
        objPositivePattern.IsMatch(strNumber) &&
        !objTwoDotPattern.IsMatch(strNumber);
    }
    // Function to test whether the string is valid number or not
    public bool IsNumber(String strNumber)
    {
        Regex objNotNumberPattern = new Regex("[^0-9.-]");
        Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
        Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
        String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
        String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
        Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");
        return !objNotNumberPattern.IsMatch(strNumber) &&
        !objTwoDotPattern.IsMatch(strNumber) &&
        !objTwoMinusPattern.IsMatch(strNumber) &&
        objNumberPattern.IsMatch(strNumber);
    }
    // Function To test for Alphabets.
    public bool IsAlpha(String strToCheck)
    {
        Regex objAlphaPattern = new Regex("[^a-zA-Z]");
        return !objAlphaPattern.IsMatch(strToCheck);
    }
    // Function to Check for AlphaNumeric.
    public bool IsAlphaNumeric(String strToCheck)
    {
        Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");
        return !objAlphaNumericPattern.IsMatch(strToCheck);
    }
    // Function to Check for AlphaNumeric.
    public bool IsAlphaNumericWithSpace(String strToCheck)
    {
        Regex objAlphaNumericPattern = new Regex("/s[^a-zA-Z0-9]");
        return !objAlphaNumericPattern.IsMatch(strToCheck);
    }
    // Function to Check for Date.
    public bool IsDate(String strToCheck)
    {
        DateTime showDate;
        bool isValid = DateTime.TryParse(strToCheck, out showDate);
        return isValid;
    }
    public bool IsEmail(string Email)
    {
        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(Email))
            return (true);
        else
            return (false);
    }

    public bool IsUrl(string Url)
    {
        string strRegex = "^(https?://)"
        + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@
        + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
        + "|" // allows either IP or domain
        + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
        + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // second level domain
        + "[a-z]{2,6})" // first level domain- .com or .museum
        + "(:[0-9]{1,4})?" // port number- :80
        + "((/?)|" // a slash isn't required if there is no file name
        + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
        Regex re = new Regex(strRegex);

        if (re.IsMatch(Url))
            return (true);
        else
            return (false);
    }

    /// <summary>
    /// stringToMixedCase will convert words written in all uppercase or all lowercase to mixed case
    /// </summary>
    /// <param name="strTmp">Any string you would like to convert to mixed case</param>
    /// <returns>The same string you sent it but in mixed case format</returns>
    public static string stringToMixedCase(string strInput)
    {
        int intStrLen = 0;
        string strOutput = "";
        string strChar = "";

        try
        {
            intStrLen = strInput.Length;

            if (intStrLen > 0)
            {
                for (int i = 0; i < intStrLen; i++)
                {
                    strChar = strInput.Substring(i, 1);
                    if (i == 0)
                    {
                        strChar = strChar.ToUpper();
                    }
                    else
                    {
                        strChar = strChar.ToLower();

                        if (i >= 3)
                        {
                            if (strInput.Substring(i - 3, 3) == " O'")
                            {
                                strChar = strChar.ToUpper();
                            }
                        }
                        if (i >= 2)
                        {
                            if (strInput.Substring(i - 2, 2) == "MC")
                            {
                                strChar = strChar.ToUpper();
                            }
                        }
                        if ((strInput.Substring(i - 1, 1) == " ") || (strInput.Substring(i - 1, 1) == "-"))
                        {
                            //checks if previous character was a space
                            strChar = strChar.ToUpper();
                        }
                    }

                    strOutput += strChar;
                }
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException("An error has occured when attempting to convert the text to mixed case.  Error: " + ex.Message);
        }
        return strOutput;
    }
}
