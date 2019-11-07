using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED;
using BAL;
using System.Data;

namespace SERVICES
{
    public class FeeSrv : IFeeSrv
    {
        string ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public string SaveFeeTerm(FeeHead FH)
        {
            BALFee bal = new BALFee(ConStr);
            return bal.SaveFeeTerm(FH);
        }
        public List<FeeHead> GetFeeHeads(FeeHead FH)
        {
            BALFee bal = new BALFee(ConStr);
            return bal.GetFeeHeads(FH);
        }
    }
}
