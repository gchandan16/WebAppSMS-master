using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using SHARED;

namespace BAL
{
    [Serializable()]
    public class Utility
    {
        #region comment
        //#region String Utility Functions
        //public static string[] Split(string input, string seperator)
        //{
        //    return input.Split(new string[1] { seperator }, StringSplitOptions.None);
        //}
        //public static bool SaveTextToFile(string strData, string FullPath, ref string ErrInfo)
        //{
        //    string Contents = null;
        //    bool Saved = false;
        //    StreamWriter objReader = default(StreamWriter);
        //    try
        //    {
        //        objReader = new StreamWriter(FullPath);
        //        objReader.Write(strData);
        //        objReader.Close();
        //        Saved = true;
        //    }
        //    catch (Exception Ex)
        //    {
        //        ErrInfo = Ex.Message;
        //    }
        //    return Saved;
        //}

        //public static string datecon(string MM)
        //{
        //    string mm_str = "";
        //    switch (MM)
        //    {
        //        case "01":
        //            mm_str = "JAN";
        //            break;
        //        case "02":
        //            mm_str = "FEB";
        //            break;
        //        case "03":
        //            mm_str = "MAR";
        //            break;
        //        case "04":
        //            mm_str = "APR";
        //            break;
        //        case "05":
        //            mm_str = "MAY";
        //            break;
        //        case "06":
        //            mm_str = "JUN";
        //            break;
        //        case "07":
        //            mm_str = "JUL";
        //            break;
        //        case "08":
        //            mm_str = "AUG";
        //            break;
        //        case "09":
        //            mm_str = "SEP";
        //            break;
        //        case "10":
        //            mm_str = "OCT";
        //            break;
        //        case "11":
        //            mm_str = "NOV";
        //            break;
        //        case "12":
        //            mm_str = "DEC";
        //            break;
        //        default:

        //            break;
        //    }

        //    return mm_str;

        //}


        //#endregion

        //internal static string[] Split(string allowedChars1, char[] sep)
        //{
        //    throw new NotImplementedException();
        //}

        //public static string GetRandomNumber(string allowedChars1)
        //{

        //    char[] sep = { ',' };

        //    string[] arr = allowedChars1.Split(sep);

        //    string rndString = "";

        //    string temp = "";

        //    Random rand = new Random();

        //    for (int i = 0; i <= 4; i++)
        //    {
        //        temp = arr[rand.Next(0, arr.Length)];
        //        rndString += temp;
        //    }

        //    return rndString;

        //}

        //public static string GetRndm()
        //{

        //    string allowedChars = "";

        //    allowedChars = "1,2,3,4,5,6,7,8,9,0";

        //    string rnmd2 = GetRandomNumber(allowedChars);

        //    return rnmd2;

        //}
        //# region SerializeAnObject
        //public string SerializeAnObject(object obj, string R)
        //{
        //    string newFileName = R + DateTime.Now.ToString("hh:mm:ss");
        //    string xml = "";
        //    XmlDocument doc = new XmlDocument();
        //    XmlSerializer serializer = new XmlSerializer(obj.GetType());
        //    System.IO.MemoryStream stream = new System.IO.MemoryStream();
        //    try
        //    {
        //        //string activeDir = @"D:\Req_Res_Abacus\" + DateTime.Now.ToString("dd-MMMM-yyyy") + @"\";
        //        string activeDir = ConfigurationManager.AppSettings["AbacusSaveUrl"] + DateTime.Now.ToString("dd-MMMM-yyyy") + @"\";

        //        DirectoryInfo objDirectoryInfo = new DirectoryInfo(activeDir);
        //        if (!Directory.Exists(objDirectoryInfo.FullName))
        //        {
        //            Directory.CreateDirectory(activeDir);
        //        }


        //        serializer.Serialize(stream, obj);
        //        stream.Position = 0;
        //        doc.Load(stream);
        //        doc.Save(activeDir + newFileName.Replace(":", "") + ".xml");
        //        xml = doc.InnerXml.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    finally
        //    {
        //        stream.Close();
        //        stream.Dispose();
        //    }
        //    return xml;
        //}
        //# endregion
        //public static string ConvertToAgeFromDOB(string birthday)
        //{
        //    //IFormatProvider culture = new CultureInfo("en-US", true);
        //    //DateTime dt = DateTime.Parse(birthday, culture);

