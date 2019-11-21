using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SHARED
{
    public partial class CountryMaster
    {
        [DataMember]
        public int COUNTRY_ID { get; set; }
        [DataMember]
        public string COUNTRYNAME { get; set; }
        [DataMember]
        public string COUNTRYDESC { get; set; }
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
        [DataMember]
        public string COUNTRYCODE { get; set; }

    }
}
