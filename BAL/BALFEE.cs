using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED;
using DAL;
using System.Data;

namespace BAL
{
    public class BALFee
    { 
        string ConStr = "";
        public BALFee(string ConnectionString)
        {
            ConStr = ConnectionString;
        }
      
       
        public string SaveFeeTerm(FeeHead FH)
        {
            DALFee dal = new DALFee(ConStr);
            return dal.SaveFeeTerm(FH);
        }
        public List<FeeHead> GetFeeHeads(FeeHead FH)
        {
            DALFee dal = new DALFee(ConStr);
            return dal.GetFeeHeads(FH);
        }
    }
}
