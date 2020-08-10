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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class PaymentSvc : IPaymentSvc
    {
        public IList<Beneficiary> GetBeneficiaries()
        {
            return new List<Beneficiary>();
        }

        public IList<Payment> GetPayments()
        {
            return new List<Payment>();
        }

        public IList<Status> GetStatuses()
        {
            return new List<Status>();
        }

        public User GetUser(long userId)
        {
            return new User();
        }

        public IList<User> GetUsers()
        {
            return new List<User>();
        }

        public void SetBeneficiaries(IList<Beneficiary> beneficiaries)
        {
            
        }

        public void SetPayment(IList<Payment> payments)
        {
            
        }
    }
}
