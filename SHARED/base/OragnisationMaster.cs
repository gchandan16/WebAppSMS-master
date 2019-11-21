using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SHARED
{

    public partial class OragnisationMaster
    {
        [DataMember]
        public int OMID { get; set; }
        [DataMember]
        public string Oname { get; set; }
        [DataMember]
        public string BOAddress { get; set; }
        [DataMember]
        public string BOAddress2 { get; set; }
        [DataMember]
        public int  BOCity { get; set; }
        [DataMember]
        public string BOPincode { get; set; }
        [DataMember]
        public int LCountry { get; set; }
        [DataMember]
        public int LState { get; set; }
        [DataMember]
        public string LDistict { get; set; }
        [DataMember]
        public string LArea { get; set; }
        [DataMember]
        public string LEmailId { get; set; }
        [DataMember]
        public string LMobile { get; set; }
        [DataMember]
        public string LPhone { get; set; }
        [DataMember]
        public string LWebsite { get; set; }
        [DataMember]
        public string OAfficilate { get; set; }
        [DataMember]
        public string OlicNo { get; set; }
        [DataMember]
        public string OTaxNo { get; set; }
        [DataMember]
        public string OPanNo { get; set; }
        [DataMember]
        public string OContactNo { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public DateTime Createddate { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTime Modifieddate { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public string OrgImage { get; set; }



    }
}
