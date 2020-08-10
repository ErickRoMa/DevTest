using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServicePaymentContract
{
    [DataContract]
    public class Payment
    {
        Int64 id;
        string description;
        double amount;
        Int64 userId;
        Int64 statusId;
        Int64 beneficiaryId;

        [DataMember] public long Id { get => id; set => id = value; }
        [DataMember] public string Description { get => description; set => description = value; }
        [DataMember] public double Amount { get => amount; set => amount = value; }
        [DataMember] public long UserId { get => userId; set => userId = value; }
        [DataMember] public long StatusId { get => statusId; set => statusId = value; }
        [DataMember] public long BeneficiaryId { get => beneficiaryId; set => beneficiaryId = value; }
    }
}
