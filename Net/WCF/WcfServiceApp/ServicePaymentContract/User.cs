using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServicePaymentContract
{
    [DataContract]
    public class User
    {
        Int64 ID;
        string name;

        [DataMember]
        public long ID1 { get => ID; set => ID = value; }
        [DataMember] 
        public string Name { get => name; set => name = value; }
    }
}
