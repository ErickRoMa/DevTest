using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServicePaymentContract
{
    [DataContract]

    public class Beneficiary
    {
        Int64 id;
        string name;
        string account;
        double maxAmount;

        [DataMember]public long Id { get => id; set => id = value; }
        [DataMember]public string Name { get => name; set => name = value; }
        [DataMember]public string Account { get => account; set => account = value; }
        [DataMember]public double MaxAmount { get => maxAmount; set => maxAmount = value; }
    }
}