        //    DateTime data;//= Convert.ToDateTime(birthday);
        //    DateTime.TryParseExact(birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data);
        //    DateTime now = DateTime.Today;
        //    int age = now.Year - data.Year;
        //    if (now < data.AddYears(age)) age--;
        //    if (age.ToString().Length == 1)
        //        return "0" + age.ToString();
        //    else
        //        return age.ToString();
        //}

        //public static System.Boolean IsNumeric(System.Object Expression)
        //{
        //    if (Expression == null || Expression is DateTime)
        //        return false;

        //    if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
        //        return true;

        //    try
        //    {
        //        if (Expression is string)
        //            Double.Parse(Expression as string);
        //        else
        //            Double.Parse(Expression.ToString());
        //        return true;
        //    }
        //    catch { return false; }

        //}


        ////public static string GetFlightTrackID()
        ////{
        ////    LNBDataAccess.FlightSearchDAL fsDal = new LNBDataAccess.FlightSearchDAL();

        ////    return fsDal.GetFlightTrackID();
        ////}


        //public static string GenerateTrackId()
        //{
        //    string strRndKey = "";
        //    strRndKey = UsingGuid() + RNGCharacterMask();
        //    // & "-" & UsingTicks() & "-" & UsingDateTime()
        //    return strRndKey;
        //}

        //private static string UsingGuid()
        //{
        //    string result = Guid.NewGuid().ToString().GetHashCode().ToString("x").ToUpper();
        //    return result;
        //}

        //public static string GenerateNumberTenDigit()
        //{
        //    Random random = new Random();
        //    string r = "";
        //    int i;
        //    for (i = 1; i < 11; i++)
        //    {
        //        r += random.Next(1, 9).ToString();
        //    }
        //    return r;
        //}
        //private static string RNGCharacterMask()
        //{
        //    int maxSize = 5;
        //    char[] chars = new char[62];
        //    string a = null;
        //    a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //    chars = a.ToCharArray();
        //    int size = maxSize;
        //    byte[] data = new byte[1];
        //    RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        //    crypto.GetNonZeroBytes(data);
        //    size = maxSize;
        //    data = new byte[size];
        //    crypto.GetNonZeroBytes(data);
        //    StringBuilder result = new StringBuilder(size);
        //    foreach (byte b in data)
        //    {
        //        result.Append(chars[b % (chars.Length - 1)]);
        //    }
        //    return result.ToString();
        //}

        //public static DateTime ConvertToDateTime(string dateDDMMYYYY, char seprator)
        //{

        //    char[] sep = { seprator };
        //    string[] datepart = dateDDMMYYYY.Split(sep, StringSplitOptions.RemoveEmptyEntries);

        //    DateTime result = new DateTime(Convert.ToInt16(datepart[2]), Convert.ToInt16(datepart[1]), Convert.ToInt16(datepart[0]));
        //    return result;


        //}

        //public static string GetTimeInHrsAndMin(int min)
        //{
        //    string rslt;
        //    if (min < 60)
        //    {
        //        rslt = "00:" + min.ToString("00");
        //    }
        //    else
        //    {
        //        int hrs = min / 60;
        //        int rmin = min % 60;

        //        rslt = hrs.ToString("00") + ":" + rmin.ToString("00");
        //    }

        //    return rslt;

        //}

        //public static string GetCityName(string city, List<FlightCityList> CityList)
        //{
        //    string city1 = "";
        //    try
        //    {
        //        city1 = ((from ct in CityList where ct.AirportCode == city select ct).ToList())[0].City;
        //    }
        //    catch { city1 = city; }
        //    return city1;
        //}
        //public static string RemoveAlpha(string s)
        //{
        //    return Regex.Replace(s, "[A-Za-z]", "");
        //}
        //public static string RemoveNumber(string s)
        //{
        //    return Regex.Replace(s, @"[\d-]", string.Empty).Trim();
        //}
        //public static string MonNameByDate(string MM)
        //{
        //    string mm_str = "";
        //    switch (MM)
        //    {
        //        case "01":
        //            mm_str = "JAN";
        //            break;
        //        case "02":
        //            mm_str = "FEB";
        //            break;
        //        case "03":
        //            mm_str = "MAR";
        //            break;
        //        case "04":
        //            mm_str = "APR";
        //            break;
        //        case "05":
        //            mm_str = "MAY";
        //            break;
        //        case "06":
        //            mm_str = "JUN";
        //            break;
        //        case "07":
        //            mm_str = "JUL";
        //            break;
        //        case "08":
        //            mm_str = "AUG";
        //            break;
        //        case "09":
        //            mm_str = "SEP";
        //            break;
        //        case "10":
        //            mm_str = "OCT";
        //            break;
        //        case "11":
        //            mm_str = "NOV";
        //            break;
        //        case "12":
        //            mm_str = "DEC";
        //            break;
        //        default:

