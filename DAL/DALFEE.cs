using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED;
using System.Data.SqlClient;
using System.Data;
using ERROR;

namespace DAL
{
    public class DALFee
    {
        private SqlDatabase DBHelper;
        private SqlCommand cmd = null;
        DataSet ds = null;
        public DALFee(string connectionstring)
        {
            DBHelper = new SqlDatabase(connectionstring);
        }
        public List<FeeHead> GetFeeHeads(FeeHead FH)
        {
            List<FeeHead> obj = new List<FeeHead>();
           
            try
            {
                cmd = new SqlCommand("USP_FEE_HEADS");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SchoolID", FH.SchoolID);
                cmd.Parameters.AddWithValue("@CreatedBy", FH.CreatedBy);
                cmd.Parameters.AddWithValue("@Action", FH.Action);
                var dr = DBHelper.ExecuteReader(cmd);
                while (dr.Read())
                {
                    obj.Add(new FeeHead
                    {
                        SchoolID = Convert.ToString(dr["SchoolID"]),
                        FeeTerm = Convert.ToString(dr["FeeTerm"]),
                        Active = Convert.ToBoolean(dr["Active"]),
                        Refundable = Convert.ToBoolean(dr["Refundable"]),
                        CreatedBy = Convert.ToString(dr["CreatedBy"]),
                    });
                }
            }
            catch (Exception ex)
            {
                ExecptionLogger.FileHandling("DALFee(SaveFeeTerm)", "Error_014", ex, "DALFee");
            }
            finally
            {
                cmd.Dispose();
            }
            return obj;
        }
        public string SaveFeeTerm(FeeHead FH)
        {
            string result = "";
            try
            {
                cmd = new SqlCommand("USP_FEE_HEADS");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FeeTerm", FH.FeeTerm);
                cmd.Parameters.Add("@Refundable", SqlDbType.Int, Convert.ToInt32(FH.Refundable));
                cmd.Parameters.Add("@Active", SqlDbType.Int,Convert.ToInt32(FH.Active));
                cmd.Parameters.AddWithValue("@SchoolID", FH.SchoolID);
                cmd.Parameters.AddWithValue("@CreatedBy", FH.CreatedBy);
                cmd.Parameters.AddWithValue("@Action", FH.Action);
                result = Convert.ToString(DBHelper.ExecuteScalar(cmd));
            }
            catch (Exception ex)
            {
                ExecptionLogger.FileHandling("DALFee(SaveFeeTerm)", "Error_014", ex, "DALFee");
            }
            finally
            {
                cmd.Dispose();
            }
            return result;
        }
    }
}
