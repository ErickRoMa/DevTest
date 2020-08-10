using ServicePaymentContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfPayment
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPaymentSvc
    {
        [OperationContract] IList<User> GetUsers();
        [OperationContract] User GetUser(Int64 userId);
        [OperationContract] IList<Status> GetStatuses();
        [OperationContract] IList<Payment> GetPayments();
        [OperationContract] void SetPayment(IList<Payment> payments);
        [OperationContract] IList<Beneficiary> GetBeneficiaries();
        [OperationContract] void SetBeneficiaries(IList<Beneficiary> beneficiaries);
    }

}
