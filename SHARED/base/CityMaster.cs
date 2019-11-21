using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SHARED
{
    public partial class CityMaster
    {
        [DataMember]
        public int CITY_ID { get; set; }
        [DataMember]
        public string CITYCODE { get; set; }
        [DataMember]
        public string CITYNAME { get; set; }
        [DataMember]
        public string CITYDESC { get; set; }
        [DataMember]
        public int STATE_ID { get; set; }
        [DataMember]
        public bool ISACTIVE { get; set; }
        [DataMember]
        public string CREATEDBY { get; set; }
        [DataMember]
        public DateTime CREATEDDATE { get; set; }
        [DataMember]
        public string MODIFIEDBY { get; set; }
        [DataMember]
        public DateTime MODIFIEDDATE { get; set; }

    }
}
