using System;
using System.Collections.Generic;

namespace NAVSCMIntegrator
{
    using SCMCustomersSVC;
    using NavCustomers;

    class CustomerManager
    {
        public static string NavCustomerCreate(NavCustomer webCustomer)
        {
            string newCustomerCode = "UNDEF";
            SCMCustomers_Service customerSVC = new SCMCustomers_Service();
            customerSVC.UseDefaultCredentials = true;
            try
            {
                SCMCustomers customer = new SCMCustomers();
                customer.No = webCustomer.CustomerID;
                customer.Name = webCustomer.CustomerNames;
                customerSVC.Create(ref customer);
                customer.Customer_Posting_Group = webCustomer.CustomerBusGroup;
                customer.Sales_Area = webCustomer.RouteSalesArea;
                customer.Customer_PIN = webCustomer.PINNo;
                customer.Phone_No = webCustomer.CustomerPhoneNo;
                customer.Customer_Posting_Group = webCustomer.PostingGroup;
                customer.VAT_Bus_Posting_Group = webCustomer.VATGroup;
                customer.Credit_Limit_LCY = webCustomer.CreditLimit;
                customer.Address = webCustomer.Address;
                customerSVC.Update(ref customer);
            }
            catch
            {
                newCustomerCode = "UNDEF";
            }
            return newCustomerCode;
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

        public NavCustomer convertCustomerToCustomer(SCMCustomers NavCustRec)
        {
            NavCustomer newNavCustomer = new NavCustomer();
            //transpose Nav Customer record to Router customer
            return newNavCustomer;
        }

        public List<NavCustomer> getAllNavCustomers()
        {
            NavCustomers_Service NAVCustomerSVC = new NavCustomers_Service();
            NAVCustomerSVC.UseDefaultCredentials = true;
            NAVCustomerSVC.PreAuthenticate = true;
            List<NavCustomer> allNavCustomers = new List<NavCustomer>();

            const int fetchsize = 0;
            string bookMarkKey = null;
            NavCustomers.NavCustomers[] results = NAVCustomerSVC.ReadMultiple(new NavCustomers_Filter[] { }, bookMarkKey, fetchsize);

            foreach (NavCustomers.NavCustomers cust in results)
            {
                NavCustomer currCustomer = new NavCustomer();
                currCustomer = ConvertNavCustomerToCustomer(cust);
                allNavCustomers.Add(currCustomer);
            };

            return allNavCustomers;
        }

        public NavCustomer ConvertNavCustomerToCustomer(NavCustomers.NavCustomers NavCustomerRec)
        {
            //transpose Nav Product to Router Product Rec
            NavCustomer newCustomerRec = new NavCustomer();
            newCustomerRec.CustomerID = NavCustomerRec.No; //create the lookups for this
            newCustomerRec.CustomerNames = NavCustomerRec.Name;
            newCustomerRec.CustomerBusGroup = NavCustomerRec.Gen_Bus_Posting_Group;
            newCustomerRec.RouteSalesArea = NavCustomerRec.Sales_Area; //create the lookups for this
            newCustomerRec.PINNo = NavCustomerRec.PIN_No;
            newCustomerRec.CustomerPhoneNo = NavCustomerRec.Phone_No;
            newCustomerRec.PostingGroup = NavCustomerRec.Customer_Posting_Group; //change this to look at an actual price ist
            newCustomerRec.VATGroup = NavCustomerRec.VAT_Bus_Posting_Group; //create the lookups for this
            newCustomerRec.CreditLimit = NavCustomerRec.Credit_Limit_LCY;
            newCustomerRec.Address = NavCustomerRec.Address;
            return newCustomerRec;
        }

        public NavCustomer getNavCustomer(string CustomerCode)
        {
            NavCustomers_Service NAVCustomerSVC = new NavCustomers_Service();
            NAVCustomerSVC.UseDefaultCredentials = true;
            NAVCustomerSVC.PreAuthenticate = true;

            NavCustomer customerRec = new NavCustomer();
            NavCustomers.NavCustomers NavCust = NAVCustomerSVC.Read(CustomerCode);

            NavCustomer currCust = ConvertNavCustomerToCustomer(NavCust);

            return currCust;
        }
    }
}
