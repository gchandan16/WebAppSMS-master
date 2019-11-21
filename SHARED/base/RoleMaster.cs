using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SHARED
{
   public partial class RoleMaster
{
        [DataMember]
        public int ROLE_ID { get; set; }
        [DataMember]
        public string ROLENAME { get; set; }
        [DataMember]
        public string ROLEDESCRIPTION { get; set; }
        [DataMember]
        public string ISACTIVE { get; set; }
        [DataMember]
        public string CREATEDBY { get; set; }
        [DataMember]
        public Nullable<System.DateTime> CREATEDDATE { get; set; }

    }
}