        //            break;
        //    }

        //    return mm_str;

        //}

        //public static string RNGNumberMask()
        //{
        //    int maxSize = 10;
        //    int minSize = 10;
        //    char[] chars = new char[62];
        //    string a = null;
        //    //a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //    a = "123456789";
        //    chars = a.ToCharArray();
        //    int size = maxSize;
        //    byte[] data = new byte[1];
        //    RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        //    crypto.GetNonZeroBytes(data);
        //    size = maxSize;
        //    data = new byte[size];
        //    crypto.GetNonZeroBytes(data);
        //    StringBuilder result = new StringBuilder(size);
        //    foreach (byte b in data)
        //    {
        //        result.Append(chars[b % (chars.Length - 1)]);
        //    }
        //    return result.ToString();
        //}
        //public static string RemoveXMLInvalidCharacters(string inString)
        //{
        //    // if (inString == null) return null;
        //    inString = inString.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
        //    return inString.ToString();

        //}
        //public static string EncryptAES(string clearText)
        //{
        //    string EncryptionKey = "MAKV2SPBNI99212";
        //    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new
        //            Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(clearBytes, 0, clearBytes.Length);
        //                cs.Close();
        //            }
        //            clearText = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }
        //    return clearText;
        //}
        //public static string DecryptAES(string cipherText)
        //{
        //    string EncryptionKey = "MAKV2SPBNI99212";
        //    byte[] cipherBytes = Convert.FromBase64String(cipherText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new
        //            Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(cipherBytes, 0, cipherBytes.Length);
        //                cs.Close();
        //            }
        //            cipherText = Encoding.Unicode.GetString(ms.ToArray());
        //        }
        //    }
        //    return cipherText;
        //}
        //public static string RNGNumberMaskAES()
        //{
        //    int maxSize = 4;
        //    int minSize = 4;
        //    char[] chars = new char[62];
        //    string a = null;
        //    //a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //    a = "123456789";
        //    chars = a.ToCharArray();
        //    int size = maxSize;
        //    byte[] data = new byte[1];
        //    RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        //    crypto.GetNonZeroBytes(data);
        //    size = maxSize;
        //    data = new byte[size];
        //    crypto.GetNonZeroBytes(data);
        //    StringBuilder result = new StringBuilder(size);
        //    foreach (byte b in data)
        //    {
        //        result.Append(chars[b % (chars.Length - 1)]);
        //    }
        //    return result.ToString();
        //}
        //#region[Encrypt decrypt functions]
        //public string EncryptAES_Link(string clearText)
        //{
        //    string EncryptionKey = "MAKV2SPBNI99212";
        //    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new
        //            Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(clearBytes, 0, clearBytes.Length);
        //                cs.Close();
        //            }
        //            clearText = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }
        //    return clearText;
        //}
        //public string DecryptAES_Link(string cipherText)
        //{
        //    string EncryptionKey = "MAKV2SPBNI99212";
        //    byte[] cipherBytes = Convert.FromBase64String(cipherText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new
        //            Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(cipherBytes, 0, cipherBytes.Length);
        //                cs.Close();
        //            }
        //            cipherText = Encoding.Unicode.GetString(ms.ToArray());
        //        }
        //    }
        //    return cipherText;
        //}
        //public string RNGNumberMaskAES_Link()
        //{
        //    int maxSize = 10;
        //    int minSize = 10;
        //    char[] chars = new char[62];
        //    string a = null;
        //    ////a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //    a = "123456789";
        //    chars = a.ToCharArray();
        //    int size = maxSize;
        //    byte[] data = new byte[1];
        //    RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        //    crypto.GetNonZeroBytes(data);
        //    size = maxSize;
        //    data = new byte[size];
        //    crypto.GetNonZeroBytes(data);
        //    StringBuilder result = new StringBuilder(size);
        //    foreach (byte b in data)
        //    {
        //        result.Append(chars[b % (chars.Length - 1)]);
        //    }
        //    return result.ToString();
        //}
        //#endregion
        //public static XDocument RemoveNamespace(XDocument xdoc)
        //{
        //    foreach (XElement e in xdoc.Root.DescendantsAndSelf())
        //    {
        //        if (e.Name.Namespace != XNamespace.None)
        //        {
        //            e.Name = XNamespace.None.GetName(e.Name.LocalName);
        //        }
        //        if (e.Attributes().Where(a => a.IsNamespaceDeclaration || a.Name.Namespace != XNamespace.None).Any())
        //        {
        //            e.ReplaceAttributes(e.Attributes().Select(a => a.IsNamespaceDeclaration ? null : a.Name.Namespace != XNamespace.None ? new XAttribute(XNamespace.None.GetName(a.Name.LocalName), a.Value) : a));
        //        }
        //    }

