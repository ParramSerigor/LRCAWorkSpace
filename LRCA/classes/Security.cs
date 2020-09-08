using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using LRCA.classes;

/// <summary>
/// Summary description for Security
/// </summary>
public class Security
{
	public Security()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string CheckByRegex(string inputStr,string TypeOfFunction)
    {
        try
        {
            if (TypeOfFunction == "Name")
            {
                RegexStringValidator regName = new RegexStringValidator(@"^[a-zA-Z''-'\s]{1,40}$");
                regName.Validate(inputStr);

            }
            else if (TypeOfFunction == "SSN")
            {
                RegexStringValidator regSSN = new RegexStringValidator(@"^\d{3}-\d{2}-\d{4}$");
                regSSN.Validate(inputStr);
            }
            else if (TypeOfFunction == "Phone")
            {
                RegexStringValidator regPhone = new RegexStringValidator(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$");
                regPhone.Validate(inputStr);
            }
            else if (TypeOfFunction == "Email")
            {
                RegexStringValidator regEmail = new RegexStringValidator(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
                regEmail.Validate(inputStr);

            }
            else if (TypeOfFunction == "URL")
            {
                RegexStringValidator regURL = new RegexStringValidator(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$");
                regURL.Validate(inputStr);
            }
            else if (TypeOfFunction == "Password")
            {
                RegexStringValidator regPassword = new RegexStringValidator(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$");
                regPassword.Validate(inputStr);
            }
            else if (TypeOfFunction == "integer") // Non negative Integers
            {
                RegexStringValidator regPInteger = new RegexStringValidator(@"^\d+$");
                regPInteger.Validate(inputStr);
            }
            else if (TypeOfFunction == "Currency") // Non negative Currency
            {
                RegexStringValidator regCurrency = new RegexStringValidator(@"^\d+(\.\d\d)?$");
                regCurrency.Validate(inputStr);
            }
            else if (TypeOfFunction == "CurrencyPN") // Both positive and negative Currency
            {
                RegexStringValidator regCurrencyPN = new RegexStringValidator(@"^(-)?\d+(\.\d\d)?$");
                regCurrencyPN.Validate(inputStr);
            }
            return inputStr;
        }
        catch (ArgumentException e)
        {
            //return e.Message.ToString();
            return "false";
        }
    }
    //********************************************
    public string SafeSqlLiteral(string inputSQL)
    {
        if (!String.IsNullOrEmpty(inputSQL))
        {
            if(inputSQL == "'")
            {
                return inputSQL.Replace("'", "~");
            }
            else if (inputSQL == "&")
            {
                return inputSQL.Replace("&", "^^");
            }
            else
            {
                return inputSQL;
            }
        }
        else
        {
            return inputSQL;
        }

    }
    public string NumberGenerator(int HowManyChars)
    {
        string strReturnVal = "";

        Random rng = new Random();
        for (int i = 0; i < HowManyChars; i++)
        {
            strReturnVal = rng.Next(1, 10) + strReturnVal;
        }
        return strReturnVal;
    }
    //********************************************
    public string KillChars(string StrWords)
    {
        string NewChars = "";
        string ValSelect = "select";
        string ValDrop = "drop";
        string ValInsert = "insert";
        string ValDelete = "delete";
        string ValXp = "xp_";
        string ValDashes = "--";
        string ValSemi = ";";
        string ValAppost = "'";

        string[] arrBadChars = {"select", "drop", ";", "--", "insert", "delete", "xp_"};
        
        if (!String.IsNullOrEmpty(StrWords))
        {
            if (StrWords.Contains(ValDrop))
            {
                NewChars = StrWords.Replace(ValDrop, "");
            }
            else if (StrWords.Contains(ValSelect))
            {
                NewChars = StrWords.Replace(ValSelect, "");
            }
            else if (StrWords.Contains(ValInsert))
            {
                NewChars = StrWords.Replace(ValInsert, "");
            }
            else if (StrWords.Contains(ValDelete))
            {
                NewChars = StrWords.Replace(ValDelete, "");
            }
            else if (StrWords.Contains(ValXp))
            {
                NewChars = StrWords.Replace(ValXp, "");
            }
            else if (StrWords.Contains(ValDashes))
            {
                NewChars = StrWords.Replace(ValDashes, "");
            }
            else if (StrWords.Contains(ValSemi))
            {
                NewChars = StrWords.Replace(ValSemi, "");
            }
            else if (StrWords.Contains(ValAppost))
            {
                NewChars = StrWords.Replace(ValAppost, "''");
            }
            else
            {
                NewChars = StrWords;
            }
            return NewChars;
        }
        else
        {
            return StrWords;
        }
    }
    public string CheckRequest(string strRequest, string DoWhat)
    {
        string strValue = "";
        string strRequestIn = "";
        CryptoJS objcryptoJS = new CryptoJS();

        strRequestIn = strRequestIn + strRequest;

        if (strRequestIn.Length > 0)
        {
            if (DoWhat == "Encrypt")
            {
                strValue = objcryptoJS.AES_encrypt(strRequestIn.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();
            }
            else if (DoWhat == "Decrypt")
            {
                strValue = objcryptoJS.AES_decrypt(strRequestIn.ToString(), AppConstants.secretKey, AppConstants.initVec).ToString();
            }
        }
        else
        {
            strValue = "0";
        }
        return strValue;
    }
    public bool CheckFileType(string ext)
    {
        string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "doc", "xls", "pdf" ,"JPG", "GIF", "PNG", "BMP", "JPEG", "DOC", "XLS", "PDF", "BMP" };
        bool isValidFile = false;
        //string ext = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
        if (ext.ToLower().IndexOf('.') != -1)
        {
            for (int i = 0; i < validFileTypes.Length; i++)
            {

                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }

            }
        }
        else
        {
            for (int i = 0; i < validFileTypes.Length; i++)
            {

                if (ext == validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }

            }
        }

        
        return isValidFile;
    }
    public string UrlEncode(string encode)
    {
        if (encode == null) return null;
        string encoded = "";

        foreach (char c in encode)
        {
            int val = (int)c;
            if (val == 32 || val == 45 || (val >= 48 && val <= 57) || (val >= 65 && val <= 90) || (val >= 97 && val <= 122))
                encoded += c;
            else
                encoded += "%" + val.ToString("X");
        }

        // Fix MS BS
        encoded = encoded.Replace("%25", "-25").Replace("%2A", "-2A").Replace("%26", "-26").Replace("%3A", "-3A");

        return encoded;
    }
    public string UrlDecode(string decode)
    {
        if (decode == null) return null;
        // Fix MS BS
        decode = decode.Replace("-25", "%25").Replace("-2A", "%2A").Replace("-26", "%26").Replace("-3A", "%3A");

        return HttpUtility.UrlDecode(decode);
    }
}
