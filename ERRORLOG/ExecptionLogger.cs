using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;
using System.Diagnostics;
namespace ERROR
{
    public class ExecptionLogger
    {
        //public static string get_Error_Det(string Err_code)
        //{
        //    string s = Error_Resource.ResourceManager.GetString(Err_code);
        //    return s;
        //}
        public static void FileHandling(string Err_Service, string Err_Code, Exception Err_Msg, string Err_Module)
        {
            try
            {
                //Error Details
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(Err_Msg, true);
                string ErrorLineNo =  (trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber()).ToString();
                string Err_Source = (trace.GetFrame((trace.FrameCount - 1)).GetFileName()).ToString();

                //try
                //{
                //    StackFrame stackFrame = new StackFrame(1, true);
                   
                //    Err_Source = stackFrame.GetMethod().ToString();
                //    ErrorLineNo = stackFrame.GetFileLineNumber().ToString();

                //    Err_Source = (trace.GetFrame((trace.FrameCount - 1)).GetFileName()).ToString();
                //    ErrorLineNo = (trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber()).ToString();
                //}
                //catch { }
                // Specify a "currently active folder" 
                string activeDir = @"C:\ExceptionLogger\" + DateTime.Now.Date.ToString("dd-MMM-yyyy");
                // Creating the folder
                DirectoryInfo objDirectoryInfo = new DirectoryInfo(activeDir);
                if (!Directory.Exists(objDirectoryInfo.FullName))
                {
                    string newPath = "", newFileName = "";
                    try
                    {
                        // Create a new file name. This example generates 
                        Directory.CreateDirectory(activeDir);
                        newFileName = Path.GetFileName(Err_Service.ToString() + ".txt");
                        // Combine the new file name with the path
                        newPath = Path.Combine(activeDir, newFileName);
                    }
                    catch (Exception ex)
                    {
                        string activeDir2 = @"C:\ExceptionLogger\" + DateTime.Now.Date.ToString("dd-MMM-yyyy");
                        DirectoryInfo objDirectoryInfo2 = new DirectoryInfo(activeDir2);
                        // Create a new file name. This example generates
                        Directory.CreateDirectory(activeDir2);
                        newFileName = Path.GetFileName(Err_Service.ToString() + ".txt");
                        // Combine the new file name with the path
                        newPath = Path.Combine(activeDir2, newFileName);
                    }
                    //// Create a new file name. This example generates 
                    //string newFileName = Path.GetFileName(Err_Service.ToString() + ".txt");
                    //// Combine the new file name with the path
                    //string newPath = Path.Combine(activeDir, newFileName);
                    FileStream fs = new FileStream(newPath, FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("Time:" + DateTime.Now.ToString());
                    sw.Write(sw.NewLine);
                    sw.WriteLine("Error Code" + Err_Code);
                    sw.Write(sw.NewLine);
                    sw.WriteLine("Actual Error Message:" + Err_Msg.Message);
                    sw.Write(sw.NewLine);
                    sw.WriteLine("User Friendly Message:Error_001");// + get_Error_Det(Err_Code));
                    sw.Write(sw.NewLine);
                    sw.WriteLine("Errror Source:" + Err_Source);
                    sw.Write(sw.NewLine);
                    sw.WriteLine("Error Module:" + Err_Module);
                    sw.Write(sw.NewLine);
                    sw.WriteLine("Error LineNo:" + ErrorLineNo);
                    sw.Write(sw.NewLine);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
                else
                {
                    string newFileName = Path.GetFileName(Err_Service.ToString() + ".txt");
                    // Combine the new file name with the path
                    string newPath = Path.Combine(activeDir, newFileName);
                    FileStream fs = new FileStream(newPath, FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(sw.NewLine);
                    sw.WriteLine("Time:" + DateTime.Now.ToString());
                    sw.Write(sw.NewLine);
                    sw.WriteLine("Error Code" + Err_Code);
                    sw.Write(sw.NewLine);
                    sw.WriteLine("Actual Error Message:" + Err_Msg.Message);
                    sw.Write(sw.NewLine);
                    //  sw.WriteLine("User Friendly Message:" + get_Error_Det(Err_Code));
                    sw.WriteLine("User Friendly Message:" + Err_Msg.InnerException);
                    sw.Write(sw.NewLine);
                    sw.WriteLine("Errror Source:" + Err_Source);
                    sw.Write(sw.NewLine);
                    sw.WriteLine("Error Module:" + Err_Module);
                    sw.Write(sw.NewLine);
                    sw.WriteLine("Error LineNo:" + ErrorLineNo);
                    sw.Write(sw.NewLine);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    
                    //}

                }
            }
            catch (Exception ex)
            {
                try
                {
                    string dir1 = "";
                    string newPath1 = "";
                    string newPathResp1 = "";
                    ////dir = HttpContext.Current.Server.MapPath("~/ImportPnrXml/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + dicCode.Trim());
                    dir1 = @"C:\ImportPnrXml\" + DateTime.Now.ToString("dd-MM-yyyy") + "\\";//System.Configuration.ConfigurationManager.AppSettings["ImportXmlPath"].ToString().Trim(); //
                    if (!Directory.Exists(dir1))
                    {
                        Directory.CreateDirectory(dir1);
                    }
                    newPath1 = Path.Combine(dir1, "Error_Log" + "_" + DateTime.Now.ToString("hh_mm_ss_tt") + "_Error_Log.xml");
                    newPathResp1 = Path.Combine(dir1, "Error_Log" + "_" + DateTime.Now.ToString("hh_mm_ss_tt") + "_Error_Log_Response.xml");
                    FileStream fs1 = new FileStream(newPathResp1, FileMode.CreateNew, FileAccess.Write);
                    StreamWriter sw1 = new StreamWriter(fs1);
                    System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(Err_Msg, true);
                    string ErrorLineNo = (trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber()).ToString();
                    string Err_Source = (trace.GetFrame((trace.FrameCount - 1)).GetFileName()).ToString();
                    sw1.Write(ex.Message + " " + ex + ex.StackTrace +"LineNo"+ ErrorLineNo + Err_Source);
                    sw1.Flush();
                    sw1.Close();
                    fs1.Close();
                }
                catch {

                    //string dir1 = "";
                    //string newPath1 = "";
                    //string newPathResp1 = "";
                    //////dir = HttpContext.Current.Server.MapPath("~/ImportPnrXml/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + dicCode.Trim());
                    //dir1 = @"C:\ImportPnrXml\" + DateTime.Now.ToString("dd-MM-yyyy") + "\\";//System.Configuration.ConfigurationManager.AppSettings["ImportXmlPath"].ToString().Trim(); //
                    //if (!Directory.Exists(dir1))
                    //{
                    //    Directory.CreateDirectory(dir1);
                    //}
                    //newPath1 = Path.Combine(dir1, "Error_Log" + "_" + DateTime.Now.ToString("hh_mm_ss_tt") + "_Error_Log_K.xml");
                    //newPathResp1 = Path.Combine(dir1, "Error_Log" + "_" + DateTime.Now.ToString("hh_mm_ss_tt") + "_Error_Log_Response_K.xml");
                    //FileStream fs1 = new FileStream(newPathResp1, FileMode.CreateNew, FileAccess.Write);
                    //StreamWriter sw1 = new StreamWriter(fs1);
                    ////System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(Err_Msg, true);
                    ////string ErrorLineNo = (trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber()).ToString();
                    ////string Err_Source = (trace.GetFrame((trace.FrameCount - 1)).GetFileName()).ToString();
                    //sw1.Write(ex.Message + " " + ex + ex.StackTrace);
                    //sw1.Flush();
                    //sw1.Close();
                    //fs1.Close();
                }
            }
        }
    }
}
