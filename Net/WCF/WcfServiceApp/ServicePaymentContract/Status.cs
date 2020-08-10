using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServicePaymentContract
{
    [DataContract]
    public class Status
    {
        Int64 id;
        string StatusDesc;
        [DataMember]
        public long Id { get => id; set => id = value; }
        [DataMember] 
        public string StatusDesc1 { get => StatusDesc; set => StatusDesc = value; }
    }
}
