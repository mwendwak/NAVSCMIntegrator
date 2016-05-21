using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAVSCMIntegrator
{
    public class NavCustomer
    {
        public string CustomerID;
        public string CustomerNames;
        public string CustomerGroup;
        public string RouteSalesArea;
        public string PINNo;
        public string CustomerPhoneNo;
        public string PostingGroup;
        public string VATGroup;

        public static Boolean validateCustomer(NavCustomer customer)
        {
            //otherwise add code to do validations
            return true;
        }

        public static string AddCustomerToNav(NavCustomer customer)
        {
            string newCustomerCode = "UNDEF";
            //Add code to do actual update to on Nav
            return newCustomerCode;
        }
    }
}