        //    return xdoc;
        //}
        //public static string DecryptAESSmart(string cipherText)
        //{
        //    string EncryptionKey = "MAKV2SITQPATGBTI99212";
        //    byte[] cipherBytes = Convert.FromBase64String(cipherText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new
        //            Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(cipherBytes, 0, cipherBytes.Length);
        //                cs.Close();
        //            }
        //            cipherText = Encoding.Unicode.GetString(ms.ToArray());
        //        }
        //    }
        //    return cipherText;
        //}
        //public static string EncryptAESSmart(string clearText)
        //{
        //    string EncryptionKey = "MAKV2SITQPATGBTI99212";
        //    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new
        //            Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(clearBytes, 0, clearBytes.Length);
        //                cs.Close();
        //            }
        //            clearText = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }
        //    return clearText;
        //}
        //private const string cardRegex = "^(?:(?<VI>4\\d{3})|(?<CA>5[1-5]\\d{2})|(?<Discover>6011)|(?<DinersClub>(?:3[68]\\d{2})|(?:30[0-5]\\d))|(?<AX>3[47]\\d{2}))([ -]?)(?(DinersClub)(?:\\d{6}\\1\\d{4})|(?(AX)(?:\\d{6}\\1\\d{5})|(?:\\d{4}\\1\\d{4}\\1\\d{4})))$";
        //public static CreditCardTypeType? GetCardTypeFromNumber(string cardNum)
        //{
        //    //Create new instance of Regex comparer with our
        //    //credit card regex patter
        //    Regex cardTest = new Regex(cardRegex);

        //    //Compare the supplied card number with the regex
        //    //pattern and get reference regex named groups
        //    GroupCollection gc = cardTest.Match(cardNum).Groups;

        //    //Compare each card type to the named groups to 
        //    //determine which card type the number matches
        //    if (gc[CreditCardTypeType.AX.ToString()].Success)
        //    {
        //        return CreditCardTypeType.AX;
        //    }
        //    else if (gc[CreditCardTypeType.CA.ToString()].Success)
        //    {
        //        return CreditCardTypeType.CA;
        //    }
        //    else if (gc[CreditCardTypeType.VI.ToString()].Success)
        //    {
        //        return CreditCardTypeType.VI;
        //    }
        //    //else if (gc[CreditCardTypeType.Discover.ToString()].Success)
        //    //{
        //    //    return CreditCardTypeType.Discover;
        //    //}
        //    else
        //    {
        //        return null;
        //    }
        //}
        //public static bool PassesLuhnTest(string cardNumber)
        //{
        //    //Clean the card number- remove dashes and spaces
        //    cardNumber = cardNumber.Replace("-", "").Replace(" ", "");

        //    //Convert card number into digits array
        //    int[] digits = new int[cardNumber.Length];
        //    for (int len = 0; len < cardNumber.Length; len++)
        //    {
        //        digits[len] = Int32.Parse(cardNumber.Substring(len, 1));
        //    }


