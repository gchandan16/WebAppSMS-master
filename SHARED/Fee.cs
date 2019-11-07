using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SHARED
{
    class Fee
    {
    }
   
    public class FeeHead : BaseModel
    {
        [DataMember]
        public string FeeTerm { get; set; }
        [DataMember]
        public bool Refundable { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public string SchoolID { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string Action { get; set; }
        [DataMember]
        public List<FeeHead> lstFeeHead { get; set; }
    }
}
