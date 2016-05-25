using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NAVSCMIntegrator
{
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
            public string VATGroup;

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

        public bool validateCustomer(NavCustomer customer)
        {
            //otherwise add code to do validations
            return true;
        }

        public string createNavCustomer(NavCustomer cust)
        {
            string newCustomerCode = "UNDEF";
            try
            {
                if (validateCustomer(cust))
                {
                    newCustomerCode = CustomerManager.NavCustomerCreate(cust);
                };
                return newCustomerCode;
            }
            catch (Exception ex)
            {
                return "'Response Code':'0000'" + "," + "'Message':'" + ex.InnerException.InnerException.Message + "'";
            }
        }
    }
}