        //    int sum = 0;
        //    bool alt = false;
        //    for (int i = digits.Length - 1; i >= 0; i--)
        //    {
        //        int curDigit = digits[i];
        //        if (alt)
        //        {
        //            curDigit *= 2;
        //            if (curDigit > 9)
        //            {
        //                curDigit -= 9;
        //            }
        //        }
        //        sum += curDigit;
        //        alt = !alt;
        //    }

        //    //If Mod 10 equals 0, the number is good and this will return true
        //    return sum % 10 == 0;
        //}
        //public static bool IsValidNumber(string cardNum, CreditCardTypeType? cardType)
        //{
        //    //Create new instance of Regex comparer with our 
        //    //credit card regex pattern
        //    Regex cardTest = new Regex(cardRegex);

        //    //Make sure the supplied number matches the supplied
        //    //card type
        //    if (cardTest.Match(cardNum).Groups[cardType.ToString()].Success)
        //    {
        //        //If the card type matches the number, then run it
        //        //through Luhn's test to make sure the number appears correct
        //        if (PassesLuhnTest(cardNum))
        //            return true;
        //        else
        //            //The card fails Luhn's test
        //            return false;
        //    }
        //    else
        //        //The card number does not match the card type
        //        return false;
        //}
        //public static string CheckCard(string cardNum)
        //{
        //    Regex cardTest = new Regex(cardRegex);

        //    //Determine the card type based on the number
        //    CreditCardTypeType? cardType = GetCardTypeFromNumber(cardNum);

        //    //Call the base version of IsValidNumber and pass the 
        //    //number and card type
        //    if (IsValidNumber(cardNum, cardType))
        //        return cardType.Value.ToString();
        //    else
        //        return "";
        //}
        //public static void WriteLog(string Module, string LogType, string Error)
        //{
        //    try
        //    {
        //        string dir = "";
        //        string newPath1 = "";
        //        //string newPathResp1 = "";
        //        ////dir = HttpContext.Current.Server.MapPath("~/ImportPnrXml/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + dicCode.Trim());
        //        dir = @"C:\Log\" + DateTime.Now.ToString("dd-MM-yyyy") + "\\";//System.Configuration.ConfigurationManager.AppSettings["ImportXmlPath"].ToString().Trim(); //
        //        if (!Directory.Exists(dir))
        //        {
        //            Directory.CreateDirectory(dir);
        //        }
        //        newPath1 = Path.Combine(dir, Module + "_" + DateTime.Now.ToString("hh_mm_ss_tt") + "" + LogType + ".txt");
        //        //  newPathResp1 = Path.Combine(dir, PCC + "_" + DateTime.Now.ToString("hh_mm_ss_tt") + "_RTVE_Response.txt");
        //        FileStream fs1 = new FileStream(newPath1, FileMode.CreateNew, FileAccess.Write);
        //        StreamWriter sw1 = new StreamWriter(fs1);
        //        sw1.Write(Module + " " + LogType + "Error" + Error);
        //        sw1.Flush();
        //        sw1.Close();
        //        fs1.Close();
        //    }
        //    catch (Exception ex) { }
        //}
        //public static void FileHandling_Utility(string Err_Service, string Err_Code, Exception Err_Msg, string Err_Module)
        //{
        //    try
        //    {
        //        //Error Details
        //        System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(Err_Msg, true);
        //        string ErrorLineNo = (trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber()).ToString();
        //        string Err_Source = (trace.GetFrame((trace.FrameCount - 1)).GetFileName()).ToString();

