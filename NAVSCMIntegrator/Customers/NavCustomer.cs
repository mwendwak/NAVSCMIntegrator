using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NAVSCMIntegrator
{
    using SCMCustomersSVC;

    [Serializable]
    [DataContract]
    public class NavCustomer
    {
        [DataMember]
            public string CustomerID { get; set; }
        [DataMember]
            public string CustomerNames { get; set; }
        [DataMember]
            public string CustomerBusGroup { get; set; }
        [DataMember]
            public string RouteSalesArea { get; set; }
        [DataMember]
            public string PINNo { get; set; }
        [DataMember]
            public string CustomerPhoneNo { get; set; }
        [DataMember]
            public string PostingGroup { get; set; }
        [DataMember]
            public string VATGroup { get; set; }
        [DataMember]
        public decimal CreditLimit { get; set; }
        [DataMember]
        public string Address { get; set; }

        public NavCustomer()
        {
            //constructor
        }

        public NavCustomer(string[] customerVars)
        {
            NavCustomer newCustomer = new NavCustomer();
            //package customer
            foreach (string var in customerVars)
            {
                //do code to loop through
            }
        }
        public NavCustomer(string id)
        {
            NavCustomer newCustomer = new NavCustomer();
            //do code to turn json cusomer data to strings
        }

    }
}