﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAVSCMIntegrator
{
    using SCMCustomersSVC;

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
                customerSVC.Update(ref customer);
            }
            catch
            {
                newCustomerCode = "UNDEF";
            }
            return newCustomerCode;
        }
    }
}