        //        // Specify a "currently active folder" 
        //        string activeDir = @"C:\ExceptionLogger_Utility\" + DateTime.Now.Date.ToString("dd-MMM-yyyy");
        //        // Creating the folder
        //        DirectoryInfo objDirectoryInfo = new DirectoryInfo(activeDir);
        //        if (!Directory.Exists(objDirectoryInfo.FullName))
        //        {
        //            string newPath = "", newFileName = "";
        //            try
        //            {
        //                // Create a new file name. This example generates 
        //                Directory.CreateDirectory(activeDir);
        //                newFileName = Path.GetFileName(Err_Service.ToString() + ".txt");
        //                // Combine the new file name with the path
        //                newPath = Path.Combine(activeDir, newFileName);
        //            }
        //            catch (Exception ex)
        //            {
        //                string activeDir2 = @"C:\ExceptionLogger_Utility\" + DateTime.Now.Date.ToString("dd-MMM-yyyy");
        //                DirectoryInfo objDirectoryInfo2 = new DirectoryInfo(activeDir2);
        //                // Create a new file name. This example generates
        //                Directory.CreateDirectory(activeDir2);
        //                newFileName = Path.GetFileName(Err_Service.ToString() + ".txt");
        //                // Combine the new file name with the path
        //                newPath = Path.Combine(activeDir2, newFileName);
        //            }
        //            //// Create a new file name. This example generates 
        //            //string newFileName = Path.GetFileName(Err_Service.ToString() + ".txt");
        //            //// Combine the new file name with the path
        //            //string newPath = Path.Combine(activeDir, newFileName);
        //            FileStream fs = new FileStream(newPath, FileMode.Append, FileAccess.Write);
        //            StreamWriter sw = new StreamWriter(fs);
        //            sw.WriteLine("Time:" + DateTime.Now.ToString());
        //            sw.Write(sw.NewLine);
        //            sw.WriteLine("Error Code" + Err_Code);
        //            sw.Write(sw.NewLine);
        //            sw.WriteLine("Actual Error Message:" + Err_Msg.Message);
        //            sw.Write(sw.NewLine);
        //            sw.WriteLine("User Friendly Message:Error_001");// + get_Error_Det(Err_Code));
        //            sw.Write(sw.NewLine);
        //            sw.WriteLine("Errror Source:" + Err_Source);
        //            sw.Write(sw.NewLine);
        //            sw.WriteLine("Error Module:" + Err_Module);
        //            sw.Write(sw.NewLine);
        //            sw.WriteLine("Error LineNo:" + ErrorLineNo);
        //            sw.Write(sw.NewLine);
        //            sw.Flush();
        //            sw.Close();
        //            fs.Close();
        //        }
        //        else
        //        {
        //            string newFileName = Path.GetFileName(Err_Service.ToString() + ".txt");
        //            // Combine the new file name with the path
        //            string newPath = Path.Combine(activeDir, newFileName);
        //            FileStream fs = new FileStream(newPath, FileMode.Append, FileAccess.Write);
        //            StreamWriter sw = new StreamWriter(fs);
        //            sw.Write(sw.NewLine);
        //            sw.WriteLine("Time:" + DateTime.Now.ToString());
        //            sw.Write(sw.NewLine);
        //            sw.WriteLine("Error Code" + Err_Code);
        //            sw.Write(sw.NewLine);
        //            sw.WriteLine("Actual Error Message:" + Err_Msg.Message);
        //            sw.Write(sw.NewLine);
        //            //  sw.WriteLine("User Friendly Message:" + get_Error_Det(Err_Code));
        //            sw.WriteLine("User Friendly Message:Error_001");
        //            sw.Write(sw.NewLine);
        //            sw.WriteLine("Errror Source:" + Err_Source);
        //            sw.Write(sw.NewLine);
        //            sw.WriteLine("Error Module:" + Err_Module);
        //            sw.Write(sw.NewLine);
        //            sw.WriteLine("Error LineNo:" + ErrorLineNo);
        //            sw.Write(sw.NewLine);
        //            sw.Flush();
        //            sw.Close();
        //            fs.Close();
        //            //}

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        #endregion comment
        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }
        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex, int endIndex)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable
            string result = param.Substring(startIndex, endIndex);
            //return the result of the operation
            return result;
        }
        private static string UsingGuid()
        {
            string result = Guid.NewGuid().ToString().GetHashCode().ToString("x").ToUpper();
            return result;
        }
        private static string RNGCharacterMask()
        {
            int maxSize = 5;
            char[] chars = new char[62];
            string a = null;
            a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }
        public static string GetRendomString(int length, string Type = "AN")
        {
            string result = "";
            try
            {
                if(Type == "AN")
                {
                    result = UsingGuid() + RNGCharacterMask();
                }
                else if (Type == "N")
                {
                    Random random = new Random();
                    
                    for (int i = 1; i <= length; i++)
                    {
                        result += random.Next(1, 9).ToString();
                    }
                }
                
            }
            catch(Exception ex) { result = ""; }
            return result;
        }
       
    }
}